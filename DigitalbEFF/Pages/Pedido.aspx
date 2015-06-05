<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" MasterPageFile="~/Site.Master" Culture="pt-BR" Inherits="DigitalbEFF.Pages.Pedido" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.2.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/Pedidos.js"></script>
    <asp:HiddenField runat="server" ID="hdn" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnFim" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnNF" ClientIDMode="Static" />

    <div>
        <asp:TextBox ID="txtPesquisa" runat="server"></asp:TextBox>
        <asp:DropDownList runat="server" ID="ddlPesquisa" Height="30px" Width="100px" Font-Size="Medium">
            <asp:ListItem Text="Ativos" Value="1" />
            <asp:ListItem Text="Inativos" Value="2" />
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Pesquisar" OnClick="btn_Pesquisar" ClientIDMode="Static" />
    </div>

    <asp:GridView ID="gridDados" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" CssClass="cssGrid" OnRowCommand="gridDados_RowCommand" HeaderStyle-BackColor="#7AC0DA" HeaderStyle-ForeColor="White"
        RowStyle-BackColor="#d3dce0" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000">
        <Columns>
            <asp:BoundField HeaderText="Pedido" HeaderStyle-CssClass="cssBoundFieldHeader" DataField="Id" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Situação">
                <ItemTemplate>
                    <asp:LinkButton ID="btnNF" runat="server" CausesValidation="False" CommandName="NF" CommandArgument='<%#Eval("ID_Nf")%>' Text='<%#Eval("ID_Nf")%>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="NF" DataField="ID_Nf" HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />--%>
            <asp:BoundField HeaderText="Empresa" DataField="NomeEmpresa" HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Data Locação" DataField="DataLocacao" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Data Retorno" DataField="DataRetorno" DataFormatString="{0:d/MM/yyyy}" HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Situação">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem,"Situacao").ToString() == "A" ?  "Ativo" : "Finalizado"%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--    <asp:BoundField HeaderText="Situação" DataField="Situacao" HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />--%>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Finalizar" CommandArgument='<%#Eval("Id")%>' Text="Finalizar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Editar" CommandArgument='<%#Eval("Id")%>' Text="Editar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Excluir" OnClientClick="return confirm('Deseja excluir ?')" CommandArgument='<%#Eval("Id")%>' Text="Excluir"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <EmptyDataTemplate>
            Nenhum Registro Encontrado.
        </EmptyDataTemplate>
    </asp:GridView>
    <div style="margin-top: 5px">
        <asp:LinkButton ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click"></asp:LinkButton>
        <asp:HyperLink ID="linkModal" runat="server" Visible="false">HyperLink</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
    </div>
    <asp:ModalPopupExtender ID="ModalUpdate" runat="server" TargetControlID="linkModal" PopupControlID="PainelModal">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalInsert" runat="server" TargetControlID="HyperLink1" PopupControlID="PainelModal">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalResposta" runat="server" TargetControlID="HyperLink1" PopupControlID="pnlResposta">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalNF" runat="server" TargetControlID="HyperLink1" PopupControlID="PnlNF">
    </asp:ModalPopupExtender>



    <asp:Panel ID="pnlResposta" runat="server" Style="width: 400px; background: #7AC0DA; height: 70px;" CssClass="modalPopup">
        <div>
            <h1 style="text-align: center; font-size: 14px; font-family: Verdana; background-color: #7AC0DA;">
                <asp:Label ID="txtResposta" BackColor="#7AC0DA" runat="server"></asp:Label>
                <br />
                <asp:Button ID="BtnNF" runat="server" Text="OK" OnClientClick="limpaCampos()" OnClick="BtnNF_Click" />
            </h1>
        </div>
        <div style="text-align: center;">
        </div>
    </asp:Panel>

    <asp:Panel ID="PainelModal" runat="server" Style="display: none" Width="750px" CssClass="modalPopup">
        <asp:Panel ID="PainelCabecalho" runat="server" Style="border-bottom: solid 1px Gray; height: 25px;">
            <div>
                <h1 style="line-height: 25px; text-align: center; font-size: 14px; font-family: Verdana; background-color: #7AC0DA;">
                    <asp:Label ID="txtTitulo" Text="Dados do Pedido" runat="server"></asp:Label>
                </h1>
            </div>
        </asp:Panel>

        <div>
            <br />
            <br />


            <table width="700px" style="margin-left: 10%;">
                <tr>
                    <td>Código Pedido:</td>
                    <td>
                        <asp:TextBox ID="txtCd_Pedido" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" ReadOnly="true" />
                    </td>
                </tr>
                <tr>
                    <td>NF:</td>
                    <td>
                        <asp:TextBox ID="txtNF" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvtxtNF" ControlToValidate="txtNF"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Empresa:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEmpresa" Width="412px" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvtxtContato" CssClass="txtEmpresa" ControlToValidate="ddlEmpresa"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue="Selecione..."></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Data de Locação:</td>
                    <td>
                        <asp:TextBox ID="txtDtLocacao" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvDtLocacao" ControlToValidate="txtDtLocacao"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="DateValidator" runat="server" Operator="DataTypeCheck" BackColor="Red" ForeColor="White"
                            Type="Date" ControlToValidate="txtDtLocacao" ErrorMessage="Data Invalída" ValidationGroup="Salvar" />

                    </td>
                </tr>
                <tr>
                    <td>Data Retorno:</td>
                    <td>
                        <asp:TextBox ID="txtDtRetorno" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvDtRetorno" ControlToValidate="txtDtRetorno" Enabled="False"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="DateValidator1" runat="server" Enabled="false" Operator="DataTypeCheck" BackColor="Red" ForeColor="White"
                            Type="Date" ControlToValidate="txtDtRetorno" ErrorMessage="Data Invalida" ValidationGroup="Salvar" />

                    </td>
                </tr>

            </table>


            <div style="text-align: center;">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" CausesValidation="True" ValidationGroup="Salvar" ClientIDMode="Static" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="limpaCampos()" />
            </div>



        </div>
    </asp:Panel>
    <asp:Panel ID="PnlNF" runat="server" Style="display: none" Width="750px" CssClass="modalPopup">
        <asp:Panel ID="Panel2" runat="server" Style="border-bottom: solid 1px Gray; height: 25px;">
            <div>
                <h1 style="line-height: 25px; text-align: center; font-size: 14px; font-family: Verdana; background-color: #7AC0DA;">
                    <asp:Label ID="Label1" Text="Dados da Nota Fiscal" runat="server"></asp:Label>
                </h1>
            </div>
        </asp:Panel>
            
        <div>
            <div style="line-height: 20px; text-align: center; font-size: 12px; font-family: Verdana; background-color: #7AC0DA;">
                Pedido: <asp:Label ID="lblTitPedido" runat="server"></asp:Label>
            </div >
            <div style="line-height: 20px; text-align: center; font-size: 12px; font-family: Verdana; background-color: #7AC0DA;">
                NF: <asp:Label ID="lblTitNf" runat="server"></asp:Label>
            </div >
            <div style="line-height:20px; text-align: center; font-size: 12px; font-family: Verdana; background-color: #7AC0DA;">
                Empresa: <asp:Label ID="lblTitEmpresa" runat="server"></asp:Label></div>
            <br />
            <br />

            <asp:GridView ID="gdvNF" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" CssClass="cssGrid" OnRowEditing="gdvNF_RowEditing" OnRowDeleting="gdvNF_RowDeleting" OnRowCommand="gridDados_RowCommand" HeaderStyle-BackColor="#7AC0DA" HeaderStyle-ForeColor="White"
                RowStyle-BackColor="#d3dce0" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000">
                <Columns>

                    <asp:TemplateField HeaderText="Balanças:">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlBalancaEdit" Text='<%#Eval("NomeBalanca") %>' ClientIDMode="Static" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblBalancaEdit" Text='<%#Eval("NomeBalanca") %>' ClientIDMode="Static" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList runat="server" ID="ddlBalanca" ClientIDMode="Static" />
                            <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" Text="*"
                                ControlToValidate="ddlBalanca" ValidationGroup="Salvar_NF"
                                ForeColor="Red" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantidade:">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtQuandidadeEdit" ClientIDMode="Static" Text='<%#Eval("Qt_Balanca")%>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblQuantidade" Text='<%#Eval("Qt_Balanca")%>' ClientIDMode="Static" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtQuandidade" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" Text="*"
                                ControlToValidate="txtQuandidade" ValidationGroup="Salvar_NF"
                                ForeColor="Red" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Situação">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtDtNFEdit" ClientIDMode="Static" Text='<%#Eval("DataNF")%>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDtNF" Text='<%#Eval("DataNF")%>' ClientIDMode="Static" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtDtNF" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" Text="*"
                                ControlToValidate="txtDtNF" ValidationGroup="Salvar_NF"
                                ForeColor="Red" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Valor">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtValorEdit" ClientIDMode="Static" Text='<%#Eval("ValorNF")%>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblValor" Text='<%#Eval("ValorNF")%>' ClientIDMode="Static" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtValor" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" Text="*"
                                ControlToValidate="txtValor" ValidationGroup="Salvar_NF"
                                ForeColor="Red" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="Update"
                                Text="Update" />
                            <asp:LinkButton ID="lbtnCancel" runat="server" CommandName="Cancel"
                                Text="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit"
                                Text="Edit" />
                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?')"
                                Text="Delete" CausesValidation="false" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add"
                                Text="Add New" ValidationGroup="Salvar_NF" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhum Registro Encontrado.
                </EmptyDataTemplate>
            </asp:GridView>
            <div style="text-align: center;">
                <asp:Button ID="Button3" runat="server" Text="Cancelar" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>

