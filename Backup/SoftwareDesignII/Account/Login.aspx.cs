using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftwareDesignII.Account
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
		}

		protected void LoginButton_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);
			string cmdstr = "select * from UserInfo where UserName = @UserName";
			//string cmdstr = "select * from UserInfo where PWAnswer = '3a'";
			SqlCommand cmd = new SqlCommand(cmdstr, conn);
			SqlParameter param = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
			//param.Value = ((TextBox)LoginUser.TemplateControl.FindControl("UserName")).Text;
			param.Value = LoginUser.UserName;
			cmd.Parameters.Add(param);
			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			if(reader.Read())
				_Default.GlobalCurrentUserID = reader["UserID"].ToString();
		}
	}
}
