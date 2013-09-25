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
	public struct QuestionStruct
	{
		public string PaperID;
		public string QNo;
		public string Question;
		public string Category;
		public string Answer;
	}
	public partial class Test_Final : System.Web.UI.Page
	{
		public string PaperID = "10001";//Need to Modify.
		public string UserID = "20001";//Need to Modify.
		public static int resultCount = 0;
		public static int currentQuestion = 0;
		public static bool hasLoaded = false;
		public List<QuestionStruct> QuestionList = new List<QuestionStruct>();
		public static List<string> UserAnswerList = new List<string>();
		public static DateTime startTime = DateTime.Now;

		public void TestButtonEnable()
		{
			preButton.Enabled = true;
			nxtButton.Enabled = true;
			if (currentQuestion == 0)
			{
				ButtonEva.Enabled = false;
				ButtonEva.Visible = false;
				preButton.Enabled = false;
				FinishButton.Visible = false;
				FinishButton.Enabled = false;
			}
			else if (currentQuestion == resultCount - 1)
			{
				ButtonEva.Enabled = false;
				ButtonEva.Visible = false;
				nxtButton.Enabled = false;
				FinishButton.Visible = true;
				FinishButton.Enabled = true;
			}
			else if(currentQuestion == resultCount)
			{
				ButtonEva.Enabled = true;
				ButtonEva.Visible = true;
				currentQuestion = 0;
				FinishButton.Visible = false;
				FinishButton.Enabled = false;
			}
			else
			{
				ButtonEva.Enabled = false;
				ButtonEva.Visible = false;
				FinishButton.Visible = false;
				FinishButton.Enabled = false;
			}
		}

		public void LoadTitle(string paperID)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString);
			string cmdStr = "select * from PaperCategory where PaperID = @PaperID";
			SqlCommand cmd = new SqlCommand(cmdStr, conn);
			SqlParameter IDparam = new SqlParameter("@PaperID", SqlDbType.NChar, 5);
			IDparam.Value = PaperID;
			cmd.Parameters.Add(IDparam);
			conn.Open();
			SqlDataReader mcpReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			while (mcpReader.Read())
			{
				string dispStr = string.Format("Paper ID: {0}| Category: {1}| Name: {2}| Update Time:{3}| Used Times:{4}", mcpReader[0].ToString(), mcpReader[1].ToString(), mcpReader[2].ToString(), mcpReader[4].ToString(), mcpReader[5].ToString());
				LabelTitle.Text = dispStr;
			}
		}

		public bool TestAnswerValidity(string category, string answer)
		{
			if (category == "S    ")
			{
				if (answer.Length != 1)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else if (category == "M    ")
			{
				for (int i = 0; i < answer.Length; i++)
				{
					if (i % 2 != 0 && answer[i] != ',')
						return false;
					else
						continue;
				}
				return true;
			}
			else if (category == "R    ")
			{
				if (answer != "Y" && answer != "y" && answer != "N" && answer != "n")
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return true;
			}
		}

		public bool UpdateDBPre(QuestionStruct question,string answer)
		{
			if (TestAnswerValidity(question.Category, answer) == false)
			{
				return false;
			}
			else
			{
				UserAnswerList[currentQuestion] = answer;
				return true;
			}
		}

		public void LoadQuestion()
		{
			QuestionStruct qs = QuestionList[currentQuestion];
			QuestionTextBox.Text = string.Format("{0}. {1}", qs.QNo, qs.Question);
			if (qs.Category == "S    ")
			{
				HintLabel.Text = "There are EXACTLY one choice is correct. Please input the corresponding letter.";
			}
			else if (qs.Category == "M    ")
			{
				HintLabel.Text = "There are one or more correct choices. Please input the corresponding letter seperated with commas. (e.g. \"A,C\")";
			}
			else if (qs.Category == "R    ")
			{
				HintLabel.Text = "\"Y\" indicates a right statement, \"N\" indicates a wrong statement.";
			}
			else
			{
				HintLabel.Text = string.Empty;
			}
		}

		public void LoadContent(string paperID)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString);
			string cmdStr = "select * from Questions where PaperID = @PaperID";
			SqlCommand cmd = new SqlCommand(cmdStr, conn);
			SqlParameter IDparam = new SqlParameter("@PaperID", SqlDbType.NChar, 5);
			IDparam.Value = PaperID;
			cmd.Parameters.Add(IDparam);
			conn.Open();
			SqlDataReader mcpReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			GridView1.DataSource = mcpReader;
			GridView1.DataBind();
			//GridView1.Visible = false;
			conn.Open();
			mcpReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			while (mcpReader.Read())
			{
				QuestionStruct qs = new QuestionStruct();
				qs.Answer = mcpReader["Answer"].ToString();
				qs.Category = mcpReader["Category"].ToString();
				qs.PaperID = mcpReader["PaperID"].ToString();
				qs.QNo = mcpReader["QNo"].ToString();
				qs.Question = mcpReader["Question"].ToString();
				QuestionList.Add(qs);
				if(!hasLoaded)
					resultCount++;
			}
			LoadQuestion();
			TestButtonEnable();
			if (UserAnswerList.Count == 0)
			{
				for (int i = 0; i < resultCount; i++)
				{
					UserAnswerList.Add(string.Empty);
				}
			}
		}

		public void TestUpdateDB()
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString);
			string cmdStr = "select * from UserAnswer";
			SqlCommand cmd = new SqlCommand(cmdStr, conn);
			conn.Open();
			SqlDataReader mcpReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			GridView1.DataSource = mcpReader;
			GridView1.DataBind();
			conn.Open();
			mcpReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public void UpdateDB()
		{
			for (int i = 0; i < resultCount; i++)
			{
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString);
				string cmdStr = "insert into UserAnswer values (@PaperID, @QNo, @Answer, @UserID, @TestTime)";
				SqlCommand cmd = new SqlCommand(cmdStr, conn);

				SqlParameter PaperIDParam = new SqlParameter("@PaperID", SqlDbType.NChar, 5);
				SqlParameter QNoParam = new SqlParameter("@QNo", SqlDbType.Int);
				SqlParameter AnswerParam = new SqlParameter("@Answer", SqlDbType.VarChar, 1000);
				SqlParameter UserIDParam = new SqlParameter("@UserID", SqlDbType.NChar, 5);
				SqlParameter TestTimeParam = new SqlParameter("@TestTime", SqlDbType.DateTime);

				PaperIDParam.Value = PaperID;
				QNoParam.Value = i + 1;
				AnswerParam.Value = UserAnswerList[i];
				UserIDParam.Value = UserID;
				TestTimeParam.Value = DateTime.Now;

				cmd.Parameters.Add(PaperIDParam);
				cmd.Parameters.Add(QNoParam);
				cmd.Parameters.Add(AnswerParam);
				cmd.Parameters.Add(UserIDParam);
				cmd.Parameters.Add(TestTimeParam);

				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
			TestUpdateDB();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadTitle(PaperID);
			LoadContent(PaperID);
			hasLoaded = true;
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (UpdateDBPre(QuestionList[currentQuestion], AnswerTextBox.Text) == true)
			{
				currentQuestion--;
				LoadQuestion();
				TestButtonEnable();
				AnswerTextBox.Text = string.Empty;
			}
			else
			{
				HintLabel.Text = "Wrong Format!";
			}
		}

		protected void nxtButton_Click(object sender, EventArgs e)
		{
			if (UpdateDBPre(QuestionList[currentQuestion], AnswerTextBox.Text) == true)
			{
				currentQuestion++;
				LoadQuestion();
				TestButtonEnable();
				AnswerTextBox.Text = string.Empty;
			}
			else
			{
				HintLabel.Text = "Wrong Format!";
			}
		}

		protected void FinishButton_Click(object sender, EventArgs e)
		{
			if (UpdateDBPre(QuestionList[currentQuestion], AnswerTextBox.Text) == true)
			{
				currentQuestion++;
				TestButtonEnable();
				AnswerTextBox.Text = "";
				HintLabel.Text = "Test Finished!";
				preButton.Enabled = false;
				nxtButton.Enabled = false;
				FinishButton.Enabled = false;
				UpdateDB();
				ButtonEva.Visible = true;
				ButtonEva.Enabled = true;
			}
			else
			{
				HintLabel.Text = "Wrong Format!";
			}
		}

		protected void Timer1_Tick(object sender, EventArgs e)
		{
			int diffHour = (DateTime.Now - startTime).Hours;
			int diffMinute = (DateTime.Now - startTime).Minutes;
			int diffSecond = (DateTime.Now - startTime).Seconds;
			LabelTimer.Text = string.Format("{0}:{1}:{2}", diffHour, diffMinute, diffSecond);
		}
	}
}