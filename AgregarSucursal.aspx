<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="TrabajoPractico5.AgregarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Material Design</title>
    <link href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" rel="stylesheet" />
    <script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link href="./styles.css" rel="stylesheet" />
    <script src="./index.js"></script>
</head>
<body>
    <form id="form1" action="#" class="agregarSucursal" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="links-container">
            <asp:HyperLink runat="server" CssClass="mdc-chip" href="./AgregarSucursal.aspx">Agregar sucursal</asp:HyperLink>
            <asp:HyperLink runat="server" CssClass="mdc-chip" href="./ListadoSucursales.aspx">Listado de sucursales</asp:HyperLink>
            <asp:HyperLink runat="server" CssClass="mdc-chip" href="./EliminarSucursal.aspx">Eliminar sucursal</asp:HyperLink>
        </div>
        <br>
        <h1 class="mdc-typography--headline4">Grupo N.º 5</h1>
        <h2 class="mdc-typography--subtitle1">Agregar sucursal</h2>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="my-label-id1">Nombre de sucursal</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- TextBox @tbNombreSucursal -->
            <asp:TextBox ID="tbNombreSucursal" CssClass="mdc-text-field__input" aria-labelledby="my-label-id1" runat="server"></asp:TextBox>
        </label>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="descripcion">Descripción</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- TextBox @tbDescripcion -->
            <asp:TextBox ID="tbDescripcion" aria-labelledby="descripcion" CssClass="mdc-text-field__input" runat="server"></asp:TextBox>
        </label>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="my-label-id3">Provincia</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- DropDownList @ddlProvincias -->
            <asp:DropDownList ID="ddlProvincias" CssClass="mdc-text-field__input" aria-labelledby="my-label-id3" runat="server">
                <asp:ListItem>Buenos Aires</asp:ListItem>
                <asp:ListItem>Córdoba</asp:ListItem>
                <asp:ListItem>Santa Fe</asp:ListItem>
                <asp:ListItem>Mendoza</asp:ListItem>
                <asp:ListItem>Entre Ríos</asp:ListItem>
            </asp:DropDownList>
        </label>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="direccion">Dirección</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- TextBox @tbDireccion -->
            <asp:TextBox ID="tbDireccion" CssClass="mdc-text-field__input" aria-labelledby="direccion" runat="server"></asp:TextBox>
        </label>
        <br />
        <asp:Button ID="btnAceptar" CssClass="mdc-button mdc-button--raised" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" UseSubmitBehavior="False" />

        <aside class="mdc-snackbar">
            <div class="mdc-snackbar__surface" role="status" aria-relevant="additions">
                <div class="mdc-snackbar__label" aria-atomic="false"></div>
            </div>
        </aside>
    </form>
</body>
</html>
