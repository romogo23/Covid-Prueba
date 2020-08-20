Imports DAO


Public Class ProvincesManager

    Public Function loadProvinces() As DataTable
        Dim dao As New DAOProvince()
        Return dao.findProvince()
    End Function


End Class
