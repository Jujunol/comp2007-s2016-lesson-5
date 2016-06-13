<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="comp2007_s2016_lesson_5.Students" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Student List</h1>
                <a href="StudentDetails.aspx" class="btn btn-sm btn-success"><i class="fa fa-plus"></i></a>

                <div class="text-right">
                    <label>Records Per Page?</label>
                    <asp:DropDownList ID="PageSizeDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged"
                        CssClass="btn btn-sm btn-primary dropdown-toggle">
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="All" Value="10000" />
                    </asp:DropDownList>
                </div>

                <asp:GridView ID="StudentGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="StudentID"
                    CssClass="table table-striped table-bordered table-hover" OnRowDeleting="StudentGridView_RowDeleting"
                    AllowPaging="true" PageSize="3" OnPageIndexChanging="StudentGridView_PageIndexChanging"
                    AllowSorting="true" OnSorting="StudentGridView_Sorting" OnRowDataBound="StudentGridView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" SortExpression="StudentID" />
                        <asp:BoundField DataField="LastName" HeaderText="Lastname" SortExpression="Lastname" />
                        <asp:BoundField DataField="FirstMidName" HeaderText="Firstname" SortExpression="FirstMidName" />
                        <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" DataFormatString="{0:MMM dd, yyyy}"
                            SortExpression="EnrollmentDate" />
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o'></i>" ControlStyle-CssClass="btn btn-sm btn-success"
                            NavigateUrl="~/StudentDetails.aspx" DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="StudentDetails.aspx?StudentID={0}" />
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o'></i>"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-sm btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
