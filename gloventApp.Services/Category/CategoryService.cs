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


        public void AddCategory(category c)
        {
            uow.getRepository<category>().Add(c);
            uow.Commit();
        }

        public void DeleteCategory(category c)
        {
            uow.getRepository<category>().Delete(c);
            uow.Commit();
        }

        public void EditCategory(category c)
        {
            uow.getRepository<category>().Update(c);
            uow.Commit();
        }

        public List<category> getAllCategories()
        {
            return uow.getRepository<category>().GetMany().ToList();
        }













    }

}









    
