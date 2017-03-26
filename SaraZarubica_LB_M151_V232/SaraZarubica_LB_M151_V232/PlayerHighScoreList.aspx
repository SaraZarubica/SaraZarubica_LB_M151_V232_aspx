<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerHighScoreList.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.PlayerHighScoreList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Highscore"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvHighscore" CssClass= "table table-striped table-bordered table-condensed" runat="server" OnRowDataBound="gvHighscore_RowDataBound">
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
