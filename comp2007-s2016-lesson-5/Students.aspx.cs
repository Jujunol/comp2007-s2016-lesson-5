using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_s2016_lesson_5.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace comp2007_s2016_lesson_5
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if we're loading the page for the first time, populate the grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "StudentID";
                Session["SortDirection"] = "ASC";
                this.FetchStudents();
            }
            if(Session["SortColumn"] == null)
            {
                Session["SortColumn"] = "StudentID";
            }
        }

        protected void FetchStudents()
        {
            string sortString = Session["SortColumn"] + " " + Session["SortDirection"];
            using (DefaultConnection db = new DefaultConnection())
            {
                // query the student's table using EF and LINQ
                var student = (from studentList in db.Students
                               select studentList);

                // bind the result to the grid view
                // StudentGridView.DataSource = student.ToList();
                StudentGridView.DataSource = student.AsQueryable().OrderBy(sortString).ToList();
                StudentGridView.DataBind();
            }
        }

        protected void StudentGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected studentID
            int studentID = Convert.ToInt32(StudentGridView.DataKeys[selectedRow].Values["StudentID"]);

            // find and delete the student in the database
            using (DefaultConnection db = new DefaultConnection())
            {
                Student student = (from studentList in db.Students
                                   where studentList.StudentID == studentID
                                   select studentList).FirstOrDefault();

                // delete the student
                db.Students.Remove(student);
                db.SaveChanges();

                // refresh the grid
                this.FetchStudents();
            }
        }

        protected void StudentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StudentGridView.PageIndex = e.NewPageIndex;

            this.FetchStudents();
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            this.FetchStudents();
        }

        protected void StudentGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sort by
            //Session["SortColumn"] = e.SortExpression;
            //Session["SortDirection"] = e.SortDirection; // doesn't work
            string column = e.SortExpression;
            Session["SortDirection"] = (Session["SortColumn"].ToString() == column && Session["SortDirection"].ToString() != "DESC" ? "DESC" : "ASC");
            Session["SortColumn"] = column;

            this.FetchStudents();
        }

        protected void StudentGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(IsPostBack && e.Row.RowType == DataControlRowType.Header) // check to see if even was a header
            {
                LinkButton linkButton = new LinkButton();
                for(int i = 0; i < StudentGridView.Columns.Count; i++)
                {
                    if(StudentGridView.Columns[i].SortExpression == Session["SortColumn"].ToString())
                    {
                        if(Session["SortDirection"].ToString() == "ASC")
                        {
                            linkButton.Text = " <i class='fa fa-lg fa-caret-up'></i>";
                        }
                        else
                        {
                            linkButton.Text = " <i class='fa fa-lg fa-caret-down'></i>";
                        }

                        e.Row.Cells[i].Controls.Add(linkButton);
                        break;
                    }
                }
            }
        }
    }
}