<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function cartClicked(CartID) {
            window.location.href = "CheckoutPage.aspx?CartID=" + CartID;
        }
    </script>
    <title>Cart - Lotz</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (role != "G")
        { %>
        <!-- Start Product -->
        <section class="bg-light">
            <div class="container py-5">
                <div class="row text-center py-3">
                    <div class="col-lg-6 m-auto">
                        <h1 class="h1">
                            <asp:Label ID="searchCloth" runat="server"></asp:Label></h1>
                    </div>
                </div>
                    <div class="row">
                            <ItemTemplate>
        <div class="row d-flex justify-content-center align-items-center h-100">
          <div class="col-10">

            <div class="d-flex justify-content-between align-items-center mb-4">
              <h3 class="fw-normal mb-0 text-black">Shopping Cart</h3>
            </div>
              <!--Start-->
            <asp:Repeater ID="cardRepeater" runat="server">
                 <ItemTemplate>
                     <asp:Label ID="id" runat="server" Visible="false"></asp:Label>
                    <div class="card rounded-3 mb-4">
                      <div class="card-body p-4">
                        <div class="row d-flex justify-content-between align-items-center">
                          <div class="col-md-2 col-lg-2 col-xl-2">
                            <img class="card-img-top" src='<%#(Eval("ClothImage")) %>' />
                          </div>
                          <div class="col-md-3 col-lg-3 col-xl-3">
                            <h5><%# Eval("ClothName") %></h5>
                            <p>Size: <%# Eval("ClothSize") %></p>
                          </div>
                          <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                            <asp:Label runat="server" ID="qty" CssClass="form-control form-control-sm">Quantity: <%#(Eval("ClothQty"))%></asp:Label>
                          </div>
                          <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                            <asp:Label ID="Label1" CssClass="text-right" runat="server">Rp <%# Eval("ClothPrice")%></asp:Label>
                          </div>
                          <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                            <a href="#!" class="text-danger">
                                <i><asp:Button runat="server" Text="Delete" OnClick="delete_Click" ID="delete" CommandArgument='<%# Eval("CartID") %>' /></i>
                            </a>
                          </div>
                            <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                                <a class="text-danger">
                                  <i><asp:Button ID="checkout" runat="server" data-image-id='<%# Eval("CartID") %>' onclick='<%# "cartClicked(" + Eval("CartID") + "); return false;" %>' Text="Buy"/></i>
                                </a>
                            </div>

                        </div>
                      </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
              <!--End-->
            <div class="card mb-4">
              <div class="card-body p-4 d-flex flex-row">
            </div>

          </div>
        </div>
      </div>
                             </ItemTemplate>
                    </div>
                </div>
        </section>
        <!-- End Product -->
    <%} %>
    <%else
    { %>
        <asp:Label ID="Label2" runat="server" Text="Login First!"></asp:Label>
    <%} %>
</asp:Content>