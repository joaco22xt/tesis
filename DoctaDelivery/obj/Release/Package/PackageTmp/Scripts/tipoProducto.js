$(document).ready(function () {
    
    $('#btnCantidad').click(function () {
        var cantidad = $('#cantidadProd').val();
        for (var i = 0; i < cantidad; i++) {
            $('#productos').append('<form id="form_producto"></form>');
            $('#form_producto').append('<hr/>');
            $('#form_producto').append('<div class="form-group" style="margin-right:5px;"><label class="control-label col-sm-2">Nombre:</label><div class="col-sm-10"><input type="text" required class="form-control" name="nombre" placeholder="Nombre del producto"/></div>');
            $('#form_producto').append('<div class="form-group" style="margin-right:10px;"><label class="control-label col-sm-2">Descripcion:</label><div class="col-sm-10"><textarea class="form-control" rows="4" cols="6" name="descripcion" required placeholder="Contenido del producto"></textarea></div>');
            $('#form_producto').append('<div class="form-group" style="margin-right:10px;"><label class="control-label col-sm-2">Precio:</label><div class="col-sm-10"><input type="number" required class="form-control" name="precio"/></div>');
            $('#form_producto').append('<div class="form-group" style="margin-right:10px;"><label class="control-label col-sm-2">Tiempo:</label><div class="col-sm-10"><input type="number" required class="form-control" name="tiempo"/></div>');
            $('#form_producto').append('<div class="form-group" style="margin-right:10px;"><label class="control-label col-sm-2">Coins:</label><div class="col-sm-10"><input type="number" required class="form-control" name="coins"/></div>');
            $('#form_producto').append('<hr/>');
        }
    });
});