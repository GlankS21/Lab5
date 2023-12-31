    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Test_Lab5.Models;

    namespace Test_Lab5.Repository;

    public interface IMusicRepository { 
        //вывести информацию обо всех существующих в каталоге композициях
        public Task<List<MusicModel>> GetAll();    
        //добавить информацию о композиции в каталог 
        public Task AddMusic(MusicModel music); 
        public Task<List<MusicModel>> FindByPartOfName(string PartOfName); 
        public Task DeleteMusic(string authorName, string compositionName); 
    }