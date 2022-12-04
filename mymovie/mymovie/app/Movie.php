<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Movie extends Model
{
    use  SoftDeletes;
    protected $table = 'movies';
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'name',
        'duration',
        'filename',
        'views'
    ];
    public function reviews()
    {
        return $this->hasOne(MovieReviews::class, 'movie_id');
    }
    public function genres()
    {
        return $this->hasMany(MovieGenre::class, 'movie_id');
    }
}
