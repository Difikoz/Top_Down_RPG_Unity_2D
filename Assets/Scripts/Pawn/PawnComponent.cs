using UnityEngine;

namespace WinterUniverse
{
    public abstract class PawnComponent : MonoBehaviour
    {
        protected PawnController _pawn;

        public virtual void Initialize()
        {
            _pawn = GetComponent<PawnController>();
        }

        public virtual void Enable()
        {

        }

        public virtual void Disable()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }
    }
}