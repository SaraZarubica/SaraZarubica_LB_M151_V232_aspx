<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerWinOrStop.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.PlayerWinOrStop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblWinOrStop" runat="server" Text="Label" Font-Size="Large"></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Geben Sie Ihren Namen für die Highscoreliste ein:"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtBoxHName" CssClass="form-control input-lg" runat="server" Width="304px" Height="16px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="txtBoxError" CssClass="form-control input-lg" runat="server" Visible="False" Width="303px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnOk" CssClass="btn btn-default" runat="server" Text="Bestätigen" OnClick="btnOk_Click" />
    </p>
</asp:Content>
