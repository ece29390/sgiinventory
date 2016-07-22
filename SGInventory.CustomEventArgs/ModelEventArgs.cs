using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.CustomEventArgs
{
    public class ModelEventArgs<T>:EventArgs
    {
        public List<T> ModelList { get; private set; }

        public T Model { get; set; }

        public ModelEventArgs(List<T> modelList)
        {
            ModelList = modelList;
        }

        public ModelEventArgs(T model)
        {
            Model = model;
        }
    }
}
