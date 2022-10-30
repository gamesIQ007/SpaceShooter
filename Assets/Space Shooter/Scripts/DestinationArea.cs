using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// Точка назначения. Выдаёт событие при достижении её игроком.
    /// </summary>
    public class DestinationArea : MonoBehaviour
    {
        /// <summary>
        /// Событие при достижении точки
        /// </summary>
        [SerializeField] private UnityEvent m_TargetReached;
        public UnityEvent TargetReached => m_TargetReached;

        #region Unity Events

        private void OnTriggerEnter2D(Collider2D collision)
        {
            m_TargetReached.Invoke();
        }

        #endregion
    }
}