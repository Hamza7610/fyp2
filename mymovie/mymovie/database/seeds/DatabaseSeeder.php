<?php

use Database\Seeders\Genre;
use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     *
     * @return void
     */
    public function run()
    {
        $this->call(palns::class);
        $this->call(UserDetails::class);
        $this->call(Su_Details::class);
        $this->call(Genre::class);
    }
}
