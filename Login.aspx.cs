using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyekPBO_CRUD
{
		// ----------- Login User ------------
    public partial class Login : System.Web.UI.Page
    {
		// ------------ LOGIN -------------
		protected void btnLogin_Click(object sender, EventArgs e)
		{
			try /* Select After Validations*/
			{
				using (NpgsqlConnection connection = new NpgsqlConnection("Server = localhost; Port = 5432; Database = ferry; User Id = postgres; Password=qwerty"))
				{
					//connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
					connection.Open();
					NpgsqlCommand cmd = new NpgsqlCommand();
					cmd.Connection = connection;
					cmd.CommandText = "Select username, password from users where username =@username and password=@password";
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.Add(new NpgsqlParameter("@username", txtusername.Text));
					cmd.Parameters.Add(new NpgsqlParameter("@password", txtpassword.Text));
					NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);
					if (dt.Rows.Count > 0)
					{
						Response.Redirect("Home.aspx");
					}
					else
					{
						ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
					}
				}
			}
			catch (Exception ex) { }
		}
	}

		// ----------- Login Admin ------------
	public partial class Login : System.Web.UI.Page
	{
		// ------------ LOGIN  -------------
		protected void btnAdminLogin_Click(object sender, EventArgs e)
		{
			try /* Select After Validations*/
			{
				using (NpgsqlConnection connection = new NpgsqlConnection("Server = localhost; Port = 5432; Database = ferry; User Id = postgres; Password=qwerty"))
				{
					//connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
					connection.Open();
					NpgsqlCommand cmd = new NpgsqlCommand();
					cmd.Connection = connection;
					cmd.CommandText = "Select username, password from admin where username =@username and password=@password";
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.Add(new NpgsqlParameter("@username", txtusername.Text));
					cmd.Parameters.Add(new NpgsqlParameter("@password", txtpassword.Text));
					NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);
					if (dt.Rows.Count > 0)
					{
						Response.Redirect("HomeAdmin.aspx");
					}
					else
					{
						ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
					}
				}
			}
			catch (Exception ex) { }
		}
	}
	
		// ----------- Regis ------------
	public partial class Login : System.Web.UI.Page
	{
		// ------------ LOGIN  -------------
		protected void btnRegis_Click(object sender, EventArgs e)
		{
			Response.Redirect("Regis.aspx");
		}
		// ----------- Login Admin ------------
	}
}