<?php

namespace App;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class MovieYears extends Model
{
    use HasFactory;
    protected $fillable = [
        'movie_id',
        'year_id'
    ];
}
