<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowGeneralInformation.aspx.cs" Inherits="PrimerParcial.ShowGeneralInformation" UICulture="auto" Culture="auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-justify" style="background-color: white;">
        <div class="container">
            <div class="row">
                <asp:GridView ID="grdGeneral" runat="server" class="table table-striped" OnRowCreated="RowCreated"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
