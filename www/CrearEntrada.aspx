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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4"><strong><span class="auto-style5">Crear Nueva Entrada</span></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">Descripción:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDesc" runat="server" Width="458px"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style8">Password:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtPassword" runat="server" Width="458px"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Permitir Acceso:</td>
                    <td class="auto-style7"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style7"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblOK" runat="server" CssClass="auto-style10" Text="Entrada creada con éxito."></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnCrearEntrada" runat="server" OnClick="btnCrearEntrada_Click" Text="Crear" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
