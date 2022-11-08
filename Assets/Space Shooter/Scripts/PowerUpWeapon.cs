using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ������� ������
    /// </summary>
    public class PowerUpWeapon : PowerUp
    {
        [SerializeField] private TurretProperties m_Properties;

        /// <summary>
        /// �������� ��� ������� ������
        /// </summary>
        /// <param name="ship">�������, � �������� ����������� �����</param>
        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AssignWeapon(m_Properties);
        }
    }
}