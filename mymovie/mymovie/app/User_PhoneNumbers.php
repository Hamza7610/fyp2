<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;
class User_PhoneNumbers extends Model
{
    use SoftDeletes;
    protected $fillable = [
        'id','phoneNumber','user_id'
    ];
}
