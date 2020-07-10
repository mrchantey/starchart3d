




public static class ParseUtility
{


    public static int SafeIntParse(string str)
    {
        return str == "" ? 0 : int.Parse(str);
    }
    public static float SafeFloatParse(string str)
    {
        return str == "" ? 0 : float.Parse(str);
    }



}