using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Device.Location;

namespace AlloCine
{
    public class AlloCineApi
    {
        #region Declarations

        private const string AlloCineBaseAddress = "http://api.allocine.fr/rest/v3/";
        private const string AlloCineSecretKey = "29d185d98c984a359e6e6f26a0474269";
        private const string AlloCinePartnerKey = "100043982026";
        //private const string MobileBrowserUserAgent = "Dalvik/1.6.0 (Linux; U; Android 4.2.2; Nexus 4 Build/JDQ39E)";
        private const string MobileBrowserUserAgent =
            "Dalvik/1.2.0 (Linux; U; Android 2.2.2; Huawei U8800-51 Build/HWU8800B635)";

        private const string SearchUrl = "search?{0}";
        private const string MovieGetInfoUrl = "movie?{0}";
        private const string MovieGetReviewListUrl = "reviewlist?{0}";
        private const string PersonGetInfoUrl = "person?{0}";
        private const string PersonGetFilmographyUrl = "filmography?{0}";
        private const string MediaGetInfoUrl = "media?{0}";
        private const string TvSeriesGetInfoUrl = "tvseries?{0}";
        private const string TvSeriesSeasonGetInfoUrl = "season?{0}";
        private const string TvSeriesEpisodeGetInfoUrl = "episode?{0}";
        private const string TheaterGetListUrl = "theaterlist?{0}";
        private const string TheaterGetShowtimeListUrl = "showtimelist?{0}";
        private const string MovieGetOnTheaterListUrl = "movielist?{0}";
        
        private readonly ProxyMode _proxyMode;
        private readonly string _proxyPassword;
        private readonly string _proxyServerAddress;
        private readonly string _proxyUserName;

        #endregion

        #region AlloCineApi Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AlloCineApi" /> class.
        /// </summary>
        public AlloCineApi()
        {
            _proxyMode = ProxyMode.NoProxy;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AlloCineApi" /> class with the specified Proxy User/Password
        ///     credentials.
        ///     The Proxy assigned to your default browser will be used.
        /// </summary>
        /// <param name="proxyUserName">Your Proxy User Name credential.</param>
        /// <param name="proxyPassword">Your Proxy Password credential.</param>
        public AlloCineApi(string proxyUserName, string proxyPassword)
            : this()
        {
            _proxyMode = ProxyMode.DefaultProxy;
            _proxyUserName = proxyUserName;
            _proxyPassword = proxyPassword;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AlloCineApi" /> class with the specified Proxy Address and
        ///     User/Password credentials.
        /// </summary>
        /// <param name="proxyServerAddress">Your Proxy absolute address including the port number.</param>
        /// <param name="proxyUserName">Your Proxy User Name credential.</param>
        /// <param name="proxyPassword">Your Proxy Password credential.</param>
        public AlloCineApi(string proxyServerAddress, string proxyUserName, string proxyPassword)
            : this()
        {
            _proxyMode = ProxyMode.GivenProxy;
            _proxyServerAddress = proxyServerAddress;
            _proxyUserName = proxyUserName;
            _proxyPassword = proxyPassword;
        }

        #endregion

        #region Search
        #region Search Function

        /// <summary>
        ///     Search any reference of a title in the AlloCine database.
        /// </summary>
        /// <param name="query">The query string you are searching for.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public Feed Search(string query, IEnumerable<TypeFilters> types, int resultsPerPage = 100, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();

            if (!string.IsNullOrEmpty(query))
                nvc["q"] = UrlEncodeUpperCase(query);

            if (types != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", types).ToLower());

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(SearchUrl, searchQuery), typeof (AllocineObjectModel)) as AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new SearchCompletedEventArgs();
            args.UserState = userState;
            args.Feed = returnObject;
            OnSearchCompleted(args);
            return returnObject;
        }

        /// <summary>
        ///     Search any reference of a title in the AlloCine database.
        ///     It only returns records of type "Movie" with a maximum of 100 results per page, showing the first page.
        /// </summary>
        /// <param name="query">The query string you are searching for.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public Feed Search(string query, object userState = null)
        {
            return Search(query, new[] {TypeFilters.Movie}, 100, 1, userState);
        }

        /// <summary>
        ///     Search any reference of a title in the AlloCine database.
        ///     It only returns records of type "Movie".
        /// </summary>
        /// <param name="query">The query string you are searching for.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public Feed Search(string query, int resultsPerPage, int pageNumber, object userState = null)
        {
            return Search(query, new[] {TypeFilters.Movie}, resultsPerPage, pageNumber, userState);
        }

        #endregion

        #region SearchAsync Function

        /// <summary>
        ///     Search any reference of a title in the AlloCine database.
        /// </summary>
        /// <param name="query">The query string you are searching for.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public async Task<Feed> SearchAsync(string query, IEnumerable<TypeFilters> types, int resultsPerPage = 100, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();

            if (!string.IsNullOrEmpty(query))
                nvc["q"] = UrlEncodeUpperCase(query);

            if (types != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", types).ToLower());

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(SearchUrl, searchQuery), typeof(AllocineObjectModel)) as AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new SearchCompletedEventArgs();
            args.UserState = userState;
            args.Feed = returnObject;
            OnSearchCompleted(args);
            return returnObject;
        }

        /// <summary>
        ///     Search any reference of a title in the AlloCine database.
        ///     It only returns records of type "Movie" with a maximum of 100 results per page, showing the first page.
        /// </summary>
        /// <param name="query">The query string you are searching for.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public async Task<Feed> SearchAsync(string query, object userState = null)
        {
            return await SearchAsync(query, new[] { TypeFilters.Movie }, 100, 1, userState);
        }

        /// <summary>
        ///     Search any reference of a title in the AlloCine database.
        ///     It only returns records of type "Movie".
        /// </summary>
        /// <param name="query">The query string you are searching for.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public async Task<Feed> SearchAsync(string query, int resultsPerPage, int pageNumber, object userState = null)
        {
            return await SearchAsync(query, new[] { TypeFilters.Movie }, resultsPerPage, pageNumber, userState);
        }

        #endregion

        #region SearchEvent

        public event EventHandler<SearchCompletedEventArgs> SearchCompleted;

        protected virtual void OnSearchCompleted(SearchCompletedEventArgs e)
        {
            EventHandler<SearchCompletedEventArgs> handler = SearchCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region MovieGetInfo
        #region MovieGetInfo Function

        /// <summary>
        ///     Retrieves all information about a particular Movie.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the Movie you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="stripTags">
        ///     Value fields from which you want any HTML tags, if present, to be removed, so the values are
        ///     returned in plain text.
        /// </param>
        /// <param name="mediaFormats">Video formats to return for the Movie.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Movie object.</returns>
        public Movie MovieGetInfo(int movieCode, ResponseProfiles profile, IEnumerable<TypeFilters> types,
            IEnumerable<string> stripTags, IEnumerable<MediaFormat> mediaFormats, object userState = null)
        {
            Movie returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = movieCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (types != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", types).ToLower());

            if (stripTags != null)
                nvc["striptags"] = UrlEncodeUpperCase(string.Join(",", stripTags).ToLower());

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(MovieGetInfoUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Movie Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Movie = new Movie {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.Movie;
            }

            var args = new MovieGetInfoCompletedEventArgs();
            args.MovieCode = movieCode;
            args.UserState = userState;
            args.Movie = returnObject;
            OnMovieGetInfoCompleted(args);
            return returnObject;
        }


        /// <summary>
        ///     Retrieves all information about a particular movie.
        ///     It only returns records of Movie type with Medium details, removing any HTML tags on synopsis and synopsisshort.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the movie you are searching for.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Movie object.</returns>
        public Movie MovieGetInfo(int movieCode, object userState = null)
        {
            return MovieGetInfo(movieCode, ResponseProfiles.Medium, new[] {TypeFilters.Movie},
                new[] {"synopsis", "synopsisshort"}, null, userState);
        }

        /// <summary>
        ///     Retrieves all information about a particular movie.
        ///     It only returns records of Movie type, removing any HTML tags on synopsis and synopsisshort.
        ///     The level of details is left to your choice.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the movie you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Movie object.</returns>
        public Movie MovieGetInfo(int movieCode, ResponseProfiles profile, object userState = null)
        {
            return MovieGetInfo(movieCode, profile, new[] {TypeFilters.Movie}, new[] {"synopsis", "synopsisshort"}, null, userState);
        }

        /// <summary>
        ///     Retrieves all information about a particular movie.
        ///     It removes any HTML tags on synopsis and synopsisshort.
        ///     The level of details and types of records to return is left to your choice.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the movie you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Movie object.</returns>
        public Movie MovieGetInfo(int movieCode, ResponseProfiles profile, IEnumerable<TypeFilters> types, object userState = null)
        {
            return MovieGetInfo(movieCode, profile, types, new[] {"synopsis", "synopsisshort"}, null, userState);
        }

        #endregion

        #region MovieGetInfoAsync Function

        /// <summary>
        ///     Retrieves all information about a particular Movie.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the Movie you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="stripTags">
        ///     Value fields from which you want any HTML tags, if present, to be removed, so the values are
        ///     returned in plain text.
        /// </param>
        /// <param name="mediaFormats">Video formats to return for the Movie.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Movie object.</returns>
        public async Task<Movie> MovieGetInfoAsync(int movieCode, ResponseProfiles profile, IEnumerable<TypeFilters> types,
            IEnumerable<string> stripTags, IEnumerable<MediaFormat> mediaFormats, object userState = null)
        {
            Movie returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = movieCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (types != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", types).ToLower());

            if (stripTags != null)
                nvc["striptags"] = UrlEncodeUpperCase(string.Join(",", stripTags).ToLower());

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(MovieGetInfoUrl, searchQuery), typeof(AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Movie Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Movie = new Movie { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Movie;
            }

            var args = new MovieGetInfoCompletedEventArgs();
            args.MovieCode = movieCode;
            args.UserState = userState;
            args.Movie = returnObject;
            OnMovieGetInfoCompleted(args);
            return returnObject;
        }


        /// <summary>
        ///     Retrieves all information about a particular movie.
        ///     It only returns records of Movie type with Medium details, removing any HTML tags on synopsis and synopsisshort.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the movie you are searching for.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Movie object.</returns>
        public async Task<Movie> MovieGetInfoAsync(int movieCode, object userState = null)
        {
            return await MovieGetInfoAsync(movieCode, ResponseProfiles.Medium, new[] { TypeFilters.Movie },
                new[] { "synopsis", "synopsisshort" }, null, userState);
        }

        /// <summary>
        ///     Retrieves all information about a particular movie.
        ///     It only returns records of Movie type, removing any HTML tags on synopsis and synopsisshort.
        ///     The level of details is left to your choice.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the movie you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Movie object.</returns>
        public async Task<Movie> MovieGetInfoAsync(int movieCode, ResponseProfiles profile, object userState = null)
        {
            return await MovieGetInfoAsync(movieCode, profile, new[] { TypeFilters.Movie }, new[] { "synopsis", "synopsisshort" }, null, userState);
        }

        /// <summary>
        ///     Retrieves all information about a particular movie.
        ///     It removes any HTML tags on synopsis and synopsisshort.
        ///     The level of details and types of records to return is left to your choice.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the movie you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Movie object.</returns>
        public async Task<Movie> MovieGetInfoAsync(int movieCode, ResponseProfiles profile, IEnumerable<TypeFilters> types, object userState = null)
        {
            return await MovieGetInfoAsync(movieCode, profile, types, new[] { "synopsis", "synopsisshort" }, null, userState);
        }

        #endregion

        #region MovieGetInfoEvent

        public event EventHandler<MovieGetInfoCompletedEventArgs> MovieGetInfoCompleted;

        protected virtual void OnMovieGetInfoCompleted(MovieGetInfoCompletedEventArgs e)
        {
            EventHandler<MovieGetInfoCompletedEventArgs> handler = MovieGetInfoCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region MovieGetReviewList
        #region MovieGetReviewList Function

        /// <summary>
        ///     Retrieves the Reviews about a particular Movie.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the Movie you are searching for.</param>
        /// <param name="type">The type of Review, either from Press or Public</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public Feed MovieGetReviewList(int movieCode, ReviewTypes type, int resultsPerPage = 100, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = movieCode.ToString().ToLower();
            nvc["type"] = "movie";

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            nvc["filter"] = ReviewTypesGetValue(type);

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(MovieGetReviewListUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new MovieGetReviewListCompletedEventArgs();
            args.MovieCode = movieCode;
            args.UserState = userState;
            args.Feed = returnObject;
            OnMovieGetReviewListCompleted(args);
            return returnObject;
        }

        #endregion

        #region MovieGetReviewListAsync Function

        /// <summary>
        ///     Retrieves the Reviews about a particular Movie.
        /// </summary>
        /// <param name="movieCode">The AlloCine Code of the Movie you are searching for.</param>
        /// <param name="type">The type of Review, either from Press or Public</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public async Task<Feed> MovieGetReviewListAsync(int movieCode, ReviewTypes type, int resultsPerPage = 100, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = movieCode.ToString().ToLower();
            nvc["type"] = "movie";

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            nvc["filter"] = ReviewTypesGetValue(type);

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(MovieGetReviewListUrl, searchQuery), typeof(AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new MovieGetReviewListCompletedEventArgs();
            args.MovieCode = movieCode;
            args.UserState = userState;
            args.Feed = returnObject;
            OnMovieGetReviewListCompleted(args);
            return returnObject;
        }

        #endregion

        #region MovieGetReviewListEvent

        public event EventHandler<MovieGetReviewListCompletedEventArgs> MovieGetReviewListCompleted;

        protected virtual void OnMovieGetReviewListCompleted(MovieGetReviewListCompletedEventArgs e)
        {
            EventHandler<MovieGetReviewListCompletedEventArgs> handler = MovieGetReviewListCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region PersonGetInfo
        #region PersonGetInfo Function

        /// <summary>
        ///     Retrieves all information about a particular Person.
        /// </summary>
        /// <param name="personCode">The AlloCine Code of the Person you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Person object.</returns>
        public Person PersonGetInfo(int personCode, ResponseProfiles profile, IEnumerable<TypeFilters> types, object userState = null)
        {
            Person returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = personCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (types != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", types).ToLower());

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(PersonGetInfoUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Person Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Person = new Person {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.Person;
            }

            var args = new PersonGetInfoCompletedEventArgs();
            args.PersonCode = personCode;
            args.UserState = userState;
            args.Person = returnObject;
            OnPersonGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region PersonGetInfoAsync Function

        /// <summary>
        ///     Retrieves all information about a particular Person.
        /// </summary>
        /// <param name="personCode">The AlloCine Code of the Person you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Person object.</returns>
        public async Task<Person> PersonGetInfoAsync(int personCode, ResponseProfiles profile, IEnumerable<TypeFilters> types, object userState = null)
        {
            Person returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = personCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (types != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", types).ToLower());

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(PersonGetInfoUrl, searchQuery), typeof(AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Person Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Person = new Person { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Person;
            }

            var args = new PersonGetInfoCompletedEventArgs();
            args.PersonCode = personCode;
            args.UserState = userState;
            args.Person = returnObject;
            OnPersonGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region PersonGetInfoEvent

        public event EventHandler<PersonGetInfoCompletedEventArgs> PersonGetInfoCompleted;

        protected virtual void OnPersonGetInfoCompleted(PersonGetInfoCompletedEventArgs e)
        {
            EventHandler<PersonGetInfoCompletedEventArgs> handler = PersonGetInfoCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region PersonGetFilmography
        #region PersonGetFilmography Function

        /// <summary>
        ///     Retrieves all Filmography about a particular Person.
        /// </summary>
        /// <param name="personCode">The AlloCine Code of the Person you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Person object.</returns>
        public Person PersonGetFilmography(int personCode, ResponseProfiles profile, IEnumerable<TypeFilters> types, object userState = null)
        {
            Person returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = personCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (types != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", types).ToLower());

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(PersonGetFilmographyUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Person Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Person = new Person {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.Person;
            }

            var args = new PersonGetFilmographyCompletedEventArgs();
            args.PersonCode = personCode;
            args.UserState = userState;
            args.Person = returnObject;
            OnPersonGetFilmographyCompleted(args);
            return returnObject;
        }

        #endregion

        #region PersonGetFilmographyAsync Function

        /// <summary>
        ///     Retrieves all Filmography about a particular Person.
        /// </summary>
        /// <param name="personCode">The AlloCine Code of the Person you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="types">The types of information you whish to include in the response from AlloCine.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Person object.</returns>
        public async Task<Person> PersonGetFilmographyAsync(int personCode, ResponseProfiles profile, IEnumerable<TypeFilters> types, object userState = null)
        {
            Person returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = personCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (types != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", types).ToLower());

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(PersonGetFilmographyUrl, searchQuery), typeof(AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Person Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Person = new Person { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Person;
            }

            var args = new PersonGetFilmographyCompletedEventArgs();
            args.PersonCode = personCode;
            args.UserState = userState;
            args.Person = returnObject;
            OnPersonGetFilmographyCompleted(args);
            return returnObject;
        }

        #endregion

        #region PersonGetFilmographyEvent

        public event EventHandler<PersonGetFilmographyCompletedEventArgs> PersonGetFilmographyCompleted;

        protected virtual void OnPersonGetFilmographyCompleted(PersonGetFilmographyCompletedEventArgs e)
        {
            EventHandler<PersonGetFilmographyCompletedEventArgs> handler = PersonGetFilmographyCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region MediaGetInfo
        #region MediaGetInfo Function

        /// <summary>
        ///     Retrieves all info about a particular Media.
        /// </summary>
        /// <param name="mediaCode">The AlloCine Code of the Media you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="mediaFormats">Video formats to return for the Media.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Media object.</returns>
        public Media MediaGetInfo(int mediaCode, ResponseProfiles profile, IEnumerable<MediaFormat> mediaFormats = null, object userState = null)
        {
            Media returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = mediaCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(MediaGetInfoUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Media Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Media = new Media {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.Media;
            }

            var args = new MediaGetInfoCompletedEventArgs();
            args.MediaCode = mediaCode;
            args.UserState = userState;
            args.Media = returnObject;
            OnMediaGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region MediaGetInfoAsync Function

        /// <summary>
        ///     Retrieves all info about a particular Media.
        /// </summary>
        /// <param name="mediaCode">The AlloCine Code of the Media you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="mediaFormats">Video formats to return for the Media.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Media object.</returns>
        public async Task<Media> MediaGetInfoAsync(int mediaCode, ResponseProfiles profile, IEnumerable<MediaFormat> mediaFormats = null, object userState = null)
        {
            Media returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = mediaCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(MediaGetInfoUrl, searchQuery), typeof(AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Media Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Media = new Media { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Media;
            }

            var args = new MediaGetInfoCompletedEventArgs();
            args.MediaCode = mediaCode;
            args.UserState = userState;
            args.Media = returnObject;
            OnMediaGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region MediaGetInfoEvent

        public event EventHandler<MediaGetInfoCompletedEventArgs> MediaGetInfoCompleted;

        protected virtual void OnMediaGetInfoCompleted(MediaGetInfoCompletedEventArgs e)
        {
            EventHandler<MediaGetInfoCompletedEventArgs> handler = MediaGetInfoCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region TvSeriesGetInfo
        #region TvSeriesGetInfo Function

        /// <summary>
        ///     Retrieves all info about a particular TvSerie Season.
        /// </summary>
        /// <param name="tvseriesCode">The AlloCine Code of the TvSeries you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="stripTags">
        ///     Value fields from which you want any HTML tags, if present, to be removed, so the values are
        ///     returned in plain text.
        /// </param>
        /// <param name="mediaFormats">Video formats to return for the TvSeries.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a TvSeries object.</returns>
        public TvSeries TvSeriesGetInfo(int tvseriesCode, ResponseProfiles profile, IEnumerable<string> stripTags,
            IEnumerable<MediaFormat> mediaFormats = null, object userState = null)
        {
            TvSeries returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = tvseriesCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (stripTags != null)
                nvc["striptags"] = UrlEncodeUpperCase(string.Join(",", stripTags).ToLower());

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(TvSeriesGetInfoUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the TvSeries Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.TvSeries = new TvSeries {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.TvSeries;
            }

            var args = new TvSeriesGetInfoCompletedEventArgs();
            args.TvSeriesCode = tvseriesCode;
            args.UserState = userState;
            args.TvSeries = returnObject;
            OnTvSeriesGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region TvSeriesGetInfoAsync Function

        /// <summary>
        ///     Retrieves all info about a particular TvSerie Season.
        /// </summary>
        /// <param name="tvseriesCode">The AlloCine Code of the TvSeries you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="stripTags">
        ///     Value fields from which you want any HTML tags, if present, to be removed, so the values are
        ///     returned in plain text.
        /// </param>
        /// <param name="mediaFormats">Video formats to return for the TvSeries.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a TvSeries object.</returns>
        public async Task<TvSeries> TvSeriesGetInfoAsync(int tvseriesCode, ResponseProfiles profile,
            IEnumerable<string> stripTags,
            IEnumerable<MediaFormat> mediaFormats = null, object userState = null)
        {
            TvSeries returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = tvseriesCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (stripTags != null)
                nvc["striptags"] = UrlEncodeUpperCase(string.Join(",", stripTags).ToLower());

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(TvSeriesGetInfoUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the TvSeries Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.TvSeries = new TvSeries {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.TvSeries;
            }

            var args = new TvSeriesGetInfoCompletedEventArgs();
            args.TvSeriesCode = tvseriesCode;
            args.UserState = userState;
            args.TvSeries = returnObject;
            OnTvSeriesGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region TvSeriesGetInfoEvent

        public event EventHandler<TvSeriesGetInfoCompletedEventArgs> TvSeriesGetInfoCompleted;

        protected virtual void OnTvSeriesGetInfoCompleted(TvSeriesGetInfoCompletedEventArgs e)
        {
            EventHandler<TvSeriesGetInfoCompletedEventArgs> handler = TvSeriesGetInfoCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region TvSeriesSeasonGetInfo
        #region TvSeriesSeasonGetInfo Function

        /// <summary>
        ///     Retrieves all info about a particular TvSerie Season.
        /// </summary>
        /// <param name="seasonCode">The AlloCine Code of the Season you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="stripTags">
        ///     Value fields from which you want any HTML tags, if present, to be removed, so the values are
        ///     returned in plain text.
        /// </param>
        /// <param name="mediaFormats">Video formats to return for the Season.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Season object.</returns>
        public Season TvSeriesSeasonGetInfo(int seasonCode, ResponseProfiles profile, IEnumerable<string> stripTags,
            IEnumerable<MediaFormat> mediaFormats = null, object userState = null)
        {
            Season returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = seasonCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (stripTags != null)
                nvc["striptags"] = UrlEncodeUpperCase(string.Join(",", stripTags).ToLower());

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(TvSeriesSeasonGetInfoUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Season Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Season = new Season {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.Season;
            }

            var args = new TvSeriesSeasonGetInfoCompletedEventArgs();
            args.SeasonCode = seasonCode;
            args.UserState = userState;
            args.Season = returnObject;
            OnTvSeriesSeasonGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region TvSeriesSeasonGetInfoAsync Function
        /// <summary>
        ///     Retrieves all info about a particular TvSerie Season.
        /// </summary>
        /// <param name="seasonCode">The AlloCine Code of the Season you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="stripTags">
        ///     Value fields from which you want any HTML tags, if present, to be removed, so the values are
        ///     returned in plain text.
        /// </param>
        /// <param name="mediaFormats">Video formats to return for the Season.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Season object.</returns>
        public async Task<Season> TvSeriesSeasonGetInfoAsync(int seasonCode, ResponseProfiles profile, IEnumerable<string> stripTags,
            IEnumerable<MediaFormat> mediaFormats = null, object userState = null)
        {
            Season returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = seasonCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (stripTags != null)
                nvc["striptags"] = UrlEncodeUpperCase(string.Join(",", stripTags).ToLower());

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(TvSeriesSeasonGetInfoUrl, searchQuery), typeof(AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Season Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Season = new Season { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Season;
            }

            var args = new TvSeriesSeasonGetInfoCompletedEventArgs();
            args.SeasonCode = seasonCode;
            args.UserState = userState;
            args.Season = returnObject;
            OnTvSeriesSeasonGetInfoCompleted(args);
            return returnObject;
        }
        #endregion

        #region TvSeriesSeasonGetInfoEvent

        public event EventHandler<TvSeriesSeasonGetInfoCompletedEventArgs> TvSeriesSeasonGetInfoCompleted;

        protected virtual void OnTvSeriesSeasonGetInfoCompleted(TvSeriesSeasonGetInfoCompletedEventArgs e)
        {
            EventHandler<TvSeriesSeasonGetInfoCompletedEventArgs> handler = TvSeriesSeasonGetInfoCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region TvSeriesEpisodeGetInfo
        #region TvSeriesEpisodeGetInfo Function

        /// <summary>
        ///     Retrieves all info about a particular TvSerie Episode.
        /// </summary>
        /// <param name="episodeCode">The AlloCine Code of the Episode you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="stripTags">
        ///     Value fields from which you want any HTML tags, if present, to be removed, so the values are
        ///     returned in plain text.
        /// </param>
        /// <param name="mediaFormats">Video formats to return for the Episode.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns an Episode object.</returns>
        public Episode TvSeriesEpisodeGetInfo(int episodeCode, ResponseProfiles profile, IEnumerable<string> stripTags,
            IEnumerable<MediaFormat> mediaFormats = null, object userState = null)
        {
            Episode returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = episodeCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (stripTags != null)
                nvc["striptags"] = UrlEncodeUpperCase(string.Join(",", stripTags).ToLower());

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(TvSeriesEpisodeGetInfoUrl, searchQuery), typeof (AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Episode Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Episode = new Episode {Error = alObjectModel.Error};
                }
                returnObject = alObjectModel.Episode;
            }

            var args = new TvSeriesEpisodeGetInfoCompletedEventArgs();
            args.EpisodeCode = episodeCode;
            args.UserState = userState;
            args.Episode = returnObject;
            OnTvSeriesEpisodeGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region TvSeriesEpisodeGetInfoAsync Function
        /// <summary>
        ///     Retrieves all info about a particular TvSerie Episode.
        /// </summary>
        /// <param name="episodeCode">The AlloCine Code of the Episode you are searching for.</param>
        /// <param name="profile">The level of details returned by AlloCine.</param>
        /// <param name="stripTags">
        ///     Value fields from which you want any HTML tags, if present, to be removed, so the values are
        ///     returned in plain text.
        /// </param>
        /// <param name="mediaFormats">Video formats to return for the Episode.</param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns an Episode object.</returns>
        public async Task<Episode> TvSeriesEpisodeGetInfoAsync(int episodeCode, ResponseProfiles profile, IEnumerable<string> stripTags,
            IEnumerable<MediaFormat> mediaFormats = null, object userState = null)
        {
            Episode returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();
            nvc["code"] = episodeCode.ToString().ToLower();
            nvc["profile"] = profile.ToString().ToLower();

            if (stripTags != null)
                nvc["striptags"] = UrlEncodeUpperCase(string.Join(",", stripTags).ToLower());

            if (mediaFormats != null)
                nvc["mediafmt"] =
                    UrlEncodeUpperCase(string.Join(",", mediaFormats.ToList().ConvertAll(MediaFormatsGetValue)));

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(TvSeriesEpisodeGetInfoUrl, searchQuery), typeof(AllocineObjectModel)) as
                    AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Episode Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Episode = new Episode { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Episode;
            }

            var args = new TvSeriesEpisodeGetInfoCompletedEventArgs();
            args.EpisodeCode = episodeCode;
            args.UserState = userState;
            args.Episode = returnObject;
            OnTvSeriesEpisodeGetInfoCompleted(args);
            return returnObject;
        }

        #endregion

        #region TvSeriesEpisodeGetInfoEvent

        public event EventHandler<TvSeriesEpisodeGetInfoCompletedEventArgs> TvSeriesEpisodeGetInfoCompleted;

        protected virtual void OnTvSeriesEpisodeGetInfoCompleted(TvSeriesEpisodeGetInfoCompletedEventArgs e)
        {
            EventHandler<TvSeriesEpisodeGetInfoCompletedEventArgs> handler = TvSeriesEpisodeGetInfoCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
        #endregion

        #region TheaterGetList
        #region TheaterGetList Function
        /// <summary>
        ///      Retrieves all Theater available based on different possible criteria.
        ///      One on postalCode, geocode, theater, lat/long or location is mandatory
        /// </summary>
        ///<param name="theaterNameSearch">The query string representing the theater you are searching for.</param>
        /// <param name="theaterCode">The AlloCine Code of the Theater you are searching for.</param>
        /// <param name="postalCode">The postal code of the town where the theater is located.</param>
        /// <param name="geoCoordinates">The latitude/longitude coordinates of a reference point.</param>
        /// <param name="radius">The radius around your reference point in 'km' unit from 1 to 500.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public Feed TheaterGetList(string theaterNameSearch = null, string theaterCode = null, int postalCode = 0, GeoCoordinate geoCoordinates = null, int radius = 0, int resultsPerPage = 100, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();

            if (!string.IsNullOrEmpty(theaterNameSearch))
                nvc["location"] = UrlEncodeUpperCase(theaterNameSearch);

            if (!string.IsNullOrEmpty(theaterCode))
                nvc["theater"] = UrlEncodeUpperCase(theaterCode);

            if (postalCode != 0)
                nvc["zip"] = postalCode.ToString();

            if (geoCoordinates != null)
            {
                nvc["lat"] = geoCoordinates.Latitude.ToString();
                nvc["long"] = geoCoordinates.Longitude.ToString();
            }

            if (radius != 0)
                nvc["radius"] = radius.ToString();

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(TheaterGetListUrl, searchQuery), typeof(AllocineObjectModel)) as AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new TheaterGetListCompletedEventArgs();
            args.UserState = userState;
            args.Feed = returnObject;
            OnTheaterGetListCompleted(args);
            return returnObject;
        }
        #endregion

        #region TheaterGetListAsync Function
        /// <summary>
        ///      Retrieves all Theater available based on different possible criteria.
        ///      One on theaterCode, postalCode, geoCoordinates, or cinemaChainCode is mandatory
        /// </summary>
        /// <param name="theaterNameSearch">The query string representing the theater you are searching for.</param> 
        /// <param name="theaterCode">The AlloCine Code of the Theater you are searching for.</param>
        /// <param name="postalCode">The postal code of the town where the theater is located.</param>
        /// <param name="geoCoordinates">The latitude/longitude coordinates of a reference point.</param>
        /// <param name="radius">The radius around your reference point in 'km' unit from 1 to 500.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public async Task<Feed> TheaterGetListAsync(string theaterNameSearch = null, string theaterCode = null, int postalCode = 0, GeoCoordinate geoCoordinates = null, int radius = 0, int resultsPerPage = 100, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();

            if (!string.IsNullOrEmpty(theaterNameSearch))
                nvc["location"] = UrlEncodeUpperCase(theaterNameSearch);

            if (!string.IsNullOrEmpty(theaterCode))
                nvc["theater"] = UrlEncodeUpperCase(theaterCode);

            if (postalCode != 0)
                nvc["zip"] = postalCode.ToString();

            if (geoCoordinates != null)
            {
                nvc["lat"] = geoCoordinates.Latitude.ToString();
                nvc["long"] = geoCoordinates.Longitude.ToString();
            }

            if (radius != 0)
                nvc["radius"] = radius.ToString();

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(TheaterGetListUrl, searchQuery), typeof(AllocineObjectModel)) as AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new TheaterGetListCompletedEventArgs();
            args.UserState = userState;
            args.Feed = returnObject;
            OnTheaterGetListCompleted(args);
            return returnObject;
        }
        #endregion

        #region TheaterGetListEvent

        public event EventHandler<TheaterGetListCompletedEventArgs> TheaterGetListCompleted;

        protected virtual void OnTheaterGetListCompleted(TheaterGetListCompletedEventArgs e)
        {
            EventHandler<TheaterGetListCompletedEventArgs> handler = TheaterGetListCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
        #endregion

        #region TheaterGetShowtimeList
        #region TheaterGetShowtimeList Function
        /// <summary>
        ///      Retrieves the Showtimes for movies per theater.
        ///      One on postalCode, theater, lat/long or location is mandatory
        /// </summary>
        /// <param name="theaterCodes">The list of Theaters you want to get the Showtime represented by their codes.</param>
        /// <param name="postalCode">The postal code of the town where the theater is located.</param>
        /// <param name="geoCoordinates">The latitude/longitude coordinates of a reference point.</param>
        /// <param name="radius">The radius around your reference point in 'km' unit from 1 to 500.</param>
        /// <param name="theaterNameSearch">The query string representing the theater you are searching for. Must be used with movieCode.</param>
        /// <param name="movieCode">The code of the specific movie you want to know the ShowTime.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public Feed TheaterGetShowtimeList(DateTime? date = null, IEnumerable<string> theaterCodes = null, int postalCode = 0, GeoCoordinate geoCoordinates = null, int radius = 0, string theaterNameSearch = null, int movieCode = 0, int resultsPerPage = 100, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();
            DateTime sentDate;

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();

            if (date != null)
            {
                sentDate = (DateTime) date;
            }
            else
            {
                sentDate = DateTime.Now;
            }
            nvc["date"] = sentDate.ToString("yyyy-MM-dd");  

            if (!string.IsNullOrEmpty(theaterNameSearch))
                nvc["location"] = UrlEncodeUpperCase(theaterNameSearch);

            if (theaterCodes != null)
                nvc["theaters"] = UrlEncodeUpperCase(string.Join(",", theaterCodes));

            if (postalCode != 0)
                nvc["zip"] = postalCode.ToString();

            if (geoCoordinates != null)
            {
                nvc["lat"] = geoCoordinates.Latitude.ToString();
                nvc["long"] = geoCoordinates.Longitude.ToString();
            }

            if (radius != 0)
                nvc["radius"] = radius.ToString();

            if (movieCode > 0)
                nvc["movie"] = movieCode.ToString();

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(TheaterGetShowtimeListUrl, searchQuery), typeof(AllocineObjectModel)) as AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new TheaterGetShowtimeListCompletedEventArgs();
            args.UserState = userState;
            args.Feed = returnObject;
            OnTheaterGetShowtimeListCompleted(args);
            return returnObject;
        }
        #endregion

        #region TheaterGetShowtimeListAsync Function
        /// <summary>
        ///      Retrieves the Showtimes for movies per theater.
        ///      One on postalCode, theater, lat/long or location is mandatory
        /// </summary>
        /// <param name="theaterCodes">The list of Theaters you want to get the Showtime represented by their codes.</param>
        /// <param name="postalCode">The postal code of the town where the theater is located.</param>
        /// <param name="geoCoordinates">The latitude/longitude coordinates of a reference point.</param>
        /// <param name="radius">The radius around your reference point in 'km' unit from 1 to 500.</param>
        /// <param name="theaterNameSearch">The query string representing the theater you are searching for. Must be used with movieCode.</param>
        /// <param name="movieCode">The code of the specific movie you want to know the ShowTime.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public async Task<Feed> TheaterGetShowtimeListAsync(DateTime? date = null, IEnumerable<string> theaterCodes = null, int postalCode = 0, GeoCoordinate geoCoordinates = null, int radius = 0, string theaterNameSearch = null, int movieCode = 0, int resultsPerPage = 100, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();
            DateTime sentDate;

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();

            if (date != null)
            {
                sentDate = (DateTime)date;
            }
            else
            {
                sentDate = DateTime.Now;
            }
            nvc["date"] = sentDate.ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(theaterNameSearch))
                nvc["location"] = UrlEncodeUpperCase(theaterNameSearch);

            if (theaterCodes != null)
                nvc["theaters"] = UrlEncodeUpperCase(string.Join(",", theaterCodes));

            if (postalCode != 0)
                nvc["zip"] = postalCode.ToString();

            if (geoCoordinates != null)
            {
                nvc["lat"] = geoCoordinates.Latitude.ToString();
                nvc["long"] = geoCoordinates.Longitude.ToString();
            }

            if (radius != 0)
                nvc["radius"] = radius.ToString();

            if (movieCode > 0)
                nvc["movie"] = movieCode.ToString();

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(TheaterGetShowtimeListUrl, searchQuery), typeof(AllocineObjectModel)) as AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new TheaterGetShowtimeListCompletedEventArgs();
            args.UserState = userState;
            args.Feed = returnObject;
            OnTheaterGetShowtimeListCompleted(args);
            return returnObject;
        }
        #endregion

        #region TheaterGetShowtimeListEvent

        public event EventHandler<TheaterGetShowtimeListCompletedEventArgs> TheaterGetShowtimeListCompleted;

        protected virtual void OnTheaterGetShowtimeListCompleted(TheaterGetShowtimeListCompletedEventArgs e)
        {
            EventHandler<TheaterGetShowtimeListCompletedEventArgs> handler = TheaterGetShowtimeListCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
        #endregion

        #region MovieGetOnTheaterList
        #region MovieGetOnTheaterList Function
        /// <summary>
        ///      Retrieves the Movies planned and/or already in Theater.
        /// </summary>
        /// <param name="filters">Specifies if you want Movies NowShowing and/or ComingSoon.</param>
        /// <param name="order">The sequence they should be listed.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public Feed MovieGetOnTheaterList(IEnumerable<MovieListFilters> filters = null, MovieListOrder order = MovieListOrder.DateDesc, int resultsPerPage = 10, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();

            if (filters != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", filters).ToLower());

            nvc["order"] = order.ToString().ToLower();

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                DownloadData(string.Format(MovieGetOnTheaterListUrl, searchQuery), typeof(AllocineObjectModel)) as AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new MovieGetOnTheaterListCompletedEventArgs();
            args.UserState = userState;
            args.Feed = returnObject;
            OnMovieGetOnTheaterListCompleted(args);
            return returnObject;
        }

        #endregion

        #region MovieGetOnTheaterListAsync Function
        /// <summary>
        ///      Retrieves the Movies planned and/or already in Theater.
        /// </summary>
        /// <param name="filters">Specifies if you want Movies NowShowing and/or ComingSoon.</param>
        /// <param name="order">The sequence they should be listed.</param>
        /// <param name="resultsPerPage">The maximum number of results per page to be returned.</param>
        /// <param name="pageNumber">
        ///     The page you want to show in case your query returns more results than the maximum value you
        ///     have specified to fit on one page.
        /// </param>
        /// <param name="userState">A unique identifier of your choice to recognize this call within the "Completed" event handler</param>
        /// <returns>Returns a Feed object.</returns>
        public async Task<Feed> MovieGetOnTheaterListAsync(IEnumerable<MovieListFilters> filters = null, MovieListOrder order = MovieListOrder.DateDesc, int resultsPerPage = 10, int pageNumber = 1, object userState = null)
        {
            Feed returnObject = null;
            var nvc = new NameValueCollection();

            nvc["partner"] = AlloCinePartnerKey;
            nvc["format"] = ResponseFormat.Json.ToString().ToLower();

            if (filters != null)
                nvc["filter"] = UrlEncodeUpperCase(string.Join(",", filters).ToLower());

            nvc["order"] = order.ToString().ToLower();

            if (resultsPerPage > 0)
                nvc["count"] = resultsPerPage.ToString();

            if (pageNumber > 0)
                nvc["page"] = pageNumber.ToString();

            //We create the final Query string including the call signature
            string searchQuery = BuildSearchQueryWithSignature(ref nvc);
            var alObjectModel =
                await DownloadDataAsync(string.Format(MovieGetOnTheaterListUrl, searchQuery), typeof(AllocineObjectModel)) as AllocineObjectModel;

            if (alObjectModel != null)
            {
                //If AlloCine returned an Error, we assigned the Error object to the Feed Error Object for easy check 
                //from the class client side
                if (alObjectModel.Error != null)
                {
                    alObjectModel.Feed = new Feed { Error = alObjectModel.Error };
                }
                returnObject = alObjectModel.Feed;
            }

            var args = new MovieGetOnTheaterListCompletedEventArgs();
            args.UserState = userState;
            args.Feed = returnObject;
            OnMovieGetOnTheaterListCompleted(args);
            return returnObject;
        }

        #endregion

        #region MovieGetOnTheaterListEvent

        public event EventHandler<MovieGetOnTheaterListCompletedEventArgs> MovieGetOnTheaterListCompleted;

        protected virtual void OnMovieGetOnTheaterListCompleted(MovieGetOnTheaterListCompletedEventArgs e)
        {
            EventHandler<MovieGetOnTheaterListCompletedEventArgs> handler = MovieGetOnTheaterListCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
        #endregion

        #region DownloadData
        #region DownloadData Function
        private object DownloadData(string url, System.Type type)
        {
            try
            {
                //Simulate the call as it was made from a Mobile device by setting the User Agent to an android browser
                //The header might need to be redefined after each request
                WebClient wc = null;
                using (wc = GetWebClient())
                {
                    wc = GetWebClient();
                    wc.Headers.Add("user-agent", MobileBrowserUserAgent);

                    using (Stream stream = wc.OpenRead(url))
                    {
                        if (stream == null)
                            return null;
                        var dcs = new DataContractJsonSerializer(type);
                        object o = dcs.ReadObject(stream);
                        return o;
                    }
                }
            }
            catch (Exception ex)
            {
                return new AllocineObjectModel {Error = new Error {Code = "Exception", Value = ex.Message}};
            }
        }
        #endregion

        #region DownloadDataAsync Function
        private async Task<object> DownloadDataAsync(string url, System.Type type)
        {
            try
            {
                //Simulate the call as it was made from a Mobile device by setting the User Agent to an android browser
                //The header might need to be redefined after each request
                WebClient wc = null;
                using (wc = GetWebClient())
                {
                    wc = GetWebClient();
                    wc.Headers.Add("user-agent", MobileBrowserUserAgent);

                    using (Stream stream = await wc.OpenReadTaskAsync(url))
                    {
                        if (stream == null)
                            return null;
                        var dcs = new DataContractJsonSerializer(type);
                        object o = dcs.ReadObject(stream);
                        return o;
                    }
                }
            }
            catch (Exception ex)
            {
                return new AllocineObjectModel { Error = new Error { Code = "Exception", Value = ex.Message } };
            }
        }
        #endregion

        #region GetWebClient Function
        private WebClient GetWebClient()
        {
            var wc = new WebClient { BaseAddress = AlloCineBaseAddress, Encoding = Encoding.UTF8 };

            switch (_proxyMode)
            {
                case ProxyMode.DefaultProxy:
                    IWebProxy proxy = wc.Proxy;
                    if (proxy != null)
                    {
                        proxy.Credentials = new NetworkCredential(_proxyUserName, _proxyPassword);
                    }
                    break;

                case ProxyMode.GivenProxy:
                    IWebProxy nwp = new WebProxy(_proxyServerAddress, false);
                    nwp.Credentials = new NetworkCredential(_proxyUserName, _proxyPassword);

                    wc.Proxy = nwp;
                    break;
            }
            return wc;
        }
        #endregion
        #endregion

        #region ReviewTypesGetValue Function

        private string ReviewTypesGetValue(ReviewTypes type)
        {
            switch (type)
            {
                case ReviewTypes.DeskPress:
                    return "desk-press";
                case ReviewTypes.Public:
                    return "public";
                default:
                    return "";
            }
        }

        #endregion

        #region MediaFormatsGetValue Function

        private string MediaFormatsGetValue(MediaFormat format)
        {
            switch (format)
            {
                case MediaFormat.Flv:
                    return "flv";
                case MediaFormat.Mp4Lc:
                    return "mp4-lc";
                case MediaFormat.Mp4Hip:
                    return "mp4-hip";
                case MediaFormat.Mp4Archive:
                    return "mp4-archive";
                case MediaFormat.Mpeg2Theater:
                    return "mpeg2-theater";
                case MediaFormat.Mpeg2:
                    return "mpeg2";
                default:
                    return "";
            }
        }

        #endregion

        #region UrlEncodeUpperCase Function

        /// <summary>
        ///     UrlEncode a string but ensures all escaped characters have their Hexadecimal notation in upper case
        ///     A special function is required to UrlEncode the Signature because of a particularity of the Dotnet URLEncode
        ///     function.
        ///     For some reasons the DotNet function retursn the escaped characters in Lowercase while it is returned in Uppercase
        ///     in PHP as described by the W3C.
        ///     So for instance the character "=" would be URLEncoded to "%3D", but the DotNet function will return "%3d", so the
        ///     lower case equivalent.
        ///     Considering the signature is used as a Hash verification code on the receiving party it cannot mess-up with the
        ///     characters case else the code is rejected
        ///     If the receiving party is expecting this "%2F7pfS95CRYGfAaVeqAVBS9PVT%2FA%3D", passing this
        ///     "%2f7pfS95CRYGfAaVeqAVBS9PVT%2fA%3d" will be rejected
        ///     and considered as incorrect.
        /// </summary>
        /// <param name="stringToEncode">The string to encode</param>
        /// <returns>Returns the Url encoded string</returns>
        private string UrlEncodeUpperCase(string stringToEncode)
        {
            var reg = new Regex(@"%[a-f0-9]{2}");
            stringToEncode = HttpUtility.UrlEncode(stringToEncode);
            return reg.Replace(stringToEncode, m => m.Value.ToUpperInvariant());
        }

        #endregion

        #region BuildSearchQueryWithSignature

        /// <summary>
        ///     Create the Query string including the new URL signature AlloCine API expects
        /// </summary>
        /// <param name="nvc">The NameValueCollection containing all parameters of the Query string</param>
        /// <returns>Returns the search Query string</returns>
        private string BuildSearchQueryWithSignature(ref NameValueCollection nvc)
        {
            NameValueCollection collection = nvc;
            nvc["sed"] = DateTime.Now.ToString("yyyyMMdd");

            string searchQuery = string.Join("&",
                collection.AllKeys.Select(k => string.Format("{0}={1}", k, collection[k])));

            string toEncrypt = AlloCineSecretKey + searchQuery;
            string sig;
            using (SHA1 sha = new SHA1CryptoServiceProvider())
            {
                //We do not forget to use our custom URLEncode function to have the escaped characters using Upper case as AlloCine is expecting
                sig = UrlEncodeUpperCase(Convert.ToBase64String(sha.ComputeHash(Encoding.ASCII.GetBytes(toEncrypt))));
            }
            searchQuery += "&sig=" + sig;

            return searchQuery;
        }

        #endregion

    }
}