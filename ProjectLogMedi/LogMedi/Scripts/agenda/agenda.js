$('#NavAgenda').addClass('active');
$('#Agenda').addClass('active');
$('#liAgenda').addClass('active');


$(".btnNuevo").click(function (eve) {
    $("#modal-content").load("/Agenda/Create/" + $(this).data("id"));
});

$(".btnDetalles").click(function (eve) {
    $("#modal-content").load("/Agenda/Details/" + $(this).data("id"));
})


$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Agenda/Edit/" + $(this).data("id"));
})


$('#FechaConsulta').datepicker({
    autoclose: true,
    format: 'yyyy/mm/dd',
});