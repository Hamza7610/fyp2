var used = false;
window.onload = function () {


    load_data();
    addRequest();

    $('.header__search-input').keypress(function(e) {
    if(e.which == 13) {
        search();
    }
    });
}
function search()
{
    if($(".header__search-input").val() != undefined && $(".header__search-input").val() != '')
    {
        
        $('#post_data').hide();
        $('#search_data').html($('#loading').html());
        $('#search_data').show();
        
        $.ajax({
            url: "/movie/searchMovie",
            method: "get",
            data: {
                query: $(".header__search-input").val()
            },
            success: function (data) {                       
                $('#search_data').html(data);
            }
        });
    }else
    {
        $('#search_data').hide();
        $('#post_data').show(); 
    }
    
}
// Add news into DB
function addRequest() {
    $('.requestBtn').click(function () {
        var movie = $('.request').val();
        var form_data = new FormData();
        form_data.append("movierequest", movie);
        if (CheckNoInput()) {
            Swal.fire({
                title: 'Are you sure request new movie',
                text: movie,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, Send 📨',
                showLoaderOnConfirm: true,
                preConfirm: (result) => {
                    $('.swal2-cancel').remove();
                    $('.requestBtn').attr('disabled', true);
                    return $.ajax({
                        type: "Post",
                        contentType: false,
                        processData: false,
                        cache: false,
                        url: '/movie/requestMovie',
                        data: form_data,
                        headers: {
                            'X-CSRF-TOKEN': $('input[name="_token"]').val()
                        },
                        success: function (response) {

                            if (response == 0) {
                                $('.requestBtn').attr('disabled', false);
                                Swal.fire(
                                    'success!',
                                    'Soon we will upload this movie ',
                                    'success'
                                );
                                window.location.reload();
                            }

                        }
                    });
                }
            }).then((result) => {
                if (result.value) {


                }

            });

        }
    });
}

function CheckNoInput() {
    if ($('.request').val().trim() == '') {
        Swal.fire({
            icon: 'error',
            title: '',
            text: 'Please Enter movie name...',
        });
        //message here future if any
        return false;
    }
    return true;


}



function load_data(id = "") {
    $('#post_data').html($('#loading').html());

    var _token = $('input[name="_token"]').val();
    $.ajax({
        url: "/movie/loadmore",
        method: "POST",
        data: {
            id: id,
            _token: _token
        },
        success: function (data) {
            $('#post_data').html(data);

        }
    })
}
