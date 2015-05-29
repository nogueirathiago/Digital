
$(document).ready(function() {

    $("#txtCnpj").mask('99.999.999/9999-99');
    $("#txtTelefone").mask('(99)9999-9999');
    $("#txtCep").mask('99999-999');
});
function carregaCep() {
    if ($.trim($("#txtCep").val()) != "") {
        $.getScript("http://cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + $("#txtCep").val(), function () {
            if (resultadoCEP["resultado"]) {
                $("#txtEndereco").val(unescape(resultadoCEP["tipo_logradouro"]) + ": " + unescape(resultadoCEP["logradouro"]) );
                $("#txtMun").val(unescape(resultadoCEP["cidade"]));
                $("#txtEstado").val(unescape(resultadoCEP["uf"]));
            } else {
                $("#txtEndereco").val('Cep Inválido');
            }
        });
    }
};

function limpaCampos() {
    $("#txtEndereco").val("");
    $("#txtMun").val("");
    $("#txtNome").val("");
    $("#txtCnpj").val("");
    $("#txtContato").val("");
    $("#txtCep").val("");
    $("#txtTelefone").val("");
    $("#txtEmail").val("");
    $("#txtEstado").val("");
}

$('#btnSalvar').click(function (e) {
    var isValid = true;
    $('#txtEndereco,#txtMun,#email,#txtNome').each(function () {
        if ($.trim($(this).val()) == '') {
            isValid = false;
            $(this).css({
                "border": "1px solid red",
                "background": "#FFCECE"
            });
        }
        else {
            $(this).css({
                "border": "",
                "background": ""
            });
        }
    });
    if (isValid == false)
        e.preventDefault();

});

