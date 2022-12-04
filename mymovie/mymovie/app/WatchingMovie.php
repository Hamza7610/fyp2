<?php

namespace App;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class WatchingMovie extends Model
{
    use HasFactory;
    protected $table = 'watching_movies';
    protected $fillable = [
        'id', 'movie_id', 'user_id'
    ];
    public function movie()
    {
        return $this->belongsTo(Movie::class, 'movie_id');
    }
    public function user()
    {
        return $this->belongsTo(Movie::class, 'user_id');
    }
}
