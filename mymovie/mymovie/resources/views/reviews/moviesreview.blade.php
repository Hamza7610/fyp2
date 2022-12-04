@extends('layouts.app')

@section('content')
<section class="section section--details section--bg">
    <!-- details content -->
    <div class="container">
        <div class="row">
            <!-- title -->
            <div class="col-12">
                <h1 class="section__title">Movies List</h1>
            </div>
        </div>
        <div class="w3-row">
            @foreach($links as $index => $link)
            <div class="w3-col l6 m6 s12">
                <div class="w3-row">
                    <a class="card__title" href="{{$link['link']}}">{{$index+1}}. {{$link['name']}}</a>
                </div>
            </div>
            @endforeach
        </div>
    </div>
</section>
@endsection
@section('seo')
<meta name="description" content="Movies List" />
<meta name="og:title" content="Movies List">
<meta name="og:url" content="/reviews_movies.html">
<meta name="og:description" content="Movies List">
<meta name="og:image" content="/img/logo.png">
<meta name="robots" content="index, follow">
<meta property="og:site_name" content="MyMovies PK">

<meta name="twitter:title" content="Movies List">
<meta name="twitter:description" content="Movies List">
<meta name="twitter:image" content="/img/logo.png">
<meta name="twitter:card" content="/img/logo.png">
<meta name="twitter:image" content="/img/logo.png">
@endsection