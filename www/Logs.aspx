<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="www.Logs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 482px;
        }
        .auto-style2 {
            width: 482px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            text-align: center;
            width: 492px;
        }
        .auto-style5 {
            height: 26px;
            text-align: center;
            width: 492px;
            color: #660066;
        }
        .auto-style6 {
            width: 492px;
        }
        .auto-style7 {
            height: 26px;
            text-align: right;
        }
        .auto-style8 {
            color: #0033CC;
            background-color: #FFFFFF;
        }
        .auto-style9 {
            color: #FF3300;
        }
        .auto-style10 {
            height: 26px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style5"><strong>Accesos de Usuarios.</strong></td>
                    <td class="auto-style7">
                        <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="Volver" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5"><strong><span class="auto-style8">Tabla de Accesos.</span></strong></td>
                    <td class="auto-style10"><strong>
                        <asp:Label ID="lblLogs" runat="server" CssClass="auto-style9"></asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;<table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </td>
                    <td class="auto-style4">
                        <asp:GridView ID="grdAccesos" runat="server" onrowcommand="grdAccesos_RowCommand" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Id." HeaderText="Id." />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:ButtonField ButtonType="Button" Text="Ver" HeaderText="Más Info" />
                        </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:GridView ID="grdLogs" runat="server"  AutoGenerateColumns="False">
                            <Columns>
                            <asp:BoundField DataField="IdEntrada" HeaderText="IdEntrada" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
    </body>
</html>
