using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace SportIsLife
{
    public static class MainFunc
    {
        public static Exception DeleteSportMen(int ID, string St)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(St);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Delete SportsMen Where id =" + ID.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
        public static Exception DeleteSportClub(int ID, string St)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(St);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Delete SportClub Where id =" + ID.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
        public static int CountSportClub(int ID, string St)
        {
            int count = 0;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(St);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select Count(*) From SportsMen Where SportClub =" + ID.ToString();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    count = Int32.Parse(rd.GetValue(0).ToString());
                }
            }
            catch
            {
                return count;
            }
            finally
            {
                connection.Close();
            }
            return count;
        }
    }
}
