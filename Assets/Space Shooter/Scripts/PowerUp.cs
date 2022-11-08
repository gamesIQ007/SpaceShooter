using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    /// <summary>
    /// Базовый класс паверапов
    /// </summary>
    public abstract class PowerUp : MonoBehaviour
    {
        #region Unity Events

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();

            if (ship != null && ship == Player.Instance.ActiveShip)
            {
                OnPickedUp(ship);
                Destroy(gameObject);
            }
        }

        #endregion

        /// <summary>
        /// Действие при подборе бонуса
        /// </summary>
        /// <param name="ship">Корабль, подобравший бонус</param>
        protected abstract void OnPickedUp(SpaceShip ship);
    }
}