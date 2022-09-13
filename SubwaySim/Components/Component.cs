using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SubwaySim.Components
{
    public abstract class Component
    {
        protected Component()
        {
            Engine = Program.Engine;

            if (Id == UniqueId.Null)
            {
                RegenerateId();
            }
        }

        internal void RegenerateId() => Id = new UniqueId();

        [JsonConverter(typeof(UniqueIdJsonConverter))]
        [JsonInclude]
        public UniqueId Id { get; internal set; }
        
        [JsonIgnore]
        public SubwayEngine Engine { get; }
    }
}