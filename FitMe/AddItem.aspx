﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="FitMe.AddItem" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <form id="formAddItem" runat="server">
        <div class="jumbotron">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"/>  
            <h1>Add an item!</h1>
            <div class ="ui-widget" style="text-align:left">
                <asp:TextBox runat="server" ID="tbDesignerName" BackColor="White" BorderStyle="None" ToolTip="Designer Name" CssClass="textboxAuto roundedcorner" placeholder="Designer name"></asp:TextBox>
                <asp:AutoCompleteExtender ServiceMethod="GetDesignerName" TargetControlID="tbDesignerName" ID="aceDesignerName" runat="server" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" FirstRowSelected="true"/>
                <asp:Label ID="lblInvalidDesignerName" runat="server" Visible="false" Text="invalid designer name" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="tbNeckSize" BackColor="White" BorderStyle="None" ToolTip="Neck Size" CssClass="textboxAuto roundedcorner" placeholder="Neck size"></asp:TextBox>
                <asp:AutoCompleteExtender ServiceMethod="GetNeckSize" TargetControlID="tbNeckSize" ID="aceNeckSize" runat="server" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" FirstRowSelected="true"/>
                <asp:Label ID="lblInvalidNeckSize" runat="server" Visible="false" Text="invalid neck size" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="tbSleeveSize" BackColor="White" BorderStyle="None" ToolTip="Sleeve Size" CssClass="textboxAuto roundedcorner" placeholder="Sleeve length"></asp:TextBox> 
                <asp:AutoCompleteExtender ServiceMethod="GetSleeveSize" TargetControlID="tbSleeveSize" ID="aceSleeveSize" runat="server" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" FirstRowSelected="true"/>
                <asp:Label ID="lblInvalidSleeveSize" runat="server" Visible="false" Text="invalid sleeve size" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="tbChestSize" BackColor="White" BorderStyle="None" ToolTip="Chest Size" CssClass="textboxAuto roundedcorner" placeholder="Chest size"></asp:TextBox>           
                <asp:AutoCompleteExtender ServiceMethod="GetChestSize" TargetControlID="tbChestSize" ID="aceChestSize" runat="server" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" FirstRowSelected="true"/>
                <asp:Label ID="lblInvalidChestSize" runat="server" Visible="false" Text="invalid chest size" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblTroubleAddingItem" runat="server" Visible="false" Text="Trouble Adding Item. Please Try Again." Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
            <!-- ui-widget -->
            <div class ="button-group">
                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" CssClass="btn btn-primary" />
            </div>
            <!-- button-group -->
        </div>
        <!-- jumbotron -->
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">


</asp:Content>
