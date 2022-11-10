# Test Automation with .NET Core 6, RestSharp 1.07+ and NUnit.

**Time to investigate .NET Core 6 and RESTSharp 1.07+ for Test Automation** 

.NET CORE 6 is now stable and production ready, so I felt it was time to jump in and implement some test automation with it.

I've implemented a couple of basic smoke tests using https://api.zippopotam.us/ for some UK Postcode lookup and typicode.com for a POST test.

I'm using RestSharp, which since version 1.07 had undergone a major upgrade, which contains quite a few breaking changes. I'm using 1.08 here and System.Text.Json.Serialization in place of Newtonsoft for some JSON framework speed improvement.

I've added a couple of performance tests using System.Diagnostics.Stopwatch with a very generous test assertion that REST requests will complete in under 1000 milliseconds. 

## Video

[.NET Core 6 Test Automation](https://youtu.be/l8yG1b66wiU)
