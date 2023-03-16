using RestSharp;
using System.Net;
using autotest.Models;
using System.Xml.Serialization;

namespace Test;

[TestFixture]
public class Tests
{
    // The base URLs for our tests
    private const string BASE_URL_POSTCODE = "https://api.zippopotam.us";
    private const string BASE_URL_COMMENT = "http://jsonplaceholder.typicode.com";
    private const string BASE_URL_ENERGY = "https://downloads.elexonportal.co.uk";

    // The RestSharp clients and Stopwatch
    private RestClient clientPostCode;
    private RestClient clientComment;
    private RestClient clientEnergy;
    private System.Diagnostics.Stopwatch timer;

    [OneTimeSetUp]
    public void Setup()
    {
        clientPostCode = new RestClient(BASE_URL_POSTCODE);
        clientComment = new RestClient(BASE_URL_COMMENT);
        clientEnergy = new RestClient(BASE_URL_ENERGY);
        timer = new System.Diagnostics.Stopwatch();
    }

    [Test]
    public async Task GetEnergyData()
    {
        //https://downloads.elexonportal.co.uk/fuel/download/latest?key=2arl4hkfmuweljw

        RestRequest request = new RestRequest($"/fuel/download/latest", Method.Get);
        request.AddParameter("key", "2arl4hkfmuweljw");

        timer.Start();
        var response = await clientEnergy.ExecuteAsync(request);
        timer.Stop();
        int elapsedMilliseconds = timer.Elapsed.Milliseconds;

        var serializer = new XmlSerializer(typeof(FuelTable));
        FuelTable result;

        using (TextReader reader = new StringReader(response.Content))
        {
            result = (FuelTable)serializer.Deserialize(reader);
        }
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

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Should return 201 - Created");
        Assert.That(elapsedMilliseconds, Is.LessThan(1000), "Should take less than 1000ms");
    }
}