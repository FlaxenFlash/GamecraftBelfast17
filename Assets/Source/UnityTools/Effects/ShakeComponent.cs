using Assets.Source.Tools;
using UnityEngine;

namespace Assets.Source.Effects
{
    public class ShakeComponent : BaseComponent
    {
        private ShakeController _shakeController = new ShakeController();

        public GameObject Target;

        public float Magnitude;
        public bool Continuous;
        public float FadeOutTime;
        public bool UseScaledTime;

        public ShakeSettings ShakeSettings;

        public override void Awake()
        {
            base.Awake();
            enabled = true;
        }

        public void OnEnable()
        {
            StartCoroutine(ShakeExtensions.Shake(Target, _shakeController, ShakeSettings));
        }

        public void Update()
        {
            _shakeController.Magnitude = Magnitude;
            _shakeController.Continuous = Continuous;
            _shakeController.FadeOutTime = FadeOutTime;
            _shakeController.UseScaledTime = UseScaledTime;
        }
    }
}
