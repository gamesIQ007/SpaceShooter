using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Условия завершения уровня по количеству очков
    /// </summary>
    public class LevelConditionScore : MonoBehaviour, ILevelCondition
    {
        /// <summary>
        /// Очки
        /// </summary>
        [SerializeField] private int m_Score;

        /// <summary>
        /// Достигнута ли цель
        /// </summary>
        private bool m_Reached;

        public bool IsCompleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    if (Player.Instance.Score >= m_Score)
                    {
                        m_Reached = true;
                    }
                }
                return m_Reached;
            }
        }
    }
}