<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateMovieYearsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('movie_years', function (Blueprint $table) {
            $table->id();
            $table->bigInteger('year_id')->unsigned();
            $table->foreign("year_id")->references('id')->on('years')->onDelete('cascade');
            $table->bigInteger('movie_id')->unsigned();
            $table->foreign("movie_id")->references('id')->on('movies')->onDelete('cascade');
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('movie_years');
    }
}
