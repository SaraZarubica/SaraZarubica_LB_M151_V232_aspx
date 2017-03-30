<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:GridView ID="gvCategories" CssClass= "table table-striped table-bordered table-condensed" runat="server" OnRowDataBound="gvCategories_RowDataBound" OnSelectedIndexChanged="gvCategories_SelectedIndexChanged">
            <SelectedRowStyle BorderStyle="Dashed" />
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnAdd" CssClass="btn btn-default" runat="server" OnClick="btnAdd_Click" Text="Kategorie hinzufügen" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnBack" CssClass="btn btn-default"
             runat="server" Text="Zurück" OnClick="btnBack_Click" />
    </p>
</asp:Content>
