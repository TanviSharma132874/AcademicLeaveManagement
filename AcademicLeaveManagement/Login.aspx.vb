Option Strict On
Option Explicit On

Imports System.Web.Security

Public Class Login
    Inherits System.Web.UI.Page

    Private Const RememberCookieName As String = "LastUser"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim lastUser As HttpCookie = Request.Cookies(RememberCookieName)
            If lastUser IsNot Nothing AndAlso Not String.IsNullOrEmpty(lastUser.Value) Then
                txtUsername.Text = lastUser.Value
                chkRemember.Checked = True
            End If
        End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        If Not Page.IsValid Then
            Return
        End If

        Dim userName As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text
        Dim role As String = String.Empty

        If Not ValidateCredentials(userName, password, role) Then
            lblMessage.Text = "Invalid username or password."
            Return
        End If

        Dim canonicalName As String = userName.ToLowerInvariant()

        ' Session
        Session("Username") = canonicalName
        Session("Role") = role
        Session("LoginTime") = DateTime.Now
        If Session("Leaves") Is Nothing Then
            Session("Leaves") = New List(Of LeaveRecord)()
        End If

        ' Cookie (remember me)
        If chkRemember.Checked Then
            Dim rememberCookie As New HttpCookie(RememberCookieName, canonicalName)
            rememberCookie.Expires = DateTime.Now.AddDays(15)
            rememberCookie.HttpOnly = True
            Response.Cookies.Add(rememberCookie)
        ElseIf Request.Cookies(RememberCookieName) IsNot Nothing Then
            Dim expiredCookie As New HttpCookie(RememberCookieName, String.Empty)
            expiredCookie.Expires = DateTime.Now.AddDays(-1)
            Response.Cookies.Add(expiredCookie)
        End If

        FormsAuthentication.SetAuthCookie(canonicalName, False)
        Response.Redirect("~/Dashboard.aspx")
    End Sub

    Private Shared Function ValidateCredentials(ByVal userName As String, ByVal password As String, ByRef role As String) As Boolean
        If String.Equals(userName, "admin", StringComparison.OrdinalIgnoreCase) _
           AndAlso String.Equals(password, "admin123", StringComparison.Ordinal) Then
            role = "Admin"
            Return True
        End If

        If String.Equals(userName, "student", StringComparison.OrdinalIgnoreCase) _
           AndAlso String.Equals(password, "stud123", StringComparison.Ordinal) Then
            role = "Student"
            Return True
        End If

        Return False
    End Function

End Class
