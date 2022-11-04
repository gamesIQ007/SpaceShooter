using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс для управления игроком
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        /// <summary>
        /// Перечень типов управления
        /// </summary>
        public enum ControlMode
        {
            Keyboard,
            Mobile
        }

        /// <summary>
        /// Ссылка на управляемый корабль
        /// </summary>
        [SerializeField] private SpaceShip m_TargetShip;
        public void SetTargetShip(SpaceShip ship) => m_TargetShip = ship;   // при вызове SetTargetShip присваиваем ссылке на управляемый корабль передаваемый корабль

        /// <summary>
        /// Ссылка на виртуальный джойстик
        /// </summary>
        [SerializeField] private VirtualJoystick m_MobileJoystick;

        /// <summary>
        /// Тип управления
        /// </summary>
        [SerializeField] private ControlMode m_ControlMode;

        /// <summary>
        /// Кнопка выстрела из основного оружия
        /// </summary>
        [SerializeField] private PointerClickHold m_MobileFirePrimary;

        /// <summary>
        /// Кнопка выстрела из дополнительного оружия
        /// </summary>
        [SerializeField] private PointerClickHold m_MobileFireSecondary;

        #region Unity Events

        private void Start()
        {
            if (m_ControlMode == ControlMode.Keyboard)
            {
                m_MobileJoystick.gameObject.SetActive(false);
                m_MobileFirePrimary.gameObject.SetActive(false);
                m_MobileFireSecondary.gameObject.SetActive(false);
            }
            else
            {
                m_MobileJoystick.gameObject.SetActive(true);
                m_MobileFirePrimary.gameObject.SetActive(true);
                m_MobileFireSecondary.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            if (m_TargetShip == null) return;

            if (m_ControlMode == ControlMode.Keyboard)
            {
                ControlKeyboard();
            }
            if (m_ControlMode == ControlMode.Mobile)
            {
                ControlMobile();
            }
        }

        #endregion

        /// <summary>
        /// Реализация управления виртуальным джойстиком
        /// </summary>
        private void ControlMobile()
        {
            Vector3 dir = m_MobileJoystick.Value;

            if (m_MobileFirePrimary.IsHold)
            {
                m_TargetShip.Fire(TurretMode.Primary);
            }

            if (m_MobileFireSecondary.IsHold)
            {
                m_TargetShip.Fire(TurretMode.Secondary);
            }

            m_TargetShip.ThrustControl = dir.y;
            m_TargetShip.TorqueControl = -dir.x;
        }

        /// <summary>
        /// Реализация управления с клавиатуры
        /// </summary>
        private void ControlKeyboard()
        {
            float thrust = 0;
            float torque = 0;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                thrust = 1.0f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                thrust = -1.0f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                torque = 1.0f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                torque = -1.0f;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                m_TargetShip.Fire(TurretMode.Primary);
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                m_TargetShip.Fire(TurretMode.Secondary);
            }

            m_TargetShip.ThrustControl = thrust;
            m_TargetShip.TorqueControl = torque;
        }
    }
}

