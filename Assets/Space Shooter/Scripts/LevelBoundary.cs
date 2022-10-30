using UnityEngine;

namespace SpaceShooter
{

    /// <summary>
    /// Класс для границ уровня
    /// </summary>
    public class LevelBoundary : SingletonBase<LevelBoundary>
    {
        /// <summary>
        /// Радиус
        /// </summary>
        [SerializeField] private float m_Radius;
        public float Radius => m_Radius;

        /// <summary>
        /// Тип границ. Limit - жёсткие границы, Teleport - телепорт в противоположную сторону
        /// </summary>
        public enum Mode
        {
            Limit,
            Teleport
        }

        /// <summary>
        /// Текущий тип границ уровня
        /// </summary>
        [SerializeField] private Mode m_LimitMode;
        public Mode LimitMode => m_LimitMode;

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, m_Radius);
        }
#endif

    }
}