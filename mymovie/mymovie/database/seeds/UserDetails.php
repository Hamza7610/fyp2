<?php

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Carbon\Carbon;
class UserDetails extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        if (DB::table('user_details')->get()->count() == 0) {

            DB::table('user_details')->insert([

                [
                    'name' => 'admin',
                    'email' => 'admin@mymovie.com',
                    'activated' => true,
                    'usertype' => 1,
                    'price_plans_id'=> 3,
                    'expiry'=>(Carbon::now())->addDays(999),
                    'secret_key' => '$2y$12$MGJZln/S.ZTQ802BlDfXEenoT5zZkcYofe4xrk75GY/Cw8PUgcIV6',
                    'session_id'=> 'abc',
                    'created_at' => date('Y-m-d H:i:s'),
                    'updated_at' => date('Y-m-d H:i:s')
                ]
            ]);
        }
    }
}
