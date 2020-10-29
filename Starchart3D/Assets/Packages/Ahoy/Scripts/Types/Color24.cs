namespace Ahoy
{
    // [UsedByNativeCodeAttribute]
    public struct Color24
    {
        //
        // Summary:
        //     Red component of the color.
        public byte r;
        //
        // Summary:
        //     Green component of the color.
        public byte g;
        //
        // Summary:
        //     Blue component of the color.
        public byte b;

        //
        // Summary:
        //     Constructs a new Color24 with given r, g, b components.
        //
        // Parameters:
        //   r:
        //
        //   g:
        //
        //   b:
        //
        //   a:
        public Color24(byte _r, byte _g, byte _b)
        {
            r = _r;
            g = _g;
            b = _b;
        }

        public override string ToString()
        {
            return $"({r},{g},{b})";
        }

        // public static implicit operator Color24(Color c)
        // {
        //     return new Color24(c.r, c.g, c.b);
        // }
        // public static implicit operator Color(Color32 c);
    }
}