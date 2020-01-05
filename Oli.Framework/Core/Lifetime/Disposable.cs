using System;

namespace Oli.Framework.Core.Lifetime
{
    public abstract class Disposable : IDisposable
    {
        // Flag: Has Dispose already been called?
        private bool _disposed;


        // Public implementation of Dispose pattern callable by consumers.

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Disposable()
        {
            Dispose(false);
        }

        // Protected implementation of Dispose pattern.

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                DisposeCore();
            }

            // Free any unmanaged objects here.
            _disposed = true;
        }

        protected abstract void DisposeCore();
    }
}