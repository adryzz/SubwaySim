using SkiaSharp;
using SubwaySim.Extensions;

namespace SubwaySim
{
    public partial class SubwayEngine
    {
        private const int StationInnerRadius = 30;

        private const int StationOuterRadius = 50;

        private const int LineWidth = StationOuterRadius;

        private const int TextSize = 30;
        public void Render()
        {
            SKBitmap bitmap = new SKBitmap((int)Width, (int)Height);
            SKCanvas canvas = new SKCanvas(bitmap);
            
            // Draw all the lines
            foreach (var line in _lines.Values)
            {
                foreach (var pair in line.Stations)
                {
                    var first = _stations[pair.Item1];
                    var second = _stations[pair.Item2];
                    canvas.DrawLine(first.Position.ToSKPoint(), second.Position.ToSKPoint(), line.LineColor.ToSKPaint(LineWidth));
                }
            }
            
            // Draw all the stations
            foreach(var station in _stations.Values)
            {
                canvas.DrawCircle(station.Position.ToSKPoint(), StationOuterRadius, SKColors.Black.ToSKPaint());
                canvas.DrawCircle(station.Position.ToSKPoint(), StationInnerRadius, SKColors.White.ToSKPaint());
                canvas.DrawText(station.Name, new SKPoint(station.Position.X + StationOuterRadius*1.5f, station.Position.Y + TextSize), SKColors.Black.ToSKPaint(TextSize*2f));
            }

            // Draw all the trains
            
            // Save
            canvas.Flush();
            FileStream stream = File.OpenWrite("subway.png");
            bitmap.Encode(stream, SKEncodedImageFormat.Png, Int32.MaxValue);
            stream.Flush();
            stream.Close();
        }
    }
}