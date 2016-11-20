<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FitMe.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <!-- Main component for a primary marketing message or call to action -->
    <div class="jumbotron">
        <h1>Contact <%=FitMe.Helper.Constants.SiteTitle %></h1>
        <p class="paragraphFormat">
            Stick around for more info!
        </p>
        <p class="paragraphFormat>
            Track Bugs and Features being worked on <a href="<%=FitMe.Helper.Constants.WebSite_TrelloFeedback %>" target="_blank">HERE</a> (You can even VOTE for the ones you like!)
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>