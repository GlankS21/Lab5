using System;
using ReactiveUI;

namespace Test_Lab5.ViewModels;

public class MusicViewModel:ViewModelBase
{
    private string _authorName = "author";
    private string _compositionName = "composition";
    private string _title;
    private Guid _id = Guid.Empty;

    public string Author {
        get => _authorName;
        set => this.RaiseAndSetIfChanged(ref _authorName, value);
    }

    public string Composition {
        get => _compositionName;
        set => this.RaiseAndSetIfChanged(ref _compositionName, value);
    }
    
    public string Title {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public Guid Id {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
}