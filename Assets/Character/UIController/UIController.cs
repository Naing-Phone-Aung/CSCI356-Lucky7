using UnityEngine;
using UnityEngine.UI;

namespace Project.End
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject pickUpText;
        [SerializeField] private GameObject EnterText;

        private void Awake()
        {
            // Ensure the UI is hidden at the start
            pickUpText.SetActive(false);
            EnterText.SetActive(false);
        }

        public void ShowPickUpText()
        {
            pickUpText.SetActive(true);
        }

        public void HidePickUpText()
        {
            pickUpText.SetActive(false);
        }

        public void ShowEnterText()
        {
            EnterText.SetActive(true);
        }

        public void HideEnterText()
        {
            EnterText.SetActive(false);
        }
    }
}
