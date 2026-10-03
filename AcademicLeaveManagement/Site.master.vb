Option Strict On
Option Explicit On

Public Class SiteMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim loggedIn As Boolean = (Session("Username") IsNot Nothing)

        pnlUser.Visible = loggedIn
        pnlNav.Visible = loggedIn

        If loggedIn Then
            lblWelcome.Text = "Welcome, " & HttpUtility.HtmlEncode(CStr(Session("Username"))) &
                              " (" & HttpUtility.HtmlEncode(CStr(Session("Role"))) & ")"
        End If

        Dim active As Object = Application("ActiveUsers")
        If active Is Nothing Then
            lblActiveUsers.Text = "0"
        Else
            lblActiveUsers.Text = active.ToString()
        End If
    End Sub

End Class
