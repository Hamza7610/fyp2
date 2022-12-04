<?php

namespace App\Http\Controllers;

use App\Genre;
use Exception;
use App\Season;
use App\SeasonGenre;
use App\SeasonReviews;
use App\SeasonYears;
use Illuminate\Http\Request;

class SeasonReviewsController extends Controller
{
    public function index()
    {
        $seasons = Season::doesnthave('reviews')->OrderBy('id', 'ASC')->get();
        $genres = $this->getgenres();
        $years = $this->getyears();
        $seasonswithoutlink = SeasonReviews::with('season')->Where('link', null)->get();
        return view(
            'reviews.seasons.index',
            ['seasons' => $seasons, 'genres' => $genres, 'years' => $years, 'seasonswithoutlink' => $seasonswithoutlink]
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
            'rating' => 'required',
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
                    SeasonGenre::firstorCreate(['season_id' => $data['id'], 'genre_id' => $genre]);
                }
            }
            if ($data['genre']) {
                foreach ($data['genre'] as $genre) {
                    SeasonGenre::firstorCreate(['season_id' => $data['id'], 'genre_id' => $genre]);
                }
            }
            SeasonYears::firstorCreate(['season_id' => $data['id'], 'year_id' => $data['year']]);
            $seasongenres = SeasonGenre::with('genre')->where('season_id', $data['id'])->get();
            $seasongenre = '';
            foreach ($seasongenres as $key => $sgenre) {
                if ($key === (count($seasongenres) - 1)) {
                    $seasongenre = $seasongenre . $sgenre->genre->genre;
                } else {
                    $seasongenre = $seasongenre . $sgenre->genre->genre . ',';
                }
            }
            $Season_review = SeasonReviews::firstOrNew(['season_id' => $data['id']]);
            $Season_review->description = $data['description'];
            $Season_review->imdbrating = $data['imdbrating'];
            $Season_review->genre = $seasongenre;
            $Season_review->rating = $data['rating'];
            $Season_review->review = $data['review'];
            $Season_review->link = $data['link'];
            $Season_review->save();
            $request->session()->flash('success', 'Season Review Saved');
            return redirect('/su/seasons');
        } catch (Exception $e) {
            dd($e->getMessage());
        }
        return redirect('/su/seasons')->withFail('Error in creating review');
    }
    public function updateseasonlinks(Request $request)
    {
        $request->validate([
            'id' => ['required', 'gt:0'],
            'year' => ['required', 'gt:0'],
            'link' => 'required'
        ]);
        $data = $request->all();
        try {
            $season_review = SeasonReviews::find($data['id']);
            $season_review->link = $data['link'];
            $season_review->save();
            SeasonYears::firstorCreate(['season_id' => $data['id'], 'year_id' => $data['year']]);
            $request->session()->flash('success', 'Season link Saved');
            return redirect('/su/seasons');
        } catch (Exception $e) {
            dd($e->getMessage());
        }
        return redirect('/su/seasons')->withFail('Error in link review');
    }
}
