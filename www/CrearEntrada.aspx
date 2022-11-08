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
            color: #FF0066;
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
        .auto-style17 {
            font-size: medium;
            font-style: italic;
        }
        .auto-style18 {
            width: 426px;
            height: 112px;
        }
        .auto-style19 {
            width: 464px;
            height: 112px;
        }
        .auto-style20 {
            height: 112px;
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
                    <td class="auto-style18"></td>
                    <td class="auto-style19" colspan="2">
                        <ol aria-label="Mensajes en " class="auto-style17" data-list-id="chat-messages" role="list" style="border-style: none; border-color: inherit; border-width: 0px; margin: 0px; padding: 0px; font-weight: 400; font-family: Whitney, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; vertical-align: baseline; list-style: none; min-height: 0px; overflow: hidden; forced-color-adjust: none; color: rgb(0, 0, 0); font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;" tabindex="0">
                            <li>La contraseña debe tener: </li>
                            <li>- 8 o más caracteres </li>
                            <li>- Al menos un dígito </li>
                            <li>- Al menos una minúscula </li>
                            <li>- Al menos una mayúscula.</li>
                            <li>&nbsp;-Puede tener otros símbolos.</li>
                        </ol>
                    </td>
                    <td class="auto-style20"></td>
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
                        <asp:Button ID="btnRem" runat="server" OnClick="btnRem_Click" Text="-" Width="30px" />
                    </td>
                    <td></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style16" colspan="2">
                        <asp:Label ID="lblOK" runat="server" CssClass="auto-style10"></asp:Label>
                    </td>
                    <td class="auto-style3"></td>
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
