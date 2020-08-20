<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sesion.aspx.cs" Inherits="PrimerParcial.Sesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-1">
        <div class="container text-center">
            <h3>Inicie sesión para poder agregar casos</h3>
            <img src="images/usa.png" alt="Bird" width="350" height="350">
        </div>
        <div class="container">
            <h2>Inicio de sesión</h2>
            <form class="form-horizontal" action="~/AddNewRecord.aspx">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="email">Email:</label>
                    <div class="col-sm-10">
                        <input type="email" class="form-control" id="email" placeholder="Enter email" name="email">
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="pwd">Password:</label>
                    <div class="col-sm-10">
                        <input type="password" class="form-control" id="pwd" placeholder="Enter password" name="pwd">
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="remember">
                                Remember me</label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <button type="submit" class="btn btn-default">Iniciar Sesión</button>
                    </div>
                </div>
            </form>
        </div>
    </div>

    <div class="container-fluid bg-2 text-center">
        <h3>Si no posee una cuenta puede registrarse</h3>
        <a id="btnRegister" href="#" class="btn btn-default btn-lg" runat="server">Registrase</a>
    </div>
</asp:Content>
