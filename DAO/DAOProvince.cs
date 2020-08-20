using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOProvince
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);
        
        public DataTable findProvince()
        {
            DataTable tbl = new DataTable();
            SqlDataReader reader;
            String query = "SELECT *  FROM Provinces";
            SqlCommand comm = new SqlCommand(query, conn);
          
            tbl.Columns.Add("Id");
            tbl.Columns.Add("ProvinceName");
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    tbl.Rows.Add(Convert.ToString(reader.GetInt32(0)), reader.GetString(1));



                }
            }
            conn.Close();
            return tbl;

        }

    }
}
