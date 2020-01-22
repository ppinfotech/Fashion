<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Fabric.aspx.cs" Inherits="Fashion.Fabric" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xl-12 py-5 px-md-5">
        <div class="row pt-md-4">
            <div class="col-md-12">

                <div class="sidebar-box ftco-animate">
                    <h3 class="sidebar-heading">Our All Fabrics</h3>
                    <div class="blog-entry ftco-animate d-md-flex row">

                        <div class="col-md-12">
                            <h3>Select Fabric
                                <asp:DropDownList ID="ddlFabric" CssClass="form-control" OnSelectedIndexChanged="ddlFabric_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList></h3>
                        </div>
                    </div>
                    <div class="blog-entry ftco-animate d-md-flex">
                        <div class="row" id="divFabric" runat="server">
                            <%--<div class="col-md-4"><a href="Lending.aspx?val=1"><img src="" /></a></div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
