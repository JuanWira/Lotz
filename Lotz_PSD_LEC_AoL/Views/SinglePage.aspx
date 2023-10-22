<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="SinglePage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.SinglePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <h6>Description:</h6>
                            <p><asp:Label ID="desc" runat="server"></asp:Label></p>
                            <h6>Size: <asp:Label ID="size" runat="server"></asp:Label></h6>
                            <h6>Gender: <asp:Label ID="gender" runat="server"></asp:Label></h6>
                            <h6>Stock: <asp:Label ID="stock" runat="server"></asp:Label></h6>

                            <div class="row">
                                <div class="col-auto">
                                    <ul class="list-inline pb-3">
                                        <li class="list-inline-item text-right">
                                            Quantity
                                            <input type="hidden" name="product-quanity" id="product-quanity" value="1">
                                        </li>
                                        <asp:TextBox ID="qty" runat="server"></asp:TextBox>
                                    </ul>
                                </div>
                            </div>
                            <asp:Label ID="errorQty" runat="server" Text="Label"></asp:Label>
                            <div class="row pb-3">
                                <div class="col d-grid">
                                    <asp:Button ID="cart" runat="server" Text="Add to Cart" CssClass="btn btn-success btn-lg" OnClick="cart_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Close Content -->
</asp:Content>
