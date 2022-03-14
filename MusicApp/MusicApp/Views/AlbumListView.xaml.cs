using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicApp.ViewModels;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumListView : ContentPage
    {
        AlbumListViewModel vm;
        public AlbumListView()
        {
            InitializeComponent();

            vm = new AlbumListViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() => vm.LoadDataCommand.Execute(null));
        }

    }
}