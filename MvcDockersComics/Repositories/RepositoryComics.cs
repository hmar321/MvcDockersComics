using Microsoft.EntityFrameworkCore;
using MvcDockersComics.Data;
using MvcDockersComics.Models;

namespace MvcDockersComics.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        public async Task<List<Comic>> GetComicsAsync()
        {
            List<Comic> comics = await this.context.Comics.ToListAsync();
            return comics;
        }
        public async Task<Comic> FindComicAsync(int idcomic)
        {
            Comic comic = await this.context.Comics.FirstOrDefaultAsync(x => x.IdComic == idcomic);
            return comic;
        }

        public async Task<int> GetNextIdComicAsync()
        {
            int nextid = await this.context.Comics.MaxAsync(x=>x.IdComic)+1;
            return nextid;
        }

        public async Task InsertComicAsync(string nombre,string imagen)
        {
            Comic comic = new Comic();
            comic.IdComic = await this.GetNextIdComicAsync();
            comic.Nombre = nombre;
            comic.Imagen = imagen;
            this.context.Comics.Add(comic);
            await this.context.SaveChangesAsync();
        }
    }
}
