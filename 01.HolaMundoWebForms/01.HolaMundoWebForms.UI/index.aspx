<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01.HolaMundoWebForms.UI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Introduce tu nombre:</p>
        <p>
            <asp:TextBox ID="txtNombre" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblSaludo" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnSaludar" runat="server" OnClick="btnSaludar_Click" Text="Saludar" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
