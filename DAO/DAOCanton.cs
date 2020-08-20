using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOCanton
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);
        public DataTable findCanton(int idP)
        {
            DataTable tbl = new DataTable();
            SqlDataReader reader;
            String query = "SELECT *  FROM Cantons WHERE ProvinceId = @idP";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@idP", idP);

            tbl.Columns.Add("Id");
            tbl.Columns.Add("ProvinceId");
            tbl.Columns.Add("CantonName");
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    tbl.Rows.Add(Convert.ToString(reader.GetInt32(0)), reader.GetInt32(1), reader.GetString(2));



                }
            }
            conn.Close();
            return tbl;

        }
    }
}


