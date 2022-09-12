using System.Numerics;
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
        
        public Dictionary<UniqueId, TrainLine> Lines { get; protected set; } = new Dictionary<UniqueId, TrainLine>();
        
        public Dictionary<UniqueId, TrainStation> Stations { get; protected set; } = new Dictionary<UniqueId, TrainStation>();
        
        public Dictionary<UniqueId, Train> Trains { get; protected set; } = new Dictionary<UniqueId, Train>();
        
        public void Tick()
        {

        }
    }
}