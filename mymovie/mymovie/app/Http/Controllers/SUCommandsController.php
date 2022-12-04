<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Artisan;

class SUCommandsController extends Controller
{
    public function index()
    {
        return view('superuser.commands.index');
    }    
    public function clearcache()
    {
        Artisan::call('cache:clear');
        return redirect()->back();
    }    
}
