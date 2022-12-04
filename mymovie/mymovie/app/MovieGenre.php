<?php

namespace App;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class MovieGenre extends Model
{
    use HasFactory;
    protected $table = 'movie_genres';
    protected $fillable = [
        'id', 'genre_id', 'movie_id'
    ];
    public function genre()
    {
        return $this->belongsTo(Genre::class, 'genre_id');
    }
    public function movie()
    {
        return $this->belongsTo(Movie::class, 'movie_id');
    }
}
