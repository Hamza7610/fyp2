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

class UserController extends Controller
{
    public function index(Request $request)
    {
        $user = User::find($request->session()->get('user_id'));
        return view('login.user.profile', ['user' => $user]);
    }
    public function updateprofiledetails(Request $request)
    {
        $this->validate($request, [
            'name'        =>   'required',
        ]);
        try {
            $user = User::find($request->session()->get('user_id'));
            $user->name = $request['name'];
            $user->save();
            $request->session()->flash('success', 'User information saved');
        } catch (Exception $e) {
            return redirect('/user')->withFail('Error in saving');
        }
        return redirect('/user');
    }
    public function updatenumberstoprofile(Request $request)
    {
        try {
            $numbers = json_decode($request['numbers']);
            $user_id = $request['user_id'];
            $numberIds = [];

            foreach ($numbers as $number) {
                $userNumber = User_PhoneNumbers::where([
                    ['phoneNumber', '=', $number],
                    ['user_id', '=', $user_id]
                ])->first();
                if ($userNumber == null) {
                    $userNumber = new User_PhoneNumbers;
                    $userNumber->phoneNumber = $number;
                    $userNumber->user_id = $user_id;
                    $userNumber->save();
                }
                array_push($numberIds, $userNumber->id);
            }
            $deletePhoneNumbes = User_PhoneNumbers::whereNotIn('id', $numberIds)->delete();
            return  response()->json([
                'code' => 1,
            ]);
        } catch (Exception $e) {
        }
        return  response()->json([
            'code' => 0,
        ]);
    }
    public function updatepasswordtoprofile(Request $request)
    {
        $this->validate($request, [
            'oldP'        =>   'required',
            'newP'      =>   'required',
            'rnewP'      =>   'required',
        ]);
        try {
            $user = User::find($request->session()->get('user_id'));
            if (!(Hash::check($request['oldP'], $user->secret_key))) {
                return redirect('/user')->withFail('Old Password doesnt match');
            }
            $user->secret_key = Hash::make($request['rnewP'], [
                'rounds' => 12
            ]);
            $user->save();
            $request->session()->flash('success', 'User password changed');
        } catch (Exception $e) {
            return redirect('/user')->withFail('Error in changing password');
        }
        return redirect('/user');
    }
}
