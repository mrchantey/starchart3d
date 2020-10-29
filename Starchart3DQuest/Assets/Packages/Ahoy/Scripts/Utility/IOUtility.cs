using System.IO;
using System.Linq;

namespace Ahoy
{

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
        public static int SafeIntParse(string str)
        {
            return str == "" ? 0 : int.Parse(str);
        }
        public static float SafeFloatParse(string str)
        {
            return str == "" ? 0 : float.Parse(str);
        }

    }

}
