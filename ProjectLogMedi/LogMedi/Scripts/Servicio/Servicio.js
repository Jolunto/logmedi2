$('#NavGeneral').addClass('active');
$('#NavServicios').addClass('active');
$('#Servicios').addClass('active');

$(document).ready(function () {
    $('#tblServicios').DataTable({

    });
});

$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Servicio/Create");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Servicio/Edit/" + $(this).data("id"));
})

$(".btnDetalles").click(function (eve) {
    $("#modal-content").load("/Servicio/Details/" + $(this).data("id"));
})