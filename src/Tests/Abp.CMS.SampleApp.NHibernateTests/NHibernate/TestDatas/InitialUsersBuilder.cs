using System.Linq;
using Abp.CMS.SampleApp.MultiTenancy;
using Abp.CMS.SampleApp.Users;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Linq;

namespace Abp.CMS.SampleApp.NHibernate.TestDatas
{
    public class InitialUsersBuilder
    {
        private readonly ISession _session;

        public InitialUsersBuilder(ISession session)
        {
            _session = session;
        }

        public void Build()
        {
            CreateUsers();
        }

        private void CreateUsers()
        {
            var defaultTenant = _session.Query<Tenant>().Single(t => t.Name == Tenant.DefaultTenantName);

            _session.Save(
                new User
                {
                    TenantId = defaultTenant.Id,
                    Name = "System",
                    Surname = "Administrator",
                    UserName = User.AdminUserName,
                    Password = new PasswordHasher().HashPassword("123qwe"),
                    EmailAddress = "admin@aspnetboilerplate.com"
                });
        }
    }
}