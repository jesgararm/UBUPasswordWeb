<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="www.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 198px;
        }
        .auto-style3 {
            height: 23px;
            width: 198px;
            color: #0033CC;
        }
        .auto-style4 {
            width: 198px;
            color: #0033CC;
        }
        .auto-style5 {
            width: 210px;
        }
        .auto-style6 {
            height: 23px;
            width: 210px;
        }
        .auto-style7 {
            text-align: center;
        }
        .auto-style8 {
            color: #660066;
        }
        .auto-style9 {
            text-align: center;
            width: 659px;
        }
        .auto-style10 {
            width: 659px;
        }
        .auto-style11 {
            height: 23px;
            width: 659px;
        }
        .auto-style12 {
            width: 198px;
            text-align: left;
        }
        .auto-style13 {
            text-align: right;
        }
        .auto-style14 {
            height: 23px;
            width: 304px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style9" colspan="2"><strong><span class="auto-style8">PANEL DE USUARIO</span></strong></td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10" colspan="2">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="Cerrar Sesión" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style9" colspan="2"><strong>
                        <asp:Label ID="lblBienvenida" runat="server"></asp:Label>
                        </strong></td>
                    <td class="auto-style13">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10" colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Email</td>
                    <td class="auto-style5">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="auto-style10" colspan="2">
                        <asp:Button ID="btnAddEnt" runat="server" OnClick="btnAddEnt_Click" Text="Crear Entrada" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Nombre</td>
                    <td class="auto-style6">
                        <asp:Label ID="lblNom" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td class="auto-style11" colspan="2"></td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Apellido</td>
                    <td class="auto-style6">
                        <asp:Label ID="lblAp" runat="server" Text="Apellido"></asp:Label>
                    </td>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style11"></td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Privilegio</td>
                    <td class="auto-style5">
                        <asp:Label ID="lblPriv" runat="server" Text="Privilegio"></asp:Label>
                    </td>
                    <td class="auto-style10" colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style11" colspan="2"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10" colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12"><em>Último acceso:</em></td>
                    <td class="auto-style5">
                        <asp:Label ID="lblFechaAcceso" runat="server" Text="FechaAcceso"></asp:Label>
                    </td>
                    <td class="auto-style10" colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
