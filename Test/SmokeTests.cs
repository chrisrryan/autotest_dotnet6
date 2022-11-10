using RestSharp;
using System.Net;
using autotest.Models;

namespace Test
{
    [TestFixture]
    public class Tests
    {

        // The base URLs for our tests
        private const string BASE_URL_POSTCODE = "https://api.zippopotam.us";
        private const string BASE_URL_COMMENT = "http://jsonplaceholder.typicode.com";

        // The RestSharp clients and Stopwatch
        private RestClient clientPostCode;
        private RestClient clientComment;
        private System.Diagnostics.Stopwatch timer;

        [OneTimeSetUp]
        public void Setup()
        {
            clientPostCode = new RestClient(BASE_URL_POSTCODE);
            clientComment = new RestClient(BASE_URL_COMMENT);
            timer = new System.Diagnostics.Stopwatch();
        }

        [Test]
        public async Task GetDataForPostCode_CW2_CheckPlaceName_ShouldEqualWeston()
        {
            RestRequest request = new RestRequest($"/GB/CW2", Method.Get);

            timer.Start();
            RestResponse<LocationData> response = await clientPostCode.ExecuteAsync<LocationData>(request);
            timer.Stop();
            int elapsedMilliseconds = timer.Elapsed.Milliseconds;

            LocationData locationData = response.Data;

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Should return 200 - OK");
            Assert.That(locationData.Places[3].PlaceName, Is.EqualTo("Weston"), "Should be Weston");
            Assert.That(elapsedMilliseconds, Is.LessThan(750), "Should take less than 750ms");
        }


        [Test]
        public async Task PostNewComment_CheckStatusCode_ShouldEqualHttpCreated()
        {
            Comment comment = new Comment
            {
                PostId = 1,
                Name = "Joe Bloggs",
                Email = "jbloggs@example.com",
                Body = "Just posting a comment..."
            };

            RestRequest request = new RestRequest($"/comments", Method.Post);
            request.AddJsonBody(comment);

            timer.Start();
            RestResponse response = await clientComment.ExecuteAsync(request);
            timer.Stop();
            int elapsedMilliseconds = timer.Elapsed.Milliseconds;

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Should return 401 - Created");
            Assert.That(elapsedMilliseconds, Is.LessThan(750), "Should take less than 750ms");
        }
    }
}