using ClassLibraryForMovieManager.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForMovieManager
{
    public class MovieManager
    {
        private const int maxMovies = 5;
        static string filePath = @"D:\Session 17\SimpleMoviesApp\movies.txt";
        static List<Movie> movies = new List<Movie>(); // Initialize the movies list
        static int movieCount;

        public static int GetMovieCount
        {
            get { { return movies.Count; } }
        }
        public MovieManager() //Constructor
        {
            var deserializedResult = MovieFileHandler.DeserializeMoviesFromFile(filePath);
            movies = deserializedResult.Movies;
            movieCount = deserializedResult.MovieCount;
        }

        public static void AddMovies(string Id, string Name, string Genre, int Year)
        {
            Movie movie = new Movie(Id, Name, Genre, Year);
            movies.Add(movie); // Add the movie to the in-memory list
            movieCount++;

            MovieFileHandler.SerializeMoviesToFile(filePath, movies); // Update the file with the modified list
        }
        
        public static List<Movie> ShowMovies()
        {
            if (movies.Count == 0)
            {
                throw new MovieNotFoundException("No movies available. Please add movies.");
            }
            return movies;
        }


        public static List<Movie> ShowMoviesByYear(int year)
        {
            List<Movie> moviesbyyear = movies.Where(m => m.Year == year).ToList();

            if (moviesbyyear.Count == 0)
            {
                throw new MovieNotAvailableForYearException($"No movies available for the year {year}.");
            }

            return moviesbyyear;
        }

        public static void ClearAllMovies()
        {
            if(movies.Count == 0)
            {
                throw new NoMovieAvailableToClearException("No movies available to clear, Add movies first !!!");
            }
            movies.Clear();
            Console.WriteLine("All movies cleared.");
            MovieFileHandler.SerializeMoviesToFile(filePath, movies);
        }

        public static bool RemoveMovieByName(string name)
        {
            // Find the movie in the in-memory list
            Movie movieToRemove = movies.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (movieToRemove != null)
            {
                movies.Remove(movieToRemove); // Remove the movie from the in-memory list

                MovieFileHandler.SerializeMoviesToFile(filePath, movies); // Update the file with the modified list

                return true;
            }
            else
            {
                return false; // Movie not found
            }
        }
    }
}
