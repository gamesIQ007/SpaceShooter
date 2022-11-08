using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Поверап оружия
    /// </summary>
    public class PowerUpWeapon : PowerUp
    {
        [SerializeField] private TurretProperties m_Properties;

        /// <summary>
        /// Действие при подборе бонуса
        /// </summary>
        /// <param name="ship">Корабль, к которому применяется бонус</param>
        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AssignWeapon(m_Properties);
        }
    }
}