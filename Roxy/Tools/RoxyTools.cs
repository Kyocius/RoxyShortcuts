using System.Diagnostics;
using System;
using System.IO;
using IWshRuntimeLibrary;

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

    public static void CreateShortcut(string directory, string shortcutName, string targetPath,
        string description = null, string iconLocation = null)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var shortcutPath = Path.Combine(directory, string.Format($"{shortcutName}.lnk"));
        var shell = new WshShell();
        
        var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
        shortcut.TargetPath = targetPath;
        shortcut.Description = description;
        shortcut.IconLocation = string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation;
        shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
        shortcut.Save();
    }
}