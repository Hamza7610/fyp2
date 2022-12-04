<?php

namespace App\Console\Commands;

use Illuminate\Console\Command;
use App\Movie;
use App\User;
use Exception;
use Illuminate\Support\Facades\File;
use Illuminate\Support\Facades\Log;
use Illuminate\Support\Facades\Mail;

class RefreshMovies extends Command
{
    /**
     * The name and signature of the console command.
     *
     * @var string
     */
    protected $signature = 'refreshmovies:daily';

    /**
     * The console command description.
     *
     * @var string
     */
    protected $description = 'This command will upload movies automatically on server.';

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
            Log::info("refreshmovies is starting!");
            $movies = File::files('public/storage/movies');
            $getID3 = new \getID3;
            $moviearray = [];
            $newMovies = [];
            foreach ($movies as $movie) {
                $durmovie = $movie;
                $pathinfo = pathinfo($movie);               
                $movie = Movie::where(['name' => $pathinfo['filename'], 'isKid' => 0])->first();
                if ($movie == null) {
                    $file = $getID3->analyze($durmovie);
                    $duration = $file ?  (isset($file['playtime_string']) ? $file['playtime_string'] : '00:00') : '00:00';
                    $movie = new Movie;
                    $movie->name = $pathinfo['filename'];
                    $movie->duration = $duration;
                    $movie->filename = $pathinfo['basename'];
                    $movie->views = rand(2000, 9000);
                    $movie->save();
                }
                array_push($moviearray, $movie->id);
            }
            Movie::whereNotIn('id', $moviearray)->where('isKid', '=', 0)->delete();           
            Log::info("refreshmovies is finished!");
        } catch (Exception $ex) {
            Log::error("refreshmovies had error " . $ex->getMessage());
        }
    }
}
