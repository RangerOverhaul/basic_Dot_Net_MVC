<%@ Page Title="" Language="C#" MasterPageFile="~/Template/template.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GFranca.web.Views.Index.Index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    
    <link href="../../CSS/sweetalert.css" rel="stylesheet"/>
    <script src="../../Scripts/js/sweetalert.min.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenedorPrincipal" runat="server">
     <div class="container-fluid">
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Tables</h1>
        <p class="mb-4">Tabla con la informacion de todos los Tecnicos en la base de datos.</p>
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Tabla de usuarios</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive" style="overflow:auto">
                    <asp:GridView runat="server" ID="dataTable" CssClass="table table-bordered"
                                    Width="100%" AutoGenerateColumns="False"
                                    EmptyDataText="No se encontraron tecnicos"
                                    CellPadding="4" ForeColor="#333333"
                                    GridLines="None"
                                    OnRowCommand="dataTable_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>                           
                            <asp:BoundField HeaderText="Codigo" DataField="codigo"/>
                            <asp:BoundField HeaderText="Nombre" DataField="nombre"/>
                            <asp:BoundField HeaderText="Salario Base" DataField="salario"/>
                            <asp:BoundField HeaderText="Sucursal" DataField="sucursal"/>
                            <asp:BoundField HeaderText="Elementos" DataField="elementos"/>
                            <asp:TemplateField HeaderText="Actualizar">
                                <ItemTemplate>                                  
                                    <asp:ImageButton runat="server" ID="editarDato" ImageUrl="~/Scripts/vendor/fontawesome-free/update.png"
                                                Text="Actualizar" CommandName="Editar" CommandArgument=" <%# ((GridViewRow) Container).RowIndex  %> "/>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>                                  
                                    <asp:ImageButton runat="server" ID="eliminarDato" ImageUrl="~/Scripts/vendor/fontawesome-free/delete.png"
                                                Text="Eliminar" CommandName="Eliminar" CommandArgument=" <%# ((GridViewRow) Container).RowIndex  %> "/>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>