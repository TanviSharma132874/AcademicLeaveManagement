Option Strict On
Option Explicit On

Imports System.Web.Security

Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        FormsAuthentication.SignOut()
        Session.Clear()
        Session.Abandon()

        Dim sessionCookie As New HttpCookie("ASP.NET_SessionId", String.Empty)
        sessionCookie.Expires = DateTime.Now.AddYears(-1)
        Response.Cookies.Add(sessionCookie)

        Response.Redirect("~/Login.aspx")
    End Sub

End Class
