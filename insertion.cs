using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ims
{
    class insertion
    {
        public void InsertNewUser(string name, string username, string pass, string email, string phoneno,Int16 status)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_insertUsers", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pwd", pass);
                cmd.Parameters.AddWithValue("@phone", phoneno);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@status", status);


                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                MainClass.ShowMSG(name + " added to system successfully", "Success...", "Success");
                MainClass.con.Close();

            }
            catch (Exception e)
            {

                MainClass.ShowMSG(e.Message, "Error...", "Error");
                MainClass.con.Close();

            }

        }

        public void InsertNewCategory(string name, int isActive)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_insertCategory", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                MainClass.ShowMSG(name + " added to system successfully", "Success...", "Success");
                MainClass.con.Close();

            }
            catch (Exception e)
            {

                MainClass.ShowMSG(e.Message, "Error...", "Error");
                MainClass.con.Close();

            }

        }

        public  void InsertNewProduct(string product, string barcode, float price, int catID, DateTime? expiry = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_productInsert", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", product);
                cmd.Parameters.AddWithValue("@barcode", barcode);
                cmd.Parameters.AddWithValue("@price", price);
                if (expiry == null)
                {
                    cmd.Parameters.AddWithValue("@expiry", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@expiry", expiry);
                }
                cmd.Parameters.AddWithValue("@catID", catID);
                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                MainClass.ShowMSG(product + " added to system successfully", "Success...", "Success");
                MainClass.con.Close();
            }
            catch (Exception e)
            {
                MainClass.ShowMSG(e.Message, "Error...", "Error");
                MainClass.con.Close();

            }

        }
    }
}
