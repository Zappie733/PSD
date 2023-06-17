<%@ Page Title="Staff UpdateRamen" Language="C#" MasterPageFile="~/View/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="UpdateRamen.aspx.cs" Inherits="RAAMEN.View.Staff.UpdateRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
    <br /><br />
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
                    <label for="nameTextBox">Name</label>
                </td>
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="meatDropDownList">Meat</label>
                </td>
                <td>
                    <asp:DropDownList ID="meatDropDownList" runat="server" Enabled="false">
                        <asp:ListItem Text="Select Meat" Value=""></asp:ListItem>
                        <asp:ListItem Text="Chiken" Value="chiken"></asp:ListItem>
                        <asp:ListItem Text="Pork" Value="pork"></asp:ListItem>
                        <asp:ListItem Text="Beef" Value="beef"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="brothTextBox">Broth</label>
                </td>
                <td>
                    <asp:TextBox ID="brothTextBox" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="priceTextBox">Price</label>
                </td>
                <td>
                    <asp:TextBox ID="priceTextBox" runat="server" Enabled="false"></asp:TextBox>
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
