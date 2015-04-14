using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherCheck.Models
{

    public class Location
    {

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }
    }

    public class Units
    {

        [JsonProperty("distance")]
        public string Distance { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("temperature")]
        public string Temperature { get; set; }
    }

    public class Wind
    {

        [JsonProperty("chill")]
        public string Chill { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }
    }

    public class Atmosphere
    {

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("rising")]
        public string Rising { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }
    }

    public class Astronomy
    {

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }

    public class Image
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Condition
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("temp")]
        public string Temp { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Forecast
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Guid
    {

        [JsonProperty("isPermaLink")]
        public string IsPermaLink { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class Item
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("pubDate")]
        public string PubDate { get; set; }

        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("forecast")]
        public IList<Forecast> Forecast { get; set; }

        [JsonProperty("guid")]
        public Guid Guid { get; set; }
    }

    public class Channel
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lastBuildDate")]
        public string LastBuildDate { get; set; }

        [JsonProperty("ttl")]
        public string Ttl { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("units")]
        public Units Units { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("atmosphere")]
        public Atmosphere Atmosphere { get; set; }

        [JsonProperty("astronomy")]
        public Astronomy Astronomy { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }
    }

    public class Results
    {

        [JsonProperty("channel")]
        public Channel Channel { get; set; }
    }

    public class Query
    {

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("results")]
        public Results Results { get; set; }
    }

    public class YahooWeather
    {

        [JsonProperty("query")]
        public Query Query { get; set; }
    }


}
