$(document).ready(function () {
    var c = 1;

        $('#1').click(function () {
            var a = $('img[name=1]').attr('src');
            var b = a.split('/');
            var fs1 = $('input[name=fotosSacar]').val();
            var fs2 =$('input[name=fotosSacar]').val(fs1+'*' + b[2]);
            $('#1').attr('disabled', 'disabled');
            $('span[name=1]').removeClass('hidden');
            $('a[name=1]').removeClass('hidden');
            var cantiF = $('input[name=cantidad]');
            var cantidad = parseInt($('input[name=cantidad]').val());
            cantiF.attr('value', cantidad - 1);
            $('a[name=1]').click(function () {
                $('a[name=1]').addClass('hidden');
                $('span[name=1]').addClass('hidden');
                $('#1').removeAttr('disabled');
                var a = fs2.val();
                var e ='*'+b[2];
                var c = a.replace(e, "");
                $('input[name=fotosSacar]').val(c);
                cantiF.attr('value', cantidad);
            });

        });

        $('#2').click(function () {
            var a = $('img[name=2]').attr('src');
            var b = a.split('/');
            var fs1 = $('input[name=fotosSacar]').val();
            var fs2 = $('input[name=fotosSacar]').val(fs1 +'*' + b[2]);
            $('#2').attr('disabled', 'disabled');
            $('span[name=2]').removeClass('hidden');
            $('a[name=2]').removeClass('hidden');
            var cantiF = $('input[name=cantidad]');
            var cantidad = parseInt($('input[name=cantidad]').val());
            cantiF.attr('value', cantidad - 1);
            $('a[name=2]').click(function () {
                $('a[name=2]').addClass('hidden');
                $('span[name=2]').addClass('hidden');
                $('#2').removeAttr('disabled');
                var a = fs2.val();
                var e = '*' + b[2];
                var c = a.replace(e, "");
                $('input[name=fotosSacar]').val(c);
                cantiF.attr('value', cantidad);
            });

        });

        $('#3').click(function () {
            var a = $('img[name=3]').attr('src');
            var b = a.split('/');
            var fs1 = $('input[name=fotosSacar]').val();
            var fs2 = $('input[name=fotosSacar]').val(fs1 + '*' + b[2]);
            $('#3').attr('disabled', 'disabled');
            $('span[name=3]').removeClass('hidden');
            $('a[name=3]').removeClass('hidden');
            var cantiF = $('input[name=cantidad]');
            var cantidad = parseInt($('input[name=cantidad]').val());
            cantiF.attr('value', cantidad - 1);
            $('a[name=3]').click(function () {
                $('a[name=3]').addClass('hidden');
                $('span[name=3]').addClass('hidden');
                $('#3').removeAttr('disabled');
                var a = fs2.val();
                var e = '*' + b[2];
                var c = a.replace(e, "");
                $('input[name=fotosSacar]').val(c);
                cantiF.attr('value', cantidad);
            });
        });



    $('#AgregarFoto').click(function () {
        c++;
       $('#SacarFoto').removeClass('hidden');
       var cantiF = $('input[name=cantidad]');
       var cantidad = parseInt($('input[name=cantidad]').val());
        if (cantidad < 2 ) {
            var b = $('div[name=fotoedit]').clone(true);
            b.attr('name', 'fotoedit'+c);
            b.insertAfter('div[name=fotoedit]');
            cantiF.attr('value', cantidad+1);
        }

    });
});