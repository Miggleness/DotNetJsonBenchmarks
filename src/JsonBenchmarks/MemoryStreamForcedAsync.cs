using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JsonBenchmarks
{
    public class MemoryStreamForcedAsync : MemoryStream
    {
        public MemoryStreamForcedAsync () : base () { }

        public MemoryStreamForcedAsync (byte[] bytes) : base (bytes) { }

        public async override ValueTask<int> ReadAsync (Memory<byte> destination, CancellationToken cancellationToken = default)
        {
            await Task.Yield ();
            return await base.ReadAsync (destination, cancellationToken);
        }

        public async override Task<int> ReadAsync (byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await Task.Yield ();
            return await base.ReadAsync (buffer, offset, count, cancellationToken);
        }

        public async override Task WriteAsync (byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await Task.Yield ();
            await base.WriteAsync (buffer, offset, count, cancellationToken);
        }

        public async override ValueTask WriteAsync (ReadOnlyMemory<byte> source, CancellationToken cancellationToken = default)
        {
            await Task.Yield ();
            await base.WriteAsync (source, cancellationToken);
        }
    }
}