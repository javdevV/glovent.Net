using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System.Collections.Generic;

namespace gloventApp.Services.Video.Likevideo
{
    public interface Ilikevideo : IService<likevideo>
    {

        IEnumerable<likevideo> Getlikebyidvideo(int id);
        void DeleteLike(int id);
    }
}
