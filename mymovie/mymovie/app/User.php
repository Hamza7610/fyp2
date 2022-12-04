<?php

namespace App;

use Illuminate\Database\Eloquent\SoftDeletes;
use Illuminate\Database\Eloquent\Model;

class User extends Model
{
    use  SoftDeletes;
    protected $table = 'user_details';
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'id', 'name', 'email', 'secret_key', 'activated', 'loginstatus', 'session_id'
    ];

    /**
     * The attributes that should be hidden for arrays.
     *
     * @var array
     */
    protected $hidden = [
        'secret_key'
    ];

    public function phoneNumbers()
    {
        return $this->hasMany(User_PhoneNumbers::class, 'user_id');
    }
    public function watching()
    {
        return $this->hasMany(WatchingMovie::class, 'user_id');
    }
}
