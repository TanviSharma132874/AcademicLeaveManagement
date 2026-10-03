Option Strict On
Option Explicit On

<Serializable()>
Public Class LeaveRecord

    Public Property Id As Integer
    Public Property Username As String
    Public Property LeaveType As String
    Public Property FromDate As Date
    Public Property ToDate As Date
    Public Property Reason As String
    Public Property Status As String

    Public Sub New()
        Status = "Pending"
    End Sub

End Class
