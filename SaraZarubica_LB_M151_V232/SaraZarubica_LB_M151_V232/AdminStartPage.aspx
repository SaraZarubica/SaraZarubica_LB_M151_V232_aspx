<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminStartPage.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.AdminStartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Was möchten Sie bearbeiten?"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnQ" CssClass="btn btn-default" runat="server" Text="Fragen" OnClick="btnQ_Click" />
        <asp:Button ID="btnC" CssClass="btn btn-default" runat="server" Text="Kategorien" OnClick="btnC_Click" />
        <asp:Button ID="btnH" CssClass="btn btn-default" runat="server" Text="Highscore" OnClick="btnH_Click" />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
