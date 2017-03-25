using UnityEngine;

namespace Assets.Source.Tools
{
    public class SetTargetFramerate : BaseComponent
    {
        public int Framerate;

        public void Update()
        {
            if (Framerate == 0) return;
            Application.targetFrameRate = Framerate;
        }
    }
}
