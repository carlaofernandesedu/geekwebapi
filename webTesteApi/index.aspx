<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="webTesteApi.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table>
               <tr>
                   <td>Sistema</td>
                   <td>Modulo Teste</td>
               </tr>
               <tr>
                   <td>SED</td>
                   <td><a href="default.aspx" >Teste de Servico REST Web API - SED</a></td>
               </tr>
               <tr>
                   <td>Portalnet</td>
                   <td><a href="validawsintranet.aspx" >Teste de WebService Comunicacao Intranet</a></td>
               </tr>
           </table>
    </div>
    </form>
</body>
</html>
