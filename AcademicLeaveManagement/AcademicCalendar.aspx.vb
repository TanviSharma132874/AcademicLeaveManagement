Option Strict On
Option Explicit On

Imports System.Globalization

Public Class AcademicCalendar
    Inherits System.Web.UI.Page

    Private Shared ReadOnly Holidays As Dictionary(Of String, String) = BuildHolidays()

    Private Shared Function BuildHolidays() As Dictionary(Of String, String)
        Dim d As New Dictionary(Of String, String)()
        d("01-26") = "Republic Day"
        d("03-04") = "Holi"
        d("03-15") = "Mid-Term Exam"
        d("04-10") = "Annual Day"
        d("05-01") = "Final Exams"
        d("08-15") = "Independence Day"
        d("10-02") = "Gandhi Jayanti"
        Return d
    End Function

    Private Shared Function DayKey(ByVal value As Date) As String
        Return value.ToString("MM-dd", CultureInfo.InvariantCulture)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("Username") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        If Not IsPostBack Then
            blDetails.Items.Add("Select a date on the calendar to see details.")
        End If
    End Sub

    Protected Sub calAcademic_DayRender(ByVal sender As Object, ByVal e As DayRenderEventArgs) Handles calAcademic.DayRender
        If e.Day.IsOtherMonth Then
            Return
        End If

        Dim eventName As String = Nothing
        If Holidays.TryGetValue(DayKey(e.Day.Date), eventName) Then
            e.Cell.BackColor = System.Drawing.Color.Red
            e.Cell.ForeColor = System.Drawing.Color.White
            e.Cell.Font.Bold = True
            e.Cell.ToolTip = eventName
        End If
    End Sub

    Protected Sub calAcademic_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles calAcademic.SelectionChanged
        Dim selected As Date = calAcademic.SelectedDate
        Dim eventName As String = Nothing

        blDetails.Items.Clear()
        blDetails.Items.Add("Date: " & selected.ToString("dd-MMM-yyyy"))
        blDetails.Items.Add("Day: " & selected.DayOfWeek.ToString())

        If Holidays.TryGetValue(DayKey(selected), eventName) Then
            blDetails.Items.Add("Event: " & eventName)
        Else
            blDetails.Items.Add("Event: No event scheduled")
        End If
    End Sub

End Class
