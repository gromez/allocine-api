#!/usr/bin/php
<?php
 
$zip = "38000"; // Zip code of location to search
$radius = "10"; // Radius of area

require_once(__DIR__.'/allocine.class.php');

define('ALLOCINE_PARTNER_KEY', '100043982026');
define('ALLOCINE_SECRET_KEY', '29d185d98c984a359e6e6f26a0474269');

$allocine = new Allocine(ALLOCINE_PARTNER_KEY, ALLOCINE_SECRET_KEY);

$response = $allocine->showtimelist($zip, $radius);
 
$json = json_decode($response); // Parse the returned json
 
$theaters = $json->feed->theaterShowtimes; // Retrieve list of theaters
 
$table = array(); // Array of data to display
$max_length = array(0,0,0,0,0); // Array of max column length (to display equal length columns)
$index = 0; // Index of current movie
 
// Iterate over all theaters and fill table with movies information
foreach($theaters as $theater){
    $times = $theater->movieShowtimes;
    foreach($times as $i => $time){
        // Append times in an array
        $horaires = $time->scr;
        $today = $horaires[0];
        $formatted_times = array();
        foreach($today->t as $t){
            array_push($formatted_times, $t->{'$'});
        }
 
        // Populate movie data in a row
        $movie = $time->onShow->movie;
        $table[$index] = array(
            $theater->place->theater->name,
            $movie->code,
            $movie->title,
            $time->version->original ? "VO" : "VF",
            implode($formatted_times, ", ")
        );
        $index++;
    }
}
 
// Compute max length for each column
foreach($table as $row){
    foreach($row as $i => $val){
        $max_length[$i] = max($max_length[$i], strlen($val));
    }
}
 
// Display results
foreach($table as $row){
    foreach($row as $i => $val){
        printf("%-".$max_length[$i]."s ", utf8_decode($val));
    }
    echo "\n";
}
