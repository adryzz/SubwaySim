using System.Numerics;

namespace SubwaySim.Components.Basic
{
    public class TrainStation : Component
    {
        public virtual uint PlatformCount => 2;

        public virtual string Name { get; set; } = $"Station";
        
        public virtual Vector2 Position { get; init; }
    }
}