using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftwareDesignII.Test
{
	public partial class Test_GRE : System.Web.UI.Page
	{
		public string PrimaryKey { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			Label_Title.Text = "GRE";
		}

		protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Label1.Text = GridView1.SelectedDataKey.Value.ToString();
			PrimaryKey = Label1.Text;
			Response.Redirect(@"~\Test_Final.aspx");
		}

		//protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
		//{
			//Label1.Text = ListView1.SelectedIndex.ToString();
		//}
	}
}