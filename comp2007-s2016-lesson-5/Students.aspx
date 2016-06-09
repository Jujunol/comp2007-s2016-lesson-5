<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="comp2007_s2016_lesson_5.Students" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Student List</h1>
                <a href="StudentDetails.aspx" class="btn btn-sm btn-success"><i class="fa fa-plus"></i></a>
                <asp:GridView ID="StudentGridView" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                        <asp:BoundField DataField="LastName" HeaderText="Lastname" />
                        <asp:BoundField DataField="FirstMidName" HeaderText="Firstname" />
                        <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" DataFormatString="{0:MMM dd, yyyy}" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
