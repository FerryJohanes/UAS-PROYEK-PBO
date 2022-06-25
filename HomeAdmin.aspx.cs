using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Data.SqlClient;
using System.Text;

namespace ProyekPBO_CRUD
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                DataTable dt = this.GetData();

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.
                html.Append("<table id=datatablesSimple>");

                //Building the Header row.
                html.Append("<thead>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</thead>");

                html.Append("<tbody>");
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");

                    }
                    html.Append("</tr>");
                }
                html.Append("</tbody>");

                //Table end.
                html.Append("</table>");

                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }
        private DataTable GetData()
        {
            //NpgsqlDataReader dr;
            using (NpgsqlConnection connection = new NpgsqlConnection("Server = localhost; Port = 5432; Database = ferry; User Id = postgres; Password=qwerty"))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand($"SELECT no_kamar AS Nomor_Kamar, keterangan, biaya, status FROM kamar ORDER BY no_kamar ASC", connection))
                {
                    using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter())
                    {
                        cmd.Connection = connection;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        // -----------  INSERT ------------
        protected void btnInsertion_Click(object sender, EventArgs e)
        {
            try
            {
                /* Insertion After Validations*/
                using (NpgsqlConnection connection = new NpgsqlConnection("Server = localhost; Port = 5432; Database = ferry; User Id = postgres; Password=qwerty"))
                {
                    //connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into kamar values(@NO_KAMAR,@KETERANGAN,@BIAYA,@STATUS)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@NO_KAMAR", Convert.ToInt32(txtNo_kamar.Text)));
                    cmd.Parameters.Add(new NpgsqlParameter("@KETERANGAN", txtKeterangan.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@BIAYA", Convert.ToInt32(txtBiaya.Text)));
                    cmd.Parameters.Add(new NpgsqlParameter("@STATUS", txtStatus.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtNo_kamar.Text = "";
                    txtKeterangan.Text = "";
                    txtBiaya.Text = "";
                    txtStatus.Text = "";
                    lblmsg.Text = "Data Has been Saved";
                    Response.Redirect("HomeAdmin.aspx");
                }
            }
            catch (Exception ex) { }
        }
        //UPDATE
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try /* Updation After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server = localhost; Port = 5432; Database = ferry; User Id = postgres; Password = qwerty"))
                {
                    //connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "update kamar set keterangan=@misc,biaya=@cost,status=@stats where no_kamar=@room_num";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@room_num", Convert.ToInt32(txtNo_kamar.Text)));
                    cmd.Parameters.Add(new NpgsqlParameter("@misc", txtKeterangan.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@cost", Convert.ToInt32(txtBiaya.Text)));
                    cmd.Parameters.Add(new NpgsqlParameter("@stats", txtStatus.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtNo_kamar.Text = "";
                    txtKeterangan.Text = "";
                    txtBiaya.Text = "";
                    txtStatus.Text = "";
                    lblmsg.Text = "Data Has been Updated";
                    Response.Redirect("HomeAdmin.aspx");

                }
            }
            catch (Exception ex) { }
        }
        // -----------  DELETE ------------
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try /* Deletion After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server = localhost; Port = 5432; Database = ferry; User Id = postgres; Password=qwerty"))
                {
                    //connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Delete from kamar where no_kamar=@No_kamar";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@No_kamar", Convert.ToInt32(txtDelNo_kamar.Text)));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtDelNo_kamar.Text = "";
                    lblmessage1.Text = "Data Has been Deleted";
			        Response.Redirect("HomeAdmin.aspx");   
                }
            }
            catch (Exception ex) { }
        }
    }
}