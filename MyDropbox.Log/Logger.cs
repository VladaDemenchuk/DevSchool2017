using NLog;

namespace MyDropbox.Log
{
    public static class Logger
    {
        public static NLog.Logger ServiceLog = LogManager.GetCurrentClassLogger();
    }
}
