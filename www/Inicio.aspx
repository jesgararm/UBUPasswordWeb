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
            height: 23px;
        }
        .auto-style13 {
            text-align: right;
        }
        .auto-style14 {
            height: 23px;
            width: 567px;
            text-align: center;
            color: #006600;
        }
        .auto-style15 {
            height: 23px;
            width: 288px;
            text-align: center;
            color: #FF9900;
        }
        .auto-style17 {
            width: 288px;
        }
        .auto-style18 {
            height: 23px;
            width: 659px;
            text-align: center;
        }
        .auto-style19 {
            width: 198px;
            color: #0033CC;
            height: 139px;
        }
        .auto-style20 {
            width: 210px;
            height: 139px;
        }
        .auto-style21 {
            text-align: center;
            width: 659px;
            height: 139px;
        }
        .auto-style22 {
            height: 139px;
        }
        .auto-style23 {
            text-align: center;
            width: 567px;
        }
        .auto-style24 {
            height: 23px;
            width: 567px;
            text-align: center;
        }
        .auto-style25 {
            text-align: center;
            width: 567px;
            height: 139px;
        }
        .auto-style26 {
            color: #FF0000;
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
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style11" colspan="2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Apellido</td>
                    <td class="auto-style6">
                        <asp:Label ID="lblAp" runat="server" Text="Apellido"></asp:Label>
                    </td>
                    <td class="auto-style14"><strong>Mis Entradas:</strong></td>
                    <td class="auto-style15"><strong>Entradas Accesibles:</strong></td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Privilegio</td>
                    <td class="auto-style5">
                        <asp:Label ID="lblPriv" runat="server" Text="Privilegio"></asp:Label>
                    </td>
                    <td class="auto-style23">
                        <asp:ListBox ID="llMisEntradas" runat="server" Width="428px"></asp:ListBox>
                    </td>
                    <td class="auto-style17">
                        <asp:ListBox ID="llEntradas" runat="server" Width="396px"></asp:ListBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style24">
                        <asp:Button ID="btnMisEntradas" runat="server" OnClick="btnMisEntradas_Click" Text="Ver" />
                    </td>
                    <td class="auto-style18">
                        <asp:Button ID="btnEntradasAccesibles" runat="server" OnClick="btnEntradasAccesibles_Click" Text="Ver" />
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style19"></td>
                    <td class="auto-style20"></td>
                    <td class="auto-style25">
                        <asp:Label ID="lblMiEntrada" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style21">
                        <asp:Label ID="lblEntrada" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style22"></td>
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
                    <td class="auto-style23">
                        <asp:Button ID="btnLogs" runat="server" OnClick="btnLogs_Click" Text="Ver Logs" Visible="False" />
                    </td>
                    <td class="auto-style9">
                        <asp:Button ID="btnUser" runat="server" OnClick="btnUser_Click" Text="Crear Usuario" Visible="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style12"><em>Último acceso:</em></td>
                    <td class="auto-style6">
                        <asp:Label ID="lblFechaAcceso" runat="server" Text="FechaAcceso"></asp:Label>
                    </td>
                    <td class="auto-style18"><strong>
                        <asp:Label ID="lblError" runat="server" CssClass="auto-style26"></asp:Label>
                        </strong></td>
                    <td class="auto-style18">
                        <asp:Button ID="btnEliminarUs" runat="server" Height="25px" OnClick="btnEliminarUs_Click" Text="Eliminar Usuario" Visible="False" Width="128px" />
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style12"><em>Contraseña Válida hasta:</em></td>
                    <td class="auto-style6">
                        <asp:Label ID="lblValidez" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style11" colspan="2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
