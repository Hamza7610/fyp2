<?php

namespace App;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class MovieReviews extends Model
{
    use HasFactory, SoftDeletes;
    protected $fillable = [
        'movie_id',
        'description',
        'imdbrating',
        'genre',
        'link',
        'rating',
        'review'
    ];
    public function movie()
    {
        return $this->belongsTo(Movie::class, 'movie_id');
    }
}
