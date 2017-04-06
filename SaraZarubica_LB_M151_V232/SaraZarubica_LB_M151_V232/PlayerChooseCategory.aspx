<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerChooseCategory.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.PlayerChooseCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Wähle eine Spielkategorie" Font-Size="Large"></asp:Label>
    </p>
    <p>
        <asp:ListBox ID="lboxC" runat="server" SelectionMode="Multiple">
        </asp:ListBox>
    </p>
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Tipp: Um mehrere Kategorien anzuwählen, halten Sie die ctrl Taste gedrückt."></asp:Label>
    </p>


    <p>
        <asp:TextBox ID="txtBoxError" CssClass="form-control input-lg"
            runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <asp:Button ID="btnStart" CssClass="btn btn-default"
        runat="server" Text="Spiel starten" OnClick="btnStart_Click" />
</asp:Content>
