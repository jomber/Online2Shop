<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ItemDetails.aspx.cs" Inherits="Online2Shop.ItemDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" runat="server">
    <div id="wrapperItemDetails">
        <div id="itemNameWrapper" runat="server"></div>
        <div id="wrapperItemDetailsInternal" runat="server">
            <div id="popupImages">
                <div id="overlayLayerInvisible" runat="server"></div>
                <div id="popupImagesInternal"></div>
            </div>
        </div>
    </div>
</asp:Content>
