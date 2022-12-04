<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateSeasonReviewsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('season_reviews', function (Blueprint $table) {
            $table->id();
            $table->bigInteger('season_id')->unsigned();
            $table->string('description', 2000);
            $table->string('imdbrating', 50);
            $table->string('rating', 50);
            $table->string('genre', 500);
            $table->string('link', 500);
            $table->text('review');
            $table->foreign("season_id")->references('id')->on('seasons')->onDelete('cascade');
            $table->timestamps();
            $table->softDeletes();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('season_reviews');
    }
}
