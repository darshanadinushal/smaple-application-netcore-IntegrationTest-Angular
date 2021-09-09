using Newtonsoft.Json;
using Sample.Application.RestService.Integration.Tests.TestFixtures;
using Sample.Application.Shared.Infra;
using Sample.Application.Shared.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace Sample.Application.RestService.Integration.Tests.Tests
{
    [Collection("Integration test collection")]
    public class EmployeeIntegrationTests
    {
        private readonly HttpClient client;

        private readonly WireMockServer wireMockServer;

        public EmployeeIntegrationTests(IntegrationTestFixture<Startup> testFixture)
        {
            this.client = testFixture.CreateClient();
            this.wireMockServer = testFixture.WireMockServer;
        }


        private void SetupWireMockResponse()

        {

            wireMockServer.Given(Request.Create()
               .UsingMethod("GET")
               .WithPath("api/Employee")
               .WithParam("Id", new[] { "" }))
           .RespondWith(Response.Create()
               .WithBodyAsJson(new Employee { })
               .WithStatusCode(HttpStatusCode.OK));



            wireMockServer.Given(Request.Create()
                .UsingMethod("POST")
                .WithPath("api/Employee"))
            .RespondWith(Response.Create()
                .WithBodyAsJson(new GenericResponse { })
                .WithStatusCode(HttpStatusCode.OK));

        }

        [Fact]

        public async Task saveEmployee_Valid_200Ok()
        {
                var resource = ReadSampleTestFiles.GetJson("EmployeeRequest");
                var employeeRequest = JsonConvert.DeserializeObject<Employee>(resource);
                var response = await client.PostAsync("api/Employee", new StringContent(JsonConvert.SerializeObject(employeeRequest), Encoding.UTF8, "application/json"));
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                var responseBody = await response.Content.ReadAsStringAsync();
                var employeeResponse = JsonConvert.DeserializeObject<Employee>(responseBody);
                Assert.IsType<Employee>(employeeResponse);

        }

    }
}
