<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link rel="apple-touch-icon" href="../assets/img/Lotz_Logo.png"/>
    <link rel="shortcut icon" type="image/x-icon" href="../assets/img/Lotz_Logo.png"/>

    <link rel="stylesheet" href="~/assets/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/assets/css/templatemo.css"/>
    <link rel="stylesheet" href="~/assets/css/custom.css"/>

    <!-- Load fonts style after rendering the layout styles -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;200;300;400;500;700;900&display=swap"/>
    <link rel="stylesheet" href="~/assets/css/fontawesome.min.css"/>
    <title>Home - Lotz</title>
    
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentClass">
            <!-- Banner -->
            <div id="template-mo-zay-hero-carousel" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <div class="container">
                            <div class="row p-5">
                                <div class="mx-auto col-md-8 col-lg-6 order-lg-last">
                                    <img class="img-fluid" src="../assets/img/bannerHome.jpg" alt="">
                                </div>
                                <div class="col-lg-6 mb-0 d-flex align-items-center">
                                    <div class="text-align-left align-self-center">
                                        <h1 class="h1 text-success"><b>Lotz</b></h1>
                                        <h3 class="h2">Get a lot at Lotz</h3>
                                        <p>
                                            Lotz is an eCommerce with latest version of clothes. 
                                            <asp:Button ID="shop" CssClass="form-control bg-dark border-light" runat="server" Text="Shop Now" OnClick="shop_Click"/>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    <!-- Banner Done -->

    <!-- Start New Product -->
            <div class="container py-5">
                <div class="row text-center py-3">
                    <div class="col-lg-6 m-auto">
                        <h1 class="h1">Featured Product</h1>
                        <p>
                            Reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                            Excepteur sint occaecat cupidatat non proident.
                        </p>
                    </div>
                </div>



                <div class="row">
                    <asp:Repeater ID="cardRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-12 col-md-4 mb-4">
                                <div class="card h-100 pointer" onclick='<%# "imageClicked(" + Eval("ClothID") + "); return false;" %>'>
                                    <a>
                                        <img class="card-img-top" src='<%#(Eval("ClothImage")) %>' data-image-id='<%# Eval("ClothID") %>'/>
                                    </a>
                                    <div class="card-body">
                                        <a class="h2 text-decoration-none text-dark">
                                            <h3><%# Eval("ClothName") %></h3></a>
                                        <p class="card-text">
                                            <%# Eval("ClothDesc") %>
                                        </p>
                                        <ul class="list-unstyled d-flex justify-content-between">
                                            <li>
                                                <asp:Label ID="price" CssClass="text-right" runat="server">Rp <%# Eval("ClothPrice")%></asp:Label>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                         </ItemTemplate>
                     </asp:Repeater>
                </div>
            </div>
        <!-- End Featured Product -->
    </div>

</asp:Content>
