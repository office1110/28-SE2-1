using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftwareDesignII
{
	public partial class ResetFavorite : System.Web.UI.Page
	{
		public string userID = _Default.GlobalCurrentUserID;
		protected void Page_Load(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);
			string cmdstr = "select * from UserInfo where UserID = @UserID";
			SqlCommand cmd = new SqlCommand(cmdstr, conn);
			SqlParameter param = new SqlParameter("@UserID", SqlDbType.NChar, 5);
			param.Value = userID;
			cmd.Parameters.Add(param);
			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			reader.Read();
			LabelInterest.Text = reader["Interest"].ToString();
		}

		protected void ButtonOK_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);
			string cmdstr = "update UserInfo set Interest = @Interest";
			SqlCommand cmd = new SqlCommand(cmdstr, conn);
			SqlParameter param = new SqlParameter("@Interest", SqlDbType.VarChar, 20);
			param.Value = TextBoxInterest.Text;
			cmd.Parameters.Add(param);
			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();
		}
	}
}