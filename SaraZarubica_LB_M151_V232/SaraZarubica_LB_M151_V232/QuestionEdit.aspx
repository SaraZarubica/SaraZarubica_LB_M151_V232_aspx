<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionEdit.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.QuestionEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:HiddenField ID="hiddenQId" runat="server" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Kategorie"></asp:Label>
        <asp:DropDownList ID="ddListCategories" CssClass="form-control"
            runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Frage"></asp:Label>
        <asp:TextBox ID="txtBoxQ" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Antwort 1</p>
    <p>
        <asp:HiddenField ID="hiddenA1" runat="server" />
        <asp:Label ID="Label3" runat="server" Text="Antwort"></asp:Label>
        <asp:TextBox ID="txtBoxA1" runat="server"></asp:TextBox>
    </p>
    <p>
        Richtigkeit:
        <asp:DropDownList ID="ddA1" CssClass="form-control"
            runat="server">
            <asp:ListItem Value="0">Falsch</asp:ListItem>
            <asp:ListItem Value="1">Richtig</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Antwort 2</p>
    <p>
        <asp:HiddenField ID="hiddenA2" runat="server" />
        <asp:Label ID="Label4" runat="server" Text="Antwort"></asp:Label>
        <asp:TextBox ID="txtBoxA2" runat="server"></asp:TextBox>
    </p>
    <p>
        Richtigkeit:
        <asp:DropDownList ID="ddA2" CssClass="form-control"
            runat="server" Width="73px">
            <asp:ListItem Value="0">Falsch</asp:ListItem>
            <asp:ListItem Value="1">Richtig</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Antwort 3</p>
    <p>
        <asp:HiddenField ID="hiddenA3" runat="server" />
        <asp:Label ID="Label5" runat="server" Text="Antwort"></asp:Label>
        <asp:TextBox ID="txtBoxA3" runat="server"></asp:TextBox>
    </p>
    <p>
        Richtigkeit:
        <asp:DropDownList ID="ddA3" CssClass="form-control"
            runat="server">
            <asp:ListItem Value="0">Falsch</asp:ListItem>
            <asp:ListItem Value="1">Richtig</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Antwort 4</p>
    <p>
        <asp:HiddenField ID="hiddenA4" runat="server" />
        <asp:Label ID="Label6" runat="server" Text="Antwort"></asp:Label>
        <asp:TextBox ID="txtBoxA4" runat="server"></asp:TextBox>
    </p>
    <p>
        Richtigkeit:
        <asp:DropDownList ID="ddA4" CssClass="form-control"
            runat="server">
            <asp:ListItem Value="0">Falsch</asp:ListItem>
            <asp:ListItem Value="1">Richtig</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:TextBox ID="txtBoxError" CssClass="form-control input-lg"
            TextMode="MultiLine" Visible="false"  runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSave"
             CssClass="btn btn-default" runat="server" Text="Speichern" OnClick="btnSave_Click" />
        <asp:Button ID="btnDelete" CssClass="btn btn-default" runat="server" Text="Löschen" OnClick="btnDelete_Click" Visible="False" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnBack" CssClass="btn btn-default"
            runat="server" Text="Abbrechen" OnClick="btnBack_Click" />
    </p>
    <p>
    </p>
</asp:Content>
