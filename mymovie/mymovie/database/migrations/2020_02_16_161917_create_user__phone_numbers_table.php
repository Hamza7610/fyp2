<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateUserPhoneNumbersTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('user__phone_numbers', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->string("phoneNumber",500);
            $table->bigInteger("user_id")->unsigned();
            $table->foreign("user_id")->references('id')->
            on('user_details')->onDelete('cascade');
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
        Schema::dropIfExists('user__phone_numbers');
    }
}
