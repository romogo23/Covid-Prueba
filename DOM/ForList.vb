<Serializable()>
Public Class ForList

    Public Property Link As String

    Public Property List As List(Of DailyRecord)

    Public Sub New()
    End Sub

    Public Sub New(link As String, list As List(Of DailyRecord))
        Me.Link = link
        Me.List = list
    End Sub

End Class
