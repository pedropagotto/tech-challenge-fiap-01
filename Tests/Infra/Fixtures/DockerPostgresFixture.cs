using Docker.DotNet;
using Docker.DotNet.Models;

namespace Tests.Infra.Fixtures
{
    public class DockerPostgresFixture : IDisposable
    {
        private DockerClient _dockerClient;
        private string _containerId;
        private readonly string _environment;

        public DockerPostgresFixture()
        {

            _dockerClient = new DockerClientConfiguration().CreateClient();

            var createContainerResponse = _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
            {
                Image = "postgres",
                Env = new List<string> { "POSTGRES_PASSWORD=postech" },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>()
          {
              { "5433/tcp", new List<PortBinding> { new PortBinding { HostPort = "5433" } } }
          },
                    PublishAllPorts = true // Optional: Set this to true if you want to publish all exposed ports
                }
            }).GetAwaiter().GetResult();


            _containerId = createContainerResponse.ID;

            _dockerClient.Containers.StartContainerAsync(_containerId, new ContainerStartParameters()).GetAwaiter().GetResult();

        }

        public string GetConnectionString()
        {
            var _connectionString = $"Server=localhost;Port=5432;Database=techchallenge02;User Id=postech;Password=postech;";
            return _connectionString;
        }

        public void Dispose()
        {
            _dockerClient.Containers.StopContainerAsync(_containerId, new ContainerStopParameters()).GetAwaiter().GetResult();
            _dockerClient.Containers.RemoveContainerAsync(_containerId, new ContainerRemoveParameters()).GetAwaiter().GetResult();
            _dockerClient.Dispose();
        }
    }
}
