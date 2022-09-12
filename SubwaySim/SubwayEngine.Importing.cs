using System.Text.Json;
using SubwaySim.Components;
using SubwaySim.Components.Basic;
using SubwaySim.Extensions;

namespace SubwaySim
{
    public partial class SubwayEngine
    {
        public void Import(string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
            options.Converters.Add(new DictionaryUniqueIdJsonConverter<TrainLine>());
            options.Converters.Add(new DictionaryUniqueIdJsonConverter<TrainStation>());
            options.Converters.Add(new DictionaryUniqueIdJsonConverter<Train>());
            options.Converters.Add(new UniqueIdJsonConverter());
            options.Converters.Add(new SKColorJsonConverter());
            
            Lines = JsonSerializer.Deserialize<Dictionary<UniqueId, TrainLine>>(
                File.ReadAllText(Path.Combine(path, "lines.json")), options) ?? new Dictionary<UniqueId, TrainLine>();

            Stations =
                JsonSerializer.Deserialize<Dictionary<UniqueId, TrainStation>>(
                    File.ReadAllText(Path.Combine(path, "stations.json")), options) ?? new Dictionary<UniqueId, TrainStation>();
            
            Trains = JsonSerializer.Deserialize<Dictionary<UniqueId, Train>>(
                File.ReadAllText(Path.Combine(path, "trains.json")), options) ?? new Dictionary<UniqueId, Train>();
        }
        
        public void Export(string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
            options.Converters.Add(new DictionaryUniqueIdJsonConverter<TrainLine>());
            options.Converters.Add(new DictionaryUniqueIdJsonConverter<TrainStation>());
            options.Converters.Add(new DictionaryUniqueIdJsonConverter<Train>());
            options.Converters.Add(new UniqueIdJsonConverter());
            options.Converters.Add(new SKColorJsonConverter());
            
            File.WriteAllText(Path.Combine(path, "lines.json"), JsonSerializer.Serialize(Lines, options));
            
            File.WriteAllText(Path.Combine(path, "stations.json"), JsonSerializer.Serialize(Stations, options));
            
            File.WriteAllText(Path.Combine(path, "trains.json"), JsonSerializer.Serialize(Trains, options));
        }

    }
}