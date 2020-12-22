using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TestNotFoundClientIssue;
using Xunit;

namespace TestNotFoundClientIssuesTest
{
    public class TestClientReturns: IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public TestClientReturns(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestNotFound()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("TestError/NotFound");
            
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }
        
        [Fact]
        public async Task TestBadRequest()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("TestError/BadRequest");
            
            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}