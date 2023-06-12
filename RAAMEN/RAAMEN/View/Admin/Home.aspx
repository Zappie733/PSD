<%@ Page Title="Admin Home" Language="C#" MasterPageFile="~/View/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RAAMEN.View.Admin.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Admin/Home.css" rel="stylesheet" type="text/css" />    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%for (int i = 0; i <= 1; i++)
      { %>
        <div class="container">
            <div class="title">
                <%if (i == 0)
                  {%>
                    <p>List Customer</p>
                <%} 
                  else if (i == 1)
                  {%>
                    <p>List Staff</p>                    
                <%} %>
            </div>
            <div class="row">
                <div class="col header">
                    <p>CustomerId</p>
                </div>
                <div class="col header">
                    <p>Username</p>
                </div>
                <div class="col header">
                    <p>Email</p>
                </div>
                <div class="col header">
                    <p>Gender</p>
                </div>
                <div class="col header">
                    <p>Password</p>
                </div>
            </div>
            <%foreach (var x in listUser[i])
                { %>
                <div class="row">
                    <div class="col">
                        <%= x.Id %>
                    </div>
                    <div class="col">
                        <%= x.Username %>
                    </div>
                    <div class="col">
                        <%= x.Email %>
                    </div>
                    <div class="col">
                        <%= x.Gender %>
                    </div>
                    <div class="col">
                        <% for (int j = 0; j < x.Password.Length; j++)
                           { %>
                                <%if (j == 0)
                                  {%>
                                    <p><%=x.Password[j] %></p>
                                <%} 
                                  else if (j == (x.Password.Length-1))
                                  {%>
                                    <p><%=x.Password[j] %></p>                    
                                <%} 
                                  else {%>  
                                    <p>*</p>
                                <%} %>
                        <% } %>
                    </div>
                </div>
            <%} %>
        </div>
    <%} %>
</asp:Content>
