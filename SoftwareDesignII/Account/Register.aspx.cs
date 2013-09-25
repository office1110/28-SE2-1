using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftwareDesignII.Account
{
	public partial class Register : System.Web.UI.Page
	{
		public static string regUserID = string.Empty;
		public string regUserName = string.Empty;
		public string regEmail = string.Empty;
		public string regPW = string.Empty;
		public string regPWQ = string.Empty;
		public string regPWA = string.Empty;
		public string regInterest = string.Empty;
		public bool regIsTeacher = true;
		public string regClassID = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);
			string cmdstr = "select * from UserInfo order by UserID desc";
			SqlCommand cmd = new SqlCommand(cmdstr, conn);
			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			if (reader.Read())
			{
				int idMax = int.Parse(reader["UserID"].ToString());
				idMax++;
				((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserID")).Text = idMax.ToString();
				regUserID = idMax.ToString();
			}
			else
			{
				regUserID = "20001";
				((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserID")).Text = regUserID;
			}
		}

		protected void RegisterUser_CreatedUser(object sender, EventArgs e)
		{
			FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

			string continueUrl = RegisterUser.ContinueDestinationPageUrl;
			if (String.IsNullOrEmpty(continueUrl))
			{
				continueUrl = "~/";
			}
			Response.Redirect(continueUrl);
		}

		protected void CreateUserButton_Click(object sender, EventArgs e)
		{
			regUserName = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName")).Text;
			regEmail = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email")).Text;
			regPW = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password")).Text;
			regPWQ = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("PasswordQuestion")).Text;
			regPWA = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("PasswordAnswer")).Text;
			regInterest = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Interest")).Text;
			if (((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("IsTeacher")).Text == "Y")
				regIsTeacher = true;
			else
				regIsTeacher = false;
			regClassID = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ClassID")).Text;

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);
			string cmdstr = "insert into UserInfo values (@UserID, @UserName, @Email, @Password, @PWQuestion, @PWAnswer, @IsTeacher, @LastLoginTime, @Interest, @ClassID, @TeacherID)";
			SqlCommand cmd = new SqlCommand(cmdstr, conn);

			SqlParameter idparam = new SqlParameter("@UserID", SqlDbType.NChar, 5);
			SqlParameter nameparam = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
			SqlParameter emailparam = new SqlParameter("@Email", SqlDbType.VarChar, 50);
			SqlParameter pwparam = new SqlParameter("@Password", SqlDbType.VarChar, 20);
			SqlParameter pwqparam = new SqlParameter("@PWQuestion", SqlDbType.VarChar, 50);
			SqlParameter pwaparam = new SqlParameter("@PWAnswer", SqlDbType.VarChar, 300);
			SqlParameter istparam = new SqlParameter("@IsTeacher", SqlDbType.Bit);
			SqlParameter logintimeparam = new SqlParameter("@LastLoginTime", SqlDbType.DateTime);
			SqlParameter interparam = new SqlParameter("@Interest", SqlDbType.VarChar, 20);
			SqlParameter classidparam = new SqlParameter("@ClassID", SqlDbType.NChar, 5);
			SqlParameter teacheridparam = new SqlParameter("@TeacherID", SqlDbType.NChar, 5);

			idparam.Value = regUserID;
			nameparam.Value = regUserName;
			emailparam.Value = regEmail;
			pwparam.Value = regPW;
			pwqparam.Value = regPWQ;
			pwaparam.Value = regPWA;
			istparam.Value = regIsTeacher;
			logintimeparam.Value = "1970-1-1 0:0:0";
			interparam.Value = regInterest;
			classidparam.Value = regClassID;
			teacheridparam.Value = "";

			cmd.Parameters.Add(idparam);
			cmd.Parameters.Add(nameparam);
			cmd.Parameters.Add(emailparam);
			cmd.Parameters.Add(pwparam);
			cmd.Parameters.Add(pwqparam);
			cmd.Parameters.Add(pwaparam);
			cmd.Parameters.Add(istparam);
			cmd.Parameters.Add(logintimeparam);
			cmd.Parameters.Add(interparam);
			cmd.Parameters.Add(classidparam);
			cmd.Parameters.Add(teacheridparam);

			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();
			_Default.GlobalCurrentUserID = regUserID;
		}
	}
}
