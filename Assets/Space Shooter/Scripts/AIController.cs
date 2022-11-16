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
        /// ������� ��������������
        /// </summary>
        [SerializeField] private AIPointPatrol m_PatrolPoint;

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

        private Timer m_RandomizeDirectionTimer;

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
            m_RandomizeDirectionTimer = new Timer(m_RandomSelectMovePointTime);
        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        private void UpdateTimers()
        {
            m_RandomizeDirectionTimer.RemoveTime(Time.deltaTime);
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
            ActionEvadeCollision();
        }

        /// <summary>
        /// ����� ����� ���� �����������
        /// </summary>
        private void ActionFindNewMovePosition()
        {
            if (m_AIBehaviour == AIBehaviour.Patrol)
            {
                if (m_SelectedTarget != null)
                {
                    m_MovePosition = m_SelectedTarget.transform.position;
                }
                else
                {
                    if (m_PatrolPoint != null)
                    {
                        bool isInsidePatrolZone = (m_PatrolPoint.transform.position - transform.position).sqrMagnitude < m_PatrolPoint.Radius * m_PatrolPoint.Radius;

                        if (isInsidePatrolZone)
                        {
                            if (m_RandomizeDirectionTimer.IsFinished)
                            {
                                Vector2 newPoint = Random.onUnitSphere * m_PatrolPoint.Radius + m_PatrolPoint.transform.position;

                                m_MovePosition = newPoint;

                                m_RandomizeDirectionTimer.Start(m_RandomSelectMovePointTime);
                            }
                        }
                        else
                        {
                            m_MovePosition = m_PatrolPoint.transform.position;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ��������� ������������
        /// </summary>
        private void ActionEvadeCollision()
        {
            if (Physics2D.Raycast(transform.position, transform.up, m_EvadeRayLength))
            {
                m_MovePosition = transform.position + transform.right * 100.0f; // �������� ������ ������, ����� �� � ����������. �� ���� ����
            }
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

        /// <summary>
        /// ������ ��������� ��������������
        /// </summary>
        /// <param name="point">������� ��������������</param>
        private void SetPatrolBehaviour(AIPointPatrol point)
        {
            m_AIBehaviour = AIBehaviour.Patrol;
            m_PatrolPoint = point;
        }
    }
}