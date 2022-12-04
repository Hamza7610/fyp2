@if ($message = Session::get('success'))
<div class="alert alert-success alert-block">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>{{ $message }}</strong>
</div>
@endif


@if ($message = Session::get('fail'))
<div class="alert alert-danger alert-block">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>{{ $message }}</strong>
</div>
@endif


@if ($message = Session::get('warning'))
<div class="alert alert-warning alert-block">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>{{ $message }}</strong>
</div>
@endif


@if ($message = Session::get('info'))
<div class="alert alert-info alert-block">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Would you like to add phonenumber and address ?</strong>
    <a href="/admin/modifyprofile">clcik to add info</a>
</div>
@endif


@if (isset($errors) && $errors->any())

@if($errors && count($errors)>0)
<div class="alert alert-danger alert-dismissible fade show" role="alert">
    Please check the form below for errors
    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
        <span aria-hidden="true">&times;</span>
        <span class="sr-only">Close</span>
    </button>


    <ul>
        @foreach($errors->all() as $error)
        <li> {{$error}}</li>
        @endforeach
    </ul>
    </strong>
</div>

@endif
@endif
@if($message = Session::get('success') || $message = Session::get('fail') ||
$message = Session::get('warning') || (isset($errors) && $errors->any()))
<script>
    $("document").ready(function() {
        setTimeout(function() {
            $("div.alert").remove();
        }, 5000); // 5 secs

    });
</script>
@endif