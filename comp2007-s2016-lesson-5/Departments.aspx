<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="comp2007_s2016_lesson_5.Departments" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Departments List</h1>
                <a href="StudentDetails.aspx" class="btn btn-sm btn-success"><i class="fa fa-plus"></i></a>

                <asp:GridView runat="server" ID="DepartmentGridView" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover"
                    AllowSorting="true" OnSorting="DepartmentGridView_Sorting" OnRowDataBound="DepartmentGridView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" SortExpression="DepartmentID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Budget" HeaderText="Budget" SortExpression="Budget" DataFormatString="{0:C}" />
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o'></i>" ControlStyle-CssClass="btn btn-sm btn-success"
                            NavigateUrl="~/DepartmentDetails.aspx" DataNavigateUrlFields="DepartmentID" DataNavigateUrlFormatString="DepartmentDetails.aspx?StudentID={0}" />
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o'></i>" 
                            ControlStyle-CssClass="btn btn-danger btn-sm" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
