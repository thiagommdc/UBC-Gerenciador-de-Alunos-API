using Microsoft.EntityFrameworkCore;
using UBC_Gerenciador_de_Alunos_API.Data;

namespace Tests
{
    public static class TestHelper
    {
        public static ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
