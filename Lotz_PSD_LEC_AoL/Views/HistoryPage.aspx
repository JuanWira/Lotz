<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.HistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>History - Lotz</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4ebe8;
            margin: 0;
            padding: 20px;
        }

        h1 {
            color: #664a3e;
            margin-bottom: 30px;
        }

        .transaction-card {
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            padding: 20px;
            margin-bottom: 20px;
        }

        .transaction-card h3 {
            color: #664a3e;
            margin-top: 0;
        }

        .transaction-card p {
            margin: 10px 0;
        }

        .transaction-card .details {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }

        .transaction-card .status {
            color: #8a685f;
            font-weight: bold;
        }

        .pagination {
            margin-top: 20px;
            text-align: center;
        }

        .pagination a {
            display: inline-block;
            padding: 8px 12px;
            background-color: #8a685f;
            color: #fff;
            border-radius: 4px;
            margin-right: 4px;
            text-decoration: none;
        }

        .pagination a.active {
            background-color: #664a3e;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="empty" runat="server"></asp:Label>
            <!-- Start Product -->
        <section class="bg-light">
            <div class="container py-5">
                    <div class="row">
                            <ItemTemplate>
        <div class="row d-flex justify-content-center align-items-center h-100">
          <div class="col-10">

            <div class="d-flex justify-content-between align-items-center mb-4">
              <h3 class="fw-normal mb-0 text-black">Transaction History</h3>
            </div>
              <!--Start-->
            <asp:Repeater ID="cardRepeater" runat="server">
                 <ItemTemplate>
                    <div class="card rounded-3 mb-4">
                      <div class="card-body p-4">
                        <div class="row d-flex justify-content-between align-items-center">
                          <div class="col-md-2 col-lg-2 col-xl-2">
                            <img class="card-img-top" src='<%#(Eval("ClothImage")) %>' />
                          </div>
                          <div class="col-md-3 col-lg-3 col-xl-3">
                            <h5><%# Eval("ClothName") %></h5>
                            <p>Size: <%# Eval("ClothSize") %></p>
                              <p>Date: <%# Eval("Date") %></p>
                          </div>
                          <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                            <asp:Label runat="server" ID="qty" CssClass="form-control form-control-sm">Quantity: <%#(Eval("ClothQty"))%></asp:Label>
                          </div>
                          <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                            <asp:Label ID="Label1" CssClass="text-right" runat="server">Rp <%# Eval("ClothPrice")%></asp:Label>
                          </div>
                          <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                              <asp:Label ID="Label2" CssClass="text-right" runat="server"><%# Eval("PaymentType")%></asp:Label>
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
        </div>
</asp:Content>
