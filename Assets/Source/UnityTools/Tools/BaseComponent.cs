using Assets.Source.Messaging;
using Assets.Source.Tools.UnityInterfaces;
using UnityEngine;

namespace Assets.Source.Tools
{
    public class BaseComponent : MonoBehaviour, IAwake, IDestroy
    {
        public virtual void Awake()
        {
            MessagingCenter.RegisterReceiver(this);
        }

        public virtual void OnDestroy()
        {
            MessagingCenter.DeregisterReceiver(this);
        }
    }
}
