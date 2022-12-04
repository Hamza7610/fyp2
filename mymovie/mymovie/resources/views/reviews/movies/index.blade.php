@extends('superuser.index')
@section('content')

<section class="section section--details section--bg">

    <div class="w3-content">
        <form action="{!! url('/su/movies/storereviews'); !!}" method="POST">
            <div class="row">
                <label class="w3-text-white">Movie</label>
                <select name="id">
                    <option value="-1">Select a movie</option>
                    @foreach($movies as $movie )
                    <option value="{{$movie->id}}">{{$movie->name}}</option>
                    @endforeach
                </select>
            </div>
            <div class="row">
                <label class="w3-text-white">Description</label>
                <input name="description" type="text" class="">
            </div>
            <div class="row">
                <label class="w3-text-white">IMDB Rating</label>
                <select name="imdbrating">
                    <option value="-1">Select IMDB Rating</option>
                    <option value="1.0">1.0</option>
                    <option value="1.1">1.1</option>
                    <option value="1.2">1.2</option>
                    <option value="1.3">1.3</option>
                    <option value="1.4">1.4</option>
                    <option value="1.4">1.4</option>
                    <option value="1.5">1.5</option>
                    <option value="1.6">1.6</option>
                    <option value="1.7">1.7</option>
                    <option value="1.8">1.8</option>
                    <option value="1.9">1.9</option>
                    <option value="2.0">2.0</option>
                    <option value="2.1">2.1</option>
                    <option value="2.2">2.2</option>
                    <option value="2.3">2.3</option>
                    <option value="2.4">2.4</option>
                    <option value="2.4">2.4</option>
                    <option value="2.5">2.5</option>
                    <option value="2.6">2.6</option>
                    <option value="2.7">2.7</option>
                    <option value="2.8">2.8</option>
                    <option value="2.9">2.9</option>
                    <option value="3.0">3.0</option>
                    <option value="3.1">3.1</option>
                    <option value="3.2">3.2</option>
                    <option value="3.3">3.3</option>
                    <option value="3.4">3.4</option>
                    <option value="3.4">3.4</option>
                    <option value="3.5">3.5</option>
                    <option value="3.6">3.6</option>
                    <option value="3.7">3.7</option>
                    <option value="3.8">3.8</option>
                    <option value="3.9">3.9</option>
                    <option value="4.0">4.0</option>
                    <option value="4.1">4.1</option>
                    <option value="4.2">4.2</option>
                    <option value="4.3">4.3</option>
                    <option value="4.4">4.4</option>
                    <option value="4.4">4.4</option>
                    <option value="4.5">4.5</option>
                    <option value="4.6">4.6</option>
                    <option value="4.7">4.7</option>
                    <option value="4.8">4.8</option>
                    <option value="4.9">4.9</option>
                    <option value="5.0">5.0</option>
                    <option value="5.1">5.1</option>
                    <option value="5.2">5.2</option>
                    <option value="5.3">5.3</option>
                    <option value="5.4">5.4</option>
                    <option value="5.4">5.4</option>
                    <option value="5.5">5.5</option>
                    <option value="5.6">5.6</option>
                    <option value="5.7">5.7</option>
                    <option value="5.8">5.8</option>
                    <option value="5.9">5.9</option>
                    <option value="6.0">6.0</option>
                    <option value="6.1">6.1</option>
                    <option value="6.2">6.2</option>
                    <option value="6.3">6.3</option>
                    <option value="6.4">6.4</option>
                    <option value="6.4">6.4</option>
                    <option value="6.5">6.5</option>
                    <option value="6.6">6.6</option>
                    <option value="6.7">6.7</option>
                    <option value="6.8">6.8</option>
                    <option value="6.9">6.9</option>
                    <option value="7.0">7.0</option>
                    <option value="7.1">7.1</option>
                    <option value="7.2">7.2</option>
                    <option value="7.3">7.3</option>
                    <option value="7.4">7.4</option>
                    <option value="7.4">7.4</option>
                    <option value="7.5">7.5</option>
                    <option value="7.6">7.6</option>
                    <option value="7.7">7.7</option>
                    <option value="7.8">7.8</option>
                    <option value="7.9">7.9</option>
                    <option value="8.0">8.0</option>
                    <option value="8.1">8.1</option>
                    <option value="8.2">8.2</option>
                    <option value="8.3">8.3</option>
                    <option value="8.4">8.4</option>
                    <option value="8.4">8.4</option>
                    <option value="8.5">8.5</option>
                    <option value="8.6">8.6</option>
                    <option value="8.7">8.7</option>
                    <option value="8.8">8.8</option>
                    <option value="8.9">8.9</option>
                    <option value="9.0">9.0</option>
                    <option value="9.1">9.1</option>
                    <option value="9.2">9.2</option>
                    <option value="9.3">9.3</option>
                    <option value="9.4">9.4</option>
                    <option value="9.4">9.4</option>
                    <option value="9.5">9.5</option>
                    <option value="9.6">9.6</option>
                    <option value="9.7">9.7</option>
                    <option value="9.8">9.8</option>
                    <option value="9.9">9.9</option>
                    <option value="10">10.0</option>
                </select>
            </div>
            <div class="row">
                <label class="w3-text-white">Genre</label>
                <input name="newgenre" type="text" class="">
            </div>
            <div class="row w3-margin-top">
                @foreach($genres as $genre)
                <div class="w3-col l3 m4 s6">
                    <input name="genre[]" type="checkbox" class="" value="{{$genre->id}}">
                    <label for="genre[]" class="w3-text-white">{{$genre->genre}}</label>
                </div>
                @endforeach
            </div>
            <div class="row">
                <label class="w3-text-white">Year</label>
                <select name="year">
                    <option value="-1">Select a Year</option>
                    @foreach($years as $index => $year)
                    <option value="{{$year->id}}">{{$year->year}}</option>
                    @endforeach
                </select>
            </div>
            <div class="row">
                <label class="w3-text-white">Youtube link</label>
                <input name="link" type="text" class="">
            </div>
            <div class="row">
                <label class="w3-text-white">Rating Stars</label>
                <select name="rating">
                    <option value="-1">Select Rating Stars</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                </select>
            </div>
            <div class="row">
                <label class="w3-text-white">Reviews</label>
                <textarea name="review" rows="10" class=""></textarea>
            </div>

            <input type="submit" value="Submit">
            {{ csrf_field() }}
        </form>
    </div>


</section>
@endsection
@section('script')
@endsection
@section('css')
<style>
    input[type=text],
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

    input[type=checkbox] {
        appearance: auto !important;
    }
</style>
@endsection