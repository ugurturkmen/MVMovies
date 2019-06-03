using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.LogManagement
{
    public interface ILogger
    {
        void add(string logConfigFile, string message);
    }
}
