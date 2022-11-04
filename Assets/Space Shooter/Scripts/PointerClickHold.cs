using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SpaceShooter
{

    /// <summary>
    /// ����� �������� ��������� ��������� �� �������
    /// </summary>
    public class PointerClickHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        /// <summary>
        /// ��������� ������������ �� �������
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