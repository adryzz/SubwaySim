using System.Numerics;
using SkiaSharp;

namespace SubwaySim.Extensions
{
    public static class VectorExtensions
    {
        public static SKPoint ToSKPoint(this Vector2 v)
        {
            return new SKPoint(v.X, v.Y);
        }
    }
}