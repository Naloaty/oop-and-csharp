using System;

namespace Lab4
{
    public abstract class BaseTransport : IDisposable
    {
        public virtual void WorkDone() { }
        public abstract void ProcessTargetItem(TargetItem item);
        public virtual void Dispose() { }
    }
}
