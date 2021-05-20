using System.Collections.Generic;
using System.Linq;
using Godot;

public abstract class FileGrabber
{
  public static List<string> GetFiles(string folder)
  {
    var files = new List<string>();
    var directory = new Directory();
    directory.Open(folder);
    directory.ListDirBegin();
    while (true)
    {
      var file = directory.GetNext();
      if (!string.IsNullOrEmpty(file))
      {
        if (file.BeginsWith(".") || file.EndsWith(".import"))
        {
          continue;
        }
        files.Add(folder + file);
      }
      else
      {
        break;
      }
    }

    return files;
  }
}
