<?php

namespace App\Http\Controllers;

use GuzzleHttp\Client;
use Illuminate\Http\Request;
use App\Http\Enums\SUUserControllerConstants;
use App\User;
use Exception;
use Illuminate\Support\Facades\Hash;

class SUUserController extends Controller
{
    public function index()
    {
        return view('superuser/user/index');
    }
    public function getUsers()
    {
        $Users = User::all();
        return $Users;
    }
    public function EditUsers(Request $request)
    {
        try {
            $user = json_decode($request["user"]);
            $userch = User::find($user->id);
            if ($user->secret_key != '') {
                $userch->secret_key = Hash::make($user->secret_key, [
                    'rounds' => 12
                ]);
            }
            if ($user->email != $userch->email) {
                $userch->email = $user->email;
            }
            if ($user->name != $userch->name) {
                $userch->name = $user->name;
            }
            if ($user->activated != $userch->activated) {
                $userch->activated = $user->activated;
            }
            $userch->save();
            return 1;
        } catch (Exception $e) {
            return 0;
        }
    }
}
