Option Strict On
Option Explicit On

Imports System.Web.Routing

Public Module RouteConfig

    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.Ignore("{resource}.axd/{*pathInfo}")
    End Sub

End Module
