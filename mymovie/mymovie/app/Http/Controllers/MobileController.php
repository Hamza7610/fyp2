<?php

namespace App\Http\Controllers;

use App\Movie;
use App\MovieRequest;
use App\User;
use App\WatchingMovie;
use App\WathcingSeason;
use Carbon\Carbon;
use Exception;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Session;
use App\SeasonDetail;
use App\Year;
use Illuminate\Support\Facades\Log;
use Illuminate\Support\Facades\Mail;

class MobileController extends Controller
{
    public function storeuser(Request $request)
    {
        try {
            $alreadyExists = User::where('email', '=', $request["email"])->first();
            if ($alreadyExists != null) {
                return response()->json([
                    'code' => -1,
                    'user' => null,
                    'session_id' => null
                ]);
            }
            $user = new User;
            $user->name = $request["name"];
            $user->email = $request["email"];
            $user->price_plans_id = 3;
            $user->expiry = (Carbon::now())->addDays(360);
            $user->secret_key = Hash::make($request["password"], [
                'rounds' => 12
            ]);
            $user->session_id = Session::getId();
            $user->save();
            return response()->json([
                'code' => 1,
                'user' => $user->id,
                'session_id' => $user->session_id
            ]);
        } catch (Exception $e) {
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null,
                'Message' => $e->getMessage()
            ]);
        }
    }
    public function login(Request $request)
    {
        try {
            $email = $request["email"];
            $password = $request["password"];
            $user = User::where('email', '=', $email)->first();
            if ($user != null) {
                if (Hash::check($password, $user->secret_key)) {
                    if ($user->activated) {
                        $user->loginstatus = true;
                        $user->session_id = Session::getId();
                        $user->save();
                        return response()->json([
                            'code' => 2,
                            'user' => $user->id,
                            'session_id' => $user->session_id
                        ]);
                        return redirect('/welcome');
                    } else {
                        return response()->json([
                            'code' => -2,
                            'user' => null,
                            'session_id' => null
                        ]);
                    }
                }
            }
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        } catch (Exception $e) {
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        }
    }
    public function sessionauth(Request $request)
    {
        try {
            $user_id = $request["user_id"];
            $session_id = $request["session_id"];
            $user = User::where(['id' => $user_id, 'session_id' => $session_id])->first();
            if ($user != null) {
                if ($user->activated) {
                    $user->loginstatus = true;
                    $user->save();
                    return response()->json([
                        'code' => 2,
                        'user' => $user->id,
                        'session_id' => $user->session_id
                    ]);
                } else {
                    return response()->json([
                        'code' => -2,
                        'user' => null,
                        'session_id' => null
                    ]);
                }
            }
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        } catch (Exception $e) {
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        }
    }
    public function logout(Request $request)
    {
        try {
            $user_id = $request["user_id"];
            $session_id = $request["session_id"];
            $user = User::where(['id' => $user_id, 'session_id' => $session_id])->first();
            if ($user != null) {
                $user->session_id = '';
                $user->save();
                return response()->json([
                    'code' => 2,
                    'user' => $user->id,
                    'session_id' => $user->session_id
                ]);
            }
            return response()->json([
                'code' => 2,
                'user' => null,
                'session_id' => null
            ]);
        } catch (Exception $e) {
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null,
                'Message' => $e->getMessage()
            ]);
        }
    }
    public function requestMovie(Request $request)
    {
        try {
            $user_id = $request["user_id"];
            $movierequest = new MovieRequest;
            $movierequest->movie = $request["movie_name"];;
            $movierequest->user_id = $user_id;
            $movierequest->save();
            return response()->json([
                'code' => 1
            ]);
        } catch (Exception $e) {
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null,
                'Message' => $e->getMessage()
            ]);
        }
    }
    public function updateview($id)
    {
        try {
            $movie = Movie::find($id);
            $movie->views = $movie->views + 1;
            $movie->save();
            return response()->json(["code" => 1]);
        } catch (Exception $e) {
        }
        return response()->json(["code" => 0]);
    }
    public function updatewatchingmovie(Request $request)
    {
        try {
            $movie_id = $request['movie_id'];
            $user_id = $request['user_id'];
            $wathching = new WatchingMovie;
            $wathching->movie_id =  $movie_id;
            $wathching->user_id = $user_id;
            $wathching->save();
            return response()->json(["code" => 1]);
        } catch (Exception $e) {
            return response()->json(["code" => 0, 'Message' => $e->getMessage()]);
        }
    }
    public function updatewatchingseason(Request $request)
    {
        try {
            $season_detail_id = $request['season_detail_id'];
            $user_id = $request['user_id'];
            $season_detail = SeasonDetail::find($season_detail_id);
            $seasonwatching = new WathcingSeason;
            $seasonwatching->season_id = $season_detail->season_id;
            $seasonwatching->user_id = $user_id;
            $seasonwatching->season_detail_id = $season_detail->id;

            $seasonwatching->save();
            return response()->json(["code" => 1]);
        } catch (Exception $e) {
            return response()->json(["code" => 0, 'Message' => $e->getMessage()]);
        }
    }
    public function getuser(Request $request)
    {
        try {
            $user_id = $request["user_id"];
            $session_id = $request["session_id"];
            $user = User::where(['id' => $user_id, 'session_id' => $session_id])->first();
            if ($user != null) {
                return response()->json($user);
            }
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        } catch (Exception $e) {
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        }
    }
    public function changepassword(Request $request)
    {
        try {
            $user_id = $request["user_id"];
            $session_id = $request["session_id"];
            $oldpass = $request["oldpass"];
            $newpass = $request["newpass"];
            $user = User::where(['id' => $user_id, 'session_id' => $session_id])->first();
            if ($user != null) {
                if (Hash::check($oldpass, $user->secret_key)) {
                    $user->secret_key = Hash::make($newpass, ['rounds' => 12]);
                    $user->save();
                    return response()->json([
                        'code' => 1,
                        'user' => null,
                        'session_id' => null
                    ]);
                }
                return response()->json([
                    'code' => 0,
                    'user' => null,
                    'session_id' => null
                ]);
            }
        } catch (Exception $e) {
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        }
    }
    public function forgetpassword(Request $request)
    {
        try {
            $email = $request['email'];
            $user = User::where(['email' => $email])->first();
            $password = $this->random_string();
            if ($user != null) {
                try {
                    Mail::send('forgetpassword', ['user' => $user, 'password' => $password], function ($message) use ($user) {
                        $message
                            ->to($user->email, $user->name)
                            ->subject('New Password')
                            ->from('info@mymovies.pk', 'MyMoviesPk');
                    });
                    $user->secret_key = Hash::make($password, ['rounds' => 12]);
                    $user->save();
                    return response()->json([
                        'code' => 1,
                        'user' => null,
                        'session_id' => null
                    ]);
                } catch (Exception $e) {
                    dd($e);
                    Log::error("Sending Mail had error " . $e->getMessage());
                }
            } else {
                return response()->json([
                    'code' => 2,
                    'user' => null,
                    'session_id' => null
                ]);
            }
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        } catch (Exception $e) {
            return response()->json([
                'code' => 0,
                'user' => null,
                'session_id' => null
            ]);
        }
    }
}
