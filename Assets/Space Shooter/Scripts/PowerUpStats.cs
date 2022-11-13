using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ������� �������������
    /// </summary>
    public class PowerUpStats : PowerUp
    {
        /// <summary>
        /// ��� ������
        /// </summary>
        public enum EffectType
        {
            AddAmmo,
            AddEnergy,
            AddTemporaryIndestructible
        }

        /// <summary>
        /// ��� ������
        /// </summary>
        [SerializeField] private EffectType m_EffectType;

        /// <summary>
        /// �������� ������
        /// </summary>
        [SerializeField] private float m_Value;

        /// <summary>
        /// �������� ��� ������� ������
        /// </summary>
        /// <param name="ship">�������, � �������� ����������� �����</param>
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