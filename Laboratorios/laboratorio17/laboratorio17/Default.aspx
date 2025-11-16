<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="laboratorio17._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  

        <div class="row">
            <div>
                <asp:GridView ID="MyridView" DataSourceID="MyDataSource1"
                    AllowSorting="true" AllowPaging="true"
                    DataKeyNames="ProductID"
                    AutoGenerateEditButton="true"
                    Runat="Server"/> 
            </div>
            <asp:SqlDataSource ID="MyDataSource1" runat="server"
                ConnectionString="data source=DESKTOP-EF8UT5E;initial catalog=northwind;persist security info=True;Integrated Security=SSPI;"
                ProviderName="System.Data.SqlClient"
                SelectCommand="SELECT ProductId, ProductName, UnitPrice From Products"
                UpdateCommand="Update Products Set [ProductName]=@ProductName,[UnitPrice]=@UnitPrice where [ProductId]=@ProductId">

            </asp:SqlDataSource>
        </div>

</asp:Content>
