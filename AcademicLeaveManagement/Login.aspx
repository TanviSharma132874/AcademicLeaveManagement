<%@ Page Title="Login" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="AcademicLeaveManagement.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card narrow">
        <h2>Sign in</h2>
        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
            <div class="field">
                <asp:Label ID="lblUserCaption" runat="server" AssociatedControlID="txtUsername" Text="Username" />
                <asp:TextBox ID="txtUsername" runat="server" MaxLength="50" />
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Username is required." Display="Dynamic" CssClass="field-error" />
            </div>
            <div class="field">
                <asp:Label ID="lblPassCaption" runat="server" AssociatedControlID="txtPassword" Text="Password" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="50" />
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password is required." Display="Dynamic" CssClass="field-error" />
            </div>
            <div class="field inline">
                <asp:CheckBox ID="chkRemember" runat="server" Text="Remember me (15 days)" />
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" />
            <asp:Label ID="lblMessage" runat="server" CssClass="msg error" EnableViewState="false" />
        </asp:Panel>
        <p class="hint">Demo accounts: admin / admin123 &nbsp;or&nbsp; student / stud123</p>
    </div>
</asp:Content>
