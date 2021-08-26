using Movies_App.Common.Models;
using Movies_App.Common.Navigation;
using Movies_App.Modules.MovieDetails;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Movies_App
{
    public class MainViewModel : BaseViewModel
    {
        private INetworkService _networkService;
        private ObservableCollection<MovieModel> items;
        private MovieModel _selectedMovie;
        private INavigationService _navigation;
        private string _selectedMovieID;

        public ObservableCollection<MovieModel> Items { get => items; set { items = value; OnPropertyChanged(); } }

        public string SearchTerm { get; set; }
        public string SelectedMovieID { get => _selectedMovieID; set => SetProperty(ref _selectedMovieID, value); }

        public MovieModel SelectedMovie { get => _selectedMovie; set => SetProperty(ref _selectedMovie, value); }

        public MainViewModel(INetworkService networkService, INavigationService navigation)
        {
            _networkService = networkService;
            _navigation = navigation;
        }

        public ICommand PerformSearchCommand => new Command(async () => await GetMovieData());
        public ICommand MovieChangedCommand => new Command(async () => await GoToMovieDetails());

        private async Task GoToMovieDetails()
        {
            if (SelectedMovie != null)
            {
                SelectedMovieID = SelectedMovie.ImdbID;
                await _navigation.PushAsync<MovieDetailsViewModel>(SelectedMovie);
                SelectedMovie = null;
                SelectedMovieID = string.Empty;
            }
        }

        private async Task GetMovieData()
        {
            var result = await _networkService.GetAsync<ListOfMovies>(ApiConstants.GetMoviesUri(SearchTerm));
            try
            {
                Items = new ObservableCollection<MovieModel>(result.Search.Select(s => new MovieModel(s.Title, s.Poster.Replace("SX300", "SX1000"), s.Year, s.imdbID)));
            }
            catch (Exception) { Items = new ObservableCollection<MovieModel>(); }

        }
    }
}
