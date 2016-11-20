<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FitMe.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="jumbotron">
        <h1>Welcome to <%=FitMe.Helper.Constants.SiteTitle %> :)</h1>
        <p class="paragraphFormat">
            Hello, and welcome to <%=FitMe.Helper.Constants.SiteTitle %>. My name is Derek Thrasher and I'm excited to help make shopping for clothes easier for all of us.
            <%=FitMe.Helper.Constants.SiteTitle %> will learn your style and size and recommend clothes that will fit you just right!
        </p>
        <p class="paragraphFormat">
            <a href="<%=FitMe.Helper.Constants.Page_AccountSignUp %>">Start building your closet today!</a>
        </p>
        <p class="paragraphFormat">
            We are adding new features daily so you'll be able to watch the site grow. 
        </p>
        <p class="paragraphFormat">
            See what users have requested and what is being worked on <a "<%=FitMe.Helper.Constants.WebSite_TrelloFeedback %>">HERE</a>
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
