Option Strict On
Option Explicit On

Imports System.Web.Optimization

Public Module BundleConfig

    Public Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New StyleBundle("~/Content/css").Include("~/Content/Site.css"))
        bundles.Add(New ScriptBundle("~/bundles/site").Include("~/Scripts/site.js"))
    End Sub

End Module
