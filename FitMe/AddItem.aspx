<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="FitMe.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <form id="formAddItem" runat="server">
        <!-- Main component for a primary marketing message or call to action -->
    <div class="jumbotron">
        <h1>Add an item!</h1>
        <div class ="input-group">
            <asp:TextBox runat="server" ID="tbDesignerName" BackColor="White" BorderStyle="Double"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="tbNeckSize" BackColor="White" BorderStyle="Double" ToolTip="asdf"></asp:TextBox>
            <br />
            <input type ="text" placeholder="Sleeve Size" id="tbSleveSize" />
            <br />
            <input type ="text" placeholder="Chest Size" id="tbChestSize" />
            <br />
            <input type ="text" placeholder="Waist Size" id="tbWaistSize" />
            
        </div>
        <br />
        <div class ="button-group">
            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" CssClass="btn btn-primary" />
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
