using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс нанесения урона при столкновении
    /// </summary>
    public class CollisionDamageApplicator : MonoBehaviour
    {
        /// <summary>
        /// Тег объектов, с которыми не будут учитываться столкновения
        /// </summary>
        public static string IgnoreTag = "WorldBoundary";

        /// <summary>
        /// Модификатор урона, зависящий от скорости
        /// </summary>
        [SerializeField] private float m_VelocityDamageModifier;

        /// <summary>
        /// Урон от столкновения
        /// </summary>
        [SerializeField] private float m_DamageConstant;

        #region Unity Events

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == IgnoreTag) return;

            var destructible = transform.root.GetComponent<Destructible>();

            if (destructible != null)
            {
                destructible.ApplyDamage((int)m_DamageConstant + (int)(m_VelocityDamageModifier * collision.relativeVelocity.magnitude));
            }
        }

        #endregion
    }
}
