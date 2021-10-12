<?php

class Allocine
{
    private $_api_url = 'https://graph.allocine.fr/v1/mobile/';
    private $_token;
    private $_user_token;

    public function __construct($token, $user_token)
    {
        $this->_token = $token;
        $this->_user_token = $user_token;
    }

    private function _do_request($query)
    {
        $data = ['query' => $query];
        $data = http_build_query($data);

        $headers = array();
        $headers[] = 'Authorization: Bearer ' . $this->_user_token;
        $headers[] = 'AC-Auth-Token: ' . $this->_token;

        $ch = curl_init();
        curl_setopt($ch, CURLOPT_URL, $this->_api_url);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_POSTFIELDS, $data);
        curl_setopt($ch, CURLOPT_POST, 1);
        curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
        $result = curl_exec($ch);

        return json_decode($result);
    }

    public function showtimelist($id, $date = null)
    {
        $id = base64_encode("Theater:" . $id);
        $query = <<<QUERY
        query {
          movieShowtimeList(theater: "$id", from: "$date", first: 100) {
            totalCount,
            edges {
              node {
                movie {
                  internalId
                  title
                  originalTitle
                  languages
                  synopsis
                  poster { url }
                  genres
                  format { audio , aspectRatios , filmGauges}
                  cast (first:3) {
                    edges {
                      node {
                        actor { stringValue }
                      }
                    }
                  }
                  credits(activity:DIRECTOR) {
                    edges {
                      node {
                        rank
                        person { stringValue }
                      }
                    }
                  }
                  runtime
                  countries { name }
                  mainRelease {
                    release {
                      releaseDate { date }
                    }
                  }
                  stats {
                    userRating {
                      score
                      count
                    }
                    pressReview {
                      score
                      count
                    }
                  }
                }
                showtimes {
                  startsAt
                  diffusionVersion
                  picture
                  languages
                  sound
                  timeBeforeStart
                  projection
                  experience
                  data {
                    ticketing {
                      urls
                      type
                      provider
                    }
                  }
                  isWeeklyMovieOuting
                }
              }
            }
          }
        }
        QUERY;

        // do the request
        $response = $this->_do_request($query);

        return $response;
    }
}
