using System.IO;
using System.Linq;



public static class IOUtility
{

    public static string[] OpenLines(string filePath)
    {
        filePath = filePath.Replace(@"\", @"/");
        return File
              .ReadAllLines(filePath)
              .Select(l => l.Trim())
              .Where(l => !System.String.IsNullOrEmpty(l))
              .ToArray();
    }
}



