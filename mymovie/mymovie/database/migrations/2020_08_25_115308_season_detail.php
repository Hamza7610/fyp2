<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class SeasonDetail extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('season_details', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->string('season_detail', 500);
            $table->boolean('iskid')->default(false);
            $table->bigInteger('season_id')->unsigned();
            $table->foreign("season_id")->references('id')->
            on('seasons')->onDelete('cascade');
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
        Schema::dropIfExists('season_details');
    }
}
