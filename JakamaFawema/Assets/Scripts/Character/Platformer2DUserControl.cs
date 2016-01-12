using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        int SW1ButtonMask = 0x40;
        int SW2ButtonMask = 0x80;
        int SW3ButtonMask = 0x100;
        int SW4ButtonMask = 0x200;
        int buttonVal = 0;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            buttonVal = Controller.sharedInstance.getButtonVal();
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                //if (!isJumping)
                //{
                m_Jump = ((buttonVal & SW2ButtonMask) != 0 || Input.GetButtonDown("Jump")); //test with mGrounded
                    //isJumping = true;
                //}
               // else if ((buttonVal & SW2ButtonMask) == 0) isJumping = false;
                
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            buttonVal = Controller.sharedInstance.getButtonVal();
            bool crouch = ((buttonVal & SW1ButtonMask) != 0 || Input.GetKey(KeyCode.LeftControl));
            float h = Input.GetAxis("Horizontal");
            if ((buttonVal & SW4ButtonMask) != 0) h = -1;
            else if ((buttonVal & SW3ButtonMask) != 0) h = 1;
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
