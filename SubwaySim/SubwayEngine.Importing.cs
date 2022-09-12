using System.Text.Json;
using SubwaySim.Components;
using SubwaySim.Components.Basic;

namespace SubwaySim
{
    public partial class SubwayEngine
    {
        public void Import(string path)
        {
            Lines = JsonSerializer.Deserialize<Dictionary<UniqueId, TrainLine>>(
                File.ReadAllText(Path.Combine(path, "lines.json"))) ?? new Dictionary<UniqueId, TrainLine>();

            Stations =
                JsonSerializer.Deserialize<Dictionary<UniqueId, TrainStation>>(
                    File.ReadAllText(Path.Combine(path, "stations.json"))) ?? new Dictionary<UniqueId, TrainStation>();
            
            Trains = JsonSerializer.Deserialize<Dictionary<UniqueId, Train>>(
                File.ReadAllText(Path.Combine(path, "trains.json"))) ?? new Dictionary<UniqueId, Train>();
        }
        
        public void Export(string path)
        {
            File.WriteAllText(Path.Combine(path, "lines.json"), JsonSerializer.Serialize(Lines, new JsonSerializerOptions{ WriteIndented = true }));
            
            File.WriteAllText(Path.Combine(path, "stations.json"), JsonSerializer.Serialize(Stations, new JsonSerializerOptions{ WriteIndented = true }));
            
            File.WriteAllText(Path.Combine(path, "trains.json"), JsonSerializer.Serialize(Trains, new JsonSerializerOptions{ WriteIndented = true }));
        }

    }
}