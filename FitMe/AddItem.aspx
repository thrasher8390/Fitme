<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="FitMe.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <form id="formAddItem" runat="server">
        <!-- Main component for a primary marketing message or call to action -->
    <div class="jumbotron">
        <h1>Add an item!</h1>
        <div class ="input-group" id="lblSuccessfullyAddedItem">
            <asp:TextBox runat="server" ID="tbDesignerName" BackColor="White" BorderStyle="Double"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="tbNeckSize" BackColor="White" BorderStyle="Double" ToolTip="asdf"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="tbSleeveSize" BackColor="White" BorderStyle="Double" ToolTip="asdf"></asp:TextBox> 
            <br />
            <asp:TextBox runat="server" ID="tbChestSize" BackColor="White" BorderStyle="Double" ToolTip="asdf"></asp:TextBox>           
            <br />
            <asp:Label ID="lblSuccessfullyAddedItem" runat="server" Visible="false" Text="YAY! You successfully added an item!" Font-Bold="True" ForeColor="#00CC00"></asp:Label>
        </div>
        <div class ="button-group">
            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" CssClass="btn btn-primary" />
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
