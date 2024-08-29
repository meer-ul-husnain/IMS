using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ims
{
    class retrieval
    {
        public void showUsers(DataGridView gv, DataGridViewColumn userIDGV, DataGridViewColumn nameGV, DataGridViewColumn usernameGV, DataGridViewColumn passGV,  DataGridViewColumn emailGV, DataGridViewColumn phoneGV, DataGridViewColumn statusGV,string data = null)
        {
            try
            {
                SqlCommand cmd;
                if (data == null)
                {
                     cmd = new SqlCommand("st_getUsersData", MainClass.con);
                }
                else
                {
                     cmd = new SqlCommand("st_getUsersDataLIKE", MainClass.con);
                     cmd.Parameters.AddWithValue("@data",data);
                }
                
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                userIDGV.DataPropertyName = dt.Columns["ID"].ToString();
                nameGV.DataPropertyName = dt.Columns["Name"].ToString();
                usernameGV.DataPropertyName = dt.Columns["Username"].ToString();
                passGV.DataPropertyName = dt.Columns["Password"].ToString();
                phoneGV.DataPropertyName = dt.Columns["Phone"].ToString();
                emailGV.DataPropertyName = dt.Columns["Email"].ToString();
                statusGV.DataPropertyName = dt.Columns["Status"].ToString();

                gv.DataSource = dt;

            }
            catch (Exception )
            {


            }

    
        }

        public void showCategories(DataGridView gv, DataGridViewColumn catIDGV, DataGridViewColumn CatNameGV, DataGridViewColumn statGV)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_getCategoriesData", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                catIDGV.DataPropertyName = dt.Columns["ID"].ToString();
                CatNameGV.DataPropertyName = dt.Columns["Category"].ToString();
                statGV.DataPropertyName = dt.Columns["Status"].ToString();
                gv.DataSource = dt;

                MainClass.con.Open();
                MainClass.con.Close();

            }
            catch (Exception e)
            {
                MainClass.ShowMSG(e + "Unable To Show Data ", "ERROR", "ERORR");
                MainClass.con.Close();

            }

        }

        public void getCategoriesList(string proc, ComboBox cb, string displayMember, string valueMembar)
        {
            try
            {
                cb.Items.Clear();
                cb.DataSource = null;

                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "Select ... " };
                dt.Rows.InsertAt(dr, 0);
                cb.DisplayMember = displayMember;
                cb.ValueMember = valueMembar;
                cb.DataSource = dt;
            }
            catch (Exception e)
            {
                MainClass.ShowMSG(e + "Unable To Show Data ", "ERROR", "ERORR");
                MainClass.con.Close();
            }
        }

        public void getAllProducts(DataGridView gv, DataGridViewColumn proidGV, DataGridViewColumn pronameGV, DataGridViewColumn expiryGV, DataGridViewColumn priceGV, DataGridViewColumn catGV, DataGridViewColumn barcodeGV, DataGridViewColumn catidGV)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_getProductsData", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                proidGV.DataPropertyName = dt.Columns["Product ID"].ToString();
                pronameGV.DataPropertyName = dt.Columns["Product"].ToString();
                expiryGV.DataPropertyName = dt.Columns["Expiry"].ToString();
                priceGV.DataPropertyName = dt.Columns["Price"].ToString();
                barcodeGV.DataPropertyName = dt.Columns["Barcode"].ToString();
                catGV.DataPropertyName = dt.Columns["Category"].ToString();
                catidGV.DataPropertyName = dt.Columns["Category ID"].ToString();
                gv.DataSource = dt;



                MainClass.con.Open();
                MainClass.con.Close();

            }
            catch (Exception e)
            {
                MainClass.con.Close();
            }
        }

        public static int USER_ID
        {
            get;
            private set;
        }

        public static string EMP_NAME
        {
            get;
            private set;
        }

        private static string user_name = null, pass_word = null;
        private static bool checkLogin;
        public static bool getuserDetails(string username , string password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("st_getUserDetails", MainClass.con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);


                MainClass.con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    checkLogin = true;
                    while (dr.Read())
                    {
                        USER_ID = Convert.ToInt32(dr["ID"].ToString());
                        EMP_NAME = dr["NAME"].ToString();
                        user_name = dr["username"].ToString();
                        pass_word = dr["Password"].ToString();

                    }
                }
                else
                {
                    checkLogin = false;
                    if(username != null && password != null)
                    {
                        if(username != null && password != null)
                        {
                            MainClass.ShowMSG("Invalid Username" , "Error" , "Error");
                        }
                        else if (user_name == username && pass_word != password)
                        {
                            MainClass.ShowMSG("Invalid Username", "Error", "Error");
                        }
                        else if (user_name != username && pass_word != password)
                        {
                            MainClass.ShowMSG("Invalid Username", "Error", "Error");
                        }
                    }
                }
                MainClass.con.Close();
            }
            catch (Exception)
            {
                MainClass.con.Close();
                MainClass.ShowMSG("Unable to login ...", "Error", "Error");
            }

            return checkLogin;
        }

    }
}
