<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RAAMEN.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="../Styling/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="username">Username: </label>
            <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
            <br />
            <label for="password">Password: </label>           
            <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:CheckBox ID="rememberCheckBox" runat="server" Text=" Remember Me"/>
            <br /><br />
            <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
            <br />
            <asp:Label ID="errorMessage" runat="server" Text=""></asp:Label>
            <br /><br />
            <label for="register">Mau Bikin Akun? </label>   
            <asp:LinkButton ID="registerButton" runat="server" OnClick="registerButton_Click">Register</asp:LinkButton>
        </div>
    </form>
</body>
</html>
