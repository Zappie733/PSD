<%@ Page Title="Staff OrderQueue" Language="C#" MasterPageFile="~/View/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="RAAMEN.View.Staff.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Staff/OrderQueue.css" rel="stylesheet" type="text/css" />          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="title">
            <p>List Unhandled Order</p>
        </div>
        <div class="row">
            <div class="col header">Id</div>
            <div class="col header">CustomerId</div>
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
        <%foreach (var order in listOrderUnhandled)
            {%>
            <div class="row">
                <div class="col"><%= order.Id %></div>
                <div class="col"><%= order.CustomerId %></div>
                <div class="colKhusus">
                    <%foreach (var detail in listDetailOrderUnhandled[index])
                        {%>
                        <div class="row">
                            <div class="col"><%= detail.Ramen.Name %></div>
                            <div class="col"><%= detail.Quantity %></div>    
                        </div>
                    <%} %>
                </div>
                <div class="col"><%=order.Date %></div>
                <div class="col">
                    <asp:Button ID="handleButton" runat="server" Text="Button" OnClick="handleButton_Click" />
                </div>
            </div>
            <%index++; %>
        <%} %>
        <div class ="row">
            <asp:Label ID="StatusLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <br /><br /><br />
        <div class="title">
            <p>List Handled Order</p>
        </div>
        <div class="row">
            <div class="col header">Id</div>
            <div class="col header">CustomerId</div>
            <div class="col header">Handled By</div>
            <div class="colKhusus header">
                <div class="row">DetailOrder</div>
                 <div class="row">
                    <div class="col">Ramen</div>
                    <div class="col">Quantity</div>
                </div>
            </div>
            <div class="col header">Date</div>
        </div>
        <%index = 0;%>
        <%foreach (var order in listOrderHandled)
            {%>
            <div class="row">
                <div class="col"><%= order.Id %></div>
                <div class="col"><%= order.CustomerId %></div>
                <div class="col"><%= order.User.Username%></div>
                <div class="colKhusus">
                    <%foreach (var detail in listDetailOrderHandled[index])
                        {%>
                        <div class="row">
                            <div class="col"><%= detail.Ramen.Name %></div>
                            <div class="col"><%= detail.Quantity %></div>    
                        </div>
                    <%} %>
                </div>
                <div class="col"><%=order.Date %></div>
            </div>
            <%index++;%>
        <%} %>
        
    </div>
</asp:Content>
