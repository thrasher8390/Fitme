<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AccountSignIn.aspx.cs" Inherits="FitMe.AccountSignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="row">
        <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong><%=FitMe.Helper.Constants.SiteTitle %> is happy you are back!</strong>
                </div>
                <div class="panel-body">
                    <form role="form" action="#" method="POST" runat="server">
                        <fieldset>
                            <div class="row">
                                <div class="center-block" style="text-align: center">
                                    <img class="profile-img" src="http://www.wishalerts.com/sites/default/files/user_default_images/default-profile-pic.jpg" alt="http://www.wishalerts.com/sites/default/files/user_default_images/default-profile-pic.jpg">
                                </div>
                            </div>
                            <div class="row">
                                <div class="center-block" style="text-align: center">
                                    <i class="glyphicon glyphicon-user"></i>
                                    <asp:TextBox runat="server" placeholder="Username (email)" ID="tbUserName" CssClass="roundedcorner"></asp:TextBox>
                                </div>
                                <div class="center-block" style="text-align: center">
                                    <i class="glyphicon glyphicon-lock"></i>
                                    <asp:TextBox runat="server" placeholder="Password" ID="tbPassword" TextMode="Password" CssClass="roundedcorner"></asp:TextBox>
                                </div>
                                <div class="center-block" style="text-align: center">
                                    <asp:Button runat="server" ID="btnSignIn" Text="Sign In" OnClick="btnSignIn_Click" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </fieldset>
                    </form>
                </div>
                <div class="panel-footer ">
                    <div class="center-block" style="text-align: center">
                        Don't have an account! <a href=<%=FitMe.Helper.Constants.Page_AccountSignUp %> onclick="">Sign Up Here </a>
                    </div>
                </div>
            </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
