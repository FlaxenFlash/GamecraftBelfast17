using UnityEngine;

namespace Assets.Source.Tools.UnityInterfaces
{
    public interface ICollisionEnter
    {
        void OnCollisionEnter(Collision collision);
    }
    public interface ICollisionStay
    {
        void OnCollisionStay(Collision collision);
    }
    public interface ICollisionExit
    {
        void OnCollisionExit(Collision collision);
    }
}