using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SubwaySim.Components
{
    public abstract class Component
    {
        protected Component()
        {
            Engine = Program.Engine;
            RegenerateId();
        }

        internal void RegenerateId() => Id = UniqueId.CreateNew();

        public UniqueId Id { get; private set; }
        
        [JsonIgnore]
        public SubwayEngine Engine { get; }
    }
}