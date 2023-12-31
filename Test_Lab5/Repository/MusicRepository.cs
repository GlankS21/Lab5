    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Test_Lab5.DB;
    using Test_Lab5.Models;

    namespace Test_Lab5.Repository;

    public class MusicRepository :IMusicRepository{ 
        private readonly MusicCatalogContext _dbContext;
        public MusicRepository(MusicCatalogContext dbContext) {
            _dbContext = dbContext;
        }
        
        public List<MusicModel> GetAll() { 
            if (_dbContext.Musics == null) return new List<MusicModel>();
            return _dbContext.Musics.ToList();
        }
         
        // list
        public Task AddMusic(MusicModel music) {  
            _dbContext.Musics.Add(music); 
            return _dbContext.SaveChangesAsync(); 
        }
        
        //searchByAuthor
        public List<MusicModel> FindByPartOfName(string PartOfName) {
            return new List<MusicModel>(GetAll().Where(m => m.composition.Contains(PartOfName)));
        }
        //delete
        public Task DeleteMusic(string authorName, string compositionName) {
            MusicModel music = _dbContext.Musics.FirstOrDefault(music => music.author == authorName && music.composition == compositionName);
            _dbContext.Remove(music);
            return _dbContext.SaveChangesAsync();
        }
    } 