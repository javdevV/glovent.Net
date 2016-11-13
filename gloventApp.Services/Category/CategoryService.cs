using gloventApp.Data.Infrastructure;
using gloventApp.Data.Models;
using gloventApp.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Services.Category
{
    class CategoryService : Service<category>, ICategoryService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(factory);
        public CategoryService() : base(uow)
        {

        }















    }

}









    
