using UnityEngine;

namespace HaKoLibrary.Pooling
{
    public class PoolObject : MonoBehaviour
    {
        public PoolContainer PoolContainer { get; set; }

        public virtual void Return()
        {
            PoolContainer.Return(this);
        }
    }
}
