using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Infra.Fixtures
{
    public class DatabaseTestBase : IDisposable
    {
        protected readonly AppDbContext _context;
        private readonly DockerPostgresFixture _dockerFixture;

        public DatabaseTestBase(DockerPostgresFixture dockerFixture)
        {
            _dockerFixture = dockerFixture;

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkNpgsql()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(_dockerFixture.GetConnectionString())
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _context = new AppDbContext(options);
            //_context.Database.EnsureCreated();
            _context.Database.Migrate();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
