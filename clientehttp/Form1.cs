using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace clientehttp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _timeoutconexao;
        private string _urlbase;
        private string _authorization;
        private string _intervaloentreexecucoes;
        private string _caminhoarquivos;
        private string _proxy;
        private string _cache;

        private void CarregarValoresIniciais()
        {
            _proxy = ConfigurationManager.AppSettings["proxy"];
            _cache = ConfigurationManager.AppSettings["cache"];
            _timeoutconexao = ConfigurationManager.AppSettings["timeoutconexao"];
            _urlbase = ConfigurationManager.AppSettings["urlbase"];
            _authorization = ConfigurationManager.AppSettings["authorization"];
            _intervaloentreexecucoes = ConfigurationManager.AppSettings["intervaloentreexecucoes"];
            _caminhoarquivos = ConfigurationManager.AppSettings["caminhoarquivos"] == "[local]" ? Application.StartupPath : ConfigurationManager.AppSettings["caminhoarquivos"];


        }

        private List<string> CarregarArquivo(string caminho)
        {
            List<string> valores = new List<string>();
            string fileName = string.Empty;
            try
            {
                fileName = caminho;
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = String.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        valores.Add(s);
                    }
                }
                return valores;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler arquivo " + fileName + " |" + ex.StackTrace);
            }
        }

        private void ExecutarHashDigitado()
        {
            button1.Enabled = false;
            List<string> valores = new List<string>();
            int execucoes = Convert.ToInt32(txtexecucoes.Text);
            for (int i = 0; i < execucoes; i++)
                valores.Add(txtvalor.Text);
            txtresultado.Clear();
            lblresult.Text = "";
            Application.DoEvents();
            var url = txturl.Text;
            var timeout = Convert.ToInt32(txtTimeout.Text);
            var exibir = chkexibir.Checked;
            StringBuilder sb = new StringBuilder();
            Parallel.For(0, valores.Count, i =>
            {
                sb.Append(RequisitarDados(i + 1, url, valores[i], timeout, exibir, _proxy,_cache));
            });
            txtresultado.Text = sb.ToString();
            button1.Enabled = true;
        }

        private FileInfo[] CarregarNomesArquivos(string _diretorio)
        {
            if (Directory.Exists(_diretorio))
            {
                DirectoryInfo diretorio = new DirectoryInfo(_diretorio);
                FileInfo[] Arquivos = diretorio.GetFiles("*.txt");
                var ArquivosOrdenados = Arquivos.OrderBy(x => x.Name).ToArray();
                return ArquivosOrdenados;
            }
            else
            {
                throw new Exception("Não foi possível ler o diretório " + _diretorio);
            }
        }

        private bool SalvarExecucaoEmArquivo(string conteudo)
        {
            var bret = false;
            try
            {
                var nomearquivo = "execucao_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                nomearquivo = Path.Combine(Application.StartupPath, nomearquivo);
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

        private void ExecutarHashDeArquivos()
        {
            button1.Enabled = false;
            var oFiles = CarregarNomesArquivos(_caminhoarquivos);
            List<string> valores = new List<string>();
            var url = txturl.Text;
            var timeout = Convert.ToInt32(txtTimeout.Text);
            var exibir = chkexibir.Checked;
            StringBuilder sb = new StringBuilder();
            foreach (var ofile in oFiles)
            {
                var caminho = ofile.FullName;
                valores = CarregarArquivo(caminho);
                txtresultado.Clear();
                sb.Clear();
                lblresult.Text = "Envio dos Hashs do arquivo:" + caminho;
                Application.DoEvents();
                Parallel.For(0, valores.Count, i =>
                {
                    sb.Append(RequisitarDados(i + 1, url, valores[i], timeout, exibir, _proxy,_cache));
                });
                txtresultado.Text = sb.ToString();
                if (SalvarExecucaoEmArquivo(sb.ToString()))
                    lblresult.Text += "\nInformação registrada também em arquivo no diretório " + Application.StartupPath;

                Application.DoEvents();

                var intervalo = Convert.ToInt32(_intervaloentreexecucoes);

                if ((oFiles.Count() > 1) && intervalo > 0)
                    Thread.Sleep(intervalo);
            }
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                lblfinalizado.Text = "";
                if (radioButton1.Checked)
                {
                    ExecutarHashDigitado();
                }
                else
                {
                    ExecutarHashDeArquivos();
                }
                lblfinalizado.Text = "Processo finalizado";
            }
            catch (Exception ex)
            {
                lblfinalizado.Text = "Ocorreu um um erro na execução! Erro: " + ex.Message;
                button1.Enabled = true;
            }

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
                        proxy  = ieproxy;
                    }
                }
                else
                {
                    proxy = new WebProxy(nomeproxy);
                }
            }
            catch {}
            return proxy;
        }

        private static string RequisitarDados(int execucoes, string url, string valor, int timeout, bool exibir, string proxy,string cache)
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
                //retorno.AppendLine("Hora:" + horainicial.ToString("dd/MM/yyyy HH:mm:ss") + " Enviando execucao:" + execucoes.ToString() + " url:" + url + " hash:" + valor);
                // Send the 'WebRequest' and wait for response.
                myWebResponse = myWebRequest.GetResponse();

                var rethttp = (HttpWebResponse)myWebResponse;
                int codhttp = (int)rethttp.StatusCode;

                horafinal = DateTime.Now;
                retorno.AppendLine("hora;" + horafinal.ToString("dd/MM/yyyy HH:mm:ss") + ";hash;" + valor + ";status;" + codhttp.ToString() + ";descr;" + rethttp.StatusDescription + ";RET;" + execucoes.ToString() + ";body;" + myWebResponse.ResponseUri + ";");
                //retorno.AppendLine("Hora:" + horafinal.ToString("dd/MM/yyyy HH:mm:ss")+ " Recebendo dados URL:" + myWebResponse.ResponseUri  + " Status:" + codhttp.ToString() + "-" + rethttp.StatusDescription);

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
                        break;
                    }

                }

                retorno.AppendLine("hora;" + horafinal.ToString("dd/MM/yyyy HH:mm:ss") + ";hash;" + valor + ";status;" + codhttp + ";descr;" + descricao + ";RET;" + execucoes.ToString() + ";");
                //retorno.AppendLine("Hora:" + horafinal.ToString("dd/MM/yyyy HH:mm:ss") + " Erro:" + ex.Message);

            }
            finally
            {
                // Release the resources of response object.
                if (myWebResponse != null)
                    myWebResponse.Close();


            }

            return retorno.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarValoresIniciais();
            lblfinalizado.Text = "";
            txtexecucoes.Text = "1";
            txturl.Text = _urlbase;
            txtTimeout.Text = _timeoutconexao;
            txtvalor.Text = _authorization;
            radioButton1.Checked = true;
            lblproxy.Text = "Info Proxy:Usando a configuração padrão";
            if (_proxy != String.Empty)
            {
                var oproxy = ObterProxy(_proxy);
                lblproxy.Text = "Info Proxy:";
                if (oproxy != null)
                {
                    var userproxy = (WebProxy) oproxy; 
                    lblproxy.Text += userproxy.Address.AbsoluteUri != String.Empty ? userproxy.Address.AbsoluteUri : "Configuracao do browser sem proxy";
                    lblproxy.Text += " Usa Credenciais" + userproxy.UseDefaultCredentials.ToString(); 
                }
            }

        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel1.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                panel1.Visible = false;
            }
        }
    }
}
