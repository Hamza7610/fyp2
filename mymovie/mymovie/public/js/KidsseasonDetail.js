var used = false;
window.onload = function () {


    load_seasonDetail();
}





function load_seasonDetail(id = "") {
    $('#seasonDetail').html($('#loading').html());

    var _token = $('input[name="_token"]').val();
    $.ajax({
        url: "/kids/load_seasonDetail",
        method: "POST",
        data: {
            id: id,
            _token: _token,
            season_id: $('.season_id').val()
        },
        success: function (data) {
            $('#seasonDetail').html(data);

        }
    })
}
