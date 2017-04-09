<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.CategoryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:HiddenField ID="HiddenCId" runat="server" />
        </p>
        <p>
            <asp:Label ID="Kategorie" runat="server" Text="Kategorie" Font-Size="Medium"></asp:Label>
        </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Kategorie"></asp:Label>
        <asp:TextBox ID="txtBoxC" CssClass="form-control input-lg"
            runat="server" required="required"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnSave" CssClass="btn btn-default"
            runat="server" Text="Speichern" OnClick="btnSave_Click1" />
        <asp:Button ID="btnDelete" CssClass="btn btn-default"
             runat="server" OnClick="btnDelete_Click" Text="Löschen" Visible="False" />
    </p>
    <p>
        <asp:TextBox ID="txtBoxError" CssClass="form-control input-lg"
            runat="server" 
            TextMode="MultiLine" Visible="False"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnBack" CssClass="btn btn-default"
            runat="server" Text="Abbrechen" OnClick="btnBack_Click" />
    </p>
</asp:Content>
