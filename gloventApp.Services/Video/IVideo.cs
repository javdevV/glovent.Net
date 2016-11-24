using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Video
{
    public interface IVideo : IService<video>
    {
        IEnumerable<video> GetAllVideo();
        void DeleteVideo(int id);
        video GetByIdVideo(int id);
        void InvisibleVideo(int id);
        void VisibleVideo(int id);
    }
}
