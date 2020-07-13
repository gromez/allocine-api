
using System.Collections.Specialized;

namespace AlloCine
{
    internal enum ProxyMode
    {
        NoProxy,
        DefaultProxy,
        GivenProxy
    }
    public enum TypeFilters
    {
        Movie,
        Theater,
        Person,
        News,
        TvSeries
    }

    public enum ResponseProfiles
    {
        Small,
        Medium,
        Large
    }

    //Not needed anymore the result "format" parameter in the AlloCine API has been removed
    public enum ResponseFormat
    {
        Json,
        Xml
    }

    public enum ReviewTypes
    {
        DeskPress,
        Public
    }
    
    public enum MediaFormat
    {
        Flv ,
        Mp4Lc,
        Mp4,
        Mp4Hip,
        Mp4Archive,
        Mpeg2Theater,
        Mpeg2
    }

    public enum MovieListFilters
    {
        NowShowing,
        ComingSoon 
    }

    public enum MovieListOrder
    {
        DateDesc,
        DateAsc,
        TheaterCount,
        TopRank
    }
}
