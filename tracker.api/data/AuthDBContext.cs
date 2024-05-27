using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace tracker.api.data
{
    public class AuthDBContext :IdentityDbContext
    {    //Add-Migration "Auth_one" -context "AuthDBContext"
        //Update-Database -context "AuthDBContext"
        public AuthDBContext( DbContextOptions<AuthDBContext> AuthDboptions) : base(AuthDboptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var readerRoleId = "ded07973-30ec-4d8e-aa14-92b55cf3b066";
            var WriterRoleId = "c80e669a-ec46-412b-9e0a-3a6ec5f63316";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()

                },
                new IdentityRole
                {
                    Id =  WriterRoleId,
                    ConcurrencyStamp = WriterRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
