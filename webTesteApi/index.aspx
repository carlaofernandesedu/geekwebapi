<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="webTesteApi.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista do Servicos disponíveis para testes</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table align="center" border="1">
               <tr>
                   <td>Ambiente AppPool</td>
                   <td>Modulo Teste</td>
               </tr>
               <tr>
                   <td>APERIBE-IIS - wsautintranet</td>
                   <td><a href="validawsintranet.aspx" >Teste de WebService Comunicacao Intranet - Autenticar (Atualizado) </a></td>
               </tr>
               <tr>
                   <td>APERIBE-IIS - ASP.NET v4.0 (compartilhado portalnet) </td>
                   <td><a href="http://localhost/PortalNet/paginas/WsTeste/WebForm1.aspx" >Teste de WebService Comunicacao Intranet - Autenticar </a></td>
               </tr>
               <tr>
                   <td>URUPEMA-IIS - webapised</td>
                   <td><a href="default.aspx" >Teste de Servico REST Web API - SED - Autenticar</a></td>
               </tr>
           </table>
    </div>
    </form>
</body>
</html>
