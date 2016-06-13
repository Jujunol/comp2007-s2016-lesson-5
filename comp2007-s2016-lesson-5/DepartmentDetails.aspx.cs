using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_s2016_lesson_5.Models;

namespace comp2007_s2016_lesson_5
{
    public partial class DepartmentDetails : System.Web.UI.Page
    {

        private Department department;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Request.QueryString.Count > 0)
            {
                this.FetchDepartment();
            }
        }

        private void FetchDepartment()
        {
            int departmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            using (DefaultConnection db = new DefaultConnection())
            {
                department = (from departmentList in db.Departments
                              where departmentList.DepartmentID == departmentID
                              select departmentList).FirstOrDefault();

                if(department != null)
                {
                    Name.Text = department.Name;
                    Budget.Text = "" + department.Budget;
                }
                              
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Departments.aspx");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                department = new Department()
                {
                    Name = Name.Text,
                    Budget = Convert.ToInt32(Budget.Text)
                };

                if(Request.QueryString.Count <= 0)
                {
                    db.Departments.Add(department);
                }

                db.SaveChanges();
            }
        }
    }
}