function getTotalProductsBuscar() {
    var serviceURL = '/Home/SearchFilm';
    $("#divcontainerInfoBuscar").html('');
    if ($("#txtText2").val()) {
        var param = '{"film":"' + $("#txtText2").val() + '"}';
        $.ajax({
            type: "POST",
            url: serviceURL,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: param,
            success: function (result) {
                var datat = result;
                if (datat != "") {
                    $("#divcontainerInfoBuscar").html(datat);
                }
                else {
                    $("#divcontainerInfoBuscar").html('<p>Results Not Found.</p>');
                }
            },
            error: function (result) {
                alert('Oh no: ' + result.responseText);
            }
        });
    }
    else {
        S$("#divcontainerInfoBuscar").html('<p>Introduce a Film title.</p>');
    }
}