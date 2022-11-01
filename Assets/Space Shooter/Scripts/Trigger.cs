using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// ����� ����������. ����� ������� ��� ���������� � �������.
    /// </summary>
    public class Trigger : MonoBehaviour
    {
        /// <summary>
        /// ������� ��� ���������� �����
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