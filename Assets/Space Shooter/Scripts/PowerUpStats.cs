using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Паверап характеристик
    /// </summary>
    public class PowerUpStats : PowerUp
    {
        /// <summary>
        /// Тип бонуса
        /// </summary>
        public enum EffectType
        {
            AddAmmo,
            AddEnergy,
            AddTemporaryIndestructible
        }

        /// <summary>
        /// Тип бонуса
        /// </summary>
        [SerializeField] private EffectType m_EffectType;

        /// <summary>
        /// Величина бонуса
        /// </summary>
        [SerializeField] private float m_Value;

        /// <summary>
        /// Действие при подборе бонуса
        /// </summary>
        /// <param name="ship">Корабль, к которому применяется бонус</param>
        protected override void OnPickedUp(SpaceShip ship)
        {
            if (m_EffectType == EffectType.AddEnergy)
            {
                ship.AddEnergy((int)m_Value);
            }

            if (m_EffectType == EffectType.AddAmmo)
            {
                ship.AddAmmo((int)m_Value);
            }
            if (m_EffectType == EffectType.AddTemporaryIndestructible)
            {
                ship.ApplyTemporaryIndestructible((int)m_Value);
            }
        }
    }
}