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

        internal void RegenerateId() => Id = new UniqueId();

        public UniqueId Id { get; internal set; }
        
        [JsonIgnore]
        public SubwayEngine Engine { get; }
    }
}