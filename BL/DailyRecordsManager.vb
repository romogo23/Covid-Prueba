Imports DAO
Imports DOM

Public Class DailyRecordsManager

    Public Sub insertDailyRecords(list As List(Of DailyRecord))
        Dim dao As New DAODailyRecord
        dao.SaveDailyRecord(list)
    End Sub

    Public Function findDailyRecord(cantonId As Integer, since As DateTime, until As DateTime) As DataTable
        Dim dao As New DAODailyRecord
        Return dao.findDailyRecords(cantonId, since, until)
    End Function

    Public Function allRecords() As DataTable
        Dim dao As New DAODailyRecord
        Return dao.allRecords()
    End Function

End Class
