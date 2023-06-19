<%@ Page Title="Customer Transactions" Language="C#" MasterPageFile="~/View/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="RAAMEN.View.Customer.Transaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Customer/Transaction.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="title">
            <p>List History Order</p>
        </div>
        <div class="row">
            <div class="col header">Id</div>
            <%--<div class="col header">CustomerId</div>--%>
            <div class="colKhusus header">
                <div class="row">DetailOrder</div>
                 <div class="row">
                    <div class="col">Ramen</div>
                    <div class="col">Quantity</div>
                </div>
            </div>
            <div class="col header">Date</div>
            <div class="col header">Action</div>
        </div>
        <%int index = 0;%>
        <%foreach (var order in listHandledOrder)
            {%>
            <div class="row">
                <div class="col"><%= order.Id %></div>
                <%--<div class="col"><%= order.CustomerId %></div>--%>
                <div class="colKhusus">
                    <%foreach (var detail in listDetailOrder[index])
                        {%>
                        <div class="row">
                            <div class="col"><%= detail.Ramen.Name %></div>
                            <div class="col"><%= detail.Quantity %></div>    
                        </div>
                    <%} %>
                </div>
                <div class="col"><%=order.Date %></div>
                <div class="col">
                    <a href="TransactionDetail.aspx?orderId=<%=order.Id%>">Detail</a>
                </div>
            </div>
            <%index++; %>
        <%} %>
    </div>
</asp:Content>
