<?php

namespace App\Console\Commands;

use Illuminate\Console\Command;
use App\Season;
use App\SeasonDetail;
use App\SeasonEpisode;
use Exception;
use Illuminate\Support\Facades\Log;
use Illuminate\Support\Facades\File;

class RefreshSeasons extends Command
{
    /**
     * The name and signature of the console command.
     *
     * @var string
     */
    protected $signature = 'refreshseasons:daily';

    /**
     * The console command description.
     *
     * @var string
     */
    protected $description = 'This command will upload seasons automatically on server.';

    /**
     * Create a new command instance.
     *
     * @return void
     */
    public function __construct()
    {
        parent::__construct();
    }

    /**
     * Execute the console command.
     *
     * @return int
     */
    public function handle()
    {
        try {
            Log::info("refreshseasons is starting!");
            $seasons = File::directories('public/storage/seasons');
            $seasonarray = [];
            $seasondetailarray = [];
            $episodearray = [];
            $getID3 = new \getID3;
            foreach ($seasons as $season) {
                $dbseason = Season::where(['name' => basename($season), 'isKid' => 0])->first();
                if ($dbseason == null) {
                    $dbseason = new Season;
                    $dbseason->name = basename($season);
                    $dbseason->save();
                }
                array_push($seasonarray, $dbseason->id);
                $season_detail = File::directories($season);
                foreach ($season_detail as $season_episodes_dir) {
                    $dseason_episodes_dir = SeasonDetail::where(['season_detail' => basename($season_episodes_dir), 'season_id' => $dbseason->id])->first();
                    if ($dseason_episodes_dir == null) {
                        $dseason_episodes_dir = new SeasonDetail;
                        $dseason_episodes_dir->season_detail = basename($season_episodes_dir);
                        $dseason_episodes_dir->season_id = $dbseason->id;
                        $dseason_episodes_dir->save();
                    }
                    array_push($seasondetailarray, $dseason_episodes_dir->id);
                    $season_episodes = File::allFiles($season_episodes_dir);
                    foreach ($season_episodes as $episode) {
                        $pathinfo = pathinfo($episode);
                        $dbepisode = SeasonEpisode::where(['episode' => $pathinfo['filename'], 'season_id' => $dbseason->id, 'season_detail_id' => $dseason_episodes_dir->id])->first();
                        if ($dbepisode == null) {
                            $dbepisode = new SeasonEpisode;
                            $dbepisode->episode = $pathinfo['filename'];
                            $dbepisode->filename = '/storage/seasons/' . $dbseason->name . '/' . $dseason_episodes_dir->season_detail . '/' . $pathinfo['basename'];
                            $file = $getID3->analyze($episode);
                            $duration = $file ?  (isset($file['playtime_string']) ? $file['playtime_string'] : '00:00') : '00:00';
                            $dbepisode->duration = $duration;
                            $dbepisode->season_id = $dbseason->id;
                            $dbepisode->season_detail_id = $dseason_episodes_dir->id;
                            $dbepisode->save();
                        }
                        array_push($episodearray, $dbepisode->id);
                    }
                }
            }
            Season::whereNotIn('id', $seasonarray)->where('isKid', '=', 0)->delete();
            SeasonDetail::whereNotIn('id', $seasondetailarray)->where('isKid', '=', 0)->delete();
            SeasonEpisode::whereNotIn('id', $episodearray)->where('isKid', '=', 0)->delete();
            Log::info("refreshseasons is finished!");
        } catch (Exception $ex) {
            Log::error("refreshseasons had error " . $ex->getMessage());
        }
    }
}
