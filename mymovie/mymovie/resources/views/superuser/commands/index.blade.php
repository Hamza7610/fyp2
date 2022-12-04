@extends('superuser.index')
@section('content')
<section class="section section--details section--bg">

    <div class="w3-content">
        <form action="{!! url('/su/commands/clearcache'); !!}" method="POST">
            <input type="submit" value="Clear Cache">
            {{ csrf_field() }}
        </form>
    </div>
</section>
@endsection
@section('script')
@endsection
@section('css')
@endsection