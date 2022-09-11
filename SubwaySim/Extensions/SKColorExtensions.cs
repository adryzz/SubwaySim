using SkiaSharp;

namespace SubwaySim.Extensions
{
    public static class SKColorExtensions
    {
        public static SKPaint ToSKPaint(this SKColor color)
        {
            return new SKPaint() { Color = color };
        }
        
        public static SKPaint ToSKPaint(this SKColor color, int strokeWidth)
        {
            return new SKPaint() { Color = color, StrokeWidth = strokeWidth };
        }
        
        public static SKPaint ToSKPaint(this SKColor color, float textSize)
        {
            return new SKPaint() { Color = color, TextSize = textSize};
        }
    }
}