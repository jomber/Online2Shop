<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TransactionResult.aspx.cs" Inherits="Online2Shop.TransactionResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/paypal.js"></script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" runat="server">
    <div id="transactionResult"></div>
    <form id="transactionForm" method="post" action="https://www.paypal.com/cgi-bin/webscr">
        <input type="hidden" name="cmd" value="_notify-synch">
        <input id="formTx" type="hidden" name="tx" value="61M56680RS733401U">
        <input type="hidden" name="at" value="abguBANFHrN_mIGopxWErMJY_uIWeGcwp_S8X2biotJY4VTZ9dXdhzg6L-0">
        <input type="submit" value="PDT">
    </form> 
</asp:Content>
