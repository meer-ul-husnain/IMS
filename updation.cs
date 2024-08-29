using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ims
{
    class updation
    {
        public  void UpdateUser(int id ,string name, string username, string pass, string email, string phoneno, Int16 status)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_updateUsers", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pwd", pass);
                cmd.Parameters.AddWithValue("@phone", phoneno);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@status", status);
                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                MainClass.ShowMSG(name + " updated to system successfully", "Success...", "Success");
                MainClass.con.Close();

            }
            catch (Exception e)
            {

                MainClass.ShowMSG(e.Message, "Error...", "Error");
                MainClass.con.Close();

            }

        }

        public void UpdateCategory(int id, string name, Int16 isActive)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_updateCategory", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                MainClass.con.Open();
                cmd.ExecuteNonQuery();
                int ucheck = cmd.ExecuteNonQuery();
                if (ucheck > 0)
                {
                    MainClass.ShowMSG(name + " Category in system successfully", "Success...", "Success");
                    MainClass.con.Close();
                }
                else
                {
                    MainClass.ShowMSG(" Category not updated", "Error...", "Error");
                    MainClass.con.Close();
                }

                MainClass.con.Close();
            }
            catch (Exception e)
            {
                MainClass.ShowMSG(e.Message, "Error...", "Error");
                MainClass.con.Close();

            }

        }

        public void UpdateProduct(int proID, string product, string barcode, float price, int catID, DateTime? expiry = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_updateProducts", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", proID);
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
                MainClass.ShowMSG(product + " Updated to system successfully", "Success...", "Success");
                MainClass.con.Close();
            }
            catch (Exception e)
            {
                MainClass.ShowMSG("Product not updated", "Error...", "Error");
                MainClass.con.Close();

            }

        }


    }
}
