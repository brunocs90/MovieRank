using Docker.DotNet;
using Docker.DotNet.Models;
using Xunit;

namespace MovieRank.Integration.Tests.Setup
{
    public class TestContext : IAsyncLifetime
    {
        private readonly DockerClient _dockerClient;
        private const string ContainerImageUri = "amazon/dynamodb-local";
        private string? _containerId;

        public TestContext()
        {
            _dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
        }

        public async Task InitializeAsync()
        {
            await PullImage();
            await StartContainer();
            await TestDataSetup.CreateTable();
        }

        private async Task PullImage()
        {
            var parameters = new ImagesCreateParameters
            {
                FromImage = ContainerImageUri,
                Tag = "latest"
            };

            await _dockerClient.Images.CreateImageAsync(parameters, new AuthConfig(), new Progress<JSONMessage>());
        }

        private async Task StartContainer()
        {
            var parameters = new CreateContainerParameters
            {
                Image = ContainerImageUri,
                ExposedPorts = new Dictionary<string, EmptyStruct>
                {
                    { "8000", default }
                },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { "8000", new List<PortBinding> { new PortBinding { HostPort = "8000" } } }
                    },
                    PublishAllPorts = true
                }
            };

            var response = await _dockerClient.Containers.CreateContainerAsync(parameters);
            _containerId = response.ID;

            await _dockerClient.Containers.StartContainerAsync(_containerId, null);
        }

        public async Task DisposeAsync()
        {
            if (_containerId != null)
            {
                await _dockerClient.Containers.KillContainerAsync(_containerId, new ContainerKillParameters());
            }
        }
    }
}
