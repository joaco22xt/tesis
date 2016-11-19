$(document).ready(function () {
    $('a[name=modifProd]').click(function (e) {
        $('#modalProd').modal('show');
        var id = e.target.id;
        var idProd = $('th[name=i' + id + ']').text();
        var tipo = $('th[name=t' + id + ']').text();
        var nombre = $('th[name=n' + id + ']').text();
        var descripcion = $('th[name=d' + id + ']').text();
        var precio = $('th[name=p' + id + ']').text();
        var precio2=precio.replace('$', '');
        var tiempo = $('th[name=ti' + id + ']').text();
        var tiempo2 = tiempo.replace('.min', '');
        var coins = $('th[name=c' + id + ']').text();
        $('input[name=id_producto]').val(idProd);
        $('input[name=nombre]').val(nombre);
        $('textarea[name=descripcion]').val(descripcion);
        $('input[name=precio]').val(parseInt(precio2));
        $('input[name=tiempo]').val(parseInt(tiempo2));
        $('input[name=coins]').val(coins);

        if(tipo=="Lomito")
        {
            tipo = 1;
        }
        else 
        {
            if (tipo == "Empanada") {
                tipo = 2;
            }
            else
            {
                if (tipo == "Pizza")
                {
                    tipo = 3;
                }
                else
                {
                    if (tipo == "Hamburguesa") {
                        tipo = 4;
                    }
                    else
                    {
                        if (tipo == "Pollo") {
                            tipo = 5;
                        }

                        else
                        {
                            if (tipo == "Tarta"){
                                tipo = 6;
                            }
                            else { tipo = 7; }
                        }
                    }
                }
            }

        }
        
        $("#select option[value=" + tipo + "]").attr("selected", true);

    });



});