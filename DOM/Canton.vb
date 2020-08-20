<Serializable()>
Public Class Canton

    Public Property CantonId As Integer

    Public Property IdProvince As Integer

    Public Property CantonName As String

    Public Sub New()
    End Sub

    Public Sub New(provinceId As Integer, cantonName As String)
        Me.IdProvince = provinceId
        Me.CantonName = cantonName
    End Sub
End Class
