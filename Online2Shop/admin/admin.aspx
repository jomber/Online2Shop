<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Online2Shop.admin.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/admin.css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapperAdmin">
        <div id="wrapperUserDetails">
        <div id="wrapperUser">
        </div>
        <div id="wrapperMails">
        </div>
        </div>
        <div id="wrapperAdminPanel">
            <div id="SearchUserByEmail">
                <p>Search User By Email</p>
                <asp:TextBox ID="InputEmail" runat="server"></asp:TextBox>
                <asp:Button ID="SearchButtonEmail" runat="server" Text="Search" OnClick="SearchUser" />
            </div>
            <div id="UserByEmail" runat="server">
                <b><p class="partOfUser">Email:</p></b><p id="emailRetrieved" class="partOfUser" runat="server">___________________</p>
                <b><p class="partOfUser">Discount </p></b><asp:CheckBox ID="DiscountCheck" class="partOfUser" runat="server" />
                <asp:Button ID="ConfirmDiscountButton" email="" class="partOfUser" runat="server" Text="Confirm" OnClick="Activate" />
            </div>
            <div>
            <br class="clear">
                <p>Activate all Users Discount</p>
                <asp:Button ID="ActivateDiscountButton" runat="server" Text="Activate" OnClick="ActivateAll" />
                <p>Disctivate all Users Discount</p>
                <asp:Button ID="DisctivateDiscountButton" runat="server" Text="Disactivate" OnClick="DisactivateAll" />
            </div>
        </div>
        </div>
    </form>
</body>
</html>
