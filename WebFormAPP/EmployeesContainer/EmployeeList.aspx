<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeList.aspx.cs" Inherits="WebFormAPP.EmployeesContainer.EmployeeList" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <a class="btn btn-primary" target="_blank" href="AddEmployee.aspx">Add Employee</a>
        <asp:Literal ID="litTable" runat="server" />

    </main>
    <script type="text/javascript" src="https://cdn.datatables.net/2.0.0/js/dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/2.0.0/css/dataTables.dataTables.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#myTable').DataTable();
        });

    </script>
</asp:Content>
