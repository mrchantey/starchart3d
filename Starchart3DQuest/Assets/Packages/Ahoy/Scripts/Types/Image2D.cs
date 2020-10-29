using System;
using UnityEngine;

namespace Ahoy
{




    public struct Image2D : IEquatable<Image2D>
    {


        public int width;
        public int height;
        public Color[] pixels;

        public bool Equals(Image2D other)
        {
            return width.Equals(other.width)
            && height.Equals(other.height)
            && pixels.ElementsAreEqual(other.pixels);
        }
    }
}