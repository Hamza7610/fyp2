<?php

namespace App\Http\Controllers;

use App\Genre;
use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Foundation\Bus\DispatchesJobs;
use Illuminate\Foundation\Validation\ValidatesRequests;
use Illuminate\Routing\Controller as BaseController;
use Illuminate\Support\Facades\Storage;
use Illuminate\Support\Facades\File;
use App\Season;
use App\SeasonEpisode;
use App\SeasonDetail;
use App\Year;
use Exception;
use Carbon\Carbon;
use Illuminate\Support\Facades\Cache;

class Controller extends BaseController
{
    use AuthorizesRequests, DispatchesJobs, ValidatesRequests;
    public function CacheTime()
    {
        return Carbon::now()->addHour(24);
    }
    public static function checkifCaptions($filename)
    {
        try {
            if ($filename) {
                foreach (File::files('storage/captions') as $file) {
                    $pathinfo = pathinfo($file);
                    if ($pathinfo['filename'] == $filename) {
                        return true;
                    }
                }
            }
        } catch (Exception $ex) {
        }
        return false;
    }
    public static function getCaption($filename)
    {
        try {
            if ($filename) {
                foreach (File::files('storage/captions') as $file) {
                    $pathinfo = pathinfo($file);
                    if ($pathinfo['filename'] == $filename) {
                        return  '/' . $pathinfo['dirname'] . '/' . $pathinfo['basename'];
                    }
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getThumbnail($file)
    {
        try {
            $file = explode('.', $file, 2);
            $file = $file[0];
            foreach (File::files('storage/thumbnails') as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $file) {
                    return  'https://www.mymovies.pk/' . $pathinfo['dirname'] . '/' . $pathinfo['basename'];
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getReviewThumbnail($file)
    {
        try {
            $file = explode('.', $file, 2);
            $file = $file[0];
            foreach (File::files('public/storage/thumbnails') as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $file) {
                    $directory = str_replace(
                        'public/',
                        '',
                        $pathinfo['dirname']
                    );
                    return str_replace(' ', '%20', 'https://www.mymovies.pk/' . $directory . '/' . $pathinfo['basename']);
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getReviewEpisodeThumnail($id)
    {
        try {
            $seasondetail = SeasonDetail::find($id);
            $season = Season::find($seasondetail->season_id);
            foreach (File::files('public/storage/seasons/' . $season->name) as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $seasondetail->season_detail) {
                    $directory = str_replace(
                        'public/',
                        '',
                        $pathinfo['dirname']
                    );
                    return 'https://www.mymovies.pk/' . $directory . '/' . $pathinfo['basename'];
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getThumbnailkids($file)
    {
        try {
            $file = explode('.', $file, 2);
            $file = $file[0];
            foreach (File::files('storage/kids/thumbnails') as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $file) {
                    return  'https://www.mymovies.pk/' . $pathinfo['dirname'] . '/' . $pathinfo['basename'];
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getMailThumbnail($file)
    {
        try {
            $file = explode('.', $file, 2);
            $file = $file[0];
            foreach (File::files('public/storage/thumbnails') as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $file) {
                    $directory = str_replace(
                        'public/',
                        '',
                        $pathinfo['dirname']
                    );
                    return str_replace(' ', '%20', 'https://www.mymovies.pk/' . $directory . '/' . $pathinfo['basename']);
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getSeasonsThumnail($id)
    {
        try {
            $season = Season::find($id);
            foreach (File::files('storage/seasons/' . $season->name) as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $season->name) {
                    return 'https://www.mymovies.pk/' . $pathinfo['dirname'] . '/' . $pathinfo['basename'];
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getSeasonsThumnailkids($id)
    {
        try {
            $season = Season::find($id);
            foreach (File::files('storage/kids/seasons/' . $season->name) as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $season->name) {
                    return 'https://www.mymovies.pk/' . $pathinfo['dirname'] . '/' . $pathinfo['basename'];
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getEpisodeThumnail($id)
    {
        try {
            $seasondetail = SeasonDetail::find($id);
            $season = Season::find($seasondetail->season_id);
            foreach (File::files('storage/seasons/' . $season->name) as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $seasondetail->season_detail) {
                    return 'https://www.mymovies.pk/' . $pathinfo['dirname'] . '/' . $pathinfo['basename'];
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public static function getEpisodeThumnailkids($id)
    {
        try {
            $seasondetail = SeasonDetail::find($id);
            $season = Season::find($seasondetail->season_id);
            foreach (File::files('storage/kids/seasons/' . $season->name) as $filename) {
                $pathinfo = pathinfo($filename);
                if ($pathinfo['filename'] == $seasondetail->season_detail) {
                    return 'https://www.mymovies.pk/' . $pathinfo['dirname'] . '/' . $pathinfo['basename'];
                }
            }
        } catch (Exception $ex) {
        }
        return null;
    }
    public function getyears()
    {
        $years = Cache::rememberForever('years', function () {
            $val =  Year::OrderBy('year', 'desc')->get();
            return $val;
        });
        return $years;
    }
    public function getgenres()
    {
        $genre = Cache::rememberForever('genre', function () {
            $val = Genre::OrderBy('genre', 'asc')->get();
            return $val;
        });
        return $genre;
    }
    public static function getadslink()
    {
        $arr =
            [
                "https://trk.boxsand.club/apiJS.php?load=p&code=s7jxn9",
                "https://trk.boxsand.club/apiJS.php?load=p&code=jxhe97",
                "https://trk.boxsand.club/apiJS.php?load=p&code=fps4du",
                "https://trk.boxsand.club/apiJS.php?load=p&code=szqxc1",
                "https://trk.boxsand.club/apiJS.php?load=p&code=cshydo",
                "https://trk.boxsand.club/apiJS.php?load=p&code=kbnv6o",
                "https://trk.boxsand.club/apiJS.php?load=p&code=gpayt6"
            ];
        return $arr[array_rand($arr, 1)];
    }
    public static function getsmartlinksads()
    {
        $arr =
            [
                // "https://trk.boxsand.club/p4zjve",
                // "https://trk.boxsand.club/nt20xz",
                // "https://trk.boxsand.club/akc4s3",
                // "https://trk.boxsand.club/oct3np",
                // "https://trk.boxsand.club/l4dcq5",
                // "https://trk.boxsand.club/5chnws",
                // "https://trk.boxsand.club/fadyrv"
                'https://www.youtube.com/embed/oMDR0oa0RFo?autoplay=1&mute=1',
                'https://www.youtube.com/embed/qZE7MzoDgNg?autoplay=1&mute=1',
                'https://www.youtube.com/embed/aE75_H-dkdQ?autoplay=1&mute=1',
                'https://www.youtube.com/embed/V6dh8kZ0YsU?autoplay=1&mute=1'
            ];
        return $arr[array_rand($arr, 1)];
    }
    public static function getvideoId($youTubeLink = '')
    {
        $reg = '/^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|&v=)([^#&?]*).*/';
        preg_match($reg, $youTubeLink, $match);
        if (count($match) > 0) {
            return $match[count($match) - 1];
        }
        return false;
    }
    public function random_string()
    {
        $characters = '0123456789';
        $charactersLength = strlen($characters);
        $mid = '';
        for (
            $i = 0;
            $i < 4;
            $i++
        ) {
            $mid .= $characters[rand(0, $charactersLength - 1)];
        }
        $characters = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
        $charactersLength = strlen($characters);
        $randomString = '';
        for ($i = 0; $i < 4; $i++) {
            $randomString .= $characters[rand(0, $charactersLength - 1)];
        }
        $fi = $mid . $randomString;
        $result = str_shuffle($fi);
        if (ctype_alnum($result)) {
            return str_shuffle($result . '$');
        } else {
            return $this->random_string();
        }
        return;
    }
}
