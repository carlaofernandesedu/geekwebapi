<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="webTesteApi._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
    <legend> Formulario de Teste do Servico Web API - SED </legend>
    <div>
      <table width="90%" align="center">
          <tr><td><asp:Label ID="lblinfo" runat="server" Text="Informações ambiente:"></asp:Label></td><td>
              <asp:Label ID="lblproxy" runat="server" Text="Timeout:"></asp:Label></td></tr>
          <tr><td>
              <asp:Label ID="lblurl" runat="server" Text="URL de acesso:"></asp:Label></td><td>
              <asp:TextBox ID="txurl" runat="server" Width="669px"></asp:TextBox>
              </td></tr>
          <tr><td><asp:Label ID="lbltoken" runat="server" Text="Token informado:"></asp:Label></td><td>
              <asp:TextBox ID="txtoken" runat="server" Width="253px"></asp:TextBox></td></tr>
          <tr><td><asp:Label ID="lbltimeout" runat="server" Text="Timeout (ms):"></asp:Label></td><td>
              <asp:TextBox ID="txtimeout" runat="server" Width="63px"></asp:TextBox></td></tr>
          <tr><td colspan="2" align="center">
              <asp:Button ID="btenviar" runat="server" Text="Enviar" OnClick="btenviar_Click" />
              </td></tr>
          <tr><td><asp:Label ID="lblcodigohttp" runat="server" Text="Retorno Codigo"></asp:Label></td><td>
              <asp:TextBox ID="txcodigohttp" runat="server" Width="48px" ></asp:TextBox></td></tr>
          <tr><td><asp:Label ID="lblresultado" runat="server" Text="Log Arquivo"></asp:Label></td><td>
              <asp:TextBox ID="txresultado"  runat="server" TextMode="MultiLine" Width="1024px" Height="52px"></asp:TextBox></td></tr>
      </table>
    </div>
    </fieldset>
    </form>
</body>
</html>
