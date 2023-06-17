<%@ Page Title="Staff InsertRamen" Language="C#" MasterPageFile="~/View/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="InsertRamen.aspx.cs" Inherits="RAAMEN.View.Staff.InsertRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
    <br /><br />
    <div>
        <label for="name">Ramen Name: </label>
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <br />
        <label for="meat">Meat: </label>
        <asp:DropDownList ID="meatDropDownList" runat="server">
            <asp:ListItem Text="Select Meat" Value=""></asp:ListItem>
            <asp:ListItem Text="Chiken" Value="chiken"></asp:ListItem>
            <asp:ListItem Text="Pork" Value="pork"></asp:ListItem>
            <asp:ListItem Text="Beef" Value="beef"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <label for="broth">Broth: </label>
        <asp:TextBox ID="brothTextBox" runat="server"></asp:TextBox>
        <br />
        <label for="PriceTextBox">Price: </label>
        <asp:TextBox ID="PriceTextBox" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Button ID="Insert" runat="server" Text="Insert" OnClick="Insert_Click" />
        <br />
        <asp:Label ID="errorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br /><br />
    </div>
</asp:Content>
