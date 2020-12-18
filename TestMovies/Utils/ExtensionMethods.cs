using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace TestMovies.Utils
{
    public static class ExtensionMethods
    {
        public static void AddRange<T>(this ObservableCollection<T> oc, IEnumerable<T> toAdd)
        {
            if (oc == null) return;
            toAdd.ForEach(element => oc.Add(element));
        }
    }
}
