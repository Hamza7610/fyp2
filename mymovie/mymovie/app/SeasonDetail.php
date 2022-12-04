<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class SeasonDetail extends Model
{
    use  SoftDeletes;
    protected $fillable = [
        'id',
        'season_details',
        'season_id'
    ];
}
