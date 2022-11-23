using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Условия завершения уровня по достижении определённой области
    /// </summary>
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        /// <summary>
        /// Область
        /// </summary>
        [SerializeField] private Trigger m_Area;

        /// <summary>
        /// Достигнута ли цель
        /// </summary>
        private bool m_Reached = false;

        public bool IsCompleted => m_Reached;

        private void Start()
        {
            m_Area.Enter.AddListener(OnAreaReached);
        }

        private void OnDestroy()
        {
            m_Area.Enter.RemoveListener(OnAreaReached);
        }

        /// <summary>
        /// Действие при достижении области
        /// </summary>
        private void OnAreaReached()
        {
            m_Reached = true;
        }
    }
}