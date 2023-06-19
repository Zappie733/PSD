<%@ Page Title="Customer Transaction Detail" Language="C#" MasterPageFile="~/View/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="RAAMEN.View.Customer.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Customer/TransactionDetail.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />

    <div class="container">
        <div class="title">
            <p>Detail Order (orderId:<%=orderId%>)</p>
        </div>
        <div class="row">
            <div class="col header">Ramen</div>
            <div class="col header">Quantity</div>
            <div class="col header">Price</div>
        </div>
        <%foreach (var detail in listDetail)
            {%>
            <div class="row">
                <div class="col">
                    <%=detail.Ramen.Name%>
                </div>
                <div class="col">
                    <%=detail.Quantity%>
                </div>
                <div class="col">
                    <%=Int32.Parse(detail.Ramen.Price) * detail.Quantity%>
                </div>
            </div>
        <%} %>
        <div class="row">
            <div class="col "></div>
            <div class="col ">Total Price</div>
            <div class="col "><%=totalPrice%></div>
        </div>
    </div>
</asp:Content>
