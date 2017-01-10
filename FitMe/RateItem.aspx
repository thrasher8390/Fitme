<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RateItem.aspx.cs" Inherits="FitMe.RateItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        <div class="jumbotron" runat="server">
            <div class="row">
                <div class="text-center">
                    <h1>Congrats!</h1>
                    <h2>This <%=UserRateditem.ItemType.ToString().ToLower() %> has been added to your closet.</h2>
                    <ajaxToolkit:Rating ID="rItemRating" runat="server" MaxRating="5" CssClass="ratingStar" StarCssClass="ratingItem" FilledStarCssClass="filledStar" EmptyStarCssClass="emptyStar" WaitingStarCssClass="waitingStar"></ajaxToolkit:Rating>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="text-center">
                        <div>
                            <asp:TextBox runat="server" ID="tbPrice" placeholder="Price (29.99)" CssClass="roundedcorner"></asp:TextBox>
                        </div>
                        <div>
                            <asp:TextBox ID="tbStore" runat="server" placeholder="Store Name or WebLink" CssClass="roundedcorner"></asp:TextBox>
                        </div>
                        <div>
                            <asp:TextBox ID="tbComment" runat="server" placeholder="Comments" CssClass="roundedcorner"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="text-center">
                        <div class="row">
                            <img id="imgPhoto" src="<%=UserRateditem.PhotoURL %>" alt="Please enter a valid URL of a shirt below" class="img-rounded" width="150" height="150">
                        </div>
                        <div class="row">
                            <asp:TextBox runat="server" ID="tbPhotoURL" placeholder="Clothes Photo URL" OnTextChanged="tbPhotoURL_TextChanged" CssClass="roundedcorner"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="text-center">
                    <asp:Button runat="server" ID="btnRateItem" Text="Update Closet Item" OnClick="btnRateItem_Click" CssClass="btn btn-primary" />
                    <asp:Button runat="server" ID="btnSkip" Text="Skip >>" OnClick="btnSkip_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
