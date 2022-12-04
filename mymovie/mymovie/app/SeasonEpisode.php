<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class SeasonEpisode extends Model
{
    use  SoftDeletes;
    protected $fillable = [
        'id',
        'episode',
        'duration',
        'filename',
        'season_id',
        'season_detail_id'
    ];
}