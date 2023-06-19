<%@ Page Title="Admin Transaction" Language="C#" MasterPageFile="~/View/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="RAAMEN.View.Admin.Transaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Admin/Transaction.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="title">
            <p>List History Order</p>
        </div>
        <div class="row">
            <div class="col header">Id</div>
            <div class="col header">CustomerId</div>
            <div class="col header">HandleBy</div>
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
        <%foreach (var order in listOrder)
            {%>
            <div class="row">
                <div class="col"><%= order.Id %></div>
                <div class="col"><%= order.CustomerId %></div>
                <div class="col"><%= order.User1.Username%></div>
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
