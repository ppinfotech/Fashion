<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Color.aspx.cs" Inherits="Fashion.Color" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xl-12 py-5 px-md-5">
        <div class="row pt-md-4">
            <div class="col-md-12">
                <h3>Color Chart</h3><br />
                <div class="blog-entry ftco-animate d-md-flex">
                    
                    <div id="divColorChart" runat="server" class="row"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
