<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowSpecificData.aspx.cs" Inherits="PrimerParcial.ShowSpecificData" UICulture="auto" Culture="auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-justify" style="background-color: white;">
        <div class="container">
            <div class="row">
                <asp:Label ID="dateSearch" runat="server" Text="Rango de fechas: "></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblsince" runat="server" Text="Desde: "></asp:Label>
                <br />
                <asp:TextBox ID="since" runat="server" type="date" class="btn btn-default dropdown-toggle"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lbluntil" runat="server" Text="Hasta: "></asp:Label>
                <br />
                <asp:TextBox ID="until" runat="server" type="date" class="btn btn-default dropdown-toggle"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="province" runat="server" Text="Provincia: "></asp:Label>
                <br />
                <br />
                <asp:DropDownList ID="ddlProvince" runat="server" class="btn btn-default dropdown-toggle" type="button" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="canton" runat="server" Text="Cantón: "></asp:Label>
                <br />
                <br />
                <asp:DropDownList ID="ddlCanton" runat="server" class="btn btn-default dropdown-toggle" type="button"></asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" class="btn btn-default"  style="background-color:lightblue;" OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>

    <div class="jumbotron text-justify" style="background-color: white;">
        <asp:GridView ID="recordsFound" runat="server" class="table table-striped" Visible="False"></asp:GridView>
    </div>
    
    <%--<br />
    <br />
    <asp:Label ID="dateSearch" runat="server" Text="Rango de fechas: "></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblsince" runat="server" Text="Desde: "></asp:Label>
    <asp:TextBox ID="since" runat="server" type="date"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbluntil" runat="server" Text="Hasta: "></asp:Label>
    <asp:TextBox ID="until" runat="server" type="date"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="province" runat="server" Text="Provincia: "></asp:Label>
    <br />
    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="canton" runat="server" Text="Cantón: "></asp:Label>
    <br />
    <asp:DropDownList ID="ddlCanton" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" />
    <br />
    <br />
    <asp:GridView ID="recordsFound" runat="server" Visible="False"></asp:GridView>--%>
</asp:Content>
