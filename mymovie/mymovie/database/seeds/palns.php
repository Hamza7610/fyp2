<?php

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
class palns extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        if (DB::table('price_plans')->get()->count() == 0) {

            DB::table('price_plans')->insert([

                [
                    'plans' => 'Basic',
                    'period' => '7 Days',
                    'support' => 'Limited Support'
                ],
                [
                    'plans' => 'Premium',
                    'period' => '1 Month',
                     'support' => '24/7 Support'
                ],
                [
                    'plans' => 'Cinematic',
                    'period' => '6 Month',
                    'support' => '24/7 Support'
                ]
            ]);
        }
    }
}
