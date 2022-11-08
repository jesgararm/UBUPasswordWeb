<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearEntrada.aspx.cs" Inherits="www.CrearEntrada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 426px;
        }
        .auto-style2 {
            width: 426px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            text-align: center;
            width: 464px;
        }
        .auto-style5 {
            color: #660066;
        }
        .auto-style6 {
            width: 464px;
        }
        .auto-style7 {
            height: 23px;
            width: 464px;
        }
        .auto-style8 {
            width: 426px;
            height: 23px;
            text-align: right;
            color: #0066FF;
        }
        .auto-style9 {
            width: 426px;
            height: 23px;
            text-align: right;
            color: #FF3300;
        }
        .auto-style10 {
            color: #00CC00;
        }
        .auto-style11 {
            text-align: right;
        }
        .auto-style12 {
            margin-left: 0px;
        }
        .auto-style13 {
            width: 94%;
        }
        .auto-style14 {
            width: 247px;
            height: 23px;
        }
        .auto-style15 {
            width: 217px;
            height: 23px;
        }
        .auto-style16 {
            height: 23px;
            width: 464px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style13">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4" colspan="2"><strong><span class="auto-style5">Crear Nueva Entrada</span></strong></td>
                    <td class="auto-style11">
                        <asp:Button ID="btnSalir" runat="server" CssClass="auto-style12" OnClick="btnSalir_Click" Text="Salir" Width="107px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style6" colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">Descripción:</td>
                    <td class="auto-style7" colspan="2">
                        <asp:TextBox ID="txtDesc" runat="server" Width="458px"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style8">Password:</td>
                    <td class="auto-style7" colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server" Width="458px"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style6" colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Permitir Acceso:</td>
                    <td class="auto-style14">
                        <asp:ListBox ID="llEmail" runat="server" Width="242px"></asp:ListBox>
                    </td>
                    <td class="auto-style15">
                        <asp:ListBox ID="llEmailSel" runat="server" Width="217px"></asp:ListBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style16" colspan="2">
                        <asp:Button ID="btnAddEnt" runat="server" OnClick="btnAddEnt_Click" Text="+" Width="32px" />
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4" colspan="2">
                        <asp:Label ID="lblOK" runat="server" CssClass="auto-style10" Text="Entrada creada con éxito."></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4" colspan="2">
                        <asp:Button ID="btnCrearEntrada" runat="server" OnClick="btnCrearEntrada_Click" Text="Crear" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
