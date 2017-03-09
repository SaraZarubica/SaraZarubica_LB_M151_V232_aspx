<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerLost.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.PlayerLost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Du hast verloren!"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnNewGame" CssClass="btn btn-default"
            runat="server" OnClick="btnNewGame_Click" Text="Neues Spiel" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
