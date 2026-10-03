<%@ Page Title="Academic Calendar" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="AcademicCalendar.aspx.vb" Inherits="AcademicLeaveManagement.AcademicCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Academic Calendar</h2>
    <p><span class="legend-box"></span> Holiday / academic event (hover for details)</p>

    <div class="two-col">
        <asp:Calendar ID="calAcademic" runat="server" CssClass="calendar" ShowGridLines="True"
            BorderColor="#9aa5b1" CellPadding="6" DayNameFormat="Short" FirstDayOfWeek="Monday"
            NextPrevFormat="ShortMonth">
            <TitleStyle BackColor="#1f3a5f" ForeColor="White" Font-Bold="True" />
            <DayHeaderStyle BackColor="#e9eef5" />
            <SelectedDayStyle BackColor="#2e7d32" ForeColor="White" />
            <TodayDayStyle BackColor="#fff3cd" />
            <OtherMonthDayStyle ForeColor="#9aa5b1" />
        </asp:Calendar>

        <div class="card">
            <h3>Selected date</h3>
            <asp:BulletedList ID="blDetails" runat="server" BulletStyle="Disc" DisplayMode="Text" />
        </div>
    </div>
</asp:Content>
