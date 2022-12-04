<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class SeasonEpisode extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('season_episodes', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->string('episode');
            $table->string('duration');
            $table->string('filename');
            $table->boolean('iskid')->default(false);
            $table->bigInteger('season_id')->unsigned();
            $table->foreign("season_id")->references('id')->
            on('seasons')->onDelete('cascade');
            $table->bigInteger('season_detail_id')->unsigned();
            $table->foreign("season_detail_id")->references('id')->
            on('season_details')->onDelete('cascade');
            $table->softDeletes();
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
        Schema::drop('season_episodes');
    }
}
