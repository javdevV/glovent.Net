using gloventApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gloventApp.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    { 
        private gloventdbContext dataContext;
        public gloventdbContext DataContext { get { return dataContext; } }
         
        public DatabaseFactory()
        {
            dataContext = new gloventdbContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
