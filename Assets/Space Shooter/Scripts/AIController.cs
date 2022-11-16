using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(SpaceShip))]

    /// <summary>
    /// ������������� ���������
    /// </summary>
    public class AIController : MonoBehaviour
    {
        /// <summary>
        /// ������������ ��������� AI
        /// </summary>
        public enum AIBehaviour
        {
            Null,
            Patrol
        }

        /// <summary>
        /// ���������
        /// </summary>
        [SerializeField] private AIBehaviour m_AIBehaviour;

        /// <summary>
        /// �������� �����������
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationLinear;

        /// <summary>
        /// �������� ��������
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationAngular;

        /// <summary>
        /// ������ ��������� �������
        /// </summary>
        [SerializeField] private float m_RandomSelectMovePointTime;

        /// <summary>
        /// ������ ��������� ����
        /// </summary>
        [SerializeField] private float m_FindNewTargetTime;

        /// <summary>
        /// ������ ��������
        /// </summary>
        [SerializeField] private float m_ShootDelay;

        /// <summary>
        /// ����� ��������
        /// </summary>
        [SerializeField] private float m_EvadeRayLength;

        /// <summary>
        /// ������ �� ���� �������
        /// </summary>
        private SpaceShip m_SpaceShip;

        /// <summary>
        /// ����� ����������
        /// </summary>
        private Vector3 m_MovePosition;

        /// <summary>
        /// ����
        /// </summary>
        private Destructible m_SelectedTarget;

        #region Unity Events

        private void Start()
        {
            m_SpaceShip = GetComponent<SpaceShip>();

            InitTimers();
        }

        private void Update()
        {
            UpdateTimers();

            UpdateAI();
        }

        #endregion

        #region Timers

        /// <summary>
        /// ������������� ��������
        /// </summary>
        private void InitTimers()
        {

        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        private void UpdateTimers()
        {

        }

        #endregion

        /// <summary>
        /// ���������� ��
        /// </summary>
        private void UpdateAI()
        {
            if (m_AIBehaviour == AIBehaviour.Patrol)
            {
                UpdateBehaviourPatrol();
            }
        }

        /// <summary>
        /// �������� ��������� ��� ��������������
        /// </summary>
        private void UpdateBehaviourPatrol()
        {
            ActionFindNewMovePosition();
            ActionControlShip();
            ActionFindNewAttackTarget();
            ActionFire();
        }

        /// <summary>
        /// ����� ����� ���� �����������
        /// </summary>
        private void ActionFindNewMovePosition()
        {

        }

        /// <summary>
        /// ���������� ������������
        /// </summary>
        private void ActionControlShip()
        {
            m_SpaceShip.ThrustControl = m_NavigationLinear;
            m_SpaceShip.TorqueControl = ComputeAliginTorqueNormalized(m_MovePosition, m_SpaceShip.transform) * m_NavigationAngular;
        }

        /// <summary>
        /// ������������ ���� ��������
        /// </summary>
        private const float MAX_ANGLE = 45.0f;

        /// <summary>
        /// ������ ��������� ��� �������� ����� ����� � �������
        /// </summary>
        /// <param name="targetPosition">����</param>
        /// <param name="ship">�������</param>
        /// <returns>��������� ��������</returns>
        private static float ComputeAliginTorqueNormalized(Vector3 targetPosition, Transform ship)
        {
            Vector2 localTargetPosition = ship.InverseTransformPoint(targetPosition);

            float angle = Vector3.SignedAngle(localTargetPosition, Vector3.up, Vector3.forward);

            angle = Mathf.Clamp(angle, -MAX_ANGLE, MAX_ANGLE) / MAX_ANGLE;

            return -angle;
        }

        /// <summary>
        /// ����� ����� ���� �����
        /// </summary>
        private void ActionFindNewAttackTarget()
        {

        }

        /// <summary>
        /// �����
        /// </summary>
        private void ActionFire()
        {

        }
    }
}