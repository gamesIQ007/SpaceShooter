using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Спавнер мусора
    /// </summary>
    public class EntitySpawnerDebris : MonoBehaviour
    {
        /// <summary>
        /// Префабы мусора
        /// </summary>
        [SerializeField] private Destructible[] m_DebrisPrefabs;

        /// <summary>
        /// Область спавна
        /// </summary>
        [SerializeField] private CircleArea m_Area;

        /// <summary>
        /// Количество мусора
        /// </summary>
        [SerializeField] private int m_NumDebris;

        /// <summary>
        /// Скорость
        /// </summary>
        [SerializeField] private float m_RandomSpeed;

        #region UnityEvents

        private void Start()
        {
            for (int i = 0; i < m_NumDebris; i++)
            {
                SpawnDebris();
            }
        }

        #endregion

        /// <summary>
        /// Спавн мусора
        /// </summary>
        private void SpawnDebris()
        {
            int index = Random.Range(0, m_DebrisPrefabs.Length);

            GameObject debris = Instantiate(m_DebrisPrefabs[index].gameObject);
            debris.transform.position = m_Area.GetRandomInsideZone();
            debris.GetComponent<Destructible>().EventOnDeath.AddListener(OnDebrisDead);

            Rigidbody2D rb = debris.GetComponent<Rigidbody2D>();

            if (rb != null && m_RandomSpeed > 0)
            {
                rb.velocity = Random.insideUnitCircle * m_RandomSpeed;
            }
        }

        /// <summary>
        /// Смерть мусора
        /// </summary>
        private void OnDebrisDead()
        {
            SpawnDebris();
        }
    }
}