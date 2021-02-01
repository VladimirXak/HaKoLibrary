using UnityEngine;

namespace HaKoLibrary.Common
{
    public abstract class MonoBehaviourCached : MonoBehaviour
    {
        protected Transform _cachedTransform;

        public new Transform transform
        {
            get
            {
                if ((object)_cachedTransform == null)
                    _cachedTransform = base.transform;

                return _cachedTransform;
            }
        }

        protected virtual void Awake()
        {
            if ((object)_cachedTransform == null)
                _cachedTransform = base.transform;
        }
    }
}
