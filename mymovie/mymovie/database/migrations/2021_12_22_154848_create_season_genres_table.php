<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateSeasonGenresTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('season_genres', function (Blueprint $table) {
            $table->id();
            $table->bigInteger('genre_id')->unsigned();
            $table->foreign("genre_id")->references('id')->on('genres')->onDelete('cascade');
            $table->bigInteger('season_id')->unsigned();
            $table->foreign("season_id")->references('id')->on('seasons')->onDelete('cascade');
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
        Schema::dropIfExists('season_genres');
    }
}
