<%@ Page Title="My Leaves" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="ViewLeaves.aspx.vb" Inherits="AcademicLeaveManagement.ViewLeaves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>My Leaves</h2>
    <asp:Label ID="lblInfo" runat="server" CssClass="msg" EnableViewState="false" />

    <asp:GridView ID="gvLeaves" runat="server" AutoGenerateColumns="False" CssClass="grid" GridLines="None"
        DataKeyNames="Id" EmptyDataText="You have not applied for any leave yet.">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
            <asp:BoundField DataField="FromDate" HeaderText="From Date" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" />
            <asp:BoundField DataField="ToDate" HeaderText="To Date" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" />
            <asp:BoundField DataField="Reason" HeaderText="Reason" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="CancelLeave"
                        CommandArgument='<%# Eval("Id") %>' CausesValidation="False"
                        Visible='<%# CStr(Eval("Status")) <> "Cancelled" %>'
                        OnClientClick="return confirm('Cancel this leave request?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
