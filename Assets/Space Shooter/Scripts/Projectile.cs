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

        /// <summary>
        /// Признак самонаведения
        /// </summary>
        [SerializeField] private bool m_IsHoming;

        /// <summary>
        /// Цель самонаведения
        /// </summary>
        private Destructible m_HomingTarget;

        #region Unity Events

        private void Update()
        {
            m_Timer += Time.deltaTime;

            if (m_Timer > m_LifeTime)
            {
                Destroy(gameObject);
            }

            float stepLength = m_Velocity * Time.deltaTime;
            Vector2 step;
            
            if (m_IsHoming && m_HomingTarget != null)
            {
                step = (m_HomingTarget.transform.position - transform.position).normalized * stepLength;
            }
            else
            {
                step = transform.up * stepLength;
            }

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLength);

            if (hit)
            {
                Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();

                if (dest != null && dest != m_Parent)
                {
                    dest.ApplyDamage(m_Damage);

                    if (m_Parent == Player.Instance.ActiveShip)
                    {
                        Player.Instance.AddScore(dest.ScoreValue);
                    }
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

            if (m_IsHoming)
            {
                m_HomingTarget = FindNearestDestructibleTarget(parent.GetComponent<SpaceShip>());
            }
        }

        #endregion

        /// <summary>
        /// Действие при конце жизни снаряда
        /// </summary>
        /// <param name="col">Коллайдер</param>
        /// <param name="pos">Позиция</param>
        private void OnProjectileLifeEnd(Collider2D col, Vector2 pos)
        {
            Instantiate(m_ImpactEffectPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        /// <summary>
        /// Поиск ближайшего корабля
        /// </summary>
        /// <param name="spaceShip">Корабль, запустивший снаряд</param>
        /// <returns></returns>
        private Destructible FindNearestDestructibleTarget(SpaceShip spaceShip)
        {
            float maxDistance = float.MaxValue;
            Destructible potencialTarget = null;

            foreach (var destructible in FindObjectsOfType<Destructible>())
            {
                if (destructible.GetComponent<SpaceShip>() == spaceShip) continue;

                float dist = Vector2.Distance(spaceShip.transform.position, destructible.transform.position);

                if (dist < maxDistance)
                {
                    maxDistance = dist;
                    potencialTarget = destructible;
                }
            }

            return potencialTarget;
        }
    }
}