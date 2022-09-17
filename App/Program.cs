using System.Net;


async Task GetWebsite1(string url)
{
    var webClin = new WebClient();
    var html = await webClin.DownloadStringTaskAsync(url);
    using (var strim = new StreamWriter("web1.html"))
    {
        await strim.WriteAsync(html); 
    }
}
async Task GetWebsite2(string url)
{
    var webClin = new WebClient();
    var html = await webClin.DownloadStringTaskAsync(url);
    using (var strim = new StreamWriter("web2.html"))
    {
        await strim.WriteAsync(html);
    }
}
//await GetWebsite1("http://www.somon.tj");

var list = new List<Task>(){ GetWebsite1("http://www.somon.tj"), GetWebsite2("http://www.softclub.tj") };
await Task.WhenAll(list);
