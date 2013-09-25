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
	public partial class UploadPaper : System.Web.UI.Page
	{
		public string userID = "10001";//Need to modify.
		public static int QuestionNo = 0;
		public static string paperID = string.Empty;
		public static string paperCategory = string.Empty;
		public static string paperName = string.Empty;
		public static List<QuestionStruct> questionList = new List<QuestionStruct>();
		public QuestionStruct qs = new QuestionStruct();

		public string CategoryTrans(int index)
		{
			switch (index)
			{
				case 0:
					return "F    ";
				case 1:
					return "S    ";
				case 2:
					return "M    ";
				case 3:
					return "R    ";
				case 4:
					return "A    ";
				default:
					return string.Empty;
			}
		}

		public void UpdateDB()
		{
			for (int i = 0; i < questionList.Count; i++)
			{
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);
				string cmdstr = "insert into Questions values (@PaperID, @QNo, @Category, @Question, @Answer)";
				SqlCommand cmd = new SqlCommand(cmdstr, conn);

				SqlParameter idParam = new SqlParameter("@PaperID", SqlDbType.NChar, 5);
				SqlParameter qnoParam = new SqlParameter("@QNo", SqlDbType.Int);
				SqlParameter cateParam = new SqlParameter("@Category", SqlDbType.NChar, 5);
				SqlParameter quesParam = new SqlParameter("@Question", SqlDbType.VarChar, 1000);
				SqlParameter ansParam = new SqlParameter("@Answer", SqlDbType.VarChar, 1000);

				idParam.Value = paperID;
				qnoParam.Value = i + 1;
				cateParam.Value = paperCategory;
				quesParam.Value = questionList[i].Question;
				ansParam.Value = questionList[i].Answer;

				cmd.Parameters.Add(idParam);
				cmd.Parameters.Add(qnoParam);
				cmd.Parameters.Add(cateParam);
				cmd.Parameters.Add(quesParam);
				cmd.Parameters.Add(ansParam);

				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
			SqlConnection connOut = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);
			string cmdstrOut = "insert into PaperCategory values (@PaperID, @Category, @Name, @UpdateUserID, @FinishTime, @UsedTimes)";
			SqlCommand cmdOut = new SqlCommand(cmdstrOut, connOut);

			SqlParameter idParamOut = new SqlParameter("@PaperID", SqlDbType.NChar, 5);
			SqlParameter cateParamOut = new SqlParameter("@Category", SqlDbType.NChar, 5);
			SqlParameter nameParam = new SqlParameter("@Name", SqlDbType.VarChar, 100);
			SqlParameter upUserParam = new SqlParameter("@UpdateUserID", SqlDbType.NChar, 5);
			SqlParameter finishParam = new SqlParameter("@FinishTime", SqlDbType.DateTime);
			SqlParameter usedTimesParam = new SqlParameter("@UsedTimes", SqlDbType.Int);

			idParamOut.Value = paperID;
			cateParamOut.Value = paperCategory;
			nameParam.Value = paperName;
			upUserParam.Value = userID;
			finishParam.Value = DateTime.Now;
			usedTimesParam.Value = 0;

			cmdOut.Parameters.Add(idParamOut);
			cmdOut.Parameters.Add(cateParamOut);
			cmdOut.Parameters.Add(nameParam);
			cmdOut.Parameters.Add(upUserParam);
			cmdOut.Parameters.Add(finishParam);
			cmdOut.Parameters.Add(usedTimesParam);

			connOut.Open();
			cmdOut.ExecuteNonQuery();
			connOut.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (QuestionNo == 0)
			{
				LabelTitle.Text = "Configure Paper Information...";
				LabelPaperID.Enabled = true;
				LabelPaperID.Visible = true;
				LabelRealID.Enabled = true;
				LabelRealID.Visible = true;
				LabelCategory.Enabled = true;
				LabelCategory.Visible = true;
				TextBoxPaperCategory.Enabled = true;
				TextBoxPaperCategory.Visible = true;
				LabelPaperName.Enabled = true;
				LabelPaperName.Visible = true;
				TextBoxPaperName.Enabled = true;
				TextBoxPaperName.Visible = true;
				DropDownListCategory.Enabled = false;
				DropDownListCategory.Visible = false;
				LabelQuestionCategory.Enabled = false;
				LabelQuestionCategory.Visible = false;
				TextBoxAnswer.Enabled = false;
				TextBoxAnswer.Visible = false;
				TextBoxQuestion.Enabled = false;
				TextBoxQuestion.Visible = false;
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamSystemConnectionString"].ConnectionString);
				string cmdStr = "select PaperID from PaperCategory";
				SqlCommand cmd = new SqlCommand(cmdStr, conn);
				conn.Open();
				SqlDataReader mcpReader;
				List<string> idList = new List<string>();
				mcpReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				while (mcpReader.Read())
				{
					idList.Add(mcpReader[0].ToString());
				}
				List<int> idListInt = new List<int>();
				foreach (var i in idList)
				{
					idListInt.Add(int.Parse(i));
				}
				int maxID = idListInt.Max();
				LabelRealID.Text = (maxID + 1).ToString();
				paperID = (maxID + 1).ToString();
				paperCategory = TextBoxPaperCategory.Text;
				paperName = TextBoxPaperName.Text;
			}
			else
			{
				LabelTitle.Text = string.Format("Question {0}", QuestionNo);
				LabelPaperID.Enabled = false;
				LabelPaperID.Visible = false;
				LabelRealID.Enabled = false;
				LabelRealID.Visible = false;
				LabelCategory.Enabled = false;
				LabelCategory.Visible = false;
				TextBoxPaperCategory.Enabled = false;
				TextBoxPaperCategory.Visible = false;
				LabelPaperName.Enabled = false;
				LabelPaperName.Visible = false;
				TextBoxPaperName.Enabled = false;
				TextBoxPaperName.Visible = false;
				DropDownListCategory.Enabled = true;
				DropDownListCategory.Visible = true;
				LabelQuestionCategory.Enabled = true;
				LabelQuestionCategory.Visible = true;
				TextBoxAnswer.Enabled = true;
				TextBoxAnswer.Visible = true;
				TextBoxQuestion.Enabled = true;
				TextBoxQuestion.Visible = true;
			}
		}

		protected void ButtonPre_Click(object sender, EventArgs e)
		{
			if (QuestionNo > 0)
			{
				qs.Answer = TextBoxAnswer.Text;
				qs.Category = CategoryTrans(DropDownListCategory.SelectedIndex);
				qs.PaperID = paperID;
				qs.QNo = QuestionNo.ToString();
				qs.Question = TextBoxQuestion.Text;
				if (QuestionNo <= questionList.Count)
				{
					questionList[QuestionNo - 1] = qs;
				}
				else
				{
					questionList.Add(qs);
				}
			}
			QuestionNo--;
			Page_Load(sender, e);
		}

		protected void ButtonNxt_Click(object sender, EventArgs e)
		{
			if (QuestionNo > 0)
			{
				qs.Answer = TextBoxAnswer.Text;
				qs.Category = CategoryTrans(DropDownListCategory.SelectedIndex);
				qs.PaperID = paperID;
				qs.QNo = QuestionNo.ToString();
				qs.Question = TextBoxQuestion.Text;
				if (QuestionNo <= questionList.Count)
				{
					questionList[QuestionNo - 1] = qs;
				}
				else
				{
					questionList.Add(qs);
				}
			}
			QuestionNo++;
			Page_Load(sender, e);
		}

		protected void TextBoxPaperCategory_TextChanged(object sender, EventArgs e)
		{
			paperCategory = TextBoxPaperCategory.Text;
		}

		protected void ButtonFinish_Click(object sender, EventArgs e)
		{
			if (QuestionNo > 0)
			{
				qs.Answer = TextBoxAnswer.Text;
				qs.Category = CategoryTrans(DropDownListCategory.SelectedIndex);
				qs.PaperID = paperID;
				qs.QNo = QuestionNo.ToString();
				qs.Question = TextBoxQuestion.Text;
				if (QuestionNo <= questionList.Count)
				{
					questionList[QuestionNo - 1] = qs;
				}
				else
				{
					questionList.Add(qs);
				}
			}
			UpdateDB();
			Page_Load(sender, e);
		}
	}
}