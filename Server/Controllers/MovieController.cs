using Microsoft.AspNetCore.Mvc;
using MyFavoriteMovies.Shared;

namespace MyFavoriteMovies.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;
    private readonly HttpClient _httpClient;
    public MovieController(ILogger<MovieController> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    [HttpGet]
    [Route("Top10Movies")]
    public async Task<List<Movie>> GetTop10MoviesAsync()
    {
        var apiKey = "728870e1397db70ea9db310a4d837c6c";
        var apiUrl = $"https://api.themoviedb.org/3/movie/top_rated?api_key={apiKey}&language=en-US&page=1";
        var response = await _httpClient.GetFromJsonAsync<MovieResponse>(apiUrl);
        return response.Results.Take(10).ToList();
    }

     [HttpGet]
    [Route("{id}/Video")]
    public async Task<MovieVideo> GetVideoById(int id)
    {
        var apiKey = "728870e1397db70ea9db310a4d837c6c";
        var apiUrl = $"https://api.themoviedb.org/3/movie/{id}/videos?api_key={apiKey}&language=en-US";
        var response = await _httpClient.GetFromJsonAsync<MovieVideoResponse>(apiUrl);
        return response.Results.FirstOrDefault();
    }

   

    private class MovieResponse
    {
        public List<Movie> Results { get; set; }
    }

        private class MovieVideoResponse
    {
        public List<MovieVideo> Results { get; set; }
    }
}
