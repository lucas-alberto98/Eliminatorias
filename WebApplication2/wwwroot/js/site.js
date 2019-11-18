$(function () {

    $('#novo-time').submit(function (e) {
        e.preventDefault();
        var nome = $('#nome-time').val();

        $.post("/time/adicionar", { nome }, function (data) {

            if (data.success) {
                Swal.fire({
                    title: 'Pronto.',
                    text: 'Adicionado com sucesso',
                    icon: "success"
                })
                $('#modal3').modal('hide');

            } else {
                Swal.fire({
                    title: 'Opss.',
                    text: 'Não pode ser adicionado, Tente novamente',
                    icon: "error"
                })
            }


        }, 'json')

        

       
    })

    $('#novo-campeonato').submit(function (e) {
        e.preventDefault();

        var nome = $('#nome-campeonato').val();

        $.post("/campeonato/Novo", { nome }, function (data) {
            //alert(data);

            if (data.success) {
                Swal.fire({
                    title: "Pronto",
                    text: "Adicionado com sucesso",
                    icon: "success"
                })
                $('#modal1').modal('hide')
                updateCampeonato();
            } else {
                Swal.fire({
                    title: "Opss",
                    text: "Falha adicionar um novo Campeonato",
                    icon: "error"
                })
            }

        }, "json")
    })

    $('#novo-jogo').submit(function (e) {
        e.preventDefault();
        var data = $("#novo-jogo").serialize();

        $.post("/Campeonato/NovoJogo",  data , function (data) {
            console.log(data);
            if (data.success) {
                Swal.fire({
                    title: 'Pronto.',
                    text: 'Adicionado com sucesso',
                    icon: "success"
                })
                $('#modal2').modal('hide');
                updateRodada();

            } else {
                Swal.fire({
                    title: 'Opss.',
                    text: 'Não pode ser adicionado, Tente novamente',
                    icon: "error"
                })
            }
        }, 'json')
        console.log({ vs1, vs2 })

    })

    $("body").on("click", "#selecionar-vencedor", function () {
        var vs1 = $(this).data('vs1-nome')
        var vs2 = $(this).data('vs2-nome')

        $('#modal4').modal('show');

        //alert(vs1 + vs2);
    })

    function updateCampeonato(){
        if ($("#tabela").length) {
            $.get("/campeonato/lista", function (data) {
                $("#tabela").html(data);
            });
        }
    }
    updateCampeonato();

    function updateRodada() {
        if ($("#tabela-rodadas").length) {

            var id_campeonato = $('#id_campeonato').val();

            $.get("/campeonato/tabela", { id_campeonato }, function (data) {
                $("#tabela-rodadas").html(data);
            });
        }
    }
    updateRodada();

    

})