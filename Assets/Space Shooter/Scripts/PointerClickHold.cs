using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SpaceShooter
{

    /// <summary>
    /// Класс проверки удержания указателя на объекте
    /// </summary>
    public class PointerClickHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        /// <summary>
        /// Указатель удерживается на объекте
        /// </summary>
        private bool m_Hold;
        public bool IsHold => m_Hold;

        public void OnPointerDown(PointerEventData eventData)
        {
            m_Hold = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_Hold = false;
        }
    }
}