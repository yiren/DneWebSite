using Microsoft.Owin;
using Owin;
using IdentityManager;
using IdentityManager.AspNetIdentity;
using IdentityManager.Configuration;
using DneWebSite.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(DneWebSite.Startup))]
namespace DneWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.Map("/idm", idm =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.IdentityManagerService = new Registration<IIdentityManagerService, ApplicationIdentityMangaerService>();
                factory.Register(new Registration<ApplicationUserManager>());
                factory.Register(new Registration<ApplicationUserStore>());
                factory.Register(new Registration<ApplicationRoleManager>());
                factory.Register(new Registration<ApplicationRoleStore>());
                factory.Register(new Registration<ApplicationDbContext>());

                idm.UseIdentityManager(new IdentityManager.Configuration.IdentityManagerOptions
                {
                    Factory=factory
                });
            });
        }
    }

    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext ctx)
            :base(ctx)
        {

        }
    }

    public class ApplicationRoleStore : RoleStore<IdentityRole>
    {
        public ApplicationRoleStore(ApplicationDbContext ctx)
            :base(ctx)
        {

        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore roleStore)
            :base(roleStore)
        {

        }
    }

    public class ApplicationIdentityMangaerService:AspNetIdentityManagerService<ApplicationUser, string, IdentityRole, string>
    {
        public ApplicationIdentityMangaerService(ApplicationUserManager userMgr, ApplicationRoleManager roleMgr)
            :base(userMgr, roleMgr)
        {

        }
    }
}
