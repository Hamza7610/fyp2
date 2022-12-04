@extends('superuser.index')
@section('content')

<section class="section section--details section--bg">
    <div class="w3-content">
        <div class="jsGrid"></div>
        {{ csrf_field() }}
    </div>
</section>
@endsection
@section('script')
<script src="/js/jsgrid.min.js"></script>
<script src="/js/superuser/User.js"></script>
@endsection
@section('css')
<link href="/css/jsgrid.min.css" rel="stylesheet">
<link href="/css/jsgrid-theme.min.css" rel="stylesheet">
@endsection