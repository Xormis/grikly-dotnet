using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi.Converters
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class ErrorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
            // Load JObject from stream 
            JObject jObject = JObject.Load(reader);

            //if(jObject.GetValue("error") )
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
