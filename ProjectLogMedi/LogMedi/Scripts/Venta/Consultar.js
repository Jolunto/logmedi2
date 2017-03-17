$('#navVenta').addClass('active');
$('#ConsultarVenta').addClass('active');
$('#ConsultarVentali').addClass('active');

$(document).ready(function () {
    $('#tblVentas').DataTable({

    });
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Venta/Edit/"+$(this).data("id"));
})

$(".btnDetalles").click(function (eve) {
    $("#modal-content").load("/Venta/Details/" + $(this).data("id"));
})