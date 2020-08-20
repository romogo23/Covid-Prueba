using DOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAODailyRecord
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);

        public void SaveDailyRecord(List<DailyRecord> list)
        {
            conn.Open();
            foreach (DailyRecord record in list)
            {
                String query = "Insert into DailyRecords(Date,ProvinceID,CantonId,Positive," +
                    "Negative,TotalTested,Recovered,Dead) values" +
                    " (@date,@provinceid,@cantonid,@positive,@negative,@totaltested,@recovered,@dead)";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@date", record.RecordDate);
                comm.Parameters.AddWithValue("@provinceid", record.RecordProvinceId);
                comm.Parameters.AddWithValue("@cantonid", record.RecordCantonId);
                comm.Parameters.AddWithValue("@positive", record.Positive);
                comm.Parameters.AddWithValue("@negative", record.Negative);
                comm.Parameters.AddWithValue("@totaltested", record.TotalTested);
                comm.Parameters.AddWithValue("@recovered", record.Recovered);
                comm.Parameters.AddWithValue("@dead", record.Dead);
                comm.ExecuteNonQuery();

            }
            conn.Close();
        }

        public DataTable findDailyRecords(int cantonid, DateTime since, DateTime until)
        {
            double deathRate = 0.0;
            String deathRatePercentage = "";
            double posRate = 0.0;
            String posRatePercentage = "";
            double recovRate = 0.0;
            String recRatePercentage = "";
            int positive = 0;
            int totaltested = 0;
            int recovered = 0;
            int negative = 0;
            int dead = 0;
            DataTable tbl = new DataTable();
            SqlDataReader reader;
            String query = "SELECT SUM(Positive) AS 'Total Positive', SUM(Negative) AS 'Total Negative', SUM(TotalTested) AS 'Total Tested',SUM(Recovered) AS 'Total Recovered', SUM(Dead) AS 'Total deaths' FROM DailyRecords WHERE CantonId = @cantonid AND Date BETWEEN @sinceDate AND @untilDate";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@cantonid", cantonid);
            comm.Parameters.AddWithValue("@sinceDate", since);
            comm.Parameters.AddWithValue("@untilDate", until);
            tbl.Columns.Add("Total Positive");
            tbl.Columns.Add("Total Discarded");
            tbl.Columns.Add("Total Tested");
            tbl.Columns.Add("Total Recovered");
            tbl.Columns.Add("Total Deaths");
            tbl.Columns.Add("Virus Death Rate");
            tbl.Columns.Add("Positivity Rate");
            tbl.Columns.Add("Recovery Rate");
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("Total Positive")))
                    {
                        positive = reader.GetInt32(0);

                    }
                    else
                    {
                        positive = 0;
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Total deaths")))
                    {
                        dead = reader.GetInt32(4);

                    }
                    else
                    {
                        dead = 0;
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Total Negative")))
                    {
                        negative = reader.GetInt32(1);

                    }
                    else
                    {
                        negative = 0;
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Total Tested")))
                    {
                        totaltested = reader.GetInt32(2);

                    }
                    else
                    {
                        totaltested = 0;
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Total Recovered")))
                    {
                        recovered = reader.GetInt32(3);

                    }
                    else
                    {
                        totaltested = 0;
                    }
                    if (positive == 0)
                    {
                        deathRate = 0;
                    }
                    else
                    {
                        deathRate = Math.Round((double)Decimal.Divide(dead, positive) * 100, 1);


                    }
                    if (totaltested == 0)
                    {
                        posRate = 0;
                    }
                    else
                    {

                        posRate = Math.Round((double)Decimal.Divide(positive, totaltested) * 100, 1);

                    }
                    if (positive == 0)
                    {
                        recovRate = 0;
                    }
                    else
                    {
                        recovRate = Math.Round((double)Decimal.Divide(recovered, positive) * 100, 1);

                    }

                    deathRatePercentage = deathRate + "%";

                    posRatePercentage = posRate + "%";

                    recRatePercentage = recovRate + "%";

                    tbl.Rows.Add(positive, negative, totaltested, recovered, dead, deathRatePercentage, posRatePercentage, recRatePercentage);
                }
            }
            conn.Close();
            return tbl;
        }

        public DataTable allRecords()
        {
            int cont = 0;

            double deathRate = 0.0;
            String deathRatePercentage = "";
            double posRate = 0.0;
            String posRatePercentage = "";
            double recovRate = 0.0;
            String recRatePercentage = "";
            int positive = 0;
            int totaltested = 0;
            int recovered = 0;
            int negative = 0;
            int dead = 0;

            double posSum = 0.0;
            double negSum = 0.0;
            double testSum = 0.0;
            double recSum = 0.0;
            double deadSum = 0.0;
            double porDeadSum = 0.0;
            double porPosSum = 0.0;
            double porRecSum = 0.0;

            double promD = 0.0;
            double promP = 0.0;
            double promR = 0.0;

            DataTable tbl = new DataTable();
            SqlDataReader reader;
            SqlDataReader reader2;
            String query = "SELECT Cantons.CantonName, SUM(Positive) AS 'Total Positive', SUM(Negative) AS 'Total Negatives', SUM(TotalTested) AS 'Total Tested', SUM(Recovered) AS 'Total Recovered', SUM(Dead) AS 'Total Deaths' FROM DailyRecords INNER JOIN Cantons ON DailyRecords.CantonId = Cantons.Id OR DailyRecords.CantonId IS NULL GROUP BY Cantons.CantonName;";
            SqlCommand comm = new SqlCommand(query, conn);
            tbl.Columns.Add("Canton");
            tbl.Columns.Add("Total Positive");
            tbl.Columns.Add("Total Discarded");
            tbl.Columns.Add("Total Tested");
            tbl.Columns.Add("Total Recovered");
            tbl.Columns.Add("Total Deaths");
            tbl.Columns.Add("Virus Death Rate");
            tbl.Columns.Add("Positivity Rate");
            tbl.Columns.Add("Recovery Rate");
            conn.Open();
            reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("Total Positive")))
                    {
                        positive = reader.GetInt32(1);

                    }
                    else
                    {
                        positive = 0;
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Total deaths")))
                    {
                        dead = reader.GetInt32(5);

                    }
                    else
                    {
                        dead = 0;
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Total Negatives")))
                    {
                        negative = reader.GetInt32(2);

                    }
                    else
                    {
                        negative = 0;
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Total Tested")))
                    {
                        totaltested = reader.GetInt32(3);

                    }
                    else
                    {
                        totaltested = 0;
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("Total Recovered")))
                    {
                        recovered = reader.GetInt32(4);

                    }
                    else
                    {
                        totaltested = 0;
                    }
                    if (positive == 0)
                    {
                        deathRate = 0;
                    }
                    else
                    {
                        deathRate = Math.Round((double)Decimal.Divide(dead, positive) * 100, 1);


                    }
                    if (totaltested == 0)
                    {
                        posRate = 0;
                    }
                    else
                    {

                        posRate = Math.Round((double)Decimal.Divide(positive, totaltested) * 100, 1);

                    }
                    if (positive == 0)
                    {
                        recovRate = 0;
                    }
                    else
                    {
                        recovRate = Math.Round((double)Decimal.Divide(recovered, positive) * 100, 1);

                    }

                    deathRatePercentage = deathRate + "%";

                    posRatePercentage = posRate + "%";

                    recRatePercentage = recovRate + "%";

                    cont++;

                    tbl.Rows.Add(reader.GetString(0), positive, negative, totaltested, recovered, dead, deathRatePercentage, posRatePercentage, recRatePercentage);
                    
                    posSum += positive;
                    negSum += negative;
                    testSum += totaltested;
                    recSum += recovered;
                    deadSum += dead;
                    porPosSum += posRate;
                    porDeadSum += deathRate;
                    porRecSum += recovRate;
                }
            }

            conn.Close();



            conn.Open();

            String query2 = "SELECT CantonName FROM Cantons WHERE Id NOT IN(SELECT CantonId FROM  DailyRecords)";
            SqlCommand comm2 = new SqlCommand(query2, conn);
            reader2 = comm2.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    cont++;
                    tbl.Rows.Add(reader2.GetString(0), 0, 0, 0, 0, 0, 0, 0, 0);
                }
            }

            conn.Close();

            String posPercentage = "";
            String deathPercentage = "";
            String recPercentage = "";

            promP = Math.Round((double)Decimal.Divide((Decimal)porPosSum, cont), 1);
            posPercentage = promP + "%";

            promD = Math.Round((double)Decimal.Divide((Decimal)porDeadSum, cont), 1);
            deathPercentage = promD + "%";

            promR = Math.Round((double)Decimal.Divide((Decimal)porRecSum, cont), 1);
            recPercentage = promR + "%";

            tbl.Rows.Add("TOTAL", posSum, negSum, testSum, recSum, deadSum, posPercentage, deathPercentage, recPercentage);

            return tbl;
        }
    }
}
