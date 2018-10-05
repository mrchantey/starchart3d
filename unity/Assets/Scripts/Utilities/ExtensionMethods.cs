

using System.Collections.Generic;

public static class ExtensionMethods
{


    public static void ForEach<T>(this IEnumerable<T> source, System.Action<T> action)
    {
        foreach (var element in source)
        {
            action(element);
        }
    }


}