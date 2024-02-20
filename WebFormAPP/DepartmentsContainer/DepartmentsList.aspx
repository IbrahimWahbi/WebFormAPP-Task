<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentsList.aspx.cs" Inherits="WebFormAPP.DepartmentsContainer.DepartmentsList" Title="Employees List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
       
        <asp:Literal ID="litTable" runat="server" />
        
    </main>
</asp:Content>