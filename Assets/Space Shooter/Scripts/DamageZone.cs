using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceShooter
{
    /// <summary>
    /// ���� ��������� �����
    /// </summary>
    [RequireComponent(typeof(CircleCollider2D))]
    public class DamageZone : MonoBehaviour
    {
        /// <summary>
        /// ����
        /// </summary>
        [SerializeField] private int m_Damage;

        /// <summary>
        /// ������
        /// </summary>
        [SerializeField] private float m_Radius;

        #region Unity Events

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destructible dest = other.transform.root.GetComponent<Destructible>();
            
            if (dest != null)
            {
                dest.ApplyDamage(m_Damage);
            }

            GetComponent<CircleCollider2D>().enabled = false;
        }

        #endregion

#if UNITY_EDITOR
        /// <summary>
        /// ���� �����
        /// </summary>
        private static Color GizmoColor = new Color(0, 1, 0, 0.3f);

        private void OnDrawGizmosSelected()
        {
            Handles.color = GizmoColor;
            Handles.DrawSolidDisc(transform.position, transform.forward, m_Radius);
        }

        private void OnValidate()
        {
            GetComponent<CircleCollider2D>().radius = m_Radius;
        }
#endif

    }
}