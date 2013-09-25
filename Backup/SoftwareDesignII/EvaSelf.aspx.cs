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
	public partial class EvaSelf : System.Web.UI.Page
	{
		public string paperID = "10001";//Need to Modify.
		public string userID = "20001";//Need to Modify.
		public static int currentQNo = 0;
		public static List<QuestionStruct> corList = new List<QuestionStruct>(Test_Final.resultCount);
		public static List<QuestionStruct> mineList = new List<QuestionStruct>(Test_Final.resultCount);

		protected void Page_Load(object sender, EventArgs e)
		{
			QuestionStruct qstmp = new QuestionStruct();
			if (corList.Count < Test_Final.resultCount)
			{
				for (int i = 0; i < Test_Final.resultCount; i++)
				{
					corList.Add(qstmp);
				}
			}
			if (mineList.Count < Test_Final.resultCount)
			{
				for (int i = 0; i < Test_Final.resultCount; i++)
				{
					mineList.Add(qstmp);
				}
			}
			for (int i = 0; i < Test_Final.resultCount; i++)
			{
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);

				string cmdstrCor = "select * from Questions where PaperID = @PaperID and QNo = @QNo";
				SqlCommand cmdCor = new SqlCommand(cmdstrCor, conn);
				SqlParameter paperIDparam = new SqlParameter("@PaperID", SqlDbType.NChar, 5);
				SqlParameter qnoparam = new SqlParameter("@QNo", SqlDbType.Int);
				paperIDparam.Value = paperID;
				qnoparam.Value = i + 1;
				cmdCor.Parameters.Add(paperIDparam);
				cmdCor.Parameters.Add(qnoparam);

				string cmdstrMine = "select * from UserAnswer where PaperID = @PaperID and QNo = @QNo and UserID = @UserID order by TestTime desc";
				SqlCommand cmdMine = new SqlCommand(cmdstrMine, conn);
				SqlParameter idParam = new SqlParameter("@PaperID", SqlDbType.NChar, 5);
				SqlParameter noParam = new SqlParameter("@QNo", SqlDbType.Int);
				SqlParameter userParam = new SqlParameter("@UserID", SqlDbType.NChar, 5);
				idParam.Value = paperID;
				noParam.Value = i + 1;
				userParam.Value = userID;
				cmdMine.Parameters.Add(idParam);
				cmdMine.Parameters.Add(noParam);
				cmdMine.Parameters.Add(userParam);
				QuestionStruct qs = new QuestionStruct();

				conn.Open();
				SqlDataReader corReader = cmdCor.ExecuteReader();
				corReader.Read();
				qs.Answer = corReader["Answer"].ToString();
				qs.Category = corReader["Category"].ToString();
				qs.PaperID = corReader["PaperID"].ToString();
				qs.QNo = corReader["QNo"].ToString();
				qs.Question = corReader["Question"].ToString();
				corList[i] = qs;
				conn.Close();

				conn.Open();
				SqlDataReader mineReader = cmdMine.ExecuteReader();
				mineReader.Read();
				qs.Answer = mineReader["Answer"].ToString();
				mineList[i] = qs;
				conn.Close();
			}
			LabelQNo.Text = string.Format("Question {0}", currentQNo + 1);
			TextBoxQuestion.Text = string.Format("{0}. {1}", currentQNo + 1, corList[currentQNo].Question);
			TextBoxCorrect.Text = string.Format("This is the correct answer:\n{0}", corList[currentQNo].Answer);
			TextBoxMine.Text = string.Format("This is your answer:\n{0}", mineList[currentQNo].Answer);
		}

		protected void ButtonPre_Click(object sender, EventArgs e)
		{
			currentQNo--;
			Page_Load(sender, e);
		}

		protected void ButtonNxt_Click(object sender, EventArgs e)
		{
			currentQNo++;
			Page_Load(sender, e);
		}
	}
}