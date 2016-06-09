using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_s2016_lesson_5.Models;
using System.Web.ModelBinding;

namespace comp2007_s2016_lesson_5
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if we're loading the page for the first time, pupulate the grid
            if (!IsPostBack)
            {
                this.FetchStudents();
            }
        }

        protected void FetchStudents()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                // query the student's table using EF and LINQ
                var student = (from allStudents in db.Students
                               select allStudents);

                // bind the result to the grid view
                StudentGridView.DataSource = student.ToList();
                StudentGridView.DataBind();
            }
        }
    }
}