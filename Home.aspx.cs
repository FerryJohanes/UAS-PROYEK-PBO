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
    public partial class Home : System.Web.UI.Page
    {
        protected void btnPesan_Click(object sender, EventArgs e)
        {
            try /* Updation After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server = localhost; Port = 5432; Database = ferry; User Id = postgres; Password = qwerty"))
                {
                    //connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "update kamar set status='Dipesan - Ferry' where no_kamar=@no_kamar";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@no_kamar", Convert.ToInt32(txtNo_kamar.Text)));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtNo_kamar.Text = "";
			        Response.Redirect("Home.aspx");
                }
            }
            catch (Exception ex) { }
        }
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
                using (NpgsqlCommand cmd = new NpgsqlCommand($"SELECT no_kamar AS Nomor_Kamar, keterangan, biaya, status FROM kamar", connection))
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
    }
}