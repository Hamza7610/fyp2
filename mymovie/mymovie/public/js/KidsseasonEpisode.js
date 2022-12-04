var used = false;
window.onload = function () {


    load_seasonEpisode();
}





function load_seasonEpisode(id = "") {
    $('#seasonEpisode').html($('#loading').html());

    var _token = $('input[name="_token"]').val();
    $.ajax({
        url: "/kids/load_seasonEpisode",
        method: "POST",
        data: {
            id: id,
            _token: _token,
            season_id: $('.season_id').val(),
            season_detail_id: $('.season_detail_id').val()
        },
        success: function (data) {
            $('#seasonEpisode').html(data);

        }
    })
}
