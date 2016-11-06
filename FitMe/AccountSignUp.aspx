<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AccountSignUp.aspx.cs" Inherits="FitMe.AccountSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="row">
			<div class="col-sm-6 col-md-4 col-md-offset-4">
				<div class="panel panel-default">
					<div class="panel-heading">
						<strong> Sign up for a new account!</strong>
					</div>
					<div class="panel-body">
						<form role="form" action="#" method="POST" runat="server">
							<fieldset>
								<div class="row">
								</div>
								<div class="row">
									<div class="col-sm-12 col-md-10  col-md-offset-1 ">
										<div class="form-group">
											<div class="input-group">
                                                <asp:TextBox runat="server" placeholder="First" ID="tbFirstName" CssClass="roundedcorner"></asp:TextBox>
                                                <asp:TextBox runat="server" placeholder="Last" ID="tbLastName" CssClass="roundedcorner"></asp:TextBox>
                                                <asp:TextBox runat="server" placeholder="Email" ID="tbEmail" CssClass="roundedcorner"></asp:TextBox>
                                                <asp:TextBox runat="server" placeholder="Password" ID="tbPassword" TextMode="Password" CssClass="roundedcorner" ></asp:TextBox>
                                                <asp:TextBox runat="server" placeholder="Re-type Password" ID="tbPasswordVerify" TextMode="Password" CssClass="roundedcorner" ></asp:TextBox>
											</div>
										</div>
										<div class="form-group">
											 <asp:Button runat="server" ID="btnSignUp" Text="Sign Up" OnClick="btnSignUp_Click" CssClass="btn btn-primary" />
										</div>
									</div>
								</div>
							</fieldset>
						</form>
					</div>
					<div class="panel-footer ">
						Already have an account? <a href="AccountSignIn.aspx" onclick=""> Sign In Here </a>
					</div>
                </div>
			</div>
		</div>
                                </div>
                                </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>