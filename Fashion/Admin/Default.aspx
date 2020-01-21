<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fashion.Admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <title>Login Page - Fashion</title>
    <link rel="apple-touch-icon" sizes="60x60" href="app-assets/images/ico/apple-icon-60.png">
    <link rel="apple-touch-icon" sizes="76x76" href="app-assets/images/ico/apple-icon-76.png">
    <link rel="apple-touch-icon" sizes="120x120" href="app-assets/images/ico/apple-icon-120.png">
    <link rel="apple-touch-icon" sizes="152x152" href="app-assets/images/ico/apple-icon-152.png">

    <link rel="shortcut icon" type="image/png" href="app-assets/images/ico/favicon-32.png">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-touch-fullscreen" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <!-- BEGIN VENDOR CSS-->
    <link rel="stylesheet" type="text/css" href="app-assets/css/bootstrap.css">
    <!-- font icons-->
    <link rel="stylesheet" type="text/css" href="app-assets/fonts/icomoon.css">
    <link rel="stylesheet" type="text/css" href="app-assets/fonts/flag-icon-css/css/flag-icon.min.css">
    <link rel="stylesheet" type="text/css" href="app-assets/vendors/css/extensions/pace.css">
    <!-- END VENDOR CSS-->
    <!-- BEGIN ROBUST CSS-->
    <link rel="stylesheet" type="text/css" href="app-assets/css/bootstrap-extended.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/app.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/colors.css">
    <!-- END ROBUST CSS-->
    <!-- BEGIN Page Level CSS-->
    <link rel="stylesheet" type="text/css" href="app-assets/css/core/menu/menu-types/vertical-menu.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/core/menu/menu-types/vertical-overlay-menu.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/pages/login-register.css">
    <!-- END Page Level CSS-->
    <!-- BEGIN Custom CSS-->
    <link rel="stylesheet" type="text/css" href="assets/css/style.css">

    <!-- END Custom CSS-->
</head>
<body data-open="click" data-menu="vertical-menu" data-col="1-column" class="vertical-layout vertical-menu 1-column  blank-page blank-page" style="background-image: url('logo.png'); background-size: 100px;">
    <form id="form1" runat="server">
        <div class="app-content content container-fluid">
            <div class="content-wrapper">
                <div class="content-header row">
                </div>
                <div class="content-body">
                    <section class="flexbox-container">
                        <div class="col-md-4 offset-md-4 col-xs-10 offset-xs-1  box-shadow-2 p-0">
                            <div class="card border-grey border-lighten-3 m-0">
                                <div class="card-header no-border">
                                    <div class="card-title text-xs-center">
                                        <div class="p-1">
                                            <img src="../images/logo.jpeg" width="245" alt="Trial Room" />
                                            <%--<p style="color: darkblue; font-size: 40px; font-family: 'Segoe UI'">Trial Room</p>--%>
                                        </div>
                                    </div>
                                    <h6 class="card-subtitle line-on-side text-muted text-xs-center font-small-3 pt-2"><span>Login with Fashion</span></h6>
                                </div>
                                <div class="card-body collapse in">
                                    <div class="card-block">
                                        <div class="form-horizontal form-simple" novalidate>
                                            <div class="alert alert-danger mb-2" role="alert" id="divAlert" runat="server" visible="false">
                                            </div>
                                            <fieldset class="form-group position-relative has-icon-left mb-0">
                                                <asp:TextBox ID="txtUserName" CssClass="form-control form-control-lg input-lg" runat="server" placeholder="Your Username" required></asp:TextBox>

                                                <div class="form-control-position">
                                                    <i class="icon-head"></i>
                                                </div>
                                            </fieldset>
                                            <fieldset class="form-group position-relative has-icon-left">
                                                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control form-control-lg input-lg" runat="server" placeholder="Enter Password" required></asp:TextBox>
                                                <div class="form-control-position">
                                                    <i class="icon-key3"></i>
                                                </div>
                                            </fieldset>
                                            <fieldset class="form-group row">
                                                <div class="col-md-6 col-xs-12 text-xs-center text-md-left">
                                                    <%--<fieldset>
                                                        <input type="checkbox" id="remember-me" class="chk-remember">
                                                        <label for="remember-me">Remember Me</label>
                                                    </fieldset>--%>
                                                </div>
                                                <%--<div class="col-md-6 col-xs-12 text-xs-center text-md-right"><a href="ForgotPassword.aspx" class="card-link">Forgot Password?</a></div>--%>
                                            </fieldset>
                                            <%--<i class="icon-unlock2"></i>--%>
                                            <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnLogin_Click" runat="server" Text="Login" />
                                            <br />
                                            <center><h4 ><a href="https://www.ppinfotech.com" class="card-link">Powered by PPInfotech</a></h4></center>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="card-footer">
                                    <div class="">
                                        <p class="float-sm-left text-xs-center m-0"><a href="recover-password.html" class="card-link">Recover password</a></p>
                                        <p class="float-sm-right text-xs-center m-0">New to Robust? <a href="register-simple.html" class="card-link">Sign Up</a></p>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
        <!-- BEGIN VENDOR JS-->
        <script src="app-assets/js/core/libraries/jquery.min.js" type="text/javascript"></script>
        <script src="app-assets/vendors/js/ui/tether.min.js" type="text/javascript"></script>
        <script src="app-assets/js/core/libraries/bootstrap.min.js" type="text/javascript"></script>
        <script src="app-assets/vendors/js/ui/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
        <script src="app-assets/vendors/js/ui/unison.min.js" type="text/javascript"></script>
        <script src="app-assets/vendors/js/ui/blockUI.min.js" type="text/javascript"></script>
        <script src="app-assets/vendors/js/ui/jquery.matchHeight-min.js" type="text/javascript"></script>
        <script src="app-assets/vendors/js/ui/screenfull.min.js" type="text/javascript"></script>
        <script src="app-assets/vendors/js/extensions/pace.min.js" type="text/javascript"></script>
        <!-- BEGIN VENDOR JS-->
        <!-- BEGIN PAGE VENDOR JS-->
        <!-- END PAGE VENDOR JS-->
        <!-- BEGIN ROBUST JS-->
        <script src="app-assets/js/core/app-menu.js" type="text/javascript"></script>
        <script src="app-assets/js/core/app.js" type="text/javascript"></script>
        <!-- END ROBUST JS-->
        <!-- BEGIN PAGE LEVEL JS-->
        <!-- END PAGE LEVEL JS-->
    </form>
</body>
</html>
