<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="FitMe3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="fUsers" runat="server">
        <p>
            <asp:SqlDataSource ID="FitMeUsers" runat="server" ConnectionString="<%$ ConnectionStrings:fitmedatabase1 %>" ProviderName="<%$ ConnectionStrings:fitmedatabase1.ProviderName %>" SelectCommand="SELECT fitmeusers.* FROM fitmeusers"></asp:SqlDataSource>
            Here is a website with 2 users</p>
        <asp:TextBox ID="tbUserName" runat="server">User Name</asp:TextBox>
        <asp:TextBox ID="tbFirstName" runat="server">First Name</asp:TextBox>
        <asp:Button ID="btnSaveUser" runat="server" OnClick="btnSaveUser_Click" Text="SaveUser" />
        <br />
        <asp:GridView ID="gvFitMeUsers" runat="server" AllowSorting="True" DataSourceID="FitMeUsers">
        </asp:GridView>
        <br />
    </form>
</body>
</html>
