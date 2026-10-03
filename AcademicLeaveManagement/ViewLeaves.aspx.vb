Option Strict On
Option Explicit On

Public Class ViewLeaves
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("Username") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        If Not IsPostBack Then
            BindLeaves()
        End If
    End Sub

    Protected Sub gvLeaves_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvLeaves.RowCommand
        If e.CommandName <> "CancelLeave" Then
            Return
        End If

        Dim leaveId As Integer = Convert.ToInt32(e.CommandArgument)
        Dim userName As String = CStr(Session("Username"))
        Dim leaves As List(Of LeaveRecord) = TryCast(Session("Leaves"), List(Of LeaveRecord))

        If leaves IsNot Nothing Then
            For Each record As LeaveRecord In leaves
                If record.Id = leaveId AndAlso String.Equals(record.Username, userName, StringComparison.OrdinalIgnoreCase) Then
                    record.Status = "Cancelled"
                    lblInfo.Text = "Leave #" & leaveId.ToString() & " has been cancelled."
                    lblInfo.CssClass = "msg success"
                    Exit For
                End If
            Next
        End If

        BindLeaves()
    End Sub

    Private Sub BindLeaves()
        Dim userName As String = CStr(Session("Username"))
        Dim allLeaves As List(Of LeaveRecord) = TryCast(Session("Leaves"), List(Of LeaveRecord))
        Dim mine As New List(Of LeaveRecord)()

        If allLeaves IsNot Nothing Then
            mine = allLeaves _
                .Where(Function(l) String.Equals(l.Username, userName, StringComparison.OrdinalIgnoreCase)) _
                .OrderBy(Function(l) l.Id) _
                .ToList()
        End If

        gvLeaves.DataSource = mine
        gvLeaves.DataBind()
    End Sub

End Class
