



using UnityEngine;

namespace Ahoy
{

    public class ImageToTexture2D : MonoBehaviour
    {
        public Texture2D tex;
        public bool debug;

        public void Set(Image2D image)
        {
            if (debug)
                Debug.Log($"Image To Texture2D - setting texture");
            if (tex.width != image.width || tex.height != image.height)
                tex.Resize(image.width, image.height);
            tex.SetPixels(image.pixels);
            tex.Apply();
        }

    }

}