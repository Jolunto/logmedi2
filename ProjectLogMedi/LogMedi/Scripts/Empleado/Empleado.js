$('#NavGeneral').addClass('active');
$('#NavEmpleados').addClass('active');
$('#Empleados').addClass('active');

           


$(document).ready(function () {
    $('#tblEmpleados').DataTable({

    });
});

$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Empleado/Create");
});

$(".btnDetalles").click(function (eve) {
    $("#modal-content").load("/Empleado/Details/" + $(this).data("id"));
})

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Empleado/Edit/" + $(this).data("id"));
})