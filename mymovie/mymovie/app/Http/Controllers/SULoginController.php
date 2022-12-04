<?php

namespace App\Http\Controllers;

use App\Su_details;
use Illuminate\Http\Request;

use Illuminate\Support\Facades\Hash;
use App\Http\Enums\SULoginControllerConstants;

class SULoginController extends Controller
{
    public function index()
    {
        return view('superuser/Login/index');
    }
    public function Login(Request $request)
    {
        $name = $request["u"];
        $password = $request["p"];
        $user = Su_details::where('name', '=', $name)->first();
        if ($user != null) {
            if (Hash::check($password, $user->secret_key)) {
                $user->session_id = $request["session_id"];
                $user->save();
                $request->session()->put('su_id', $user->id);
                return redirect('su/welcome');
            }
        }
        return redirect('/su')->withInput()->withFail('Wrong email or password');
    }
    public function Logout(Request $request)
    {
        $id = $request["su_id"];
        $su_user = Su_details::where(['session_id' => $request["session_id"], 'id' => $id])->first();
        $request->session()->flush();
        return view('superuser/Login/index');
    }
    public function changePassword()
    {
        return view('superuser/changepassword/index');
    }
    public function supage()
    {
        return view('superuser/index');
    }
    public function EditPassword(Request $request)
    {
        $data = $request->all();
        $messages = [
            'oldP.required' => 'Old Password is required',
            'newP.required' => 'New Password is required',
            'rnewP.required' => 'Re-Type New Password'
        ];
        $request->validate([
            'oldP' => ['required'],
            'newP' => 'required',
            'rnewP' => 'required',
        ], $messages);

        $id = $request->session()->get('su_id');
        $user = Su_details::find($id)->first();

        if ($user != null) {
            if (Hash::check($data['oldP'], $user->secret_key)) {
                $user->secret_key = Hash::make($data['rnewP'], [
                    'rounds' => 12
                ]);;
                $user->save();
                $request->session()->flash('success', 'Password Changed');
                return redirect()->back();
            } else {
                return redirect()->back()->withFail('Old Password doest Match');
            }
        }
        return redirect()->back()->withFail('Error in Password Change');
    }
}
