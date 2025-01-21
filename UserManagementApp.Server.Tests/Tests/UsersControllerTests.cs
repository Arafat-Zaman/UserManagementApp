using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementApp.Server.Tests.Tests
{
    [TestFixture]
    public class UsersControllerTests : IntegrationTestBase
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = Factory.CreateClient();
        }

        [Test]
        public async Task GetUsers_ShouldReturnUsers()
        {
            var response = await _client.GetAsync("/api/users");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task SearchUsers_ShouldReturnFilteredResults()
        {
            var response = await _client.GetAsync("/api/users/search?query=Manager");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose the HttpClient after each test
            _client?.Dispose();
        }
    }
}
