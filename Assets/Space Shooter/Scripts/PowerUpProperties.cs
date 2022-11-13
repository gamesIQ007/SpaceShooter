using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Паверап временных повышений характеристик
    /// </summary>
    public class PowerUpProperties : PowerUp
    {
        /// <summary>
        /// Величина бонуса
        /// </summary>
        [SerializeField] private float m_Value;

        /// <summary>
        /// Время действия бонуса
        /// </summary>
        [SerializeField] private float m_TimeBonus;

        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.EnableTemporarySpeedUp(m_Value, m_TimeBonus);
        }
    }
}