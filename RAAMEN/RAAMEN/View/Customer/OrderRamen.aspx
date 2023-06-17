<%@ Page Title="OrderRamen" Language="C#" MasterPageFile="~/View/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="RAAMEN.View.Customer.OrderRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Customer/OrderRamen.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 class="judul-ramen">
        Order our ramen 
    </h1>
    <div class="view-ramen">
         <%foreach (var x in ramens){ %>
        <div class="sec">
            <div>
            <img src="../../Images/Ramen_1.jfif" class="img-ramen">
            </div>
            <div class="detail-ramen">
                <h1 class="nama-ramen"> <%=x.Name %></h1>
                <h3> Broth : <%=x.Broth %></h3>
                <h3> Meat : <%=x.Meat.Name %> </h3>
                <h3> Price : <%=x.Price %></h3>
                <asp:DropDownList ID="DropDownListQuantity" runat="server">
                    <asp:ListItem Text="Select Quantity" Value=""></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                </asp:DropDownList>
            <asp:CheckBox ID="CheckBox1" runat="server" />
            </div>
        </div>
        <%} %>
    </div>
    <div class="button-sec">
        <div>
            <asp:Button class="buttonRamen" ID="orderButton" runat="server" Text="Order ramen" OnClick="orderButton_Click" />
        </div>
        <div>
            <asp:Button CssClass="buttonRamen" ID="cartButton" runat="server" Text="Add to cart" />
        </div>
        <div>
            <asp:Label ID="selectedRamenLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
    
</asp:Content>
