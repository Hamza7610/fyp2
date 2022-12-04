<?php

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class Su_Details extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        if (DB::table('su_details')->get()->count() == 0) {

            DB::table('su_details')->insert([

                [
                    'name' => 'admin',
                    'secret_key' => '$2y$12$MGJZln/S.ZTQ802BlDfXEenoT5zZkcYofe4xrk75GY/Cw8PUgcIV6',
                    'created_at' => date('Y-m-d H:i:s'),
                    'updated_at' => date('Y-m-d H:i:s')
                ]
            ]);
        }
    }
}