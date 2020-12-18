using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using TestMovies.Services;

namespace TestMovies.Utils
{
    //[DebuggerNonUserCode]
    public sealed class WeakEventHandler : IWeakReferenceService
    {
        private WeakReference _targetReference;
        private MethodInfo _method;

        public WeakEventHandler() { }

        //[DebuggerNonUserCode]
        public void Handler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs
        {
            var target = _targetReference.Target;
            if (target != null)
            {
                var callback = (Action<object, TEventArgs>)Delegate.CreateDelegate(typeof(Action<object, TEventArgs>), target, _method, true);
                if (callback != null)
                {
                    callback(sender, e);
                }
            }
        }

        public IWeakReferenceService Subscribe<TEventArgs>(EventHandler<TEventArgs> callback) where TEventArgs : EventArgs
        {
            _method = callback.Method;
            _targetReference = new WeakReference(callback.Target, true);
            return this;
        }
    }


    //public class Test
    //{
    //    public event PropertyChangedEventHandler eventx;

    //    public Test()
    //    {

    //    }

    //    public void execute()
    //    {
    //        eventx?.Invoke(this, null);
    //    }
    //}

    //public class Test2
    //{
    //    public Test2()
    //    {
    //        Test tst = new Test();
    //        WeakEventHandler eh = new WeakEventHandler();

    //        tst.eventx += eh.Subscribe<EventArgs>(Tst_eventx).Handler;
    //    }

    //    private void Tst_eventx(object sender, EventArgs e)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
