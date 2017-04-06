<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.Game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;&nbsp;&nbsp;</p>
    <p>
        <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Wer wird Millionär?"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblQ" runat="server" Text="Frage"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn50Joker" CssClass="btn btn-default"
            runat="server" Text="50:50" OnClick="btn50Joker_Click" />
        <br />
        
    </p>
    <asp:Button ID="btnA1" CssClass="btn btn-default"
        runat="server" Height="36px" OnClick="btnA1_Click" Text="Antwort" Width="150px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnA2" CssClass="btn btn-default"
        runat="server" OnClick="btnA2_Click" Text="Antwort" Width="150px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Punkte:"></asp:Label>
    <asp:Label ID="lblPoints" runat="server" Text="0"></asp:Label>
    <p>
        <asp:Button ID="btnA3" CssClass="btn btn-default"
            runat="server" OnClick="btnA3_Click" Text="Antwort" Width="150px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnA4" CssClass="btn btn-default"
            runat="server" OnClick="btnA4_Click" Text="Antwort" Width="150px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Frage wurde richtig beantwortet zu:"></asp:Label>
        <asp:Label ID="lblATrue" runat="server" Text="0"></asp:Label> </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnStop" CssClass="btn btn-default"
            runat="server" OnClick="btnStop_Click" Text="Aufhören" />
    </p>
    <asp:HiddenField ID="hiddenA" runat="server" />
    <p>
        <asp:HiddenField ID="hiddenA1" runat="server" />
        <asp:HiddenField ID="hiddenA2" runat="server" />
        <asp:HiddenField ID="hiddenA3" runat="server" />
        <asp:HiddenField ID="hiddenA4" runat="server" />
        <asp:HiddenField ID="hiddenQId" runat="server" />
        <asp:HiddenField ID="hidden5050Set" runat="server" />
    </p>
</asp:Content>
