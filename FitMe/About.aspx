﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FitMe.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <!-- Main component for a primary marketing message or call to action -->
    <div class="jumbotron">
        <h1>About <%=FitMe.Helper.Constants.SiteTitle %></h1>
        <p class="paragraphFormat>
            <%=FitMe.Helper.Constants.SiteTitle %> was started in 2016.
        </p>
        <p class="paragraphFormat>
            Stick around for more info!
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>