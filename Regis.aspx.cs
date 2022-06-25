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

namespace ProyekPBO_CRUD
{
	public partial class Regis : System.Web.UI.Page
	{
		// -----------  INSERT ------------
		protected void btnRegistrasi_Click(object sender, EventArgs e)
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
					cmd.CommandText = "Insert into users values(@username,@password,@name,@no_telp)";
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.Add(new NpgsqlParameter("@username", txtUsername.Text));
					cmd.Parameters.Add(new NpgsqlParameter("@password", txtPassword.Text));
					cmd.Parameters.Add(new NpgsqlParameter("@name", txtNama.Text));
					cmd.Parameters.Add(new NpgsqlParameter("@no_telp", Convert.ToInt32(txtNoTelp.Text)));
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					connection.Close();
					txtUsername.Text = "";
					txtPassword.Text = "";
					txtNama.Text = "";
					txtNoTelp.Text = "";
					ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Pendaftaran berhasil!')</script>");
					Response.Redirect("Login.aspx");
				}
			}
			catch (Exception ex) { }
		}
	}
}