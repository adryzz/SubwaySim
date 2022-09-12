using System.Runtime.CompilerServices;

namespace SubwaySim.Components
{
    public struct UniqueId
    {
        public ulong Id { get; private init; }

        internal static UniqueId FromValue(ulong value)
        {
            return new UniqueId { Id = value };
        }
        
        public static UniqueId CreateNew()
        {
            long i = Random.Shared.NextInt64(long.MinValue, long.MaxValue);
            return FromValue(Unsafe.As<long, ulong>(ref i));
        }

        public static bool operator ==(UniqueId a, UniqueId b) => a.Id == b.Id;
        
        public static bool operator !=(UniqueId a, UniqueId b) => a.Id != b.Id;
    }
}