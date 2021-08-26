using Movies_App.Common.Database;
using Movies_App.Common.Models;
using Movies_App.Common.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Movies_App.Modules.MovieDetails
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private MovieModel _movieData;
        private FullMovieInformation _movieInformation;
        private INavigationService _navigationService;
        private INetworkService _networkService;
        private IRepository<FullMovieInformation> _movieInformationRepository;
        private bool _isFavorite;

        public MovieModel MovieData { get => _movieData; set => SetProperty(ref _movieData, value); }
        public FullMovieInformation MovieInformation { get => _movieInformation; set => SetProperty(ref _movieInformation, value); }
        public bool IsFavorite { get => _isFavorite; set => SetProperty(ref _isFavorite, value); }

        public MovieDetailsViewModel(INavigationService navigationService, INetworkService networkService, IRepository<FullMovieInformation> repository)
        {
            _navigationService = navigationService;
            _networkService = networkService;
            _movieInformationRepository = repository;
        }

        public ICommand GoBackCommand => new Command(async () => await GoBack());
        public ICommand FavoriteCommand => new Command(async()=> await SetMovieFavorite());

        private async Task SetMovieFavorite()
        {
            IsFavorite = !IsFavorite;
            MovieInformation.IsFavorite = IsFavorite;
            await _movieInformationRepository.SaveAsync(MovieInformation);
        }

        private async Task GoBack()
        {
            await _navigationService.PopAsync();
        }

        public override async Task InitializeAsync(object parameter)
        {
            MovieData = (MovieModel)parameter;
            MovieInformation = await _networkService.GetAsync<FullMovieInformation>(ApiConstants.GetMovieByID(MovieData.ImdbID));
            var dbinfo = (await _movieInformationRepository.GetAllAsync()).FirstOrDefault(x => x.imdbID == MovieInformation.imdbID);

            if(dbinfo != null)
            {
                MovieInformation.ID = dbinfo.ID;
                IsFavorite = dbinfo.IsFavorite;
            }
        }
    }
}
