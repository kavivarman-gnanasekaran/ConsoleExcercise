using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace JsonReader
{
    public  class JsonRead

    {
        public void program()
        {
            string filepath = "C:\\Users\\Anaiyaan\\Downloads\\jsonread.json";
            string Json = File.ReadAllText(filepath);
            List<Forecast> Result = JsonConvert.DeserializeObject<List<Forecast>>(Json);
            foreach(var source in Result)
            {
                Console.WriteLine($"date:{source.date},summary:{source.summary},temperatureC:{source.temperatureC},temperatureF:{source.temperatureF}");
            }
        }

    }
}
