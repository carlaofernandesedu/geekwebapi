<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="validawsintranet.aspx.cs" Inherits="webTesteApi.validawsintranet" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Teste de autenticação - INTRANET - versão atualizada</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Teste comunicação Intranet </p>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblLogin" runat="server" Text="Login: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtlogin" runat="server" Text="rg143684954sp"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSenha" runat="server" Text="Senha(Hash): "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtsenha" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSistema" runat="server" Text="Sistema: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtsistema" runat="server" Text="INTRANET"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnChave" Text="Conectividade(Chave Publica)" OnClick="btnChave_Click" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnResultado" Text="Autenticar" OnClick="btnResultado_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label runat="server" ID="lblchave" Text=""></asp:Label>
            <br />
            <asp:Label runat="server" ID="lblResultado" Text="Resultado"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="grvResult" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Campo" DataField="name" />
                    <asp:BoundField HeaderText="Valor" DataField="value" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>