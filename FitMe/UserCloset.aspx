﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserCloset.aspx.cs" Inherits="FitMe.UserCloset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <form runat="server">
        <div class="jumbotron" runat="server">
            <asp:GridView runat="server" ID="gvUserCloset" CssClass="table table-striped table-bordered table-condensed" AutoGenerateDeleteButton="True" AutoGenerateEditButton="true" OnRowDeleting="gvUserCloset_RowDeleting" OnRowEditing="gvUserCloset_RowEditing"></asp:GridView>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>