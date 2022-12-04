<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateSeasonYearsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('season_years', function (Blueprint $table) {
            $table->id();
            $table->bigInteger('year_id')->unsigned();
            $table->foreign("year_id")->references('id')->on('years')->onDelete('cascade');
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
        Schema::dropIfExists('season_years');
    }
}
