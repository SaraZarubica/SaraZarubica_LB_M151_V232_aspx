<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HighscoreEdit.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.HighscoreEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <br />
        <asp:Label ID="Label8" runat="server" Font-Size="Large" Text="Highscore Eintrag"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Rang:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRank" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Gewichtete Punkte:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblWeightedPoints" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Name Spieler:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Zeitpunkt Spiel:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMomentOfGame" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Punkte:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPoints" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Dauer Spiel:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDurationGame" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label7" runat="server" Text="Gewählte Kategorien:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCategories" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnDelete" CssClass="btn btn-default" runat="server" Text="Löschen" OnClick="btnDelete_Click" />
    </p>
    <p>
        <asp:Button ID="btnBack" CssClass="btn btn-default" runat="server" Text="Zurück" OnClick="btnBack_Click" />
    </p>
</asp:Content>
