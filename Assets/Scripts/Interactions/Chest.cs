using UnityEngine;


namespace PyramidGamesTest.Interactions
{
    public class Chest : InteractableObject
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Open()
        {
            GiveChoice("Open?", () => animator.SetBool("Open", true));
        }


    }
}