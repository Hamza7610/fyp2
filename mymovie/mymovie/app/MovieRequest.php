<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class MovieRequest extends Model
{
    use  SoftDeletes;
    protected $fillable = [
        'id',
        'movie',
        'user_id'
    ];
}
