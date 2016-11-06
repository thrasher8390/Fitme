<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AccountSignIn.aspx.cs" Inherits="FitMe.AccountSignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="row">
			<div class="col-sm-6 col-md-4 col-md-offset-4">
				<div class="panel panel-default">
					<div class="panel-heading">
						<strong> Sign in to continue</strong>
					</div>
					<div class="panel-body">
						<form role="form" action="#" method="POST" runat="server">
							<fieldset>
								<div class="row">
									<div class="center-block" style="text-align:center" >
										<img class="profile-img" src="https://scontent-atl3-1.xx.fbcdn.net/v/t1.0-1/p160x160/14492317_10207407225799009_6469008992148351723_n.jpg?oh=53a7338dfc0b8a5fbaae2ad4ff37e736&oe=58D57619" alt="">
									</div>
								</div>
								<div class="row">
									<div class="col-sm-12 col-md-10  col-md-offset-1 ">
										<div class="form-group">
											<div class="input-group">
												<i class="glyphicon glyphicon-user"></i>
                                                <asp:TextBox runat="server" placeholder="Username (email)" ID="tbUserName" CssClass="roundedcorner"></asp:TextBox>
											</div>
											<div class="input-group">
												<i class="glyphicon glyphicon-lock"></i>
                                                <asp:TextBox runat="server" placeholder="Password" ID="tbPassword" TextMode="Password" CssClass="roundedcorner" ></asp:TextBox>
											</div>
										</div>
										<div class="form-group">
											 <asp:Button runat="server" ID="btnSignIn" Text="Sign In" OnClick="btnSignIn_Click" CssClass="btn btn-primary" />
										</div>
									</div>
								</div>
							</fieldset>
						</form>
					</div>
					<div class="panel-footer ">
						Don't have an account! <a href="AccountSignUp.aspx" onclick=""> Sign Up Here </a>
					</div>
                </div>
			</div>
		</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>