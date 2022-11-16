using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(SpaceShip))]

    /// <summary>
    /// Искусственный интеллект
    /// </summary>
    public class AIController : MonoBehaviour
    {
        /// <summary>
        /// Перечисление поведений AI
        /// </summary>
        public enum AIBehaviour
        {
            Null,
            Patrol
        }

        /// <summary>
        /// Поведение
        /// </summary>
        [SerializeField] private AIBehaviour m_AIBehaviour;

        /// <summary>
        /// Скорость перемещения
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationLinear;

        /// <summary>
        /// Скорость вращения
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationAngular;

        /// <summary>
        /// Таймер изменения позиции
        /// </summary>
        [SerializeField] private float m_RandomSelectMovePointTime;

        /// <summary>
        /// Таймер изменения цели
        /// </summary>
        [SerializeField] private float m_FindNewTargetTime;

        /// <summary>
        /// Таймер стрельбы
        /// </summary>
        [SerializeField] private float m_ShootDelay;

        /// <summary>
        /// Длина рейкаста
        /// </summary>
        [SerializeField] private float m_EvadeRayLength;

        /// <summary>
        /// Ссылка на свой корабль
        /// </summary>
        private SpaceShip m_SpaceShip;

        /// <summary>
        /// Точка назначения
        /// </summary>
        private Vector3 m_MovePosition;

        /// <summary>
        /// Цель
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
        /// Инициализация таймеров
        /// </summary>
        private void InitTimers()
        {

        }

        /// <summary>
        /// Обновление таймеров
        /// </summary>
        private void UpdateTimers()
        {

        }

        #endregion

        /// <summary>
        /// Обновление ИИ
        /// </summary>
        private void UpdateAI()
        {
            if (m_AIBehaviour == AIBehaviour.Patrol)
            {
                UpdateBehaviourPatrol();
            }
        }

        /// <summary>
        /// Обновить поведение при патрулировании
        /// </summary>
        private void UpdateBehaviourPatrol()
        {
            ActionFindNewMovePosition();
            ActionControlShip();
            ActionFindNewAttackTarget();
            ActionFire();
        }

        /// <summary>
        /// Найти новую цель перемещения
        /// </summary>
        private void ActionFindNewMovePosition()
        {

        }

        /// <summary>
        /// Управление перемещением
        /// </summary>
        private void ActionControlShip()
        {
            m_SpaceShip.ThrustControl = m_NavigationLinear;
            m_SpaceShip.TorqueControl = ComputeAliginTorqueNormalized(m_MovePosition, m_SpaceShip.transform) * m_NavigationAngular;
        }

        /// <summary>
        /// Максимальный угол поворота
        /// </summary>
        private const float MAX_ANGLE = 45.0f;

        /// <summary>
        /// Расчёт множителя для поворота между целью и кораблём
        /// </summary>
        /// <param name="targetPosition">Цель</param>
        /// <param name="ship">Корабль</param>
        /// <returns>Множитель поворота</returns>
        private static float ComputeAliginTorqueNormalized(Vector3 targetPosition, Transform ship)
        {
            Vector2 localTargetPosition = ship.InverseTransformPoint(targetPosition);

            float angle = Vector3.SignedAngle(localTargetPosition, Vector3.up, Vector3.forward);

            angle = Mathf.Clamp(angle, -MAX_ANGLE, MAX_ANGLE) / MAX_ANGLE;

            return -angle;
        }

        /// <summary>
        /// Поиск новой цели атаки
        /// </summary>
        private void ActionFindNewAttackTarget()
        {

        }

        /// <summary>
        /// Атака
        /// </summary>
        private void ActionFire()
        {

        }
    }
}