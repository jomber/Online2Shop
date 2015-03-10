<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="Online2Shop.MyCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" runat="server">
    <div id="messageCart">
        <asp:Label ID="YourCartLabel" runat="server" Text="Your Cart"></asp:Label>
        <asp:Button class="buttons" ID="ContinueCart" runat="server" Text="Continue" />
    </div>
    <div id="headItemsCart"></div>
    <div id="wrapperItemsCart" runat="server"></div>
    <div id="deliveryItemsCart">
        <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
        
        
          
    </div>
    
</asp:Content>

