<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionEdit.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.QuestionEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <p>
        <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Frage"></asp:Label>
        <br />
        <asp:HiddenField ID="hiddenQId" runat="server" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Kategorie"></asp:Label>
        <br />
        <asp:DropDownList ID="ddListCategories" CssClass="form-control"
            runat="server" Width="150px">
        </asp:DropDownList>
    </p>
    <p></p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Frage"></asp:Label>
        <br />
        <asp:TextBox ID="txtBoxQ" CssClass="form-control input-lg" runat="server" Height="30px" Width="300px"></asp:TextBox>
    </p>
    <br />
    <p>
        Antwort 1
        <asp:HiddenField ID="hiddenA1" runat="server" />
        <br />
        <asp:TextBox ID="txtBoxA1" CssClass="form-control input-lg" runat="server" Height="30px" Width="300px"></asp:TextBox>
        
        Richtigkeit:
        <br />
        <asp:DropDownList ID="ddA1" CssClass="form-control"
            runat="server" Width="100px">
            <asp:ListItem Value="0">Falsch</asp:ListItem>
            <asp:ListItem Value="1">Richtig</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p></p>
    <p>
        Antwort 2
        <asp:HiddenField ID="hiddenA2" runat="server" />
        <br />
        <asp:TextBox ID="txtBoxA2" CssClass="form-control input-lg" runat="server" Height="30px" Width="300px"></asp:TextBox>
        
        Richtigkeit:
        <br />
        <asp:DropDownList ID="ddA2" CssClass="form-control"
            runat="server" Width="100px">
            <asp:ListItem Value="0">Falsch</asp:ListItem>
            <asp:ListItem Value="1">Richtig</asp:ListItem>
        </asp:DropDownList>
        <br />
    </p>
    <p></p>
    <p>
        Antwort 3
        <br />
        <asp:HiddenField ID="hiddenA3" runat="server" />
        <asp:TextBox ID="txtBoxA3" CssClass="form-control input-lg" runat="server" Height="30px" Width="300px"></asp:TextBox>
        
        Richtigkeit:
        <br />
        <asp:DropDownList ID="ddA3" CssClass="form-control"
            runat="server" Width="100px">
            <asp:ListItem Value="0">Falsch</asp:ListItem>
            <asp:ListItem Value="1">Richtig</asp:ListItem>
        </asp:DropDownList>
        <br />
    </p>
    <p></p>
        Antwort 4
        <br />
        <asp:HiddenField ID="hiddenA4" runat="server" />
        <asp:TextBox ID="txtBoxA4" CssClass="form-control input-lg" runat="server" Height="30px" Width="299px"></asp:TextBox>
        
        Richtigkeit:
        <br />
        <asp:DropDownList ID="ddA4" CssClass="form-control"
            runat="server" Width="100px">
            <asp:ListItem Value="0">Falsch</asp:ListItem>
            <asp:ListItem Value="1">Richtig</asp:ListItem>
        </asp:DropDownList>

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
        <asp:Button ID="btnBack" CssClass="btn btn-default"
            runat="server" Text="Abbrechen" OnClick="btnBack_Click" />
    </p>
</asp:Content>
