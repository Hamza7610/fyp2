<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Su_details extends Model
{
    protected $fillable = [
        'id', 'name', 'secret_key', 'session_id',
    ];
}