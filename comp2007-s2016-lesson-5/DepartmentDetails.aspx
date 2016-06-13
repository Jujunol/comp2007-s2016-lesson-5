<%@ Page Title="Department Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentDetails.aspx.cs" Inherits="comp2007_s2016_lesson_5.DepartmentDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-offset-3 col-md-6">
        <h1>Department Details</h1>
        <h4>All fields are required</h4>
        <div class="form-group">
            <label class="control-label" for="Name">Name:</label>
            <asp:TextBox CssClass="form-control" ID="Name" placeholder="Name" required="true" MaxLength="50" runat="server" />
        </div>
        <div class="form-group">
            <label class="control-label" for="Budget">Budget:</label>
            <asp:TextBox CssClass="form-control" ID="Budget" TextMode="Number" required="true" runat="server" />
        </div>
        <div class="text-right">
            <asp:Button Text="Cancel" ID="Cancel" runat="server" CssClass="btn btn-warning btn-lg" UseSubmitBehavior="false" CausesValidation="false" OnClick="Cancel_Click" />
            <asp:Button Text="Save" ID="Save" runat="server" CssClass="btn btn-primary btn-lg" OnClick="Save_Click" />
        </div>
    </div>
</asp:Content>
