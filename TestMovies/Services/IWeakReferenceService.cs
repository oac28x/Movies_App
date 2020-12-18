using System;
namespace TestMovies.Services
{
    public interface IWeakReferenceService
    {
        IWeakReferenceService Subscribe<T>(EventHandler<T> callback) where T : EventArgs;
        void Handler<T>(object sender, T e) where T : EventArgs;
    }
}
