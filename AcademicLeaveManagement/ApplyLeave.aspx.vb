Option Strict On
Option Explicit On

Imports System.Globalization

Public Class ApplyLeave
    Inherits System.Web.UI.Page

    Private Shared ReadOnly DateFormats() As String = {"yyyy-MM-dd", "dd-MMM-yyyy", "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy"}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("Username") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If Not Page.IsValid Then
            Return
        End If

        Dim fromDate As Date
        Dim toDate As Date

        If Not TryParseDate(txtFromDate.Text, fromDate) OrElse Not TryParseDate(txtToDate.Text, toDate) Then
            ShowMessage("Please enter valid dates.", True)
            Return
        End If

        If toDate < fromDate Then
            ShowMessage("To date must be on or after From date.", True)
            Return
        End If

        Dim reason As String = txtReason.Text.Trim()
        If reason.Length = 0 Then
            ShowMessage("Reason is required.", True)
            Return
        End If

        Dim leaves As List(Of LeaveRecord) = TryCast(Session("Leaves"), List(Of LeaveRecord))
        If leaves Is Nothing Then
            leaves = New List(Of LeaveRecord)()
            Session("Leaves") = leaves
        End If

        Dim nextId As Integer = 1
        If leaves.Count > 0 Then
            nextId = leaves.Max(Function(l) l.Id) + 1
        End If

        Dim record As New LeaveRecord()
        record.Id = nextId
        record.Username = CStr(Session("Username"))
        record.LeaveType = ddlLeaveType.SelectedValue
        record.FromDate = fromDate
        record.ToDate = toDate
        record.Reason = reason
        record.Status = "Pending"
        leaves.Add(record)

        txtFromDate.Text = String.Empty
        txtToDate.Text = String.Empty
        txtReason.Text = String.Empty
        ddlLeaveType.SelectedIndex = 0

        ShowMessage("Leave request #" & nextId.ToString() & " submitted successfully.", False)
    End Sub

    Private Sub ShowMessage(ByVal text As String, ByVal isError As Boolean)
        lblMessage.Text = text
        If isError Then
            lblMessage.CssClass = "msg error"
        Else
            lblMessage.CssClass = "msg success"
        End If
    End Sub

    Private Shared Function TryParseDate(ByVal text As String, ByRef result As Date) As Boolean
        Return Date.TryParseExact(text.Trim(), DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, result)
    End Function

End Class
