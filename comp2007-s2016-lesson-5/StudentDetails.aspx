<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="comp2007_s2016_lesson_5.Models.StudentDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-offset-3 col-md-6">
        <h1>Student Details</h1>
        <h4>All fields are required</h4>
        <div class="form-group">
            <label class="control-label" for="Lastname">Lastname:</label>
            <asp:TextBox CssClass="form-control" ID="Lastname" placeholder="Lastname" required="true" MaxLength="50" runat="server" />
        </div>
        <div class="form-group">
            <label class="control-label" for="Firstname">Firstname:</label>
            <asp:TextBox CssClass="form-control" ID="Firstname" placeholder="Firstname" required="true" MaxLength="50" runat="server" />
        </div>
        <div class="form-group">
            <label class="control-label" for="EnrollmentDate">Enrollment Date:</label>
            <asp:TextBox TextMode="Date" CssClass="form-control" ID="EnrollmentDate" placeholder="Enrollment Date" required="true" runat="server" />
        </div>
        <div class="text-right">
            <asp:Button Text="Cancel" ID="Cancel" runat="server" CssClass="btn btn-warning btn-lg" UseSubmitBehavior="false" CausesValidation="false" OnClick="Cancel_Click" />
            <asp:Button Text="Save" ID="Save" runat="server" CssClass="btn btn-primary btn-lg" OnClick="Save_Click" />
        </div>
    </div>
</asp:Content>
