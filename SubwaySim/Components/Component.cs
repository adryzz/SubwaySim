using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SubwaySim.Components
{
    public abstract class Component
    {
        protected Component()
        {
            Engine = Program.Engine;
            long i = Random.Shared.NextInt64(long.MinValue, long.MaxValue);
            Id = Unsafe.As<long, ulong>(ref i);
        }

        internal void RegenerateId()
        {
            long i = Random.Shared.NextInt64(long.MinValue, long.MaxValue);
            Id = Unsafe.As<long, ulong>(ref i);
        }
        
        public ulong Id { get; private set; }
        
        [JsonIgnore]
        public SubwayEngine Engine { get; }
    }
}