<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewRecord.aspx.cs" Inherits="PrimerParcial.AddNewRecord" UICulture="auto" Culture="auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-justify" style="background-color: white;">
        <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <asp:Label ID="dateAdd" runat="server" Text="Fecha: "></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="recordDate" runat="server" type="date" class="btn btn-default dropdown-toggle"></asp:TextBox>
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
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="cases" runat="server" Text="Casos: "></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="positives" runat="server" Text="Positivos: "></asp:Label><asp:TextBox ID="txtPositives" runat="server" type="number" min="0" class="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="negatives" runat="server" Text="Negativos: "></asp:Label><asp:TextBox ID="txtNegatives" runat="server" type="number" min="0" class="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="recovered" runat="server" Text="Recuperados: "></asp:Label><asp:TextBox ID="txtRecovered" runat="server" type="number" min="0" class="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="deads" runat="server" Text="Fallecimientos: "></asp:Label><asp:TextBox ID="txtDeads" runat="server" type="number" min="0" class="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnAdd" runat="server" Text="Agregar" class="btn btn-default"  style="background-color:lightblue;" OnClick="btnAdd_Click" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>

    <div class="jumbotron text-justify" style="background-color: white;">
        <asp:GridView ID="grdRecords" runat="server" class="table table-striped" OnRowCreated="grdRecords_RowCreated" OnRowDeleting="grdRecords_RowDeleting">
            <Columns>
                <asp:CommandField ButtonType="Link" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Guardar" class="btn btn-default"  style="background-color:lightblue;" OnClick="btnSave_Click" Visible="False" />
    </div>

    <%--<br />
    <br />
    <asp:Label ID="dateAdd" runat="server" Text="Fecha: "></asp:Label>
    <br />
    <asp:TextBox ID="recordDate" runat="server" type="date"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="province" runat="server" Text="Provincia: "></asp:Label>
    <br />
    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="canton" runat="server" Text="Cantón: "></asp:Label>
    <br />
    <asp:DropDownList ID="ddlCanton" runat="server"></asp:DropDownList>
    <br />
    <br />
    <br />
    <asp:Label ID="cases" runat="server" Text="Casos: "></asp:Label>
    <br />
    <br />
    <asp:Label ID="positives" runat="server" Text="Positivos: "></asp:Label><asp:TextBox ID="txtPositives" runat="server" type="number" min="0"></asp:TextBox>
    <br />
    <asp:Label ID="negatives" runat="server" Text="Negativos: "></asp:Label><asp:TextBox ID="txtNegatives" runat="server" type="number" min="0"></asp:TextBox>
    <br />
    <asp:Label ID="recovered" runat="server" Text="Recuperados: "></asp:Label><asp:TextBox ID="txtRecovered" runat="server" type="number" min="0"></asp:TextBox>
    <br />
    <asp:Label ID="deads" runat="server" Text="Fallecimientos: "></asp:Label><asp:TextBox ID="txtDeads" runat="server" type="number" min="0"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="btnAdd_Click" />
    <br />
    <br />
    <asp:GridView ID="grdRecords" runat="server" OnRowCreated="grdRecords_RowCreated" OnRowDeleting="grdRecords_RowDeleting">
        <Columns>
            <asp:CommandField ButtonType="Link" ShowDeleteButton="true"/>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" Visible="False" />--%>
</asp:Content>
