using CompanySelf.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CompanySelf.Application.Tests.Helpers
{
    public static class DbContextOptionsHelper
    {
        public static DbContextOptions<ApplicationDbContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: databaseName)
                 .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                 .Options;
        }
    }
}