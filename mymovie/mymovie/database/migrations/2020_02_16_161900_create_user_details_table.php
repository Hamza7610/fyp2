<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateUserDetailsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('user_details', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->string('name', 2000);
            $table->string('email', 500);
            $table->string('secret_key', 2000);
            $table->boolean('activated')->default(1);
            $table->boolean('loginstatus')->default(0);
            $table->integer('usertype')->default(3);
            $table->bigInteger('price_plans_id')->unsigned();
            $table->foreign("price_plans_id")->references('id')->
            on('price_plans')->onDelete('cascade');
            $table->dateTime('expiry');
            $table->string('session_id', 5000);
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
        Schema::dropIfExists('user_details');
    }
}
