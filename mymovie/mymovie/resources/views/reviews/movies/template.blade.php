@extends('layouts.app')
@section('content')
<!-- details -->
<section class="section section--details section--bg">
    <!-- details content -->
    <div class="container">
        <div class="row">
            <ul class="breadcrumb">
                <li><a href="/reviews_movies.html">Movies List</a></li>
                <li>{{$name}}</li>
            </ul>
            <!-- title -->
            <div class="col-12">
                <h3 class="section__title">{{$name}}</h3>
            </div>
            <div class="w3-container">
                <div class="w3-row">
                    @if($movie->reviews)
                    @if($movie->reviews->link)
                    <div class="w3-col l6 m6 s12">
                        <iframe allowfullscreen="allowfullscreen" mozallowfullscreen="mozallowfullscreen" msallowfullscreen="msallowfullscreen" oallowfullscreen="oallowfullscreen" webkitallowfullscreen="webkitallowfullscreen" class="w3-mobile" scrolling="no" style="border: 5px solid black;width:90%;height:120%;" src="https://www.youtube.com/embed/{{App\Http\Controllers\Controller::getvideoId($movie->reviews->link)}}">
                        </iframe>
                    </div>
                    @endif
                    @endif
                    <div class="w3-col l6 m6 s12">
                        <div class="card__content">
                            @if($movie->reviews)
                            <span class="card__category">
                                <span class="comments__time">{{$movie->reviews->description}}</span>
                            </span>
                            <div class="w3-row">
                                <div class="w3-half">
                                    <span class="card__category">
                                        @for($i=1;$i<=5;$i++) @if((int)$movie->reviews->rating >=$i) <span class="fa fa-star checked"></span>
                                            @else
                                            <span class="fa fa-star"></span>
                                            @endif
                                            @endfor
                                    </span>
                                </div>
                                <div class="w3-half">
                                    <span class="card__category">
                                        <span class="comments__time">
                                            <strong><span itemprop="ratingValue">{{$movie->reviews->imdbrating}}</span></strong><span class="grey">/</span><span class="grey" itemprop="bestRating">10 IMDb</span>
                                        </span>
                                    </span>
                                </div>
                            </div>
                            <span class="card__category w3-margin-top">
                                <span class="comments__time">{{$movie->reviews->genre}}</span>
                            </span>
                            <span class="card__category w3-margin-top">
                                <span class="comments__time">{{$movie->reviews->review}}</span>
                            </span>
                            @endif
                        </div>
                    </div>
                </div>


            </div>
            <!-- end player -->
        </div>
    </div>
    <!-- end details content -->
</section>
<!-- end details -->

@endsection
@section('script')

@endsection
@section('css')
<style>
    .comments__time {
        font-size: 18px !important;
    }

    ul.breadcrumb {
        padding: 10px 16px;
        list-style: none;
    }

    ul.breadcrumb li {
        display: inline;
        font-size: 18px;
        color: white;
    }

    ul.breadcrumb li+li:before {
        padding: 8px;
        content: "/\00a0";
    }

    ul.breadcrumb li a {
        text-decoration: none;
    }

    ul.breadcrumb li a:hover {
        text-decoration: underline;
    }
</style>
@endsection
@section('seo')
<meta name="description" content="{{$name}}" />
<meta name="og:title" content="{{$name}}">
<meta name="og:url" content="/reviews/movies/{{$name}}.html">
<meta name="og:description" content="Watch movie {{$name}}">
<meta name="og:image" content="{{App\Http\Controllers\Controller::getReviewThumbnail($filename)}}">
<meta name="robots" content="index, follow">
<meta property="og:site_name" content="MyMovies PK">

<meta name="twitter:title" content="Watch movie {{$name}}">
<meta name="twitter:description" content="Watch movie {{$name}}">
<meta name="twitter:image" content="{{App\Http\Controllers\Controller::getReviewThumbnail($filename)}}">
<meta name="twitter:card" content="{{App\Http\Controllers\Controller::getReviewThumbnail($filename)}}">
<meta name="twitter:image" content="{{App\Http\Controllers\Controller::getReviewThumbnail($filename)}}">
@endsection