using BepInEx;
using BepInEx.Logging;
using System;
using System.IO;
using System.Text;

namespace WestAPI.Utilities;

public static class WestLog
{
    public static readonly string LogPath;

    public static bool EnableDebug = WestAPIMain.IsDebugMode;

    private static readonly object _lock = new();
    private static ManualLogSource _source;

    static WestLog()
    {
        try { _source = BepInEx.Logging.Logger.CreateLogSource("WestAPI"); }
        catch { }

        try
        {
            string dir = Path.Combine(Paths.GameRootPath, "Logs");
            Directory.CreateDirectory(dir);

            string stamp = DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss");
            LogPath = Path.Combine(dir, $"WestLog_{stamp}.log");

            using (new FileStream(LogPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) { }
        }
        catch
        { 
        }
    }

    public static void Debug(string msg) { if (EnableDebug) Write(LogLevel.Debug, msg); }
    public static void Info(string msg) => Write(LogLevel.Info, msg);
    public static void Warn(string msg) => Write(LogLevel.Warning, msg);
    public static void Error(string msg) => Write(LogLevel.Error, msg);

    public static void Error(Exception ex, string msg = null)
        => Write(LogLevel.Error, msg == null ? ex?.ToString() : $"{msg} | {ex}");

    private static void Write(LogLevel level, string message)
    {
        string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";

        if (!string.IsNullOrEmpty(LogPath))
        {
            lock (_lock)
            {
                try
                {
                    File.AppendAllText(LogPath, line + Environment.NewLine, Encoding.UTF8);
                }
                catch {  }
            }
        }

        try { _source?.Log(level, message); }
        catch { }
    }
}