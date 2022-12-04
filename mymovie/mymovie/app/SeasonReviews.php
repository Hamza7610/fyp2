<?php

namespace App;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class SeasonReviews extends Model
{
    use HasFactory, SoftDeletes;
    protected $fillable = [
        'season_id',
        'description',
        'imdbrating',
        'genre',
        'link',
        'rating',
        'review'
    ];
    public function season()
    {
        return $this->belongsTo(Season::class, 'season_id');
    }
}
