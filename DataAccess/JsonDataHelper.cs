using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Newtonsoft.Json;

namespace DataAccess
{
    public class JsonDataHelper<T>
    {
        public List<T> ReadJsonFile(string path)
        {
            using (StreamReader reader = new StreamReader($"C:/Users/Barış/Desktop/HRDatabase/{path}.json"))
            {
                string json = reader.ReadToEnd();
                List<T> entities = JsonConvert.DeserializeObject<List<T>>(json);
                return entities;
            }
        }
    }
}
