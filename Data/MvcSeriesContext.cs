using Microsoft.EntityFrameworkCore;
using MvcSeries.Models;
using Newtonsoft.Json.Linq;
using System;

namespace MvcSeries.Data
{
    public class MvcSeriesContext : DbContext
    {
        public MvcSeriesContext (DbContextOptions<MvcSeriesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public void seedSeries(ModelBuilder modelBuilder){
            const string GURL = "https://api.themoviedb.org/3/genre/tv/list";
            string GurlParameters = $"?api_key=e8aa54218562d4d13c49fea81693c67b&language=en-US";
            var genreResponse = HTTP.Response.returnResponse(GURL, GurlParameters);
            JArray genrejObject = (JArray)genreResponse["genres"];

            JArray seriesObject = new JArray();
            for(int i=1; i<20; i++){
                const string URL = "https://api.themoviedb.org/3/tv/popular";
                string urlParameters = $"?api_key=e8aa54218562d4d13c49fea81693c67b&language=en-US&page={i}";
                var seriesReponse = HTTP.Response.returnResponse(URL, urlParameters);
                seriesObject.Merge((JArray)seriesReponse["results"]);
            }
            int counter = 1;
            foreach(var item in seriesObject.Children()){
                var genre_id = (string)item["genre_ids"].First;
                // Loop through the genres to find the matching id
                foreach(var genreObj in genrejObject){
                    if((string)genreObj["id"] == genre_id){
                        var genre = (string)genreObj["name"];
                        var release = (string)item["first_air_date"];
                        if(String.IsNullOrEmpty(release)){
                            release = "10/10/2010";
                        }
                        modelBuilder.Entity<Series>().HasData(
                            new Series{
                                Id = counter,
                                Title = (string)item["original_name"],
                                ReleaseDate = DateTime.Parse(release),
                                Genre = genre,
                                Rating = (decimal)item["vote_average"],
                                Poster_path = (string)item["poster_path"],
                                Overview = (string)item["overview"]
                            }
                        );
                        modelBuilder.Entity<SeriesComment>().HasData(
                            new SeriesComment {
                                Id = counter,
                                SId = counter,
                                Creator = "Anonymous",
                                Text = "This is a sample text for " + (string)item["original_name"]
                            }
                        );
                    }
                    counter += 1;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            seedSeries(builder);
        }
        public DbSet<Series> Series { get; set; }
        public DbSet<SeriesComment> SComments {get; set;}
    }
}