    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using DynamicData;
    using ReactiveUI;
    using Test_Lab5.DB;
    using Test_Lab5.Models;
    using Test_Lab5.Repository;
    using Test_Lab5.Views;

    namespace Test_Lab5.ViewModels;
    public class MainWindowViewModel : ViewModelBase
    {
        private string _authorName;
        private string _compositionName;
        private string _partOfName;
        private string _message;
        private MusicCatalogContext _dbContext;
        private MusicRepository _musicRepository;
        public ObservableCollection<MusicModel> MusicList { get; set; } = new ObservableCollection<MusicModel>();
        private MusicModel _music;
        public string GetAuthorName {
            get => _authorName;
            set => this.RaiseAndSetIfChanged(ref _authorName, value);
        }
        public string GetCompositionName {
            get => _compositionName;
            set => this.RaiseAndSetIfChanged(ref _compositionName, value);
        }
        public string GetPartOfName {
            get => _partOfName;
            set => this.RaiseAndSetIfChanged(ref _partOfName, value);
        }
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }
        public MusicModel Music{
            get => _music;
            set => this.RaiseAndSetIfChanged(ref _music, value);
        }

        public MainWindowViewModel() {
            _dbContext = new MusicCatalogContext();
            _musicRepository = new MusicRepository(_dbContext);
            LoadData();
        }

        private async Task LoadData() {
            var musicFromDatabase = await _musicRepository.GetAll();
            foreach (var music in musicFromDatabase)
                MusicList.Add(music);
        }
        public async Task AddMusicToDatabase() {
            try {
                if (_authorName == null || _compositionName == null) {
                    Message = "Please enter the author's name and the composition's name !";
                    return;
                }
                MusicModel check = _dbContext.Musics.FirstOrDefault(music =>
                    music.author == _authorName && music.composition == _compositionName);
                if (check != null) {
                    Message = "Music already exists";
                    return;
                }
                var newMusic = new MusicModel() {
                    author = _authorName,
                    composition = _compositionName,
                    Id = Guid.NewGuid()
                };

                MusicList.Add(newMusic);
                _musicRepository.AddMusic(newMusic);
                Music = newMusic;
                Message = "New music added successfully !";
            }
            catch (Exception e) {
                Message = "Error...";
            }
        }
        public async Task LoadMusicFromDatabase() {
            try {
                MusicList.Clear();
                IEnumerable<MusicModel> musicList = await _musicRepository.GetAll();
                foreach (var music in musicList)
                    MusicList.Add(music);
                
                Message = "Music loaded successfully !";
            }
            catch (Exception e) {
                Message = "Error...";
            }
        }
        public async Task DeleteMusic() {
            try {
                if (_authorName == null || _compositionName == null) {
                    Message = "Please enter the author's name and the composition's name !";
                    return;
                }
                _musicRepository.DeleteMusic(_authorName, _compositionName);
                MusicList.Remove(_music);
                Message = "Music deleted successfully !";
            }
            catch (Exception e)
            {
                Message = "Error...";
            }
        }
        public async Task FindByPartOfName() { 
            try {
                if (_partOfName == null) {
                    Message = "Please enter the part of name !";
                    return;
                }
                List<MusicModel> musics = MusicList.Where(m => m.composition.Contains(_partOfName)).ToList();
                Message = $"{musics.Count} results found";
            }catch (Exception e) {
                Message = "Error...";
            }
            
        }
    }