using SubwaySim.Components;

namespace SubwaySim.Extensions
{
    public static class DictionaryExtensions
    {
        public static void Add<T>(this IDictionary<ulong, T> dict, T item) where T : Component
        {
            dict.Add(item.Id, item);
        }
        
        public static void Add<T>(this List<(ulong, ulong)> dict, T item1, T item2) where T : Component
        {
            dict.Add((item1.Id, item2.Id));
        }
    }
}