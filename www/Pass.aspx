<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pass.aspx.cs" Inherits="www.Pass" %>

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
            text-align: center;
            width: 716px;
        }
        .auto-style3 {
            color: #800000;
        }
        .auto-style4 {
            width: 716px;
        }
        .auto-style5 {
            height: 23px;
            width: 716px;
        }
        .auto-style6 {
            text-align: right;
            width: 385px;
        }
        .auto-style7 {
            width: 385px;
        }
        .auto-style8 {
            height: 23px;
            width: 385px;
        }
        .auto-style17 {
            font-size: medium;
            font-style: italic;
        }
        .auto-style18 {
            height: 23px;
            width: 716px;
            text-align: center;
        }
        .auto-style19 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style2"><strong><span class="auto-style3">CONTRASEÑA CADUCADA</span></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">Introduzca la nueva clave <em>(debe ser diferente a las tres últimas):</em></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">
                        <ol aria-label="Mensajes en " class="auto-style17" data-list-id="chat-messages" role="list" style="border-style: none; border-color: inherit; border-width: 0px; margin: 0px; padding: 0px; font-weight: 400; font-family: Whitney, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; vertical-align: baseline; list-style: none; min-height: 0px; overflow: hidden; forced-color-adjust: none; color: rgb(0, 0, 0); font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;" tabindex="0">
                            <li>La contraseña debe tener: </li>
                            <li>- 8 o más caracteres </li>
                            <li>- Al menos un dígito </li>
                            <li>- Al menos una minúscula </li>
                            <li>- Al menos una mayúscula.</li>
                            <li>&nbsp;-Puede tener otros símbolos.</li>
                        </ol>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">Nueva Contraseña :</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtPass" runat="server" Width="380px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style18">
                        <asp:Label ID="lblError" runat="server" CssClass="auto-style19"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style18">
                        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="Enviar" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
