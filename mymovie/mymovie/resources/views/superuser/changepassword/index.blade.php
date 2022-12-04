@extends('superuser.index')
@section('content')
<section class="section section--details section--bg">

    <div class="w3-content">
        <form action="{!! url('/su/editpassword'); !!}" method="POST">
            <div class="row">
                <h3 class="w3-text-white">Change Password</h3>
            </div>
            <div class="row">
                <label class="w3-text-white">Old Password</label>
                <input name="oldP" type="password" placeholder="Old Password">

            </div>
            <div class="row">
                <label class="w3-text-white">New Password</label>
                <input name="newP" type="password" placeholder="New Password">
            </div>
            <div class="row">
                <label class="w3-text-white">Re-Type New Password</label>
                <input name="rnewP" type="password" placeholder="Re-Type New Password">
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
@endsection