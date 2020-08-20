<Serializable()>
Public Class DailyRecord

    Public Property Id As Integer

    Public Property RecordDate As String

    Public Property RecordProvinceId As Integer

    Public Property RecordCantonId As Integer

    Public Property Positive As Integer

    Public Property Negative As Integer

    Public Property TotalTested As Integer

    Public Property Recovered As Integer

    Public Property Dead As Integer

    Public Sub New()
    End Sub

    Public Sub New(recordDate As String, provinceId As Integer, cantonId As Integer, positive As Integer, negative As Integer, totalTested As Integer, recovered As Integer, dead As Integer)
        Me.RecordDate = recordDate
        Me.RecordProvinceId = provinceId
        Me.RecordCantonId = cantonId
        Me.Positive = positive
        Me.Negative = negative
        Me.TotalTested = totalTested
        Me.Recovered = recovered
        Me.Dead = dead
    End Sub
End Class
