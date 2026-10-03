Option Strict On
Option Explicit On

Imports System.Web.Optimization
Imports System.Web.Routing

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Application("ActiveUsers") = 0
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        Session("SessionStarted") = DateTime.Now
        Application.Lock()
        Try
            Dim current As Integer = 0
            If Application("ActiveUsers") IsNot Nothing Then
                current = CInt(Application("ActiveUsers"))
            End If
            Application("ActiveUsers") = current + 1
        Finally
            Application.UnLock()
        End Try
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        Application.Lock()
        Try
            Dim current As Integer = 0
            If Application("ActiveUsers") IsNot Nothing Then
                current = CInt(Application("ActiveUsers"))
            End If
            current = current - 1
            If current < 0 Then
                current = 0
            End If
            Application("ActiveUsers") = current
        Finally
            Application.UnLock()
        End Try
    End Sub

End Class
