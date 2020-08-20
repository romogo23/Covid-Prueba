<Serializable()>
Public Class Province

    Public Property ProvinceId As Integer

    Public Property ProvinceName As String

    Public Sub New()
    End Sub

    Public Sub New(provinceName As String)
        Me.ProvinceName = ProvinceId
    End Sub
End Class
