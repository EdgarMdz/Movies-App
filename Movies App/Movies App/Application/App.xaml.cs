using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Autofac;
using System.Reflection;
using Movies_App.Common.Navigation;
using Plugin.SharedTransitions;
using Movies_App.Common.Database;
using Movies_App.Common.Models;

namespace Movies_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();

            builder.RegisterType<Repository<FullMovieInformation>>()
                .As<IRepository<FullMovieInformation>>();

            //register navigation service
            SharedTransitionNavigationPage navigationPage = null;
            Func<INavigation> navigationFunc = () => {
                return navigationPage.Navigation;
            };
            builder.RegisterType<NavigationService>().As<INavigationService>()
                .WithParameter("navigation", navigationFunc)
                .SingleInstance();

            //get container
            var container = builder.Build();
            //set first page
            navigationPage = new SharedTransitionNavigationPage(container.Resolve<MainView>());
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
