using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webTesteApi
{
    public partial class validawsintranet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResultado_Click(object sender, EventArgs e)
        {
            using (svcintranet.wsAutenticacaoSoapClient cliente = new svcintranet.wsAutenticacaoSoapClient())
            {
                lblchave.Text = "";
                if (!String.IsNullOrWhiteSpace(txtlogin.Text) && !String.IsNullOrWhiteSpace(txtsenha.Text))
                {
                    string mensagem = string.Format(@"<?xml version='1.0' encoding='UTF-8'?><ObterPerfil xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><Nome>{0}</Nome><Senha>{1}</Senha><Sistema>{2}</Sistema></ObterPerfil>", txtlogin.Text, txtsenha.Text, txtsistema.Text);
                    string ret = cliente.ObterPermissoesUsuario(mensagem);
                    XElement xml = XElement.Parse(ret);
                    var node = xml.Elements().Elements();
                    grvResult.DataSource = node;
                    grvResult.DataBind();
                    cliente.Close();
                }
                else
                {
                    lblchave.Text = "Informe usuario e/ou senha";
                }
               
            }

        }

        protected void btnChave_Click(object sender, EventArgs e)
        {
            lblchave.Text = "";
            using (svcintranet.wsAutenticacaoSoapClient cliente = new svcintranet.wsAutenticacaoSoapClient())
            {
                string ret = cliente.ObterChavePublica();
                cliente.Close();
                lblchave.Text = "conexao realizada em " + DateTime.Now.ToString();
                lblchave.Text += ret;
            }
        }
    }
}