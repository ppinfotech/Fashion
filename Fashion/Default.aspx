<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fashion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/jscolor.js"></script>

    <link href="Content/myStyle.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript" src="js/webcam.js"></script>

    <script type="text/javascript">
        function fillBG(imgFabric) {

            document.getElementById("imgMain").style.backgroundImage = 'url(' + imgFabric.src + ')';
        }
        function changeSize(txtSize) {

            document.getElementById("imgMain").style.backgroundSize = txtSize.value + 'px';
        }
        function fillColor(txtColor) {

            //document.getElementById("divBG").style.backgroundColor = txtColor.value;

            var style = document.createElement('style');
            style.type = 'text/css';
            style.innerHTML = '.container1 { background-color: ' + txtColor.value + '; } .container1 img {mix-blend-mode: lighten;}';
            document.getElementById('cssClasses').innerHTML = '<style type="text/css">.container1 { background-color: ' + txtColor.value + '; } .container1 img {mix-blend-mode: lighten;}</style>';
            document.getElementById('divBG').className = 'container1';
        }
        function RemoveColor() {
            document.getElementById('divBG').className = '';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="cssClasses">
        <style></style>
    </div>
    <div class="col-xl-8 py-5 px-md-5">
        <div class="row pt-md-4">
            <div class="col-md-12">
                <div class="blog-entry ftco-animate d-md-flex">
                    <div class="row">
                        <div class="col-md-6" style="text-align: center;">
                            <div id="my_camera"></div>
                            <script language="JavaScript">
                                Webcam.set({
                                    width: 450,
                                    height: 100,

                                    image_format: 'jpeg',
                                    jpeg_quality: 100
                                });
                                Webcam.attach('#my_camera');
                            </script>
                            <div id="divBG">
                                <img src="main2.png" id="imgMain" style="background-image: url('f3.jpg'); background-repeat: repeat; width: 100%; background-size: 200px;" />
                            </div>
                        </div>



                        <div class="col-md-6">
                            Select Fabric<br />
                            <br />
                            <img src="f1.jpg" height="100" onclick="fillBG(this)" />
                            <img src="f2.jpg" height="100" onclick="fillBG(this)" />
                            <img src="f3.jpg" height="100" onclick="fillBG(this)" />
                            <img src="f4.jpg" height="100" onclick="fillBG(this)" />
                            <img src="f5.jpg" height="100" onclick="fillBG(this)" />
                            <img src="f6.jpg" height="100" onclick="fillBG(this)" />
                            <img src="f7.jpg" height="100" onclick="fillBG(this)" />
                            <img src="f8.jpg" height="100" onclick="fillBG(this)" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
        </div>
    </div>
    <div class="col-xl-4 sidebar ftco-animate bg-light pt-5">

        <div class="sidebar-box ftco-animate">
            <h3 class="sidebar-heading">Fabric Size:<input type="number" value="200" id="size" onchange="changeSize(this)" /></h3>
            <h3 class="sidebar-heading">Fabric Color:
            <asp:TextBox ID="txtColor" TextMode="Color" onchange="fillColor(this)" ClientIDMode="Static" runat="server"></asp:TextBox></h3>
            <input type="button" class="btn btn-primary" value="Remove Fabric Color" onclick="RemoveColor()" />
            <br />
            <br />
            <h3 class="sidebar-heading">Select Color Code</h3>
            <div id="divColorChart" runat="server" class="row" style="overflow-y: scroll; max-height: 200px;"></div>

        </div>
    </div>
</asp:Content>
