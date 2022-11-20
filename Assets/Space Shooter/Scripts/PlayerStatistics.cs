using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Статистика игрока
    /// </summary>
    public class PlayerStatistics : MonoBehaviour
    {
        /// <summary>
        /// Количество убийств
        /// </summary>
        public int numKills;

        /// <summary>
        /// Очки
        /// </summary>
        public int score;

        /// <summary>
        /// Время
        /// </summary>
        public int time;

        public void Reset()
        {
            numKills = 0;
            score = 0;
            time = 0;
        }
    }
}