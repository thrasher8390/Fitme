<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RateItem.aspx.cs" Inherits="FitMe.RateItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        <div class="jumbotron" runat="server">

            <h1>Rate Item</h1>
            <div>
                <ajaxToolkit:Rating ID="rItemRating" runat="server" CurrentRating="1" MaxRating="5" CssClass="ratingStar" StarCssClass="ratingItem" FilledStarCssClass="filledStar" EmptyStarCssClass="emptyStar" WaitingStarCssClass="waitingStar"></ajaxToolkit:Rating>
            </div>
            <div>
                <asp:Button runat="server" ID="btnRateItem" Text="Rate Item" OnClick="btnRateItem_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
