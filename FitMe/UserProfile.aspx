<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="FitMe.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <form runat="server">
        <div class="jumbotron" runat="server">
            <h1>My Profile</h1>
            <p>
                First Name: 
                <asp:TextBox runat="server" ID="tbFirstName" CssClass="roundedcorner"></asp:TextBox>
            </p>
            <p>
                Last Name: 
                <asp:TextBox runat="server" ID="tbLastName" CssClass="roundedcorner"></asp:TextBox>
            </p>
            <p>
                Email Address:
            <asp:TextBox runat="server" ID="tbEmailAddress" ReadOnly="true" CssClass="roundedcorner"></asp:TextBox>
            </p>
            <br />
            <asp:Button runat="server" ID="btnUpdateProfile" Text="Update Profile" OnClick="btnUpdateProfile_Click" CssClass="btn btn-primary"/>
            <asp:Label runat="server" ID="lblUpdateSuccessfull" Text="Your profile has been updated!" ForeColor="Green" Visible="false"></asp:Label>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
