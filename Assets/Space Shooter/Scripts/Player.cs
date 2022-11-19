using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// Класс игрока
    /// </summary>

    public class Player : SingletonBase<Player>
    {
        /// <summary>
        /// Количество жизней
        /// </summary>
        [SerializeField] private int m_NumLives;

        /// <summary>
        /// Корабль игрока
        /// </summary>
        [SerializeField] private SpaceShip m_Ship;
        public SpaceShip ActiveShip => m_Ship;

        /// <summary>
        /// Префаб корабля игрока
        /// </summary>
        [SerializeField] private GameObject m_PlayerShipPrefab;

        /// <summary>
        /// Контроллер камеры
        /// </summary>
        [SerializeField] private CameraController m_CameraController;

        /// <summary>
        /// Контроллер управления
        /// </summary>
        [SerializeField] private MovementController m_MovementController;

        [Header("DeathEffect")]
        /// <summary>
        /// Префаб эффекта посмертного префаба
        /// </summary>
        [SerializeField] private GameObject m_EffectPrefab;

        /// <summary>
        /// Время жизни эффекта
        /// </summary>
        [SerializeField] private float m_EffectDuration;

        /// <summary>
        /// Ивент на изменение количества очков
        /// </summary>
        [HideInInspector] public UnityEvent m_EventScoreChanged;

        #region Unity Events

        private void Start()
        {
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

        #endregion

        /// <summary>
        /// Действие при смерти корабля
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
        /// Респаун
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
        /// Очки
        /// </summary>
        private int m_Score;
        public int Score => m_Score;

        /// <summary>
        /// Количество убийств
        /// </summary>
        private int m_NumKills;
        public int NumKills => m_NumKills;

        /// <summary>
        /// Увеличение количество очков
        /// </summary>
        /// <param name="score">Количество добавляемых очков</param>
        public void AddScore(int score)
        {
            m_Score += score;

            m_EventScoreChanged?.Invoke();
        }

        /// <summary>
        /// Увеличение счётчика убийств
        /// </summary>
        public void AddKill()
        {
            m_NumKills++;
        }

        #endregion
    }
}