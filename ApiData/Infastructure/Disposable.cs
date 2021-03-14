using System;
using System.Collections.Generic;
using System.Text;

namespace ApiData.Infastructure
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
           if(!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeCore()
        {

        }
    }
}
