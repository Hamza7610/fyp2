$(window).on('load', function () {


    $('.header__btn').on('click', function () {
        $(this).toggleClass('header__btn--active');
        $('.header__nav').toggleClass('header__nav--active');
        $('.body').toggleClass('body--active');
    });

    $('.header__search-btn, .header__search-close').on('click', function () {
        $('.header__search').toggleClass('header__search--active');
    });
    $(window).trigger('resize');
    $('.content__mobile-tabs-menu li').each(function () {
        $(this).attr('data-value', $(this).text().toLowerCase());
    });

    $('.content__mobile-tabs-menu li').on('click', function () {
        var text = $(this).text();
        var item = $(this);
        var id = item.closest('.content__mobile-tabs').attr('id');
        $('#' + id).find('.content__mobile-tabs-btn input').val(text);
    });
    $('.section--bg, .details__bg').each(function () {
        if ($(this).attr("data-bg")) {
            $(this).css({
                'background': 'url(' + $(this).data('bg') + ')',
                'background-position': 'center center',
                'background-repeat': 'no-repeat',
                'background-size': 'cover'
            });
        }
    });
    

});
