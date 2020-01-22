<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Lending.aspx.cs" Inherits="Fashion.Lending" %>

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
        function fillPallet(colorcode) {
            var clr = colorcode.innerHTML;
            document.getElementById("txtColor").value = clr;
            fillColor(document.getElementById("txtColor"));
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
                        <div class="col-md-12">
                            <center><div id="my_camera" ></div></center>
                            <script language="JavaScript">
                                Webcam.set({
                                    width: 500,
                                    height: 150,

                                    image_format: 'jpeg',
                                    jpeg_quality: 100
                                });
                                Webcam.attach('#my_camera');
                            </script>
                            <div id="divMain" runat="server">
                            </div>

                        </div>

                        <div class="col-md-12">
                            <div class="sidebar-box ftco-animate">
                                <h3 class="sidebar-heading">Fabric Size:<input type="number" value="200" id="size" onchange="changeSize(this)" class="form-control-sm" /></h3>
                                <h3 class="sidebar-heading">Fabric Color:
                                <asp:TextBox ID="txtColor" TextMode="Color" onchange="fillColor(this)" ClientIDMode="Static" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;<input type="button" class="btn btn-primary" value="Remove Fabric Color" onclick="RemoveColor()" /></h3>
                                <h3 class="sidebar-heading">Select Color Code</h3>
                                <div id="divColorChart" runat="server" class="row" style="overflow-y: scroll; max-height: 200px;"></div>
                            </div>
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
            <h3 class="sidebar-heading">Select Fabric
                <asp:DropDownList ID="ddlFabric" CssClass="form-control" OnSelectedIndexChanged="ddlFabric_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList></h3>

            <div id="divFabric" runat="server" class="row">
                
            </div>

        </div>
    </div>

</asp:Content>
