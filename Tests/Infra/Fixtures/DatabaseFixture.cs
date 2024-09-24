namespace Tests.Infra.Fixtures
{
    public class DatabaseFixture : IClassFixture<DockerPostgresFixture>
    {
        private readonly DockerPostgresFixture _dockerFixture;

        public DatabaseFixture(DockerPostgresFixture dockerFixture)
        {
            _dockerFixture = dockerFixture;
        }
    }
}
