using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text; 
using System.Net;
using System.Net.Cache;
using System.IO;

namespace webTesteApi
{
    public partial class _default : System.Web.UI.Page
    {
        protected void btenviar_Click(object sender, EventArgs e)
        {
            ExecutarHashDigitado();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                CarregarValoresIniciais();
                txurl.Text = _urlbase;
                txtimeout.Text = _timeoutconexao;
                txtoken.Text = _authorization;
                lblproxy.Text = "Info Proxy:Usando a configuração padrão";
                if (_proxy != String.Empty)
                {
                    var oproxy = ObterProxy(_proxy);
                    lblproxy.Text = "Info Proxy:";
                    if (oproxy != null && ((WebProxy)oproxy).Address != null)
                    {
                        var userproxy = (WebProxy)oproxy;
                        lblproxy.Text += userproxy.Address.AbsoluteUri != String.Empty ? userproxy.Address.AbsoluteUri : "Configuracao do browser sem proxy ou automatica";
                        lblproxy.Text += " Usa Credenciais" + userproxy.UseDefaultCredentials.ToString();
                    }
                    else
                    {
                        lblproxy.Text += "Configuracao do browser sem proxy ou automatica";
                    }
                }
            }
        }

        #region "Metodos"
        private string _timeoutconexao;
        private string _urlbase;
        private string _authorization;
        private string _proxy;
        private string _cache;

        private void CarregarValoresIniciais()
        {
            _proxy = ConfigurationManager.AppSettings["proxy"];
            _cache = ConfigurationManager.AppSettings["cache"];
            _timeoutconexao = ConfigurationManager.AppSettings["timeoutconexao"];
            _urlbase = ConfigurationManager.AppSettings["urlbase"];
            _authorization = ConfigurationManager.AppSettings["authorization"];
        }


        private static IWebProxy ObterProxy(string nomeproxy)
        {
            IWebProxy proxy = null;
            try
            {
                if (nomeproxy == "[local]")
                {

                    var ieproxy = WebRequest.GetSystemWebProxy();
                    if (ieproxy != null && ((WebProxy)ieproxy).Address.AbsoluteUri != String.Empty)
                    {
                        proxy = ieproxy;
                    }
                }
                else
                {
                    proxy = new WebProxy(nomeproxy);
                }
            }
            catch { }
            return proxy;
        }

        private void ExecutarHashDigitado()
        {
            btenviar.Enabled = false;
            List<string> valores = new List<string>();
            int execucoes = 1;
            txresultado.Text = "";
            var url = txurl.Text;
            var timeout = Convert.ToInt32(txtimeout.Text);
            var exibir = false;
            StringBuilder sb = new StringBuilder();
            string retornohttp = "503";
            sb.Append(RequisitarDados(execucoes, url, txtoken.Text , timeout, exibir, _proxy, _cache,ref retornohttp));
            txcodigohttp.Text = retornohttp;
            txresultado.Text = sb.ToString();
            SalvarExecucaoEmArquivo(sb.ToString());
            btenviar.Enabled = true;
        }


        private bool SalvarExecucaoEmArquivo(string conteudo)
        {
            var bret = false;
            try
            {
                var nomearquivo = "execucao_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                nomearquivo = Path.Combine(Request.MapPath("logs"), nomearquivo);
                var encode = System.Text.Encoding.GetEncoding("iso-8859-8");
                using (StreamWriter sw = new StreamWriter(nomearquivo, false, encode))
                {
                    sw.Write(conteudo);
                    bret = true;
                }

            }
            catch { }
            return bret;

        }

        private static string RequisitarDados(int execucoes, string url, string valor, int timeout, bool exibir, string proxy,string cache, ref string codrethttp)
        {
            StringBuilder retorno = new StringBuilder();
            WebResponse myWebResponse = null;
            DateTime horainicial;
            DateTime horafinal;
            try
            {
                var uri = new Uri(url);
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                if (!String.IsNullOrEmpty(proxy))
                {
                    var userproxy = ObterProxy(proxy);
                    if (userproxy != null)
                    {
                        //userproxy.UseDefaultCredentials = true;
                        myWebRequest.Proxy = userproxy;
                    }
                }
                if (cache == "disabled")
                {
                  var policy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                  WebRequest.DefaultCachePolicy = policy;
                }
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36";
                myWebRequest.KeepAlive = true;


                if (!String.IsNullOrEmpty(valor))
                    myWebRequest.Headers[HttpRequestHeader.Authorization] = valor;

                myWebRequest.Timeout = timeout;
                myWebRequest.Accept = "*/*";
                myWebRequest.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, sdch";
                myWebRequest.Headers[HttpRequestHeader.AcceptLanguage] = "pt-BR,pt;q=0.8,en-US;q=0.6,en;q=0.4";
                myWebRequest.Headers[HttpRequestHeader.Pragma] = "no-cache";

                horainicial = DateTime.Now;
                retorno.AppendLine("hora;" + horainicial.ToString("dd/MM/yyyy HH:mm:ss") + ";hash;" + valor + ";status;;descr;;ENV;" + execucoes.ToString() + ";");
                myWebResponse = myWebRequest.GetResponse();

                var rethttp = (HttpWebResponse)myWebResponse;
                int codhttp = (int)rethttp.StatusCode;

                codrethttp = codhttp.ToString();

                horafinal = DateTime.Now;
                retorno.AppendLine("hora;" + horafinal.ToString("dd/MM/yyyy HH:mm:ss") + ";hash;" + valor + ";status;" + codhttp.ToString() + ";descr;" + rethttp.StatusDescription + ";RET;" + execucoes.ToString() + ";body;" + myWebResponse.ResponseUri + ";");


                // Obtain a 'Stream' object associated with the response object.
                Stream ReceiveStream = myWebResponse.GetResponseStream();

                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

                // Pipe the stream to a higher level stream reader with the required encoding format. 
                using (StreamReader readStream = new StreamReader(ReceiveStream, encode))
                {
                    if (exibir)
                        retorno.AppendLine(readStream.ReadToEnd());

                    readStream.Close();
                }
            }
            catch (Exception ex)
            {
                horafinal = DateTime.Now;
                var descricao = ex.Message;
                var codhttp = "";
                var lista = new string[] { "400", "401", "402", "403", "404", "405", "500", "501", "502", "503", "504", "505" };
                foreach (var item in lista)
                {
                    if (descricao.Contains(item))
                    {
                        codhttp = item;
                        codrethttp = item;
                        break;
                    }

                }

                retorno.AppendLine("hora;" + horafinal.ToString("dd/MM/yyyy HH:mm:ss") + ";hash;" + valor + ";status;" + codhttp + ";descr;" + descricao + ";RET;" + execucoes.ToString() + ";");

            }
            finally
            {
                // Release the resources of response object.
                if (myWebResponse != null)
                    myWebResponse.Close();


            }

            return retorno.ToString();

        }

        #endregion
    }
}