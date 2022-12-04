<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Season extends Model
{
    use  SoftDeletes;
    protected $fillable = [
        'id',
        'name'
    ];
    public function reviews()
    {
        return $this->hasOne(SeasonReviews::class, 'season_id');
    }
    public function seasondetails()
    {
        return $this->hasMany(SeasonDetail::class, 'season_id');
    }
    public function genres()
    {
        return $this->hasMany(SeasonGenre::class, 'season_id');
    }
}
