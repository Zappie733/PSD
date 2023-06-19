<%@ Page Title="Customer Home" Language="C#" MasterPageFile="~/View/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RAAMEN.View.Customer.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Customer/Home.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="title">
            <p>List Ongoing Order</p>
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
        </div>
        <%int index = 0;%>
        <%foreach (var order in listOngoingOrder)
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
            </div>
            <%index++; %>
        <%} %>
    </div>
</asp:Content>
