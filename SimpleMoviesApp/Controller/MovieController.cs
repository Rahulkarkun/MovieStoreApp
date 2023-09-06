using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryForMovieManager;

namespace SimpleMoviesApp
{
    internal class MovieController
    {

        public MovieController()
        {

            MainMenu();
        }
        private static void MainMenu()
        {
            while (true)
            {
                new MovieManager();
                Console.WriteLine("----------------- Welcome to Movies App -----------------");
                Console.WriteLine("1. Display All movies");
                Console.WriteLine("2. Display Movie By Year");
                Console.WriteLine("3. Add movies");
                Console.WriteLine("4. Remove Movie");
                Console.WriteLine("5. Clear all");
                Console.WriteLine("6. Exit");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Movie Status: " + MovieManager.GetMovieCount + " / " + "5");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("What do you wish to do ?\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                    ShowMovies();
                else if (choice == 2)
                    DisplayMoviesAccToYear();
                else if (choice == 3)
                    AddMovies();
                else if (choice == 4)
                    RemoveMoviesByName();
                else if (choice == 5)
                    ClearAllMovies();
                else if (choice == 6)
                    Environment.Exit(0);
                else
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            }
        }

        private static void AddMovies()
        {
            try
            {
                if (MovieManager.GetMovieCount == 5)
                {
                    throw new MovieLimitExceededException($"Movies Exceeded from the Limit, You can add" +
                    $" only 5 movies");
                }

                string Id;
                string Name;
                string Genre;
                int Year;
                Console.Write("ID: ");
                Id = Console.ReadLine();

                Console.Write("Name: ");
                Name = Console.ReadLine();

                Console.Write("Genre (Action, Adventure, Comedy, Horror, Romance, etc..): ");
                Genre = Console.ReadLine();

                Console.Write("Year: ");
                if (int.TryParse(Console.ReadLine(), out Year))
                {
                    MovieManager.AddMovies(Id, Name, Genre, Year);
                    Console.WriteLine($"Movie added successfully. {MovieManager.GetMovieCount} out of 5 movies added.");
                }
                else
                {
                    Console.WriteLine("Invalid input for Year. Please enter a valid integer.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message+"\n" );
            }

        }
        private static void DisplayMoviesAccToYear()
        {
            try
            {
                int Year;
                Console.WriteLine("Enter the Year: ");
                Year = int.Parse(Console.ReadLine());
                List<Movie> moviesbyyear = MovieManager.ShowMoviesByYear(Year);
                Console.WriteLine($"movies released in {Year}:");
                foreach (Movie movie in moviesbyyear)
                {
                    Console.WriteLine($"id: {movie.Id}, name: {movie.Name}, genre: {movie.Genre}, year: {movie.Year}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }

        }

        private static void ShowMovies()
        {
            try
            {
                List<Movie> movie = MovieManager.ShowMovies();
                Console.WriteLine("Movies:");
                foreach (Movie movies in movie)
                {
                    Console.WriteLine($"ID: {movies.Id}, Name: {movies.Name}, Genre: {movies.Genre}, Year: {movies.Year}");
                }
                Console.WriteLine("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }

        }

        private static void RemoveMoviesByName()
        {
            try
            {
                Console.Write("Enter the name of the movie to remove: ");
                string name = Console.ReadLine();
                bool Found = MovieManager.RemoveMovieByName(name);
                if (Found)
                {
                    Console.WriteLine($"Movie '{name}' removed successfully.");
                }
                else
                {
                    Console.WriteLine($"Movie '{name}' not found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }

        }

        private static void ClearAllMovies()
        {
            try
            {
                MovieManager.ClearAllMovies();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
