using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ACStalkMarket.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public People People { get; set; }
        [Required]
        public int PeopleId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            userIdentity.AddClaim(new Claim("PeopleId", PeopleId.ToString()));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<People> People { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<WeekValues> WeekValues { get; set; }
        public DbSet<WeekPattern> WeekPatterns { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}