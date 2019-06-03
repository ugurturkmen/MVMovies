using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace MVMovies.LogManagement
{
    public class Logger : ILogger
    {
        private readonly ILog _log;
        private ILoggerRepository _loggerRepository;
        /// <summary>
        /// Dışarıdan gelen talebe göre log oluşturuluyor.
        /// Ayarları, dışarıdan gelen dosyaya göre belirleniyor.
        /// </summary>
        public void add(string logConfigFile, string message)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(logConfigFile));

            _loggerRepository = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(_loggerRepository, log4netConfig["log4net"]);

            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Logger));

            log.Info(message);

        }
    }
}
