using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// ����� ������
    /// </summary>

    public class Player : SingletonBase<Player>
    {
        /// <summary>
        /// ���������� ������
        /// </summary>
        [SerializeField] private int m_NumLives;

        /// <summary>
        /// ������� ������
        /// </summary>
        [SerializeField] private SpaceShip m_Ship;
        public SpaceShip ActiveShip => m_Ship;

        /// <summary>
        /// ������ ������� ������
        /// </summary>
        [SerializeField] private GameObject m_PlayerShipPrefab;

        /// <summary>
        /// ���������� ������
        /// </summary>
        [SerializeField] private CameraController m_CameraController;

        /// <summary>
        /// ���������� ����������
        /// </summary>
        [SerializeField] private MovementController m_MovementController;

        [Header("DeathEffect")]
        /// <summary>
        /// ������ ������� ����������� �������
        /// </summary>
        [SerializeField] private GameObject m_EffectPrefab;

        /// <summary>
        /// ����� ����� �������
        /// </summary>
        [SerializeField] private float m_EffectDuration;

        /// <summary>
        /// ����� �� ��������� ���������� �����
        /// </summary>
        [HideInInspector] public UnityEvent m_EventScoreChanged;

        #region Unity Events

        private void Start()
        {
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

        #endregion

        /// <summary>
        /// �������� ��� ������ �������
        /// </summary>
        private void OnShipDeath()
        {
            m_NumLives--;

            GameObject effect = Instantiate(m_EffectPrefab, m_Ship.transform.position, Quaternion.identity);
            Destroy(effect, m_EffectDuration);

            if (m_NumLives > 0)
            {
                Respawn();
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        private void Respawn()
        {
            var newPlayerShip = Instantiate(m_PlayerShipPrefab);
            m_Ship = newPlayerShip.GetComponent<SpaceShip>();
            m_CameraController.SetTarget(m_Ship.transform);
            m_MovementController.SetTargetShip(m_Ship);
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

        #region Score

        /// <summary>
        /// ����
        /// </summary>
        private int m_Score;
        public int Score => m_Score;

        /// <summary>
        /// ���������� �������
        /// </summary>
        private int m_NumKills;
        public int NumKills => m_NumKills;

        /// <summary>
        /// ���������� ���������� �����
        /// </summary>
        /// <param name="score">���������� ����������� �����</param>
        public void AddScore(int score)
        {
            m_Score += score;

            m_EventScoreChanged?.Invoke();
        }

        /// <summary>
        /// ���������� �������� �������
        /// </summary>
        public void AddKill()
        {
            m_NumKills++;
        }

        #endregion
    }
}