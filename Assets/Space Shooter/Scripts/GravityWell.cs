using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    /// <summary>
    /// ����� ��������������� �������
    /// </summary>
    public class GravityWell : MonoBehaviour
    {
        /// <summary>
        /// ���� ����������
        /// </summary>
        [SerializeField] private float m_Force;

        /// <summary>
        /// ������ �������� ��� ����������
        /// </summary>
        [SerializeField] private float m_Radius;

        #region Unity Events

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.attachedRigidbody == null) return;

            Vector2 dir = transform.position - collision.transform.position;

            float dist = dir.magnitude;

            if (dist < m_Radius)
            {
                Vector2 force = dir.normalized * m_Force * (dist / m_Radius);
                collision.attachedRigidbody.AddForce(force, ForceMode2D.Force);
            }
        }

        #endregion

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetComponent<CircleCollider2D>().radius = m_Radius;
        }
#endif
    }
}