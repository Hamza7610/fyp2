<?php

namespace App\Http\Controllers;

use App\Genre;
use App\Movie;
use App\MovieGenre;
use App\MovieReviews;
use App\MovieYears;
use App\Year;
use Exception;
use Illuminate\Http\Request;

class MovieReviewsController extends Controller
{
    public function index()
    {

        $movies = Movie::doesnthave('reviews')->OrderBy('id', 'ASC')->select('id', 'name')->get();
        $genres = $this->getgenres();
        $years = $this->getyears();
        $movies_without_link = MovieReviews::with('movie')->Where('link', null)->get();

        return view(
            'reviews.movies.index',
            ['movies' => $movies, 'genres' => $genres, 'years' => $years, 'movies_without_link' => $movies_without_link]
        );
    }
    public function storereviews(Request $request)
    {
        $request->validate([
            'id' => ['required', 'gt:0'],
            'description' => 'required',
            'imdbrating' => 'required',
            'genre' => 'required_if:newgenre,==,""|array|nullable',
            'newgenre' => 'required_if:genre,==,gt:0|nullable',
            'rating' => ['required', 'gt:0'],
            'review' => 'required',
            'year' => ['required', 'gt:0'],
            'link' => 'required'
        ]);
        $data = $request->all();
        try {
            $genarray = [];
            if ($data['newgenre']) {
                $genres = explode(',', $data['newgenre']);
                foreach ($genres as $genre) {
                    $gen = Genre::firstorCreate(['genre' => rtrim(ltrim($genre))]);
                    array_push($genarray, $gen->id);
                }
            }
            if (count($genarray)) {
                foreach ($genarray as $genre) {
                    MovieGenre::firstorCreate(['movie_id' => $data['id'], 'genre_id' => $genre]);
                }
            }
            if ($data['genre']) {
                foreach ($data['genre'] as $genre) {
                    MovieGenre::firstorCreate(['movie_id' => $data['id'], 'genre_id' => $genre]);
                }
            }
            MovieYears::firstorCreate(['movie_id' => $data['id'], 'year_id' => $data['year']]);
            $moviegenres = MovieGenre::with('genre')->where('movie_id', $data['id'])->get();
            $moviegenre = '';
            foreach ($moviegenres as $key => $mgenre) {
                if ($key === (count($moviegenres) - 1)) {
                    $moviegenre = $moviegenre . $mgenre->genre->genre;
                } else {
                    $moviegenre = $moviegenre . $mgenre->genre->genre . ',';
                }
            }
            $movie_review = MovieReviews::firstOrNew(['movie_id' => $data['id']]);
            $movie_review->description = $data['description'];
            $movie_review->imdbrating = $data['imdbrating'];
            $movie_review->genre = $moviegenre;
            $movie_review->rating = $data['rating'];
            $movie_review->review = $data['review'];
            $movie_review->link = $data['link'];
            $movie_review->save();
            $request->session()->flash('success', 'Movie Review Saved');
            return redirect('/su/movies');
        } catch (Exception $e) {
            dd($e->getMessage());
        }
        return redirect('/su/movies')->withFail('Error in creating review');
    }
    public function updatemovielinks(Request $request)
    {
        $request->validate([
            'id' => ['required', 'gt:0'],
            'link' => 'required'
        ]);
        $data = $request->all();

        try {
            $movie_review = MovieReviews::find($data['id']);
            $movie_review->link = $data['link'];
            $movie_review->save();
            $request->session()->flash('success', 'Movie Review Saved');
            return redirect('/su/movies');
        } catch (Exception $e) {
            dd($e->getMessage());
        }
        return redirect('/su/movies')->withFail('Error in creating review');
    }
}
