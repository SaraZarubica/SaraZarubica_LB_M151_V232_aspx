<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerChooseCategory.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.PlayerChooseCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Wähle eine Spielkategorie"></asp:Label>
    </p>
    <p>
        <asp:ListBox ID="lboxC" runat="server" SelectionMode="Multiple">
        </asp:ListBox>
    </p>
    <asp:Button ID="btnStart" CssClass="btn btn-default"
        runat="server" Text="Spiel starten" OnClick="btnStart_Click" />
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
