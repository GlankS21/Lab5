using System;
using System.ComponentModel.DataAnnotations;
using Test_Lab5.ViewModels;

namespace Test_Lab5.Models;

public class MusicModel { 
    public string author { get; set; }
    public string composition{ get; set; }
    
    [Key]
    public Guid Id { get; set; }
}