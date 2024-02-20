<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="WebFormAPP.EmployeesContainer.EditEmployee" Title="Edit Employee" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.<asp:HiddenField ID="HiddenField_EmployeeID" runat="server" />
    </h2>
        <div class="col-md-8">
            <section id="loginForm">
                <div class="row">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 col-form-label">First Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                                CssClass="text-danger" ErrorMessage="The First Name field is required." />
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 col-form-label">Last Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="LastName" TextMode="SingleLine" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" CssClass="text-danger" ErrorMessage="The Last name field is required." />
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="Position" CssClass="col-md-2 col-form-label">Position</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Position" TextMode="SingleLine" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Position" CssClass="text-danger" ErrorMessage="The Position field is required." />
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="Salary" CssClass="col-md-2 col-form-label">Salary</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Salary" TextMode="Number" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Salary" CssClass="text-danger" ErrorMessage="The Salary field is required." />
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="DateOfBirth" CssClass="col-md-2 col-form-label">Birth Date</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="DateOfBirth" TextMode="Date" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DateOfBirth" CssClass="text-danger" ErrorMessage="The Date field is required." />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="Departments" CssClass="col-md-2 col-form-label">Departments</asp:Label>
                        <div class="col-md-10">
                            <asp:CheckBoxList ID="Departments" runat="server" CssClass="form-control"></asp:CheckBoxList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-offset-md-2 col-md-10">
                            <asp:Button runat="server" OnClick="EditEmployee_btn" Text="Edit" CssClass="btn btn-outline-dark" />
                        </div>
                    </div>
                </div>

            </section>
        </div>

    </main>
</asp:Content>
