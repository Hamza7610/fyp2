<?php

namespace App\Console\Commands;

use App\MovieRequest;
use Exception;
use Illuminate\Console\Command;
use GuzzleHttp\Client;
use Illuminate\Support\Facades\File;
use Illuminate\Support\Facades\Http;
use Illuminate\Support\Facades\Storage;
use GuzzleHttp;

class Download extends Command
{
    /**
     * The name and signature of the console command.
     *
     * @var string
     */
    protected $signature = 'download:daily';

    /**
     * The console command description.
     *
     * @var string
     */
    protected $description = 'Command description';

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
            $movieRquests = MovieRequest::Where('completed_request', 0)->get();
            $this->info('Downloading Starting');
            foreach ($movieRquests as $request) {
                $Progress = $this->output->createProgressBar(100);
                $ProgressArray = [];
                $client = new Client();
                $this->info('Downloading Movie Start : ' . $request->movie);
                $response = $client->request('GET', 'http://movie.tattoo/movie/' . $request->movie, [
                    'progress' => function (
                        $downloadTotal,
                        $downloadedBytes,
                        $uploadTotal,
                        $uploadedBytes
                    ) use ($Progress, $ProgressArray) {
                        if ($downloadedBytes != 0 && $downloadTotal != 0) {
                            $Progress->advance();
                        }
                    },
                ]);
                $contents = $response->getBody();
                File::put('public/storage/movies/' . $request->movie . '.mp4', $contents);
                $Progress->finish();
                $this->info('Downloading Movie Finished');
                sleep(10);
                $this->info('Downloading Thumbnail Start');
                $response = $client->request('GET', 'http://movie.tattoo/thumb/' . $request->movie, [
                    'progress' => function (
                        $downloadTotal,
                        $downloadedBytes,
                        $uploadTotal,
                        $uploadedBytes
                    ) use ($Progress, $ProgressArray) {
                        if ($downloadedBytes != 0 && $downloadTotal != 0) {
                            $Progress->advance();
                        }
                    }
                ]);
                $contents = $response->getBody();
                File::put('public/storage/thumbnails/' . $request->movie . '.jpg', $contents);
                $request->completed_request = 1;
                $request->save();
                $this->info('Downloading Thumbnail Finished');
            }
            $this->info('Downloading Finished');
        } catch (Exception $e) {
            $this->error('Downloading has Error ' . $e->getMessage());
        }
    }
}
