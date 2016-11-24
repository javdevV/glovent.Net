using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace gloventApp.Data.Models
{
    public partial class user: IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>

    {
        public user()
        {
            this.answers = new List<answer>();
            this.complaints = new List<complaint>();
            this.images = new List<image>();
            this.likeimages = new List<likeimage>();
            this.likevideos = new List<likevideo>();
            this.polls = new List<poll>();
            this.tasks = new List<task>();
            this.tickets = new List<ticket>();
            this.tickets1 = new List<ticket>();
            this.videos = new List<video>();
            this.events = new List<evente>();
            this.organizations = new List<organization>();
        }

        public string DTYPE { get; set; }
        //public int idUser { get; set; }
        public bool AccountState { get; set; }
        public string adress { get; set; }
        public int age { get; set; }
        //public string email { get; set; }
        public string fName { get; set; }
        public string image { get; set; }
        public string lName { get; set; }
        //public string login { get; set; }
        public string pwd { get; set; }
        public Nullable<int> attachement_file { get; set; }
        public Nullable<int> MyOrganization_id { get; set; }
        public string friendrand { get; set; }
        public string rand { get; set; }
        public virtual ICollection<answer> answers { get; set; }
        public virtual ICollection<complaint> complaints { get; set; }
        public virtual ICollection<image> images { get; set; }
        public virtual ICollection<likeimage> likeimages { get; set; }
        public virtual ICollection<likevideo> likevideos { get; set; }
        public virtual organization organization { get; set; }
        public virtual ICollection<poll> polls { get; set; }
        public virtual ICollection<task> tasks { get; set; }
        public virtual ICollection<ticket> tickets { get; set; }
        public virtual ICollection<ticket> tickets1 { get; set; }
        public virtual ICollection<video> videos { get; set; }
        public virtual ICollection<evente> events { get; set; }
        public virtual ICollection<organization> organizations { get; set; }

        public organization myOrganization { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<user,int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }
    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }

    }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }
}







