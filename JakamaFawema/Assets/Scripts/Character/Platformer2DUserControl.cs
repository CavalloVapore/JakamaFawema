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
        bool jumped = false;
        float timeJumped = 0.0f;
        float time = 0.0f;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (Controller.sharedInstance.getRunning())
                buttonVal = System.Convert.ToInt32(Controller.sharedInstance.getButtonVal(), 16);

            if (!m_Jump && m_Character.getGrounded() && !jumped)
            {
                m_Jump = ((buttonVal & SW2ButtonMask) != 0 || Input.GetButtonDown("Jump")); //test with mGrounded
            }


        }


        private void FixedUpdate()
        {
            // Read the inputs.
            if (Controller.sharedInstance.getRunning())
                buttonVal = System.Convert.ToInt32(Controller.sharedInstance.getButtonVal(), 16);
            else buttonVal = 0;
            bool crouch = ((buttonVal & SW1ButtonMask) != 0 || Input.GetKey(KeyCode.LeftControl));
            float h = Input.GetAxis("Horizontal");
            if ((buttonVal & SW4ButtonMask) != 0) h = -1;
            else if ((buttonVal & SW3ButtonMask) != 0) h = 1;
            // Pass all parameters to the character control script.
            
            if (jumped)
            {
                //Debug.Log(time);
                m_Jump = false;
                time += Time.deltaTime;
                if (timeJumped < time - 0.85f)
                {
                    jumped = false;
                }                
            }
            if (m_Jump && !jumped)
            {
                timeJumped = Time.deltaTime;
                time = timeJumped;
                jumped = true;
            }
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
