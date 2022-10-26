using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ����� ��� ���������� �������
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        /// <summary>
        /// �������� ����� ����������
        /// </summary>
        public enum ControlMode
        {
            Keyboard,
            Mobile
        }

        /// <summary>
        /// ������ �� ����������� �������
        /// </summary>
        [SerializeField] private SpaceShip m_TargetShip;

        /// <summary>
        /// ������ �� ����������� ��������
        /// </summary>
        [SerializeField] private VirtualJoystick m_MobileJoystick;

        /// <summary>
        /// ��� ����������
        /// </summary>
        [SerializeField] private ControlMode m_ControlMode;

        #region Unity Events

        private void Start()
        {
            if (m_ControlMode == ControlMode.Keyboard)
            {
                m_MobileJoystick.gameObject.SetActive(false);
            }
            else
            {
                m_MobileJoystick.gameObject.SetActive(true);
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
        /// ���������� ���������� ����������� ����������
        /// </summary>
        private void ControlMobile()
        {
            Vector3 dir = m_MobileJoystick.Value;

            m_TargetShip.ThrustControl = dir.y;
            m_TargetShip.TorqueControl = -dir.x;
        }

        /// <summary>
        /// ���������� ���������� � ����������
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

            m_TargetShip.ThrustControl = thrust;
            m_TargetShip.TorqueControl = torque;
        }
    }
}

