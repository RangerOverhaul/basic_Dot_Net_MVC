<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GFranca.web.Views.Register.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <link href="../../Scripts/vendor/fontawesome-free/css/all.css" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet"/>

    <link href="../../CSS/sb-admin-2.css" rel="stylesheet"/>
    <link href="../../CSS/sweetalert.css" rel="stylesheet"/>
      
    <script src="../../Scripts/vendor/jquery/jquery.min.js"></script>
    <script src="../../Scripts/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <script src="../../Scripts/vendor/jquery-easing/jquery.easing.min.js"></script>

    <script src="../../Scripts/js/sb-admin-2.min.js"></script>
    <script src="../../Scripts/js/sweetalert.min.js"></script> 

    <title>Register</title>
</head>
<body>
     <div class="container-fluid">
        <div class="card o-hidden border-0 shadow-lg ">
            <div class="card-body p-0">                
                    <div class="p-5">
                        <div class="text-center">
                            <h1 class="h4 text-gray-900 mb-4">Agregar nuevo tecnico</h1>
                        </div>
                        <div class="nav-link"/>                                               
                    </div>
                        <form class="user" runat="server">
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="nombre" runat="server" CssClass="form-control form-control-user" placeholder="Nombre"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="codigo" runat="server" CssClass="form-control form-control-user" placeholder="Codigo"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="s_base" runat="server" CssClass="form-control form-control-user" placeholder="Salario"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="sucursal" runat="server" CssClass="form-control form-control-user" placeholder="ID Sucursal"></asp:TextBox>
                                </div>                   
                            </div>
                            <div class="form-group">
                                    <asp:TextBox ID="cantidaEle" runat="server" CssClass="form-control form-control-user" placeholder="Cantidad de elementos"></asp:TextBox>
                                </div>
                            <hr/>                            
                                <p>Elementos disponibles</p>
                                <div class="table-responsive" style="overflow:auto">
                                    <asp:GridView runat="server" ID="ElementDataTable" CssClass="table table-bordered"
                                            Width="100%" AutoGenerateColumns="False"
                                            EmptyDataText="No se encontraron tecnicos" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Codigo de elemento" DataField="codigo"/>
                                            <asp:BoundField HeaderText="Tecnico asignado a elemento" DataField="nombre"/>
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
                                                       
                            <div class="form-group">
                                <h6>Formulario de elementos</h6>
                                <div id="columns" runat="server" style="height: auto; width: 300px; overflow: auto;">
                                </div>                                
                            </div>
                            <div class="my-2"></div>
                            <asp:Button ID="addButton" runat="server" CssClass="btn btn-secondary btn-icon-split btn-block" Text="Agregar elementos" OnClick="addButton_Click"/>    
                            <div class="my-2"></div>
                            <hr/>
                            <asp:Button ID="guardar" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Guardar Tecnico" OnClick="guardar_Click" />                            
                            <hr/>
                            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-danger btn-icon-split btn-block" NavigateUrl="~/Views/Index/Index.aspx" runat="server">
                                <i class="fas fa-fw fa-table"></i>
                                <span>Regresar a tabla de tecnicos</span>
                            </asp:HyperLink>
                        </form>
                    </div>
                </div>
            </div>        
    </div>
</body>
</html>
