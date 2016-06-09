using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace comp2007_s2016_lesson_5.User_Controls
{
    public partial class Jumbotron : System.Web.UI.UserControl
    {

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PlaceHolder Body { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            content.Controls.Add(Body);
        }
    }
}