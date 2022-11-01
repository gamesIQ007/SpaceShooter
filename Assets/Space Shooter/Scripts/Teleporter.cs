using UnityEngine;

namespace SpaceShooter
{

    /// <summary>
    /// “елепорт, перемещает корабль в указанную точку
    /// </summary>
    public class Teleporter : MonoBehaviour
    {
        /// <summary>
        /// ÷ель, в позицию которой будет перенесЄн корабль
        /// </summary>
        [SerializeField] private Teleporter target;

        /// <summary>
        /// ѕеременна€, отвечающа€ за то, получен ли корабль из другого телепорта
        /// </summary>
        [HideInInspector] public bool IsReceived;

        #region Unity Events

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsReceived) return;
            
            SpaceShip ship = other.GetComponentInParent<SpaceShip>();

            if (ship != null)
            {
                target.IsReceived = true;
                ship.transform.position = target.transform.position;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            SpaceShip ship = other.GetComponentInParent<SpaceShip>();

            if (ship != null)
            {
                IsReceived = false;
            }
        }

        #endregion
    }
}