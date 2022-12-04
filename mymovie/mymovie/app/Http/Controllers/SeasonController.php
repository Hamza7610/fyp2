<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Season;
use App\SeasonDetail;
use App\SeasonEpisode;
use App\WathcingSeason;
use Exception;

class SeasonController extends Controller
{
    public function get($id = 0)
    {

        try {
            $seasons = cache()->remember('seasons_mobile', $this->CacheTime(), function () {
                $seasons = Season::where('isKid', 0)->with('reviews')->OrderBy('id', 'DESC')->get()->toArray();
                $seasonslist = [];
                foreach ($seasons as $season) {
                    $season['image_path'] = $this->getSeasonsThumnail($season['id']);
                    array_push($seasonslist, $season);
                }
                return json_encode($seasonslist);
            });
            return $seasons;
        } catch (Exception $ex) {
            dd($ex);
        }
    }
    public function playSeason($id, Request $request)
    {

        $seasonPlay = SeasonEpisode::find($id);
        $episodes =  SeasonEpisode::select('id', 'episode', 'season_detail_id')->where('season_detail_id', $seasonPlay->season_detail_id)->get();

        $season_detail = SeasonDetail::find($seasonPlay->season_detail_id);
        $seasonwatching = new WathcingSeason;
        $seasonwatching->season_id = $season_detail->season_id;
        $seasonwatching->user_id = $request->session()->get('user_id');
        $seasonwatching->season_detail_id = $season_detail->id;
        $seasonwatching->season_episode_id = $id;
        $seasonwatching->save();
        return View('season/playSeason', compact('seasonPlay', 'episodes'));
    }
    public function load_seasonHome(Request $request)
    {
        if ($request->ajax()) {
            if ($request->session()->get('user_id')) {
                $seasons = cache()->remember('seasons_session', $this->CacheTime(), function () {
                    $seasons = Season::where('isKid', 0)->with('reviews')
                        ->select('id', 'name', 'created_at')
                        ->orderByDesc(
                            SeasonDetail::select('created_at')
                                ->whereColumn('season_id', 'seasons.id')
                                ->orderByDesc('created_at')
                                ->limit(1)
                        )->get();
                    $view = view('season/seasonHomeLoadmore', ['seasons' => $seasons, 'session' => true])->render();
                    return $view;
                });
                return $seasons;
            } else {
                $seasons = cache()->remember('seasons_nosession', $this->CacheTime(), function () {
                    $seasons = Season::where('isKid', 0)->with('reviews')
                        ->select('id', 'name', 'created_at')
                        ->orderByDesc(
                            SeasonDetail::select('created_at')
                                ->whereColumn('season_id', 'seasons.id')
                                ->orderByDesc('created_at')
                                ->limit(1)
                        )
                        ->get();
                    $view = view('season/seasonHomeLoadmore', ['seasons' => $seasons, 'session' => false])->render();
                    return $view;
                });
                return $seasons;
            }
        }
        return "";
    }

    public function seasonDetail(Request $request)
    {
        $season_id = $request['season_id'];
        if ($request->ajax()) {
            $SeasonDetails = SeasonDetail::select('id', 'season_detail', 'season_id')->where('season_id', $season_id)->orderBy('season_detail', 'ASC')->get();
            return view('season/seasonDetailLoadmore', ['SeasonDetails' => $SeasonDetails]);
        } else {
            $id = $request['id'];
            return view('season/seasonDetail', ['season_id' => $id]);
        }
        return "";
    }
    public function getseasondetail($id)
    {
        $SeasonDetails = SeasonDetail::select('id', 'season_detail', 'season_id')->where('season_id', $id)->orderBy('id', 'ASC')->get();
        $seasondetailslist = [];
        foreach ($SeasonDetails as $SeasonDetail) {
            $SeasonDetail['image_path'] = $this->getEpisodeThumnail($SeasonDetail['id']);
            array_push($seasondetailslist, $SeasonDetail);
        }
        return json_encode($seasondetailslist);
    }
    public function seasonEpisodes(Request $request)
    {
        $ids = [];
        if ($request->ajax()) {
            $season_detail_id = $request['season_detail_id'];
            $season_id = $request['season_id'];
            $SeasonEpisodes = SeasonEpisode::select('id', 'episode', 'duration', 'filename', 'season_detail_id', 'season_id')->where(['season_id' => $season_id, 'season_detail_id' => $season_detail_id])->orderBy('episode', 'ASC')->get();
            return view('season/seasonEpisodeLoadmore', ['SeasonEpisodes' => $SeasonEpisodes]);
        } else {
            return view('season/seasonEpisode', ['season_detail_id' => $request['id'], 'season_id' => $request['season_id']]);
        }
        return "";
    }
    public function getseasonepisodes($id)
    {
        $Seasonepisodess = SeasonEpisode::select('id', 'episode', 'duration', 'filename', 'season_detail_id', 'season_id')->where('season_detail_id', $id)->orderBy('episode', 'ASC')->get();
        $Seasonepisodeslist = [];
        foreach ($Seasonepisodess as $Seasonepisodes) {
            $Seasonepisodes['image_path'] = $this->getEpisodeThumnail($Seasonepisodes['season_detail_id']);
            array_push($Seasonepisodeslist, $Seasonepisodes);
        }
        return json_encode($Seasonepisodeslist);
    }
}
