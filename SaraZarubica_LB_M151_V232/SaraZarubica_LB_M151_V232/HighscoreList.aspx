<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HighscoreList.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.HighscoreList" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:GridView ID="gvHighscore" AutoGenerateColumns="false" CssClass= "table table-striped table-bordered table-condensed"  runat="server" OnRowDataBound="gvHighscore_RowDataBound" OnSelectedIndexChanged="gvHighscore_SelectedIndexChanged" Width="1308px">
        <Columns>                  
            <asp:BoundField DataField="Rang" HeaderText="Rang" ReadOnly="true"/>                    
            <asp:BoundField DataField="WeightedPoints"  HeaderText="Gewichtete Punkte" ReadOnly="true"/>
            <asp:BoundField DataField="Name"  HeaderText="Name" ReadOnly="true"/>
            <asp:BoundField DataField="MomentOfGame"  HeaderText="Zeitpunkt" ReadOnly="true"/>
            <asp:BoundField DataField="Points"  HeaderText="Punkte" ReadOnly="true"/>
            <asp:BoundField DataField="GameDuration"  HeaderText="Dauer" ReadOnly="true"/>
            <asp:BoundField DataField="CategoryName"  HeaderText="Kategorien" ReadOnly="true"/>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnBack" CssClass="btn btn-default" runat="server" Text="Zurück" OnClick="btnBack_Click" />

</asp:Content>
