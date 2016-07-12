using System.Diagnostics;

namespace ZhuifengLib.ProcessControl
{
    public class Process_Control
    {
        /// <summary>
        /// 结束进程
        /// </summary>
        /// <param name="_ProcessName">进程名称</param>
        /// <returns></returns>
        public bool kill_Process(string processName)
        {
            var process = Process.GetProcessesByName(processName);
            foreach (var p in process)
            {
                if (!string.IsNullOrEmpty(processName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
            return true;
        }
    }
}
