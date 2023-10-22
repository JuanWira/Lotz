<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBarFooter.Master" AutoEventWireup="true" CodeBehind="InsertClothPage.aspx.cs" Inherits="Lotz_PSD_LEC_AoL.Views.InsertClothPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentClass">
        <h1 class="title">Insert New Cloth</h1>
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="nameTb" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="descriptionTb" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="priceTb" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Stock"></asp:Label>
        <asp:TextBox ID="stockTb" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Image"></asp:Label>
        <asp:FileUpload ID="imageUpload" runat="server" />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Size"></asp:Label>
        <asp:DropDownList ID="size" runat="server">
            <asp:ListItem>XS</asp:ListItem>
            <asp:ListItem>S</asp:ListItem>
            <asp:ListItem>M</asp:ListItem>
            <asp:ListItem>L</asp:ListItem>
            <asp:ListItem>XL</asp:ListItem>
            <asp:ListItem>XXL</asp:ListItem>
            <asp:ListItem>XXXL</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Gender"></asp:Label>
        <asp:DropDownList ID="gender" runat="server">
            <asp:ListItem>Female</asp:ListItem>
            <asp:ListItem>Male</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="insertCloth" runat="server" Text="Insert Cloth" OnClick="insertCloth_Click"/>
    </div>
</asp:Content>
