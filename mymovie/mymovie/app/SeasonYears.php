<?php

namespace App;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class SeasonYears extends Model
{
    use HasFactory;
    protected $fillable = [
        'season_id',
        'year_id'
    ];
}
