<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmConCNPJ.aspx.cs" Inherits="ConsultaCNPJ.frmConCNPJ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="MessageBox" runat="server" ></asp:Label> <br/>
    <asp:Image ID="imgCaptcha" runat="server" /><br/>
    <h4 style="color:#F00">Digite os caracteres acima no campo capcha:</h4>
    <form id="form1" runat="server">
    <asp:HiddenField ID="ttbCNPJ" runat="server" />
    
    <div>
        <asp:Label ID="labelcapcha" runat="server" Text="Capchta"></asp:Label><br/>
        <asp:TextBox ID="ttbLetras" runat="server" MaxLength="6"></asp:TextBox><br/><br/>
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />&nbsp;
        <asp:Button ID="btnTrocarImagem" runat="server" Text="Troca Imagem" OnClick="btnTrocarImagem_Click"/>
    </div>
       

    </form>
       <br/><br/>
        CNPJ: <asp:Label ID="lblCNPJ" runat="server" Text=""></asp:Label><br/>
        RAZÃO SOCIAL: <asp:Label ID="txtRazao" runat="server" Text=""></asp:Label><br/>
        NOME FANTASIA:<asp:Label ID="txtFantasia" runat="server" Text=""></asp:Label><br/>
        ENDEREÇO: <asp:Label ID="txtEndereco" runat="server" Text=""></asp:Label><br/>
        BAIRRO: <asp:Label ID="txtBairro" runat="server" Text=""></asp:Label><br/>
        CEP: <asp:Label ID="txtCep" runat="server" Text=""></asp:Label><br/>
        CNAE: <asp:Label ID="txtCnae" runat="server" Text=""></asp:Label><br/>
        CIDADE: <asp:Label ID="txtCidade" runat="server" Text=""></asp:Label><br/>
        UF: <asp:Label ID="txtUF" runat="server" Text=""></asp:Label>
</body>
</html>
