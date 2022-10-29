using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotbollsStatReworkedOOP
{
    internal class Handler
    {
        public void Save() //sprarar listan med lagen.
        {

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(@"teamstats.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Program.lagLista);
            }

        }

        public void Load() //laddar in datan  / objekt från listan med lag. lagList
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;


            using (StreamReader file = File.OpenText(@"teamstats.json"))
            {
                Program.lagLista = JsonConvert.DeserializeObject<List<Lag>>(File.ReadAllText(@"teamstats.json"));
                serializer = new JsonSerializer();
                Program.lagLista = (List<Lag>)serializer.Deserialize(file, typeof(List<Lag>));
            }

        }
    }
}
