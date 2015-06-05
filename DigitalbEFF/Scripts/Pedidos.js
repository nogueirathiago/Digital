//function limpaCamposBalanca() {
//    $("#txtCodigo").val("");
//    $("#txtModelo").val("");
//    $("#txtTotal").val("");
//    $("#txtAlugadas").val("");
//    $("#txtDisponíveis").val("");
//}
$(function () {
    $("#txtDtRetorno").datepicker({dateFormat: 'dd/mm/yy'}).val();
    $("#txtDtRetorno").mask('99/99/9999');
    $("#txtDtLocacao").datepicker({ dateFormat: 'dd/mm/yy' }).val();
    $("#txtDtLocacao").mask('99/99/9999');
});
function limpaCampos() {
    $("#hdn").val("");
    $("#hdnFim").val("");
    $("#txtDtRetorno").val("");
    $("#txtDtLocacao").val("");
    $("#txtNF").val("");
    $("#ddlEmpresa").val('0');

}