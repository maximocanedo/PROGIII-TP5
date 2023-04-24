﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursales.aspx.cs" Inherits="TrabajoPractico5.ListadoSucursales" %>

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
    <form id="form1" class="agregarSucursal" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="links-container">
            <asp:HyperLink runat="server" CssClass="mdc-chip" href="./AgregarSucursal.html">Agregar sucursal</asp:HyperLink>
            <asp:HyperLink runat="server" CssClass="mdc-chip" href="./ListadoSucursales.html">Listado de sucursales</asp:HyperLink>
            <asp:HyperLink runat="server" CssClass="mdc-chip" href="./EliminarSucursal.html">Eliminar sucursal</asp:HyperLink>
        </div>
        <br>
        <h1 class="mdc-typography--headline4">Grupo N.º 5</h1>
        <h2 class="mdc-typography--subtitle1">Listado de sucursales</h2>
        <div class="flex-horizontal">
            <label class="mdc-text-field mdc-text-field--outlined">
                <span class="mdc-notched-outline">
                  <span class="mdc-notched-outline__leading"></span>
                  <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="my-label-id1">Buscar por ID</span>
                  </span>
                  <span class="mdc-notched-outline__trailing"></span>
                </span>
                <asp:TextBox ID="tbBuscarPorID" CssClass="mdc-text-field__input" aria-labelledby="my-label-id1" runat="server"></asp:TextBox>
              </label>
            <asp:Button ID="btnBuscar" CssClass="mdc-button mdc-button--raised" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>
        <br />
        <asp:GridView ID="GridView1" CssClass="mdc-typography--body2" runat="server"></asp:GridView>

        <aside class="mdc-snackbar">
            <div class="mdc-snackbar__surface" role="status" aria-relevant="additions">
              <div class="mdc-snackbar__label" aria-atomic="false">
                Mensaje
              </div>
            </div>
          </aside>
    </form>
</body>
</html>