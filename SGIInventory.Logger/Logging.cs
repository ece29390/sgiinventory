using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace SGIInventory.Logger
{
    public class Logging : ILogging
    {
        private readonly ILog _log;
        public Logging()
        {
            _log = LogManager.GetLogger("SGIInventoryLogger");
        }

        public void LogError(string source, Exception ex)
        {
            _log.Error(source, ex);
        }
    }
}
