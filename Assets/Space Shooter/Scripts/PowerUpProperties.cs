using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ������� ��������� ��������� �������������
    /// </summary>
    public class PowerUpProperties : PowerUp
    {
        /// <summary>
        /// �������� ������
        /// </summary>
        [SerializeField] private float m_Value;

        /// <summary>
        /// ����� �������� ������
        /// </summary>
        [SerializeField] private float m_TimeBonus;

        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.EnableTemporarySpeedUp(m_Value, m_TimeBonus);
        }
    }
}