using UnityEngine;

namespace SpaceShooter
{

    /// <summary>
    /// Снаряд и его поведение
    /// </summary>
    public class Projectile : Entity
    {
        /// <summary>
        /// Скорость снаряда
        /// </summary>
        [SerializeField] private float m_Velocity;

        /// <summary>
        /// Время жизни
        /// </summary>
        [SerializeField] private float m_LifeTime;

        /// <summary>
        /// Урон
        /// </summary>
        [SerializeField] private int m_Damage;

        /// <summary>
        /// Префаб посмертного эффекта
        /// </summary>
        [SerializeField] private ImpactEffect m_ImpactEffectPrefab;

        /// <summary>
        /// Таймер
        /// </summary>
        private float m_Timer;

        /// <summary>
        /// Дестрактибл родителя
        /// </summary>
        private Destructible m_Parent;

        #region Unity Events

        private void Update()
        {
            m_Timer += Time.deltaTime;

            if (m_Timer > m_LifeTime)
            {
                Destroy(gameObject);
            }

            float stepLength = m_Velocity * Time.deltaTime;
            Vector2 step = transform.up * stepLength;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLength);

            if (hit)
            {
                Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();

                if (dest != null && dest != m_Parent)
                {
                    dest.ApplyDamage(m_Damage);
                }

                OnProjectileLifeEnd(hit.collider, hit.point);
            }

            transform.position += new Vector3(step.x, step.y, 0);
        }

        #endregion

        #region Public API

        /// <summary>
        /// Установить родителя проджектайла
        /// </summary>
        /// <param name="parent"></param>
        public void SetParentShooter(Destructible parent)
        {
            m_Parent = parent;
        }

        #endregion

        private void OnProjectileLifeEnd(Collider2D col, Vector2 pos)
        {
            Instantiate(m_ImpactEffectPrefab, transform);

            Destroy(gameObject);
        }
    }
}