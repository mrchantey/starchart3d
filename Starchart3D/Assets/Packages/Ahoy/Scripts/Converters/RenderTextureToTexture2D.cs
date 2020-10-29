
using UnityEngine;

namespace Ahoy
{

    public class RenderTextureToTexture2D : InvocableMono
    {

        public RenderTexture tex;
        public Texture2DUnityEvent onInvoke;

        Texture2D buffTex;

        private void Awake()
        {
            buffTex = new Texture2D(255, 255);
        }

        public override void Invoke()
        {
            RenderTexture.active = tex;
            if (buffTex.width != tex.width || buffTex.height != tex.height)
                buffTex.Resize(tex.width, tex.height);
            buffTex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
            buffTex.Apply();
            RenderTexture.active = null;
            onInvoke.Invoke(buffTex);
        }

    }

}