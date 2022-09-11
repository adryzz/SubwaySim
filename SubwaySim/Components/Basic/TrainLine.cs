using SkiaSharp;

namespace SubwaySim.Components.Basic
{
    public class TrainLine : Component
    {
        public virtual LineLayout Layout => LineLayout.Linear;

        public virtual LineStatus Status { get; set; } = LineStatus.Forward;

        public virtual SKColor LineColor { get; init; } = SKColors.Green;

        public virtual List<(ulong, ulong)> Stations { get; } = new List<(ulong, ulong)>();

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