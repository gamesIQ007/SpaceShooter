using System;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ����� ������
    /// </summary>

    public class Player : MonoBehaviour
    {
        /// <summary>
        /// ���������� ������
        /// </summary>
        [SerializeField] private int m_NumLives;

        /// <summary>
        /// ������� ������
        /// </summary>
        [SerializeField] private SpaceShip m_Ship;

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