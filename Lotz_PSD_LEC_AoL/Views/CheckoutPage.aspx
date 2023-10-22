<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.CheckoutPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <title>Check Out - Lotz</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <h2>Checkout</h2>
            <!-- Open Content -->
    <section class="bg-light">
        <div class="container pb-5">
            <div class="row">
                <div class="col-lg-5 mt-5">
                    <div class="card mb-3">
                        <asp:Image ID="img" runat="server" CssClass="card-img img-fluid" />
                    </div>
                </div>
                <!-- col end -->
                <div class="col-lg-7 mt-5">
                    <div class="card">
                        <div class="card-body">
                            <h1 class="h2"><asp:Label ID="name" runat="server"></asp:Label></h1>
                            <p class="h3 py-2"><asp:Label ID="prc" runat="server"></asp:Label></p>
                            <h6>Size: <asp:Label ID="size" runat="server"></asp:Label></h6>

                            <div class="row">
                                <div class="col-auto">
                                    <ul class="list-inline pb-3">
                                        <li class="list-inline-item text-right">
                                            Quantity: 
                                            <input type="hidden" name="product-quanity" id="product-quanity" value="1">
                                        </li>
                                        <asp:Label ID="qty" runat="server"></asp:Label>
                                    </ul>
                                    <ul class="list-inline pb-3">
                                        <li class="list-inline-item text-right">
                                            <asp:Label ID="Label1" runat="server" Text="Payment: "></asp:Label>
                                        </li>
                                        <asp:DropDownList ID="payment" runat="server">
                                                <asp:ListItem>OVO</asp:ListItem>
                                                <asp:ListItem>Gopay</asp:ListItem>
                                                <asp:ListItem>ShopeePay</asp:ListItem>
                                        </asp:DropDownList>
                                    </ul>
                                </div>
                            </div>
                            <div class="row pb-3">
                                <div class="col d-grid">
                                    <asp:Button ID="buy" CssClass="btn btn-success btn-lg" Text="Buy" runat="server" OnClick="buy_Click"/>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Close Content -->
        </div>
</asp:Content>
