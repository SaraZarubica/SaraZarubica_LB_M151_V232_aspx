<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SaraZarubica_LB_M151_V232._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Wer wird Millionär?</h1>
        <p class="lead">Hast du Lust es rauszufinden?</p>
        <p class="lead">
            <asp:Button ID="btnPlay" CssClass="btn btn-default"
                runat="server" OnClick="Button1_Click" Text="Spielen" />
        </p>
    </div>

    </asp:Content>
