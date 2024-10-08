using System.IO;
using NLog;

namespace Broom.Core;

public static class DeleteService
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    public static void RemovingReadOnlyAttributeFromFiles(string path)
    {
        if (!Directory.Exists(path))
        {
            Logger.Error($"Directory {path} does not exist");
            return;
        }

        var directory = new DirectoryInfo(path);
        directory.Attributes &= ~FileAttributes.ReadOnly;
        Logger.Info($"Set {directory.FullName} attributes to normal");

        var files = directory.GetFiles();
        foreach (var file in files)
        {
            file.Attributes = FileAttributes.Normal;
            Logger.Info($"Set {file.FullName} attributes to normal");
        }
    }

    public static void DeleteFiles(string path)
    {
        var directory = new DirectoryInfo(path);
        var files = directory.GetFiles();
        foreach (var file in files)
        {
            file.Delete();
            Logger.Info($"Delete {file.FullName}");
        }

        directory.Delete(recursive: true);//FIXME  ??? recursive ???
        Logger.Info($"Delete {directory.FullName}");
    }
}
