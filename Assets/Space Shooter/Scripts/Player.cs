using System;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс игрока
    /// </summary>

    public class Player : MonoBehaviour
    {
        /// <summary>
        /// Количество жизней
        /// </summary>
        [SerializeField] private int m_NumLives;

        /// <summary>
        /// Корабль игрока
        /// </summary>
        [SerializeField] private SpaceShip m_Ship;

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

        #region Unity Events

        private void Start()
        {
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

        #endregion

        private void OnShipDeath()
        {
            m_NumLives--;

            if (m_NumLives > 0)
            {
                Respawn();
            }
        }

        private void Respawn()
        {
            var newPlayerShip = Instantiate(m_PlayerShipPrefab);
            m_Ship = newPlayerShip.GetComponent<SpaceShip>();
            m_CameraController.SetTarget(m_Ship.transform);
            m_MovementController.SetTargetShip(m_Ship);
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }
    }
}