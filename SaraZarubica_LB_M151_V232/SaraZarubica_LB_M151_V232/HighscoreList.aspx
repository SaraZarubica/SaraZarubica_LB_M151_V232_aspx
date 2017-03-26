<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HighscoreList.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.HighscoreList" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:GridView ID="gvHighscore" CssClass= "table table-striped table-bordered table-condensed"  runat="server" OnRowDataBound="gvHighscore_RowDataBound" OnSelectedIndexChanged="gvHighscore_SelectedIndexChanged">
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="btnBack" CssClass="btn btn-default" runat="server" Text="Zurück" OnClick="btnBack_Click" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
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
