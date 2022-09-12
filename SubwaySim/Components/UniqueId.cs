using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SubwaySim.Components
{
    public struct UniqueId
    {
        public ulong Id { get; private init; }

        public UniqueId()
        {
            long i = Random.Shared.NextInt64(long.MinValue, long.MaxValue);
            Id = Unsafe.As<long, ulong>(ref i);
        }
        
        internal UniqueId(ulong value)
        {
            Id = value;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public static bool operator ==(UniqueId a, UniqueId b) => a.Id == b.Id;
        
        public static bool operator !=(UniqueId a, UniqueId b) => a.Id != b.Id;
    }

    public class UniqueIdJsonConverter : JsonConverter<UniqueId>
    {
        public override UniqueId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new UniqueId(reader.GetUInt64());
        }

        public override void Write(Utf8JsonWriter writer, UniqueId value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.ToString());
        }
    }

    public class DictionaryUniqueIdJsonConverter<T> : JsonConverter<Dictionary<UniqueId, T>>
    {
        public override Dictionary<UniqueId, T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dict = new Dictionary<UniqueId, T>();
            foreach (var v in JsonSerializer.Deserialize<Dictionary<ulong, T>>(ref reader, options) ?? new Dictionary<ulong, T>())
            {
                dict.Add(new UniqueId(v.Key), v.Value);
            }
            
            return dict;
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<UniqueId, T> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var v in value)
            {
                writer.WritePropertyName(v.Key.ToString());
                JsonSerializer.Serialize(writer, v.Value, options);
            }
            writer.WriteEndObject();
        }
    }
}