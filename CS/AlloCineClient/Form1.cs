using System;
using System.Device.Location;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlloCine;
using Allocine.ExtensionMethods;

namespace AlloCineClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonVariousCalls_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            //"ah si j'etais riche" = 42346
            var api = new AlloCineApi();

            textBox1.AppendText("//Look for anything in Allocine that contains 'riche'");
            var alFeed = api.Search("riche", new[] { TypeFilters.Movie }, 8, 1);
            if (alFeed.Error != null)
            {
                textBox1.AppendText("\r\n" + alFeed.Error.Value);
            }
            else
            {
                foreach (var mov in alFeed.MovieList)
                {
                    textBox1.AppendText("\r\n" + mov.Code + "\t" + mov.OriginalTitle + "\t");
                }
            }

            textBox1.AppendText("\r\n\r\n\r\n//Retrieve the details of the Movie 'Ah si j'etais riche");
            var alMovie = api.MovieGetInfo(42346, ResponseProfiles.Large, new[] { TypeFilters.Movie, TypeFilters.News }, new[] { "synopsis" }, new[] { MediaFormat.Mpeg2 });
            if (alMovie.Error != null)
            {
                textBox1.AppendText("\r\n" + alMovie.Error.Value);
            }
            else
            {
                textBox1.AppendText("\r\n" + alMovie.Code + "\t" + alMovie.OriginalTitle + "\t" + alMovie.MovieType.Code);
            }

            textBox1.AppendText("\r\n\r\n\r\n//Retrieve the details about the TvSeries 'Lost'");
            var alTvSeries = api.TvSeriesGetInfo(223, ResponseProfiles.Large, new[] { "synopsis" }, null);
            if (alTvSeries.Error != null)
            {
                textBox1.AppendText("\r\n" + alTvSeries.Error.Value);
            }
            else
            {
                textBox1.AppendText("\r\n" + alTvSeries.Code + "\t" + alTvSeries.OriginalTitle + "\t" + alTvSeries.Title + "\t" + alTvSeries.OriginalBroadcast.DateStart);
            }


        }

        private void buttonEvent_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            var api = new AlloCineApi();
            api.TvSeriesGetInfoCompleted += api_TvSeriesGetInfoCompleted;

            textBox1.AppendText("\r\n\r\n\r\n//Batch retrieve - The UI is freezing - main tread is waiting");
            for (int i = 223; i >= 200; i--)
            {
                api.TvSeriesGetInfo(i, ResponseProfiles.Large, new[] { "synopsis" }, null);
            }
        }

        private async void buttonAsync_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            var api = new AlloCineApi();
            api.TvSeriesGetInfoCompleted += api_TvSeriesGetInfoCompleted;

            textBox1.AppendText("\r\n\r\n\r\n//Batch retrieve - The UI is responsive - main tread is NOT waiting, asynchronous calls, yet sequential");
            for (int i = 223; i >= 200; i--)
            {
                await api.TvSeriesGetInfoAsync(i, ResponseProfiles.Large, new[] { "synopsis" }, null);
            }
        }


        private async void buttonParallel_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            var api = new AlloCineApi();
            api.TvSeriesGetInfoCompleted += api_TvSeriesGetInfoCompleted;

            textBox1.AppendText(
    "\r\n\r\n\r\n//Batch retrieve - The UI is responsive - main tread is NOT waiting, asynchronous AND Parallel calls");
            Parallel.For(200, 250,
                async i => { await api.TvSeriesGetInfoAsync(i, ResponseProfiles.Large, new[] { "synopsis" }, null); });
        }


        private void api_TvSeriesGetInfoCompleted(object sender, TvSeriesGetInfoCompletedEventArgs e)
        {
            TvSeries alTvSeries = e.TvSeries;
            int tvSeriesCode = e.TvSeriesCode;

            //textBox1.AppendText("\r\n\r\n\r\n//Retrieve the details about the TvSeries 'Lost' - EVENT");
            if (alTvSeries.Error != null)
            {
                AppendText("\r\n" + tvSeriesCode + "\t" + alTvSeries.Error.Value);
            }
            else
            {
                AppendText("\r\n" + alTvSeries.Code + "\t" + alTvSeries.OriginalTitle + "\t" + alTvSeries.Title);
            }
        }

        private void AppendText(string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (textBox1.InvokeRequired)
            {
                AppendTextCallback d = AppendText;
                Invoke(d, new object[] { text });
            }
            else
            {
                textBox1.AppendText(text);
            }
        }

        private delegate void AppendTextCallback(string text);

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            var api = new AlloCineApi();
            var alFeed = api.TheaterGetList(theaterNameSearch:"normandy");

            if (alFeed.Error != null)
            {
                textBox1.AppendText("\r\n" + alFeed.Error.Value);
            }
            else
            {
                textBox1.AppendText("\r\n" + alFeed.Updated);
                if (alFeed.TheaterList != null)
                    foreach (var thea in alFeed.TheaterList)
                    {
                        textBox1.AppendText("\r\n" + thea.Code + "\t" + thea.Name + "\t");
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            var api = new AlloCineApi();
            var alFeed = api.TheaterGetShowtimeList(date:DateTime.Now,postalCode:45000);

            if (alFeed.Error != null)
            {
                textBox1.AppendText("\r\n" + alFeed.Error.Value);
            }
            else
            {
                textBox1.AppendText("\r\n" + alFeed.Updated);
                if (alFeed.TheaterShowtimeList != null)
                    foreach (var thea in alFeed.TheaterShowtimeList)
                    {
                        textBox1.AppendText("\r\n" + thea.Place.Theater.Name);
                        foreach (var showTime in thea.MovieShowtimeList)
                        {
                            textBox1.AppendText("\r\n\t" + showTime.OnShow.Movie.Title + "\t" + showTime.Version.Value + "\t");

                            foreach (var day in showTime.ScrList)
                            {
                                textBox1.AppendText("\r\n\t\t" + day.D.ToString("yyyy-MM-dd") + "\t");
                                foreach (var time in day.T)
                                {
                                    textBox1.AppendText("\r\n\t\t\t" + time.Value + "\t");
                                }
                            }
                        }
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            var api = new AlloCineApi();
            var alFeed = api.MovieGetOnTheaterList(filters: new[] { MovieListFilters.NowShowing },resultsPerPage:10);

            if (alFeed.Error != null)
            {
                textBox1.AppendText("\r\n" + alFeed.Error.Value);
            }
            else
            {
                if (alFeed.MovieList != null)
                    foreach (var movie in alFeed.MovieList)
                    {
                        textBox1.AppendText("\r\n" + movie.Code + "\t" + movie.Title + "\t");
                    }
            }
        }

    }
}