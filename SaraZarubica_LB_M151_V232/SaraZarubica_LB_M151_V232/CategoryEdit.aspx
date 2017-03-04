<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.CategoryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:HiddenField ID="HiddenCId" runat="server" />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Kategorie"></asp:Label>
        <asp:TextBox ID="txtBoxC" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" Text="Speichern" OnClick="btnSave_Click1" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
