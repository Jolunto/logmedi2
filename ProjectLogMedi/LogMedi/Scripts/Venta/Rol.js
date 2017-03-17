$('#NavGeneral').addClass('active');
$('#NavRol').addClass('active');
$('#Roles').addClass('active');

$(document).ready(function () {
    $('#tblRoles').DataTable({

    });
});

$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Rol/Create");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Rol/Edit/"+$(this).data("id"));
})

$(".btnDetalles").click(function (eve) {
    $("#modal-content").load("/Rol/Details/" + $(this).data("id"));
})