using System.Numerics;
using SkiaSharp;
using SubwaySim.Components.Basic;
using SubwaySim.Extensions;

namespace SubwaySim
{
    public partial class SubwayEngine
    {
        public double TimeScale { get; set; } = 1;

        public uint Width => 4096;
        
        public uint Height => 4096;
        
        public IDictionary<ulong, TrainLine> Lines { get; protected set; }

        private IDictionary<ulong, TrainLine> _lines = new Dictionary<ulong, TrainLine>();

        public IDictionary<ulong, TrainStation> Stations { get; protected set; }
        
        private IDictionary<ulong, TrainStation> _stations = new Dictionary<ulong, TrainStation>();
        
        public IDictionary<ulong, Train> Trains { get; protected set; }
        
        private IDictionary<ulong, Train> _trains = new Dictionary<ulong, Train>();

        public void Tick()
        {

        }
    }
}