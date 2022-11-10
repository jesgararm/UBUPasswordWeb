<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="www.CrearUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 652px;
        }
        .auto-style2 {
            color: #660066;
        }
        .auto-style3 {
            width: 322px;
        }
        .auto-style4 {
            width: 652px;
        }
        .auto-style5 {
            width: 322px;
            height: 23px;
            text-align: right;
        }
        .auto-style6 {
            width: 652px;
            height: 23px;
        }
        .auto-style7 {
            height: 23px;
        }
        .auto-style8 {
            width: 322px;
            text-align: right;
        }
        .auto-style9 {
            width: 322px;
            height: 23px;
        }
        .auto-style10 {
            width: 652px;
            height: 23px;
            text-align: center;
        }
        .auto-style11 {
            text-align: right;
        }
        .auto-style12 {
            color: #CC00CC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1"><strong><span class="auto-style2">Nuevo Usuario</span></strong></td>
                    <td class="auto-style11">
                        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">Email :</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtEmail" runat="server" Width="315px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">Nombre : </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtNombre" runat="server" Width="314px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">Apellido : </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtApellido" runat="server" Width="315px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">Contraseña : </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtPass" runat="server" Width="312px"></asp:TextBox>
                    </td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style8">Rol :</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="lstRol" runat="server">
                            <asp:ListItem>Usuario</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style10">
                        <asp:Label ID="lblError" runat="server" CssClass="auto-style12"></asp:Label>
                    </td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="Crear" />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
