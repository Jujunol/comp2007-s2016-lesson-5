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

        private Student student;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Request.QueryString.Count > 0)
            {
                this.FetchStudent();
            }
        }

        private void FetchStudent()
        {
            int studentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            using (DefaultConnection db = new DefaultConnection())
            {
                student = (from studentList in db.Students
                           where studentList.StudentID == studentID
                           select studentList).FirstOrDefault();

                if(student != null)
                {
                    Lastname.Text = student.LastName;
                    Firstname.Text = student.FirstMidName;
                    EnrollmentDate.Text = student.EnrollmentDate.ToString("yyyy-MM-dd");
                }
            }
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
                student = new Student()
                {
                    LastName = Lastname.Text,
                    FirstMidName = Firstname.Text,
                    EnrollmentDate = Convert.ToDateTime(EnrollmentDate.Text)
                };

                if(Request.QueryString.Count <= 0)
                {
                    db.Students.Add(student);
                }

                db.SaveChanges();
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}