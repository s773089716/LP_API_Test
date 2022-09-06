//using Newtonsoft.Json;
using NUnit.Framework;
using StemServiceTests1;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Tests
{
    public class StemServiceResult
    {
        public IList<string> data { get; set; }
    }

    [TestFixture]
    public class Tests
    {
        private StemServiceFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new StemServiceFactory();
            _client = _factory.CreateClient();
        }

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}

        [Test, Description("should return a list of words starting with \"aar\"")]
        public async Task TestGetAar()
        {
            var response = await _client.GetAsync("/?stem=aar");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.Write(responseBody);
            var expected = new List<string>
            {
                "aardvark",
                "aardvarks",
                "aardwolf",
                "aardwolves",
                "aargh",
                "aaron",
                "aaronic",
                "aaronical",
                "aaronite",
                "aaronitic",
                "aarrgh",
                "aarrghh",
                "aaru"
            };

            try
            {
                var actual = JsonSerializer.Deserialize<StemServiceResult>(responseBody);
                Assert.That(actual.data, Is.EqualTo(expected));
            }
            //catch (System.Text.Json.JsonException)
            catch (Exception)
            {
                Assert.Fail("Could not deserialize response JSON:\n" + Trunc(responseBody));
            }
        }

        [Test, Description("should return a Not Found Status")]
        public async Task TestGetUnavailablePrefix()
        {
            var response = await _client.GetAsync("/?stem=zebra1");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));            
        }

        [Test, Description("should return a the full list")]
        public async Task TestGetEmptyStem()
        {
            int expectedCount = 370101;
            var response = await _client.GetAsync("/?stem=");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.Write(responseBody);
           
            try
            {
                var actual = JsonSerializer.Deserialize<StemServiceResult>(responseBody);
                Assert.That(actual.data.Count, Is.EqualTo(expectedCount));
            }
            //catch (System.Text.Json.JsonException)
            catch (Exception)
            {
                Assert.Fail("Could not deserialize response JSON:\n" + Trunc(responseBody));
            }
        }

        [Test, Description("should return a the full list")]
        public async Task TestGetNoStem()
        {
            int expectedCount = 370101;

            var response = await _client.GetAsync("/");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.Write(responseBody);

            try
            {
                var actual = JsonSerializer.Deserialize<StemServiceResult>(responseBody);
                Assert.That(actual.data.Count, Is.EqualTo(expectedCount));
            }
            //catch (System.Text.Json.JsonException)
            catch (Exception)
            {
                Assert.Fail("Could not deserialize response JSON:\n" + Trunc(responseBody));
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        private static string Trunc(string s, int thresh = 200, int trunc = 50)
        {
            if (s.Length > thresh)
            {
                return s.Substring(0, trunc) + "..." + s.Substring(s.Length - trunc);
            }

            return s;
        }
    }
}