using System.Numerics;

namespace SubwaySim.Components.Basic
{
    public class TrainStation : Component
    {
        public virtual uint PlatformCount => 2;

        public virtual string Name { get; set; } = $"Station";
        
        public virtual Vector2 Position { get; init; }

        public IEnumerable<TrainLine> Lines =>
            Engine.Lines.Values.Where(x => x.Links.Any(y => y.Item1 == Id || y.Item2 == Id));
    }
}