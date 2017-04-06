<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerHighScoreList.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.PlayerHighScoreList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Highscore" Font-Size="Large"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvHighscore" EmptyDataText="Keine Daten vorhanden" AutoGenerateColumns="false" CssClass= "table table-striped table-bordered table-condensed" runat="server" OnRowDataBound="gvHighscore_RowDataBound">
            <Columns>                  
                <asp:BoundField DataField="Rang" HeaderText="Rang" ReadOnly="true"/>                    
                <asp:BoundField DataField="WeightedPoints"  HeaderText="Gewichtete Punkte" ReadOnly="true"/>
                <asp:BoundField DataField="Name"  HeaderText="Name" ReadOnly="true"/>
                <asp:BoundField DataField="MomentOfGame"  HeaderText="Zeitpunkt" ReadOnly="true"/>
                <asp:BoundField DataField="Points"  HeaderText="Punkte" ReadOnly="true"/>
                <asp:BoundField DataField="GameDuration"  HeaderText="Dauer in Sekunden" ReadOnly="true"/>
                <asp:BoundField DataField="CategoryName"  HeaderText="Kategorien" ReadOnly="true"/>
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
