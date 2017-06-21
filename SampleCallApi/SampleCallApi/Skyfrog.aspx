<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Skyfrog.aspx.cs" Inherits="SampleCallApi.Skyfrog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Sample</h2>

    <div class="row">
        <div class="col-md-12">
            <div class="alert alert-success" role="alert" id="AreaSuccess" runat="server"> <strong>Well done!</strong> <span id="TextSuccess" runat="server"></span></div>
            <div class="alert alert-danger" role="alert" id="AreaError" runat="server"> <strong>Oh snap!</strong> <span id="TextError" runat="server"></span></div>

            <asp:Button ID="BtnCreate" runat="server" Text="Create Job" CssClass="btn btn-primary" OnClick="BtnCreate_Click" />
        </div>
    </div>
</asp:Content>
