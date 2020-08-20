<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimerParcial.Default" UICulture="auto" Culture="auto"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <img src="images/image-1.jpg" alt="">
            </div>
            <div class="item">
                <img src="images/image-2.jpg" alt="">
            </div>
            <div class="item">
                <img src="images/image-3.jpg" alt="">
            </div>
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <script type="text/javascript">
        // Call carousel manually
        $('#myCarouselCustom').carousel();

        // Go to the previous item
        $("#prevBtn").click(function () {
            $("#myCarouselCustom").carousel("prev");
        });
        // Go to the previous item
        $("#nextBtn").click(function () {
            $("#myCarouselCustom").carousel("next");
        });
    </script>

    <script type="text/javascript">
        $('.carousel').carousel({
            interval: 3000,
            pause: true,
            wrap: false
        });
    </script>

    <div class="jumbotron text-center" style="background-color:white;">
        <div class="container">
            <h2 ID="lblStudents" runat="server">Nombres de estudiantes:</h2>
        </div>
        <div class="container">
            <h4 ID="lblStudents1" runat="server">Ronald Mora Gómez B64690</h4>
        </div>
        <div class="container"> 
            <h4 ID="lblStudent2">Hilary Ramirez Perez B76212</h4>
        </div>
    </div>

    <nav class="navbar navbar-light bg-light">
        <form class="form-inline">
            <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
        </form>
    </nav>

</asp:Content>
