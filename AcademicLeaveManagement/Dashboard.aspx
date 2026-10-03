<%@ Page Title="Dashboard" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" Inherits="AcademicLeaveManagement.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Dashboard</h2>

    <div class="card">
        <p class="welcome"><asp:Literal ID="litWelcome" runat="server" /></p>
        <p>Login time: <asp:Label ID="lblLoginTime" runat="server" /></p>
        <p>Total leaves applied: <asp:Label ID="lblTotalLeaves" runat="server" CssClass="badge" /></p>
    </div>

    <h3>Upcoming Academic Events</h3>
    <asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="False" CssClass="grid" GridLines="None">
        <Columns>
            <asp:BoundField DataField="EventName" HeaderText="Event" />
            <asp:BoundField DataField="EventDate" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
        </Columns>
    </asp:GridView>
</asp:Content>
