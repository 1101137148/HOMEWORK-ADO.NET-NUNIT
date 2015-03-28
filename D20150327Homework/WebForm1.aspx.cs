using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Age;

namespace D20150327Homework
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            searchButton_Click(null,null);
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HOMEWORKConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    //cmd.CommandText = "select * from Student where Name like @name";

                    cmd.CommandText = "SELECT ID, Name, Class, FORMAT(Birthday,'yyyy/MM/dd') AS Birthday, Phone FROM Student where Name like @name;";

                    cmd.Parameters.Add(new SqlParameter("@name", "%" + searchTextBox.Text + "%"));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        
                        dr.Close();

                        //add age column and calculate age
                        dt.Columns.Add("Age", typeof(System.Int32));
                        Calculate cal = new Calculate();
                        foreach (DataRow data in dt.Rows)
                        {
                            int age = cal.getAge(Convert.ToDateTime(data["Birthday"]));
                            data["Age"] = age;
                        }

                        resultGridView.DataSource = dt;
                        resultGridView.DataBind();
                    }
                }
            }
        }

        protected void insertButton_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO [dbo].[Student]([ID],[Name],[Class],[Birthday],[Phone])
                            VALUES (@ID,@Name,@Class,@Birthday,@Phone);SELECT CAST(scope_identity() AS int);";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HOMEWORKConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@ID",insertIDTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Name",insertNameTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Class",insertClassTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Birthday",insertBirthdayTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Phone",insertPhoneTextBox.Text));

                    insertIDTextBox.Text = cmd.ExecuteScalar().ToString();
                }
                searchButton_Click(null,null);
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string sql = @"update [dbo].[Student] set [Name] = @Name, [Class] = @Class, [Birthday] = @Birthday, [Phone] = @Phone
                             where ID = @ID";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HOMEWORKConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@ID", updateIDTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Name", updateNameTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Class", updateClassTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Birthday", updateBirthdayTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Phone", updatePhoneTextBox.Text));

                    cmd.ExecuteNonQuery();
                }
                searchButton_Click(null, null);
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string sql = @"DELETE FROM [dbo].[Student]
                             WHERE ID = @ID";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HOMEWORKConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@ID", deleteIDTextBox.Text));
                    
                    cmd.ExecuteNonQuery();
                }
                searchButton_Click(null, null);
            }
        }

        protected void updateIDTextBox_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HOMEWORKConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from Student where ID = @ID";
                    cmd.Parameters.Add(new SqlParameter("@ID", updateIDTextBox.Text));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            updateNameTextBox.Text = dr.GetString(1);
                            updateClassTextBox.Text = dr.GetString(2);
                            updateBirthdayTextBox.Text = dr.GetDateTime(3).ToString("yyyy/MM/dd");
                            updatePhoneTextBox.Text = dr.GetString(4);
                            
                            updateNameTextBox.Enabled = true;
                            updateClassTextBox.Enabled = true;
                            updateBirthdayTextBox.Enabled = true;
                            updatePhoneTextBox.Enabled = true;

                            updateButton.Enabled = true;
                        }
                        else
                        {
                            updateNameTextBox.Enabled = false;
                            updateClassTextBox.Enabled = false;
                            updateBirthdayTextBox.Enabled = false;
                            updatePhoneTextBox.Enabled = false;

                            updateButton.Enabled = false;

                            updateNameTextBox.Text = "";
                            updateClassTextBox.Text = "";
                            updateBirthdayTextBox.Text = "";
                            updatePhoneTextBox.Text = "";
                        }
                        dr.Close();
                    }
                }
            }
        }

        /*
        protected void deleteIDTextBox_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HOMEWORKConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from Student where ID = @ID";
                    cmd.Parameters.Add(new SqlParameter("@ID", deleteIDTextBox.Text));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            deleteButton.Enabled = true;
                        }
                        else
                        {
                            deleteButton.Enabled = false;
                        }
                        dr.Close();
                    }
                }
            }
        }*/

    }
}