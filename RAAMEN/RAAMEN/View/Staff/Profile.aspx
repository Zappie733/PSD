<%@ Page Title="Staff Profile" Language="C#" MasterPageFile="~/View/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="RAAMEN.View.Staff.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Staff/Profile.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <table>
            <tr>
                <td>
                    <label for="idTextBox">Id</label>
                <td>
                    <asp:TextBox ID="idTextBox" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="roleTextBox">Role</label>
                </td>
                <td>
                    <asp:TextBox ID="roleTextBox" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="usernameTextBox">Username</label>
                </td>
                <td>
                    <asp:TextBox ID="usernameTextBox" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="emailTextBox">Email</label>
                </td>
                <td>
                    <asp:TextBox ID="emailTextBox" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="genderTextBox">Gender</label>
                </td>
                <td>
                    <asp:DropDownList ID="genderDropDownList" runat="server" Enabled="false">
                        <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                        <asp:ListItem Text="Male" Value="male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="female"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="passwordTextBox">Password</label>
                </td>
                <td>
                    <asp:TextBox ID="passwordTextBox" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td>
                    <asp:Button ID="editButton" runat="server" Text="Edit" OnClick="editButton_Click" />
                    <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" />
                </td>
             </tr>
        </table>
        <asp:Label ID="updateMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
