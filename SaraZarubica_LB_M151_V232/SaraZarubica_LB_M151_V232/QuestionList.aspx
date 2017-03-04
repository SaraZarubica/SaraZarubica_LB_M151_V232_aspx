<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.QuestionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <asp:GridView ID="gvQuestions" runat="server" OnRowDataBound="gvQuestions_RowDataBound" OnSelectedIndexChanged="gvQuestions_SelectedIndexChanged">
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>
