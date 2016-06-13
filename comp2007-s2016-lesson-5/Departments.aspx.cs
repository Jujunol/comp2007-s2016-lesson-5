using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_s2016_lesson_5.Models;
using System.Linq.Dynamic;

namespace comp2007_s2016_lesson_5
{
    public partial class Departments : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "DepartmentID";
                Session["SortDirection"] = "ASC";
                this.FetchDepartments();
            }
        }

        private void FetchDepartments()
        {
            string sortString = Session["SortColumn"] + " " + Session["SortDirection"];
            using (DefaultConnection db = new DefaultConnection())
            {
                var departments = (from departmentList in db.Departments
                                   select departmentList);

                //DepartmentGridView.DataSource = departments.ToList();
                DepartmentGridView.DataSource = departments.AsQueryable().OrderBy(sortString).ToList();
                DepartmentGridView.DataBind();
            }
        }

        protected void DepartmentGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string column = e.SortExpression;
            Session["SortDirection"] = (Session["SortColumn"].ToString() == column && Session["SortDirection"].ToString() != "DESC" ? "DESC" : "ASC");
            Session["SortColumn"] = column;

            this.FetchDepartments();
        }

        protected void DepartmentGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(IsPostBack && e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton btn = new LinkButton();
                for(int i = 0; i < DepartmentGridView.Columns.Count; i++)
                {
                    if (DepartmentGridView.Columns[i].SortExpression == Session["SortColumn"].ToString())
                    {
                        if (Session["SortDirection"].ToString() == "ASC")
                        {
                            btn.Text = " <i class='fa fa-caret-down'></i>";
                        }
                        else
                        {
                            btn.Text = " <i class='fa fa-caret-up'></i>";
                        }

                        e.Row.Cells[i].Controls.Add(btn);
                        break;
                    }
                }
            }
        }
    }
}