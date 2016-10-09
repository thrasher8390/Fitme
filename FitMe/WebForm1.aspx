<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FitMe3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="FitMeUsers" runat="server" ConnectionString="<%$ ConnectionStrings:FitMeDatabase %>" ProviderName="<%$ ConnectionStrings:FitMeDatabase.ProviderName %>" SelectCommand="SELECT fitmeusers.* FROM fitmeusers"></asp:SqlDataSource>
    
    </div>
        <p>
            Here is a website with 2 users</p>
        <asp:TextBox ID="tbUserName" runat="server">User Name</asp:TextBox>
        <asp:TextBox ID="tbFirstName" runat="server">First Name</asp:TextBox>
        <asp:Button ID="btnSaveUser" runat="server" OnClick="btnSaveUser_Click" Text="SaveUser" />
        <br />
        <asp:GridView ID="gvFitMeUsers" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="FitMeUsers">
        </asp:GridView>
    </form>
</body>
</html>
