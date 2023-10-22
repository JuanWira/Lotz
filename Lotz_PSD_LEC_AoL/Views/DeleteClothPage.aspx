<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="DeleteClothPage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.DeleteClothPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Delete Cloth - Lotz</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Product -->
    <section class="bg-light">
        <div class="container py-5">
                <div class="row">
                    <asp:Repeater ID="cardRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-12 col-md-4 mb-4">
                                <div class="card h-100" href="shop-single.aspx">
                                    <a>
                                        <img class="card-img-top" src='<%#(Eval("ClothImage")) %>' data-image-id='<%# Eval("ClothID") %>' />
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
                                        <asp:Button ID="del" CommandArgument='<%# Eval("ClothID") %>' runat="server" Text="Delete Cloth" OnClick="del_Click" />
                                    </div>
                                </div>
                            </div>
                         </ItemTemplate>
                     </asp:Repeater>
                </div>
            </div>
    </section>
    <!-- End Product -->
</asp:Content>
