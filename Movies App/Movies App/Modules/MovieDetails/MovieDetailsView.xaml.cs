using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movies_App.Modules.MovieDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsView : ContentPage
    {
        public MovieDetailsView(MovieDetailsViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        private async void imageBuutton_Clicked(object sender, EventArgs e)
        {
            await imageBuutton.ScaleTo(1.3, 250);
            await imageBuutton.ScaleTo(1, 250);
        }
    }
}