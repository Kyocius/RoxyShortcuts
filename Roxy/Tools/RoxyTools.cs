using System.Diagnostics;
using System;

namespace Roxy.Tools;

public class RoxyTools
{
    public static void OpenExplorer(string path)
    {
        var p = new Process();
        p.StartInfo.FileName = "explorer.exe";
        p.StartInfo.Arguments = path;
        p.Start();
    }

    public static string GetStartMenuPath()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
        return path;
    }
}