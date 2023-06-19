<%@ Page Title="OrderRamen" Language="C#" MasterPageFile="~/View/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="RAAMEN.View.Customer.OrderRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styling/Customer/OrderRamen.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <p class="title">
            Order List Ramen 
        </p>
        <div class="ramen">
             <%foreach (var x in listRamen)
               { %>
                <div class="item" data-ramen-id="<%=x.Id%>">
                    <div class="image">
                        <img src="../../Images/Ramen_1.jfif" class="img-ramen">
                    </div>
                    <div class="detail-ramen">
                        <div class="name">
                            <p > <%=x.Name %></p>
                        </div>
                        <div class="detail">
                            <p> Broth : <%=x.Broth %></p>
                            <p> Meat : <%=x.Meat.Name %> </p>
                            <p> Price : <%=x.Price %></p>
                        </div>
                        <div class="order">
                            <div>
                                <asp:DropDownList ID="dropDownListQuantity" runat="server" CssClass="select">
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
                              
                            </div>
                            <div class="cart">
                                <a href="#" class="confirm">Confirm</a>
                            </div>
                        </div>
                    </div>
                </div> 
            <% } %>
        </div>
         <br />
         <asp:Button ID="AddToCartButton" runat="server" Text="Add To Cart" OnClick="AddToCartButton_Click" />
         <br />
         <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
         <br /><br /><br />
         <p class="title">
            Your Cart
        </p>
        <div class="row">
            <div class="col header">
                <p>Ramen</p>
            </div>
            <div class="col header">
                <p>Quantity</p>
            </div>
            <div class="col header">
                <p>AddedDate</p>
            </div>
            <div class="col header">
                <p>Action</p>
            </div>
        </div>
        <%foreach (var c in listCart)
            { %>
             <% if (c.Ramen != null) 
                { %>
                <div class="row">
                    <div class="col">
                           <%= c.Ramen.Name %>
                    </div>
                    <div class="col">
                        <%= c.Quantity %>
                    </div>
                    <div class="col">
                        <%= c.CreatedDate %>
                    </div>
                    <div class="col">
                        <a href="OrderRamen.aspx?cartId=<%=c.Id%>&ramen=<%= c.Ramen.Name %>&quantity=<%= c.Quantity %>">Remove</a>
                    </div>
                </div>
              <%} %>
        <%} %>
         <br />
         <asp:Button ID="clearButton" runat="server" Text="Clear Cart" OnClick="clearButton_Click" />
         <span>&nbsp;</span> 
         <asp:Button ID="orderButton" runat="server" Text="Make Order" OnClick="orderButton_Click" />
         <br />
         <asp:Label ID="cartStatus" runat="server" Text=""></asp:Label>
    </div>

    <script>
        // Ambil semua elemen dengan kelas "add-to-cart"
        const addToCartButtons = document.querySelectorAll('.confirm');

        // Tambahkan event listener pada setiap tombol "Add To Cart"
        addToCartButtons.forEach(button => {
            button.addEventListener('click', addToCartClicked);
        });

        // Fungsi yang dipanggil ketika tombol "Add To Cart" ditekan
        function addToCartClicked(event) {
            // Dapatkan elemen "item" yang berisi data ramen
            const item = event.target.closest('.item');

            // Dapatkan ID ramen dari atribut "data-ramen-id"
            const ramenId = item.getAttribute('data-ramen-id');

            // Dapatkan kuantitas (quantity) dari elemen dropdown
            const dropdown = item.querySelector('.select');
            const quantity = dropdown.value;

            // Kirim data ke server menggunakan permintaan AJAX (POST)
            $.ajax({
                type: 'POST',
                url: 'OrderRamen.aspx/AddToCart',
                data: JSON.stringify({ ramenId: ramenId, quantity: quantity }),
                contentType: 'application/json',
                success: function (response) {
                    // Tanggapan sukses dari server
                    console.log(response);
 
                },
                error: function (error) {
                    // Tanggapan error dari server
                    console.log(error);
                }
            });
        }
    </script>

</asp:Content>
