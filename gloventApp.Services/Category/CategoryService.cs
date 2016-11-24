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
   public class CategoryService : Service<category>
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(factory);
        public CategoryService() : base(uow)
        {

        }


       

        public List<category> getAllCategories()
        {
            return uow.getRepository<category>().GetMany().ToList();
        }



        public int numberOfCategories()
        {


            return getAllCategories().Count();


        }




        public int numberOfEventsInCategory(int id)
        {


            return uow.getRepository<evente>().GetMany().Where(e => e.MyCategory_id.Equals(id)).Count();


        }








        public int[] cate()
        {


            int[] tab = new int[getAllCategories().ToList().Count];


            for(int i=0;i< getAllCategories().ToList().Count; i++)
            {

                tab[i] = nec(i);

                return tab;
            }
            return null;

        }




        public int nec(int id)
        {

            return uow.getRepository<evente>().GetMany(e => e.category.id.Equals(id)).Sum(e => e.nombreParticipant);


        }











    }

}









    
