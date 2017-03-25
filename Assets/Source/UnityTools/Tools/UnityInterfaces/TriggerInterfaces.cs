using UnityEngine;

namespace Assets.Source.Tools.UnityInterfaces
{
    public interface ITriggerEnter
    {
        void OnTriggerEnter(Collider other);
    }
    public interface ITriggerStay
    {
        void OnTriggerStay(Collider other);
    }
    public interface ITriggerExit
    {
        void OnTriggerExit(Collider other);
    }
}