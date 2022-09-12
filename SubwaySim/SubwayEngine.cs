using System.Numerics;
using System.Text.Json.Serialization;
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
        
        [JsonConverter(typeof(DictionaryUniqueIdJsonConverter<TrainLine>))]
        public Dictionary<UniqueId, TrainLine> Lines { get; protected set; } = new Dictionary<UniqueId, TrainLine>();

        [JsonConverter(typeof(DictionaryUniqueIdJsonConverter<TrainStation>))]
        public Dictionary<UniqueId, TrainStation> Stations { get; protected set; } = new Dictionary<UniqueId, TrainStation>();

        [JsonConverter(typeof(DictionaryUniqueIdJsonConverter<Train>))]
        public Dictionary<UniqueId, Train> Trains { get; protected set; } = new Dictionary<UniqueId, Train>();
        
        public void Tick()
        {

        }
    }
}