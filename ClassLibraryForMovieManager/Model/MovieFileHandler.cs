using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForMovieManager
{
    public class MovieFileHandler
    {
        const int maxMovies = 5;


        public static void SerializeMoviesToFile(string filePath, List<Movie> movies)
        {
            
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, movies);
            }
            
        }

        public static (List<Movie> Movies, int MovieCount) DeserializeMoviesFromFile(string filePath)
        {
            
            List<Movie> movies = null;
            
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length > 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    movies = (List<Movie>)formatter.Deserialize(fileStream);
                }
                else
                {
                    // If the file is empty or doesn't exist, initialize movies to an empty list.
                    movies = new List<Movie>();
                }
            }
            
            int movieCount = movies.Count / maxMovies;
            return (movies, movieCount);
        }
    }
}
