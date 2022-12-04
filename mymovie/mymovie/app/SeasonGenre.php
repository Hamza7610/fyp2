<?php

namespace App;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class SeasonGenre extends Model
{
    use HasFactory;
    protected $table = 'season_genres';
    protected $fillable = [
        'id', 'genre_id', 'season_id'
    ];
    public function genre()
    {
        return $this->belongsTo(Genre::class, 'genre_id');
    }
    public function season()
    {
        return $this->belongsTo(Movie::class, 'season_id');
    }
}
