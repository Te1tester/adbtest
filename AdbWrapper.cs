using System;
using System.Diagnostics;
using System.IO;

class AdbWrapper {
    static void Main(string[] args) {
        string logLine = $"{DateTime.Now}: adb {string.Join(" ", args)}";
        File.AppendAllText("C:\\android\\platform-tools\\log\\adb_log.txt", logLine + Environment.NewLine);

        Process adb = new Process();
        adb.StartInfo.FileName = "adb_real.exe";
        adb.StartInfo.Arguments = string.Join(" ", args);
        adb.StartInfo.UseShellExecute = false;
        adb.StartInfo.RedirectStandardOutput = true;
        adb.StartInfo.RedirectStandardError = true;

        adb.Start();
        Console.Write(adb.StandardOutput.ReadToEnd());
        Console.Error.Write(adb.StandardError.ReadToEnd());
        adb.WaitForExit();
        Environment.Exit(adb.ExitCode);
    }
}
