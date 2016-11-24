using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Galerie
{
    public interface IGalerie : IService<galerie>
    {
        IEnumerable<evente> GetAllGalerie();
        void DeleteGalerie(int id);
        galerie GetByIdGalerie(int id);
        bool BloqueGalerie(int id);
        IEnumerable<image> GetimageByGalerie(int id);
        IEnumerable<video> GetvideoByGalerie(int id);
        IEnumerable<image> GetimageInvisibleByGalerie(int id);
        IEnumerable<video> GetvideoInvisibleByGalerie(int id);
        void UpdateVisibilite();
        IEnumerable<galerie> SearchBynamecategory(string searchincat);
        Dictionary<string, int> CountImage();
        Dictionary<string, int> CountVideo();
    }
}
