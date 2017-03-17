$('#NavGeneral').addClass('active');
$('#NavUsuarios').addClass('active');
$('#Usuarios').addClass('active');




$(document).ready(function () {
    $('#tblUsuarios').DataTable({

    });
});

$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Usuario/Create");
});
$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Usuario/Edit/" + $(this).data("id"));
})
$(".btnDetalles").click(function (eve) {
    $("#modal-content").load("/Usuario/Details/" + $(this).data("id"));
})



