using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftwareDesignII
{
	public partial class About : System.Web.UI.Page
	{
		public bool isTeacher = true;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (isTeacher)
			{
				LinkButton1.Visible = true;
				LinkButton1.Enabled = true;
				Label1.Visible = false;
				Label1.Enabled = false;
			}
			else
			{
				LinkButton1.Visible = false;
				LinkButton1.Enabled = false;
				Label1.Visible = true;
				Label1.Enabled = true;
			}
		}

		protected void LinkButton1_Click(object sender, EventArgs e)
		{
		}
	}
}
