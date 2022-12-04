var used = false;
window.onload = function () {


    load_seasonEpisode();
}





function load_seasonEpisode(id = "") {
    $('#load_more_seasons').html($('#loading').html());

    var _token = $('input[name="_token"]').val();
    $.ajax({
        url: "/kids/load_kidsData",
        method: "POST",
        data: {
            id: id,
            _token: _token,
            season_id: $('.season_id').val(),
            season_detail_id: $('.season_detail_id').val()
        },
        success: function (data) {
            $('#kidshome').html(data);

        }
    })
}
