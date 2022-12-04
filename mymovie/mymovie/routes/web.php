<?php

use App\Http\Middleware\VerifySessionSu;
use Illuminate\Support\Facades\Route;

Route::get('/', 'HomeController@welcome');
Route::group(['prefix' => 'movie'], function () {
    Route::get('/get/{id?}', "MovieController@get");    
});
Route::group(['prefix' => 'season'], function () {
    Route::get('/', "HomeController@seasonHome");
    Route::get('/get/{id?}', "SeasonController@get");
    Route::get('/getseasondetail/{id}', "SeasonController@getseasondetail");
    Route::get('/getseasonepisodes/{id}', "SeasonController@getseasonepisodes");
    
});

Route::group(['prefix' => 'su'], function () {
    Route::get('/', "SULoginController@index");
    Route::post('/auth', "SULoginController@Login");
    Route::get('/logout', "SULoginController@Logout")->middleware('session_verifysu');
    Route::get('/welcome', 'SULoginController@supage')->middleware('session_verifysu');
    Route::get('/changepassword', 'SULoginController@changePassword')->middleware('session_verifysu');
    Route::post('/editpassword', "SULoginController@EditPassword")->middleware('session_verifysu');

    Route::group(['prefix' => 'movies'], function () {
        Route::get('/', "MovieReviewsController@index")->middleware('session_verifysu');
        Route::post('/storereviews', "MovieReviewsController@storereviews")->middleware('session_verifysu');
        Route::post('/updatemovielinks', "MovieReviewsController@updatemovielinks")->middleware('session_verifysu');
    });
    Route::group(['prefix' => 'seasons'], function () {
        Route::get('/', "SeasonReviewsController@index")->middleware('session_verifysu');
        Route::post('/storereviews', "SeasonReviewsController@storereviews")->middleware('session_verifysu');
        Route::post('/updateseasonlinks', "SeasonReviewsController@updateseasonlinks")->middleware('session_verifysu');
    });
    Route::get('/suuser', 'SUUserController@index')->middleware('session_verifysu');
    Route::group(['prefix' => 'user'], function () {
        Route::get('/getusers', 'SUUserController@getUsers')->middleware('session_verifysu');
        Route::post('/edit', "SUUserController@EditUsers")->middleware('session_verifysu');
        Route::post('/remove', "SUUserController@RemoveUsers")->middleware('session_verifysu');
    });
    Route::group(['prefix' => 'commands'], function () {
        Route::get('/', "SUCommandsController@index");
        Route::post('/refreshmovies', "SUCommandsController@refreshmovies")->middleware('session_verifysu');
        Route::post('/refreshseasons', "SUCommandsController@RemoveUsers")->middleware('session_verifysu');
        Route::post('/clearcache', "SUCommandsController@clearcache")->middleware('session_verifysu');
        Route::post('/makereviews', "SUCommandsController@makereviews")->middleware('session_verifysu');
    });
});
Route::group(['prefix' => 'mob'], function () {
    Route::post('/getuser', 'MobileController@getuser');
    Route::post('/changepassword', 'MobileController@changepassword');
    Route::post('/authsession', 'MobileController@sessionauth');
    Route::post('/createuser', 'MobileController@storeuser');
    Route::post('/auth', 'MobileController@login');
    Route::get('/logout', 'MobileController@logout');
    Route::post('/requestmovie', "MobileController@requestMovie");
    Route::get('/updateview/{id}', 'MobileController@updateview');
    Route::post('/updatewatchingmovie', 'MobileController@updatewatchingmovie');
    Route::post('/updatewatchingseason', 'MobileController@updatewatchingseason');
    Route::post('/forgetpassword', 'MobileController@forgetpassword');
});
