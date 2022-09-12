using System.Text.Json.Serialization;
using SkiaSharp;

namespace SubwaySim.Components.Basic
{
    public class TrainLine : Component
    {
        public virtual LineLayout Layout => LineLayout.Linear;

        public virtual LineStatus Status { get; set; } = LineStatus.Forward;

        public virtual SKColor LineColor { get; init; } = SKColors.Green;
        
        public virtual List<(UniqueId, UniqueId)> Links { get; init; } = new List<(UniqueId, UniqueId)>();

        [JsonIgnore]
        public virtual List<UniqueId> Trains { get; set; } = new List<UniqueId>();

        public enum LineLayout
        {
            Linear,
            Circular
        }

        [Flags]
        public enum LineStatus
        {
            Forward,
            Backward,
            Stalled,
            Error
        }
    }
}