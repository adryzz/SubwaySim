using System.Numerics;
using SkiaSharp;
using SubwaySim.Components;
using SubwaySim.Components.Basic;
using SubwaySim.Extensions;

namespace SubwaySim
{
    public partial class SubwayEngine
    {
        public double TimeScale { get; set; } = 1;

        public uint Width => 4096;
        
        public uint Height => 4096;
        
        public IDictionary<UniqueId, TrainLine> Lines { get; protected set; } = new Dictionary<UniqueId, TrainLine>();

        public IDictionary<UniqueId, TrainStation> Stations { get; protected set; } = new Dictionary<UniqueId, TrainStation>();

        public IDictionary<UniqueId, Train> Trains { get; protected set; } = new Dictionary<UniqueId, Train>();

        public void Import()
        {
            
        }
        
        public void Tick()
        {
            
        }
    }
}