using gloventApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gloventApp.GUI.Helpers
{
    public static class extensionMethod
    {


        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<category> numPres)
        {
            return numPres.Select(r =>
                        new SelectListItem
                        {
                            Text = r.Libelle,
                            Value = r.id.ToString()

                        }

             );
        }









public static IEnumerable<SelectListItem> ToSelectListItems1(this IEnumerable<user> numPres)
        {
            var x = numPres.OrderBy(c => c.Id).Where(d => d.DTYPE.ToLower() == "president" && d.MyOrganization_id == null).Select(r =>
                           new SelectListItem
                           {
                               Text = r.fName,
                               Value = r.Id.ToString()
                           }
             );
            if (x != null) return x;
            else return new List<SelectListItem>().DefaultIfEmpty();
        }












        public static IEnumerable<SelectListItem> ToSelectListItems2(this IEnumerable<string> lstSubject)
        {
            return lstSubject.Select(r =>
                   new SelectListItem
                   {
                       Text = r,
                       Value = r

                   }

            );
        }















    }
}