// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Text.Json.Nodes;

Console.WriteLine("fetching quote");

using (HttpClient client = new HttpClient())
{
    using (HttpResponseMessage res = await client.GetAsync("https://animechan.vercel.app/api/random"))
    {
        using (HttpContent content = res.Content)
        {
            var data = await content.ReadAsStringAsync();

            if (content == null)
            {
                Console.WriteLine("failed to fetch data");
            }

            JsonNode quoteData = JsonObject.Parse(data);

            if (quoteData == null)
            {
                return;
            }
    
            Console.WriteLine($"character: {quoteData["character"]}\nquote:{quoteData["quote"]}");
            

        }
    }
}