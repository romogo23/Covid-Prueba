Imports DAO

Public Class CantonsManager

    Public Function loadCanton(id As Integer) As DataTable
        Dim dao As New DAOCanton()
        Return dao.findCanton(id)

    End Function

    Public Function hola(id As Integer) As DataTable
        Dim dao As New DAOCanton()
        Return dao.findCanton(id)

    End Function

End Class
