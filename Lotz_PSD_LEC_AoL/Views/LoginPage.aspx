<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.AccountPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentClass">
        <div class="row">
            <div class="col-12 col-md-4 mb-4">
                <div class="h-100" href="shop-single.aspx">
                    <div class="card-body">
                        <h1 class="title">Login</h1>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Email :"></asp:Label>
                        <asp:TextBox ID="emailTb" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Password :"></asp:Label>
                        <asp:TextBox ID="passwordTb" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
