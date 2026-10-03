Option Strict On
Option Explicit On

Public Class Dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("Username") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        If Not IsPostBack Then
            Dim userName As String = CStr(Session("Username"))
            Dim role As String = CStr(Session("Role"))

            litWelcome.Text = "Hello, <b>" & Server.HtmlEncode(userName) & "</b> (" & Server.HtmlEncode(role) & ")"

            If Session("LoginTime") IsNot Nothing Then
                Dim loginTime As Date = CDate(Session("LoginTime"))
                lblLoginTime.Text = loginTime.ToString("dd-MMM-yyyy hh:mm:ss tt")
            Else
                lblLoginTime.Text = "-"
            End If

            lblTotalLeaves.Text = GetLeaveCount(userName).ToString()

            gvEvents.DataSource = BuildEvents()
            gvEvents.DataBind()
        End If
    End Sub

    Private Function GetLeaveCount(ByVal userName As String) As Integer
        Dim leaves As List(Of LeaveRecord) = TryCast(Session("Leaves"), List(Of LeaveRecord))
        If leaves Is Nothing Then
            Return 0
        End If
        Return leaves.Where(Function(l) String.Equals(l.Username, userName, StringComparison.OrdinalIgnoreCase)).Count()
    End Function

    Private Shared Function BuildEvents() As DataTable
        Dim y As Integer = Date.Today.Year
        Dim dt As New DataTable("Events")
        dt.Columns.Add("EventName", GetType(String))
        dt.Columns.Add("EventDate", GetType(Date))
        dt.Columns.Add("Category", GetType(String))

        dt.Rows.Add("Mid-Term Exam", New Date(y, 3, 15), "Examination")
        dt.Rows.Add("Annual Day", New Date(y, 4, 10), "Cultural Event")
        dt.Rows.Add("Final Exams", New Date(y, 5, 1), "Examination")
        dt.Rows.Add("Independence Day", New Date(y, 8, 15), "Holiday")
        Return dt
    End Function

End Class
