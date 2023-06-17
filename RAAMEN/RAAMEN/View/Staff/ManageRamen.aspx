<%@ Page Title="Staff ManageRamen" Language="C#" MasterPageFile="~/View/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="RAAMEN.View.Staff.ManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Staff/ManageRamen.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="title">
            <p>List Ramen</p>
        </div>
        <div class="row">
            <div class="col header">
                <p>Id</p>
            </div>
            <div class="col header">
                <p>MeatId</p>
            </div>
            <div class="col header">
                <p>Name</p>
            </div>
            <div class="col header">
                <p>Broth</p>
            </div>
            <div class="col header">
                <p>Price</p>
            </div>
            <div class="col header">
                <p>Action</p>
            </div>
        </div>
        <%foreach (var x in listRamen)
          { %>
            <div class="row">
                <div class="col">
                    <%= x.Id %>
                </div>
                <div class="col">
                    <%= x.Meat.Name %>
                </div>
                <div class="col">
                    <%= x.Name %>
                </div>
                <div class="col">
                    <%= x.Broth %>
                </div>
                <div class="col">
                    <%= x.Price %>                    
                </div> 
                <%int testId = x.Id; %>
                <div class="col">
                    <a href="UpdateRamen.aspx?ramenId=<%= x.Id %>">Update</a>
                    <span>&nbsp;</span> 
                    <a href="ManageRamen.aspx?ramenId=<%= x.Id %>">Delete</a>
                    <asp:Button ID="testButton" runat="server" Text="Button" OnClick="Button1_Click"/>
                </div>    
            </div>
        <%} %>
       
        <div class ="row">
            <asp:Label ID="StatusLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <br /><br />
        <asp:Button ID="InsertButton" runat="server" Text="Insert Ramen" OnClick="InsertButton_Click" />
    </div>
</asp:Content>
