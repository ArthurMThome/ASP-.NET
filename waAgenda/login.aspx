<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="waAgenda.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 440px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="E-mail:"></asp:Label>
            <br />
            <asp:TextBox ID="tbEmail" runat="server" Height="24px" Width="210px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Senha:"></asp:Label>
            <br />
            <asp:TextBox ID="tbSenha" runat="server" Height="24px" Width="210px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogar" runat="server" Font-Bold="True" Text="Logar" Height="33px" OnClick="btnLogar_Click" Width="142px" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbMessageError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text=" "></asp:Label>
        </div>
    </form>
</body>
</html>
