using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System.Collections.Generic;

namespace gloventApp.Services.Image
{
    public interface IImage : IService<image>
    {
        IEnumerable<image> GetAllImage();
        void DeleteImage(int id);
        image GetByIdImage(int id);
        void InvisibleImage(int id);
        void VisibleImage(int id);
        void Updateallsign(int id);

    }
}
