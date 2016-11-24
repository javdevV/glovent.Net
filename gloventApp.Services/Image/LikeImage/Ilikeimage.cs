using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Image.LikeImage
{
    public interface Ilikeimage : IService<likeimage>
    {

        IEnumerable<likeimage> Getlikebyidimage(int id);
    }
}
