<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Movie;
use App\MovieRequest;
use App\WatchingMovie;
use Exception;
use Illuminate\Contracts\Session\Session;

class MovieController extends Controller
{
    public function get($id = 0)
    {
        try {
            $movies = cache()->remember('movies_mobile', $this->CacheTime(), function () {
                $movies = Movie::where('isKid', 0)->with('reviews')->OrderBy('id', 'DESC')->get()->toArray();
                $movieslist = [];
                foreach ($movies as $movie) {
                    $movie['image_path'] = $this->getThumbnail($movie['filename']);
                    array_push($movieslist, $movie);
                }
                return json_encode($movieslist);
            });
            return $movies;
        } catch (Exception $ex) {
            dd($ex);
        }
    }
    public function store()
    {
    }
    public function play($id, Request $request)
    {
        $movie = Movie::with('reviews')->find($id);
        $movie->views = $movie->views + 1;
        $movie->save();
        $wathching = new WatchingMovie;
        $wathching->movie_id =  $movie->id;
        $wathching->user_id = $request->session()->get('user_id');
        $wathching->save();
        $movie = Movie::with('reviews')->find($id);
        return View('playmovie', ['filename' => $movie->filename, 'name' => $movie->name, 'movie' => $movie]);
    }
    public function requestMovie(Request $request)
    {

        try {
            $user_id = $request->session()->get('user_id');
            $movierequest = new MovieRequest;
            $movierequest->movie = $request->movierequest;
            $movierequest->user_id = $user_id;
            $movierequest->save();
        } catch (Exception $e) {
            dd($e);
            return redirect('/')->withInput()->withFail('Error in movie request');
        }
    }
    public function loadmovie()
    {
    }
    public function load_data(Request $request)
    {
        if ($request->ajax()) {

            try {
                if ($request->session()->get('user_id')) {
                    $movies = cache()->remember('movies_session', $this->CacheTime(), function () {
                        $movies = Movie::where('isKid', 0)->with('reviews')->select('id', 'name', 'duration', 'filename', 'views', 'created_at')->orderBy('id', 'DESC')->get();
                        $view = view('movieloadmore', ['movies' => $movies, 'session' => true])->render();
                        return $view;
                    });
                    return $movies;
                } else {
                    $movies = cache()->remember('movies_nosession', $this->CacheTime(), function () {
                        $movies = Movie::where('isKid', 0)->with('reviews')->select('id', 'name', 'duration', 'filename', 'views', 'created_at')->orderBy('id', 'DESC')->get();
                        $view = view('movieloadmore', ['movies' => $movies, 'session' => false])->render();
                        return $view;
                    });
                    return $movies;
                }
            } catch (Exception $ex) {
                dd($ex);
            }
        }
    }
    public function searchMovie(Request $request)
    {
        if ($request->get('query')) {
            $query = $request->get('query');
            $movies = Movie::where('isKid', 0)->where('name', 'LIKE', "%{$query}%")
                ->with('reviews')
                ->select('id', 'name', 'duration', 'description', 'filename', 'views', 'created_at')
                ->orderBy('id', 'DESC')->get();
            return view('movieloadmore', ['movies' => $movies, 'session' => $request->session()->get('user_id') ? true : false]);
        }
    }
}
