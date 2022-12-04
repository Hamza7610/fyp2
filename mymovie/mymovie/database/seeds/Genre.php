<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class Genre extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        if (DB::table('genres')->get()->count() == 0) {

            DB::table('genres')->insert([
                [
                    'genre' => 'Action'
                ],
                [
                    'genre' => 'Thriller'
                ],
                [
                    'genre' => 'Drama'
                ],
                [
                    'genre' => 'Horror'
                ],
                [
                    'genre' => 'Comedy'
                ],
                [
                    'genre' => 'Romance'
                ],
                [
                    'genre' => 'Sport'
                ],
                [
                    'genre' => 'Crime'
                ],
                [
                    'genre' => 'Adventure'
                ],
                [
                    'genre' => 'Fantasy'
                ],
                [
                    'genre' => 'Sci-Fi'
                ],
                [
                    'genre' => 'Musical'
                ],
                [
                    'genre' => 'Biography'
                ],
                [
                    'genre' => 'Documentary'
                ],
                [
                    'genre' => 'War'
                ],
                [
                    'genre' => 'Mystery'
                ],
                [
                    'genre' => 'History'
                ],
                [
                    'genre' => 'Family'
                ],
                [
                    'genre' => 'Western'
                ],
                [
                    'genre' => 'Animation'
                ]
            ]);
        }
    }
}
