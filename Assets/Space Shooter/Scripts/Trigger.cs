using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// Точка назначения. Выдаёт событие при достижении её игроком.
    /// </summary>
    public class Trigger : MonoBehaviour
    {
        /// <summary>
        /// Событие при достижении точки
        /// </summary>
        [SerializeField] private UnityEvent m_Enter;
        public UnityEvent Enter => m_Enter;

        #region Unity Events

        private void OnTriggerEnter2D(Collider2D collision)
        {
            m_Enter.Invoke();
        }

        #endregion
    }
}