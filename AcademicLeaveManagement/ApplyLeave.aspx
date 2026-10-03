<%@ Page Title="Apply Leave" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="ApplyLeave.aspx.vb" Inherits="AcademicLeaveManagement.ApplyLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Apply Leave</h2>

    <div class="card narrow">
        <div class="field">
            <asp:Label ID="lblTypeCaption" runat="server" AssociatedControlID="ddlLeaveType" Text="Leave Type" />
            <asp:DropDownList ID="ddlLeaveType" runat="server">
                <asp:ListItem Text="Sick Leave" Value="Sick Leave" />
                <asp:ListItem Text="Casual Leave" Value="Casual Leave" />
                <asp:ListItem Text="Medical Leave" Value="Medical Leave" />
                <asp:ListItem Text="Emergency Leave" Value="Emergency Leave" />
            </asp:DropDownList>
        </div>

        <div class="field">
            <asp:Label ID="lblFromCaption" runat="server" AssociatedControlID="txtFromDate" Text="From Date" />
            <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" />
            <asp:RequiredFieldValidator ID="rfvFrom" runat="server" ControlToValidate="txtFromDate"
                ErrorMessage="From date is required." Display="Dynamic" CssClass="field-error" />
            <asp:CompareValidator ID="cvFromType" runat="server" ControlToValidate="txtFromDate"
                Operator="DataTypeCheck" Type="Date" ErrorMessage="Enter a valid From date."
                Display="Dynamic" CssClass="field-error" />
        </div>

        <div class="field">
            <asp:Label ID="lblToCaption" runat="server" AssociatedControlID="txtToDate" Text="To Date" />
            <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" />
            <asp:RequiredFieldValidator ID="rfvTo" runat="server" ControlToValidate="txtToDate"
                ErrorMessage="To date is required." Display="Dynamic" CssClass="field-error" />
            <asp:CompareValidator ID="cvToType" runat="server" ControlToValidate="txtToDate"
                Operator="DataTypeCheck" Type="Date" ErrorMessage="Enter a valid To date."
                Display="Dynamic" CssClass="field-error" />
            <asp:CompareValidator ID="cvRange" runat="server" ControlToValidate="txtToDate"
                ControlToCompare="txtFromDate" Operator="GreaterThanEqual" Type="Date"
                ErrorMessage="To date must be on or after From date." Display="Dynamic" CssClass="field-error" />
        </div>

        <div class="field">
            <asp:Label ID="lblReasonCaption" runat="server" AssociatedControlID="txtReason" Text="Reason" />
            <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="4" MaxLength="500" />
            <asp:RequiredFieldValidator ID="rfvReason" runat="server" ControlToValidate="txtReason"
                ErrorMessage="Reason is required." Display="Dynamic" CssClass="field-error" />
        </div>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit Leave Request" CssClass="btn" />
        <asp:Label ID="lblMessage" runat="server" CssClass="msg" EnableViewState="false" />
    </div>
</asp:Content>
