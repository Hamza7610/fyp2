<?php

namespace App\Http\Controllers;

use App\User;
use Exception;
use Carbon\Carbon;
use App\User_PhoneNumbers;
use Illuminate\Http\Request;
use Illuminate\Http\Response;
use Illuminate\Support\Facades\Log;
use Illuminate\Support\Facades\Hash;
use App\Http\Enums\LoginControllerConstants;

use Illuminate\Support\Facades\Cookie;
use Illuminate\Support\Facades\Session;

class LoginController extends Controller
{
    public function login(Request $request)
    {
        $request->session()->flush();
        try {
            $email = $request["email"];
            $password = $request["password"];
            $user = User::where('email', '=', $email)->first();
            if ($user != null) {
                if (Hash::check($password, $user->secret_key)) {
                    if ($user->activated) {
                        $user->loginstatus = true;
                        $request->session()->put('user_id', $user->id);
                        $request->session()->put('user_type', $user->usertype);
                        if ($request->remember == 'on') {
                            $cookie =  cookie()->forever('session_id', Session::getId());
                            $user->session_id = Session::getId();
                            $user->save();
                            return redirect('/welcome')->cookie($cookie);
                        }
                        return redirect('/welcome');
                    } else {
                        return redirect('/login')->withInput()->withFail('Account not activated please contact admin');
                    }
                }
            }
            return redirect('/login')->withInput()->withFail('Wrong email or password');
        } catch (Exception $e) {
            dd($e);
            return redirect('/login')->withInput()->withFail('Error loging in');
        }
    }

    public function storeuser(Request $request)
    {
        $expiry = 0;
        if ($request["plans"] == 1) {
            $expiry = 7;
        } elseif ($request["plans"] == 1) {
            $expiry = 30;
        } else {
            $expiry = 180;
        }

        try {
            $alreadyExists = User::where('email', '=', $request["email"])->first();
            if ($alreadyExists != null) {
                return redirect('login')->withInput()->withFail('User already exisits');
            }
            $user = new User;
            $user->name = $request["name"];
            $user->email = $request["email"];
            $user->price_plans_id = $request["plans"];
            $user->expiry = (Carbon::now())->addDays($expiry);
            $user->secret_key = Hash::make($request["password"], [
                'rounds' => 12
            ]);
            if (isset($request['usertype'])) {
                $user->usertype = $request["usertype"];
            }
            $user->save();
            $request->session()->flash('success', 'User created please contact admin to activate the account');

            return redirect('login');
        } catch (Exception $e) {

            return redirect('login')->withInput()->withFail('User creation error');
        }
    }

    public function logout(Request $request)
    {
        $user_id = $request->session()->get('user_id');
        $user = User::find($user_id);

        $user->loginstatus = false;
        $request->session()->flush();
        return redirect('/')->cookie(cookie()->forget('session_id'));;
    }
    public function storeadmin(Request $request)
    {
        try {
            $alreadyExists = User::where('email', '=', $request["email"])->first();
            if ($alreadyExists != null) {
                return redirect('admin/createadmin')->withInput()->withFail('User already exisits');
            }
            $user = new User;
            $user->name = $request["name"];
            $user->email = $request["email"];
            $user->id_card_number = $request["id_card_number"];
            $user->secret_key = Hash::make($request["password"], [
                'rounds' => 12
            ]);
            if (isset($request['usertype'])) {
                $user->usertype = $request["usertype"];
            }
            if (isset($request['activated'])) {
                $user->activated = $request["activated"];
            }
            $user->save();
            $request->session()->flash('success', 'Admin created');
            return redirect('/');
        } catch (Exception $e) {
            return redirect('admin/createadmin')->withInput()->withFail('Admin creating error');
        }
    }
}
