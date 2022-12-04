<head>
    <html lang="{{ str_replace('_', '-', app()->getLocale()) }}">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>My Movies</title>
    <link rel="shortcut icon" href="/img/logo.png">
    <script src="/js/app.js"></script>

    <script src="/js/autocomplete.js"></script>
    <link href="/css/autocomplete.css" rel="stylesheet">

    <script src="/js/layout.js"></script>

    <link rel="stylesheet" href="/css/w3.css">
    <link rel="stylesheet" href="/css/layout_v1.1.css">
    <link rel='stylesheet' href="/css/fontawesome.min.css" type="text/css">
    <script src="/js/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="/css/sweetalert2.min.css">
    <link href="/css/welcome.css" rel="stylesheet">
    @yield('script')
    @yield('css')
</head>
<style>
    input[type=text],
    input[type=password],
    select {
        width: 100%;
        padding: 6px 20px;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    input[type=submit] {
        width: 100%;
        background-color: #4CAF50;
        color: white;
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    input[type=submit]:hover {
        background-color: #45a049;
    }

    textarea {
        width: 100%;
    }
</style>
<script>
    $(".buttonlink").click(function() {
        window.location = $(this).find("a").attr("href");
        return false;
    });
</script>

<body>
    @include('flash-messages')
    @section('sidebar')

    <header class="header">
        @include('flash-messages')
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="header__content">
                        <a href="{!! url('/'); !!}" class="header__logo">
                            <img src="/img/logo.png" class="imageRendering" alt="">
                        </a>
                        <ul class="header__nav">
                            <li class="header__nav-item">
                                <a href="{!! url('/su/movies'); !!}" class="header__nav-link">Movies Modifications</a>
                            </li>
                            <li class="header__nav-item">
                                <a href="{!! url('/su/seasons'); !!}" class="header__nav-link">Seasons Modifications</a>
                            </li>
                            <li class="header__nav-item">
                                <a href="{!! url('/su/suuser'); !!}" class="header__nav-link">Modify Users</a>
                            </li>
                            <li class="header__nav-item">
                                <a href="{!! url('/su/changepassword'); !!}" class="header__nav-link">Change Password</a>
                            </li>
                            <li class="header__nav-item">
                                <a href="{!! url('/su/commands'); !!}" class="header__nav-link">Commands</a>
                            </li>
                        </ul>
                        <div class="header__auth">
                            <a href="{!! url('/su/logout'); !!}" class="header__sign-in">
                                <i class="fa fa-sign-out"></i>
                                <span>signout</span>
                            </a>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </header>
    @show
    <div class="row">
        <div class="container">
            @yield('content')
        </div>
    </div>
</body>

</html>