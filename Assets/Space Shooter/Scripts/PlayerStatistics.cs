using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ������
    /// </summary>
    public class PlayerStatistics : MonoBehaviour
    {
        /// <summary>
        /// ���������� �������
        /// </summary>
        public int numKills;

        /// <summary>
        /// ����
        /// </summary>
        public int score;

        /// <summary>
        /// �����
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