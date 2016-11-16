<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RateItem.aspx.cs" Inherits="FitMe.RateItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        <div class="jumbotron" runat="server">

            <h1>Congrats!</h1>
            <h2>This <%=UserRateditem.ItemType.ToString().ToLower() %> has been added to your closet.</h2>
            <div>
                <ajaxToolkit:Rating ID="rItemRating" runat="server" MaxRating="5" CssClass="ratingStar" StarCssClass="ratingItem" FilledStarCssClass="filledStar" EmptyStarCssClass="emptyStar" WaitingStarCssClass="waitingStar"></ajaxToolkit:Rating>
            </div>
            <div>
               <asp:TextBox runat="server" ID="tbPrice" placeholder="Price (29.99)" CssClass="roundedcorner"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="tbStore" runat="server" placeholder="Store Name or WebLink" CssClass="roundedcorner"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="tbComment" runat="server" placeholder="Comments" CssClass="roundedcorner"></asp:TextBox>
            </div>
            <div>
                <asp:Button runat="server" ID="btnRateItem" Text="Update Closet Item" OnClick="btnRateItem_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
