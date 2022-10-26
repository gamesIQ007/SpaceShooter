using UnityEngine;

namespace SpaceShooter
{

    /// <summary>
    /// Класс для синхронизации положения объектов
    /// </summary>
    public class SyncTransform : MonoBehaviour
    {
        /// <summary>
        /// Цель синхронизации
        /// </summary>
        [SerializeField] private Transform m_Target;

        private void FixedUpdate()
        {
            transform.position = new Vector3(m_Target.position.x, m_Target.position.y, transform.position.z);
        }
    }
}