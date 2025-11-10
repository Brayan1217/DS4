<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="laboratorio154.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Suma de Numeros"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Width="29px"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Width="25px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Calcular" OnClick="Button1_Click"/>
        <br />
    </form>
</body>
</html>
