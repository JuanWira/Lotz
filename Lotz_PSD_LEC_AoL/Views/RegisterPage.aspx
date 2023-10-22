<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentClass">
        <div class="row">
            <div class="col-12 col-md-4 mb-4">
                <div class="h-100" href="shop-single.aspx">
                    <div class="card-body">
                        <h1 class="title">Register</h1>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox ID="nameReg" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="emailReg" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Gender"></asp:Label>
                        <asp:RadioButtonList ID="genderRb" runat="server">
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>
                        <asp:TextBox ID="addressTb" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="pw" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Phone Number"></asp:Label>
                        <asp:TextBox ID="number" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="errorReg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
