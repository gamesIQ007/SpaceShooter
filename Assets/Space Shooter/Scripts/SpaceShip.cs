using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class SpaceShip : Destructible
    {
        [Header("Space ship")]
        /// <summary>
        /// �����, ��� �������������� ��������� � ������
        /// </summary>
        [SerializeField] private float m_Mass;

        /// <summary>
        /// ��������� ����� ����
        /// </summary>
        [SerializeField] private float m_Thrust;

        /// <summary>
        /// ��������� ����
        /// </summary>
        [SerializeField] private float m_Mobility;

        /// <summary>
        /// ������������ �������� ��������
        /// </summary>
        [SerializeField] private float m_MaxLinearVelocity;

        /// <summary>
        /// ������������ ������������ �������� � ��������/���.
        /// </summary>
        [SerializeField] private float m_MaxAngularVelocity;

        /// <summary>
        /// ���������� ������ �� �����
        /// </summary>
        [SerializeField] private Rigidbody2D m_Rigid;

        #region Unity Events

        protected override void Start()
        {
            base.Start();
            m_Rigid = GetComponent<Rigidbody2D>();
            m_Rigid.mass = m_Mass;
            m_Rigid.inertia = 1; // ������������� ����, ����� ���� ����� ������������� ����������� ��� � ����� ���������
        }

        private void Update()
        {
            ThrustControl = 0;
            TorqueControl = 0;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                ThrustControl = 1.0f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                ThrustControl = -1.0f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                TorqueControl = 1.0f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                TorqueControl = -1.0f;
            }
        }

        private void FixedUpdate()
        {
            UpdateRigitBody();
        }

        #endregion

        #region Public API

        /// <summary>
        /// ���������� �������� �����. �� -1.0 �� +1.0
        /// </summary>
        public float ThrustControl { get; set; }

        /// <summary>
        /// ���������� ������������ �����. �� -1.0 �� +1.0
        /// </summary>
        public float TorqueControl { get; set; }

        #endregion

        /// <summary>
        /// ����� ���������� ��� ������� ��� ��������
        /// </summary>
        private void UpdateRigitBody()
        {
            m_Rigid.AddForce(ThrustControl * m_Thrust * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);
            m_Rigid.AddForce(-m_Rigid.velocity * (m_Thrust / m_MaxLinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddTorque(TorqueControl * m_Mobility * Time.fixedDeltaTime, ForceMode2D.Force);
            m_Rigid.AddTorque(-m_Rigid.angularVelocity * (m_Mobility / m_MaxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
}
