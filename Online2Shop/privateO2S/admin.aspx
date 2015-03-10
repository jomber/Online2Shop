<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Online2Shop.privateO2S.admin" %>

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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="IdUser" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="IdUser" HeaderText="IdUser" SortExpression="IdUser" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" Visible="false" />
                    <asp:BoundField DataField="Admin" HeaderText="Admin" SortExpression="Admin" Visible="false" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUsers" TypeName="DataStore.Online2ShopTableAdapters.membersTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_IdUser" Type="Int64" />
                    <asp:Parameter Name="Original_Username" Type="String" />
                    <asp:Parameter Name="Original_Password" Type="String" />
                    <asp:Parameter Name="Original_Admin" Type="UInt64" />
                    <asp:Parameter Name="Original_Email" Type="String" />
                    <asp:Parameter Name="Original_Discount" Type="UInt64" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Username" Type="String" />
                    <asp:Parameter Name="Password" Type="String" />
                    <asp:Parameter Name="Admin" Type="UInt64" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Discount" Type="UInt64" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Username" Type="String" />
                    <asp:Parameter Name="Password" Type="String" />
                    <asp:Parameter Name="Admin" Type="UInt64" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Discount" Type="UInt64" />
                    <asp:Parameter Name="Original_IdUser" Type="Int64" />
                    <asp:Parameter Name="Original_Username" Type="String" />
                    <asp:Parameter Name="Original_Password" Type="String" />
                    <asp:Parameter Name="Original_Admin" Type="UInt64" />
                    <asp:Parameter Name="Original_Email" Type="String" />
                    <asp:Parameter Name="Original_Discount" Type="UInt64" />
                </UpdateParameters>
            </asp:ObjectDataSource>
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
