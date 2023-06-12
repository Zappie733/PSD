<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RAAMEN.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
    <link href="../Styling/Register.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="username">Username: </label>
            <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
            <br />
            <label for="email">Email: </label>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            <br />
            <label for="gender">Gender: </label>
            <asp:DropDownList ID="genderDropDownList" runat="server">
                <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                <asp:ListItem Text="Male" Value="male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="female"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <label for="password">Password: </label>
            <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <label for="confirmPassword">Confirm Password: </label>
            <asp:TextBox ID="confirmPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <label for="userRole">Choose your role: </label>
            <asp:DropDownList ID="userRoleDropDownList" runat="server">
                <asp:ListItem Text="Select Role" Value=""></asp:ListItem>
                <asp:ListItem Text="Customer" Value="customer"></asp:ListItem>
                <asp:ListItem Text="Staff" Value="staff"></asp:ListItem>
            </asp:DropDownList>
            <br /><br />
            <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" />
            <br />
            <asp:Label ID="errorMessage" runat="server" Text=""></asp:Label>
            <br /><br />
            <label for="register">Already have an account? </label>   
            <asp:LinkButton ID="loginButton" runat="server" OnClick="loginButton_Click">Login</asp:LinkButton>
        </div>
    </form>
</body>
</html>
