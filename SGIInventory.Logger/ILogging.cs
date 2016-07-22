using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGIInventory.Logger
{
    public interface ILogging
    {
        void LogError(string source, Exception ex);
    }
}
