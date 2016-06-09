using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_s2016_lesson_5.Models;
using System.Web.ModelBinding;

namespace comp2007_s2016_lesson_5.Models
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Students.aspx");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                // use the student model to store a new record
                db.Students.Add(new Student()
                {
                    LastName = Lastname.Text,
                    FirstMidName = Firstname.Text,
                    EnrollmentDate = Convert.ToDateTime(EnrollmentDate.Text)
                });

                db.SaveChanges();
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}