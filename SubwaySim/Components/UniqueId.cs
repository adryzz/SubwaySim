using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SubwaySim.Components
{
    public struct UniqueId
    {
        public ulong Id { get; private init; }

        internal static UniqueId FromValue(ulong value)
        {
            return new UniqueId { Id = value };
        }
        
        public static UniqueId CreateNew()
        {
            long i = Random.Shared.NextInt64(long.MinValue, long.MaxValue);
            return FromValue(Unsafe.As<long, ulong>(ref i));
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public static bool operator ==(UniqueId a, UniqueId b) => a.Id == b.Id;
        
        public static bool operator !=(UniqueId a, UniqueId b) => a.Id != b.Id;
    }

    public class DictionaryUniqueIdJsonConverter<T> : JsonConverter<Dictionary<UniqueId, T>>
    {
        public override Dictionary<UniqueId, T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dict = new Dictionary<UniqueId, T>();

            return dict;
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<UniqueId, T> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var v in value)
            {
                writer.WritePropertyName(v.Key.ToString());
                writer.WriteNumberValue(69);
            }
            writer.WriteEndObject();
        }
    }
}