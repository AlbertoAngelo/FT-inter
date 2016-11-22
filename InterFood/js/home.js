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
    
    $('#subscribebtn').on('click', function () {
        //Consulta o WebService GoogleMaps Geocoding API

        //$.getJSON("//maps.googleapis.com/maps/api/geocode/json?" + logradouro + "+" + rua1 "+" )

    });
});