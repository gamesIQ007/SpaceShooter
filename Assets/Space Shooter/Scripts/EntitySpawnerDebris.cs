using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ������� ������
    /// </summary>
    public class EntitySpawnerDebris : MonoBehaviour
    {
        /// <summary>
        /// ������� ������
        /// </summary>
        [SerializeField] private Destructible[] m_DebrisPrefabs;

        /// <summary>
        /// ������� ������
        /// </summary>
        [SerializeField] private CircleArea m_Area;

        /// <summary>
        /// ���������� ������
        /// </summary>
        [SerializeField] private int m_NumDebris;

        /// <summary>
        /// ��������
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
        /// ����� ������
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
        /// ������ ������
        /// </summary>
        private void OnDebrisDead()
        {
            SpawnDebris();
        }
    }
}