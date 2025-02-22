namespace MusiCodeWebApp.Migrations
{
    using MusiCodeWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<MusiCodeWebApp.Models.MusiCodeDBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(MusiCodeDBModel context)
        {
            #region Manager Types

            //context.ManagerRoles.AddOrUpdate(x => x.ID, new ManagerRole() { ID = 1, Name = "Admin", IsDeleted = false });
            //context.ManagerRoles.AddOrUpdate(x => x.ID, new ManagerRole() { ID = 2, Name = "Moderator", IsDeleted = false });

            #endregion

            #region Manager

            //context.Managers.AddOrUpdate(x => x.ID, new Manager() { ID = 1, Name = "Developer", Surname = "Developer", Mail = "dev@dev.com", ManagerRoleID = 1, Password = "12345", IsActive = true, IsDeleted = false });

            #endregion

        }
    }
}
