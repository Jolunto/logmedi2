$('#NavPaciente').addClass('active');
$('#Pacientes').addClass('active');



$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Paciente/Create");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Paciente/Edit/" + $(this).data("id"));
})

$(".btnDetalles").click(function (eve) {
    $("#modal-content").load("/Paciente/Details/" + $(this).data("id"));
})