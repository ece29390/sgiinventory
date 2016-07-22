using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory
{
    public class LogInEventArgs:EventArgs
    {
        public Model.User User { get; private set; }

        public LogInEventArgs(Model.User user)
        {
            User = user;
        }

    }
}
