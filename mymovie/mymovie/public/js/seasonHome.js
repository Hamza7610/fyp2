var used = false;
window.onload = function () {


    load_seasons();
}





function load_seasons(id = "") {
    $('#seasons').html($('#loading').html());
    var _token = $('input[name="_token"]').val();
    $.ajax({
        url: "/season/load_seasonHome",
        method: "POST",
        data: {
            id: id,
            _token: _token
        },
        success: function (data) {
            $('#seasons').html(data);

        }
    })
}
