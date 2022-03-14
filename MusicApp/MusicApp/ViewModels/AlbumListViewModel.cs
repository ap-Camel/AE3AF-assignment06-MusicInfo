using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

using MusicApp.Models;
using MusicApp.Services;
using MusicApp.ViewModels;
using MusicApp.Views;

namespace MusicApp.ViewModels
{
    public class AlbumListViewModel : BaseViewModel
    {

        public ObservableCollection<Album> albums { get; }

        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set { SetProperty(ref selectedAlbum, value); }
        }

        private string search;

        public string Search
        {
            get { return search; }
            set { SetProperty(ref search, value); }
        }

        public ICommand LoadDataCommand { private set; get; }

        public ICommand GoToDetailCommand { private set; get; }

        private List<Album> AlbumList;

        public async Task LoadData(string search = "Hello")
        {
            IsBusy = true;

            search = Search;

            AlbumList = await MusicInfoServices.GetAlbums(search);
            albums.Clear();

            IEnumerable<Album> albumSet = AlbumList;

            foreach (Album album in albumSet)
            {
                album.ImgUrl = album.image[1].Text;
                albums.Add(album);
            }

            IsBusy = false;
        }

        //public void LoadAlbums()
        //{

        //}

        public async Task GoToDetails()
        {
            if(SelectedAlbum != null)
            {
                AlbumDetailsViewModel km = new AlbumDetailsViewModel();
                km.SelectedAlbum = SelectedAlbum;

                AlbumDetailView page = new AlbumDetailView();
                page.BindingContext = km;

                IEnumerable<Track> trackList = await MusicInfoServices.GetAlbumInfo(SelectedAlbum.artist, SelectedAlbum.name);

                foreach (Track track in trackList)
                {
                    km.tracks.Add(track);
                }


                await App.Current.MainPage.Navigation.PushAsync(page);

            }
        }

        public  AlbumListViewModel()
        {
            //AlbumList = new List<Album>();
            //albums = new ObservableCollection<Album>();

            //LoadDataCommand = new Command(async () => await LoadData());


            AlbumList = new List<Album>();
            albums = new ObservableCollection<Album>();

            LoadDataCommand = new Command(async () => await LoadData());
            GoToDetailCommand = new Command(async () => await GoToDetails());

        }

    }
}
