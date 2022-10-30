using UnityEngine;

namespace SpaceShooter
{

    /// <summary>
    /// Ограничитель позиции. Работает в связке с LevelBoundary, при наличии.
    /// Размещается на объекте, который нужно ограничить
    /// </summary>
    public class LevelBoundaryLimiter : MonoBehaviour
    {
        #region Unity Events

        private void Update()
        {
            if (LevelBoundary.Instance == null) return;

            // Делаем новые переменные для краткости записи
            var lb = LevelBoundary.Instance;
            var r = lb.Radius;

            if (transform.position.magnitude > r)
            {
                if (lb.LimitMode == LevelBoundary.Mode.Limit)
                {
                    transform.position = transform.position.normalized * r;
                }

                if (lb.LimitMode == LevelBoundary.Mode.Teleport)
                {
                    transform.position = -transform.position.normalized * r;
                }
            }
        }

        #endregion
    }
}