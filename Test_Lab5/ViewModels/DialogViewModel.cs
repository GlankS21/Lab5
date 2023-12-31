using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReactiveUI;
using Test_Lab5.Models;
using Test_Lab5.Views;

namespace Test_Lab5.ViewModels;

public class DialogViewModel:ViewModelBase {
    private List<MusicModel> _musics;
    //private DialogWindow _dialogWindow;

    public DialogViewModel(List<MusicModel> musics) { 
        _musics = musics;
    }

    public List<MusicModel> MusicModels {
        get => _musics;
        set => this.RaiseAndSetIfChanged(ref _musics, value);
    }
    
    public async Task GetAllMusics() {
        var dialogWindow = new DialogWindow {
            DataContext = this
        };
        dialogWindow.Show();
    }
}