using UnityEngine;

namespace SpaceShooter
{
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

        private Timer testTimer;

        #region Unity Events

        private void Start()
        {
            testTimer = new Timer(3);
        }

        private void Update()
        {
            testTimer.RemoveTime(Time.deltaTime);

            if (testTimer.IsFinished)
            {
                Debug.Log("таймер!");

                testTimer.Start(3);
            }
        }

        #endregion
    }
}