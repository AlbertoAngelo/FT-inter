//Quando for tipo Cliente
//Ocultar o form de Truck
//Tornar visivel o de Cliente
$('#cliente').click('on', function () {
    $('#truck_form').hide();
    $('#cliente_form').show();
    $('input#food_truck').prop('checked', false);
});
//Quando for tipo Truck
//Ocultar o form de Cliente
//Tornar visivel o de Truck
$('#food_truck').click('on', function () {
    $('#cliente_form').hide();
    $('#truck_form').show();
    $('input#cliente').prop('checked', false);
});

//Preenche automaticamente o endereco através do CEP
$(document).ready(function () {
    $('#cep').blur(function () {
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //valida o formato do CEP
            if (validacep.test(cep)) {
                $("#uf").val("Aguarde...");
                $("#cidade").val("Aguarde...");
                $("#bairro").val("Aguarde...");
                $("#rua").val("Aguarde...");

                $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#uf").val(dados.uf);
                        $("#cidade").val(dados.localidade);
                        $("#bairro").val(dados.bairro);
                        $("#rua").val(dados.logradouro);
                    }
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            }
        }//END IF
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
});



