<?php

namespace App;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class WathcingSeason extends Model
{
    use HasFactory;
    protected $table = 'wathcing_seasons';
    protected $fillable = [
        'id', 'season_id', 'season_detail_id', 'season_episode_id', 'user_id'
    ];
}
