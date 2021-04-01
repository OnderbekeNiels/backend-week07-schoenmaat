using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Schoenmaat.API;
using Xunit;

namespace Schoenmaat.Test
{
    public class SchoenmaatTest : IClassFixture<WebApplicationFactory<Schoenmaat.API.Startup>>
    {
        public HttpClient Client { get; }

        public SchoenmaatTest(WebApplicationFactory<Schoenmaat.API.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]

        public void Calc_Schoenmaat_Schould_Be_Ok()
        {
            SchoenmaatService service = new SchoenmaatService();

            Assert.Equal<double>(41.5, service.calcShoenmaat(40));
        }

        [Fact]

        public void Calc_Schoenmaat_1_Schould_Be_Exception()
        {
            SchoenmaatService service = new SchoenmaatService();
            Assert.Throws<ArgumentException>(() => service.calcShoenmaat(1));
        }

        [Fact]

        public void Calc_Schoenmaat_51_Schould_Be_Exception()
        {
            SchoenmaatService service = new SchoenmaatService();
            Assert.Throws<ArgumentException>(() => service.calcShoenmaat(51));
        }

        [Fact]

        public async Task Get_Schoenmaat_Schould_Return_Ok()
        {
            var response = await Client.GetAsync("/api/schoenmaat/40");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]

        public async Task Get_Schoenmaat_Schould_Return_Error()
        {
            var response = await Client.GetAsync("/api/schoenmaat/1");
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }


    }
}
