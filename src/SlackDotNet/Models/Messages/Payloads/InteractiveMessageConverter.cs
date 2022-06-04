using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackDotNet.Enums;

namespace SlackDotNet.Models.Messages.Payloads
{
    public class InteractiveMessageConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JToken.ReadFrom(reader);
            var type = jObject["type"].ToObject<InteractiveMessageType>();

            var enumType = type.GetType();
            var name = EventsAPIType.GetName(enumType, type);

            if (name == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            var field = enumType.GetField(name);
            var attribute = Attribute.GetCustomAttribute(field, typeof(TypeAttribute)) as TypeAttribute;

            var payload = Activator.CreateInstance(attribute.ImplementingType);

            serializer.Populate(jObject.CreateReader(), payload);

            return payload;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
