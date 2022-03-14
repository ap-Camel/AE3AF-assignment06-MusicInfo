using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MusicApp.Models;
using MusicApp.Services;
using MusicApp.ViewModels;

namespace MusicApp.ViewModels
{
    public class AlbumDetailsViewModel : BaseViewModel
    {

        public ObservableCollection<Track> tracks { get; }

        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set { SetProperty(ref selectedAlbum, value); }
        }

        public AlbumDetailsViewModel()
        {
            tracks = new ObservableCollection<Track>();


        }

    }
}
