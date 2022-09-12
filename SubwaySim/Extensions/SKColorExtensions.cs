using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
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

    public class SKColorJsonConverter : JsonConverter<SKColor>
    {
        public override SKColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new SKColor(uint.Parse(reader.GetString()?[1..] ?? "0", NumberStyles.HexNumber));
        }

        public override void Write(Utf8JsonWriter writer, SKColor value, JsonSerializerOptions options)
        {
            writer.WriteRawValue($"\"#{value.Alpha:X2}{value.Red:X2}{value.Green:X2}{value.Blue:X2}\"");
        }
    }
}