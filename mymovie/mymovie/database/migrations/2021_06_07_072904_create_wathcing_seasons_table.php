<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateWathcingSeasonsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('wathcing_seasons', function (Blueprint $table) {
            $table->id();
            $table->bigInteger('season_id')->unsigned();

            $table->bigInteger('season_detail_id')->unsigned();
            $table->bigInteger('season_episode_id')->unsigned();

            $table->bigInteger('user_id')->unsigned();
            $table->foreign("season_id")->references('id')->on('season_details')->onDelete('cascade');
            $table->foreign("user_id")->references('id')->on('user_details')->onDelete('cascade');

            $table->foreign("season_detail_id")->references('id')->on('season_details');
            $table->foreign("season_episode_id")->references('id')->on('season_episodes');
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
        Schema::dropIfExists('wathcing_seasons');
    }
}
