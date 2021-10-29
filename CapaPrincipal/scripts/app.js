//FUNCIONES DEL HOME/INDEX
function Listar() {
    location.replace("../Listar/Lista");
}
function Crear() {
    location.replace("../Alta/Alta");
}

//FINCIONES DE LISTAR
function BorrarProveedor(id) {
    if (confirm("¿Está seguro que desea borrar?")) {
        $.ajax({
            url: '/Listar/BorrarProveedor?id=' + id,
            type: 'POST',
            success: function (data) {
                var res = JSON.parse(data);
                var obj = res;
                if (res.Resultado == -1) {
                    alert(res.Error);
                } else {
                    location.reload();
                }
            },
            error: function (errorText) {
                alert("Wwoops something went wrong !");
            }
        });

    }
    else
        return false;
}