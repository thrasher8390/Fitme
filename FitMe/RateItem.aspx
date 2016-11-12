<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RateItem.aspx.cs" Inherits="FitMe.RateItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        <div class="jumbotron" runat="server">

            <h1>Rate Newly Added Item / Update Existing Item</h1>
            <div>
                <ajaxToolkit:Rating ID="rItemRating" runat="server" CurrentRating="1" MaxRating="5" CssClass="ratingStar" EmptyStarCssClass="emptyStar" FilledStarCssClass="filledStar" StarCssClass="ratingItem" WaitingStarCssClass="waitingStar" AutoPostBack="true" OnChanged="rItemRating_Changed"></ajaxToolkit:Rating>
            </div>
            <div>
                <asp:Button runat="server" ID="btnRateItem" Text="Rate Item" OnClick="btnRateItem_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
