<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="SaraZarubica_LB_M151_V232.QuestionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:GridView ID="gvQuestions" CssClass= "table table-striped table-bordered table-condensed"
            runat="server" AutoGenerateColumns="false"
            OnRowDataBound="gvQuestions_RowDataBound" OnSelectedIndexChanged="gvQuestions_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="QuestionText" HeaderText="Frage" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnAdd" CssClass="btn btn-default" runat="server" Text="Frage hinzufügen" OnClick="btnAdd_Click" />
    </p>
    <p>
        <asp:Button ID="btnBack" CssClass="btn btn-default"
            runat="server" Text="Zurück" OnClick="btnBack_Click" />
    </p>
</asp:Content>
