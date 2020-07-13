using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlloCine
{
    public class TvSeriesGetInfoCompletedEventArgs : EventArgs
    {
        public int TvSeriesCode { get; set; }
        public object UserState { get; set; }
        public TvSeries TvSeries { get; set; }
    }

    public class TvSeriesSeasonGetInfoCompletedEventArgs : EventArgs
    {
        public int SeasonCode { get; set; }
        public object UserState { get; set; }
        public Season Season { get; set; }
    }

    public class TvSeriesEpisodeGetInfoCompletedEventArgs : EventArgs
    {
        public int EpisodeCode { get; set; }
        public object UserState { get; set; }
        public Episode Episode { get; set; }
    }

    public class MediaGetInfoCompletedEventArgs : EventArgs
    {
        public int MediaCode { get; set; }
        public object UserState { get; set; }
        public Media Media { get; set; }
    }

    public class PersonGetFilmographyCompletedEventArgs : EventArgs
    {
        public int PersonCode { get; set; }
        public object UserState { get; set; }
        public Person Person { get; set; }
    }

    public class PersonGetInfoCompletedEventArgs : EventArgs
    {
        public int PersonCode { get; set; }
        public object UserState { get; set; }
        public Person Person { get; set; }
    }


    public class MovieGetReviewListCompletedEventArgs : EventArgs
    {
        public int MovieCode { get; set; }
        public object UserState { get; set; }
        public Feed Feed { get; set; }
    }

    public class MovieGetInfoCompletedEventArgs : EventArgs
    {
        public int MovieCode { get; set; }
        public object UserState { get; set; }
        public Movie Movie { get; set; }
    }

    public class SearchCompletedEventArgs : EventArgs
    {
        public object UserState { get; set; }
        public Feed Feed { get; set; }
    }

    public class TheaterGetListCompletedEventArgs : EventArgs
    {
        public object UserState { get; set; }
        public Feed Feed { get; set; }
    } 

    public class TheaterGetShowtimeListCompletedEventArgs : EventArgs
    {
        public object UserState { get; set; }
        public Feed Feed { get; set; }
    }

    public class MovieGetOnTheaterListCompletedEventArgs : EventArgs
    {
        public object UserState { get; set; }
        public Feed Feed { get; set; }
    }   
    
    
}
