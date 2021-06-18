using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

//Read() - It is used to read record from the SQL Server database.
//To create a SqlDataReader instance, we must call the ExecuteReader method of the SqlCommand object.
namespace ADO.Net_DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().GetData();
        }

        //create 1 method
        public void GetData()
        {
            //to establish connection with sql server
            SqlConnection con = null;
            //using try ,except ,finally
            try
            {
                con = new SqlConnection("data source=.; database=Employee; integrated security=SSPI");

                //writing sql query
                SqlCommand sc = new SqlCommand("select * from Employee", con);

                //opening connection
                con.Open();

                //apply data reader instance
                SqlDataReader sdr = sc.ExecuteReader();

                //apply while loop for reading
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["name"] + "" + sdr["email"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("failed" + e);
            }
            finally
            {
                con.Close();       //close connection
            }
        }
    }
}
