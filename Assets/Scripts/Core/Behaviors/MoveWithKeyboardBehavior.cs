using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys
public enum InputKeyboard{
    arrows =0, 
    wasd = 1
}
public class MoveWithKeyboardBehavior : AgentBehaviour
{
    public InputKeyboard inputKeyboard;

    private void Start()
    {
        this.gameObject.tag = "Player";
    }

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        float horizontal = 0;
        float vertical = 0;
        if(inputKeyboard == InputKeyboard.arrows)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        else
        {
            horizontal = Input.GetAxis("HorizontalWASD");
            vertical = Input.GetAxis("VerticalWASD");
        }
        steering.linear = new Vector3(horizontal, 0,  vertical) * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.
        linear, agent.maxAccel));
        return steering;
    }

}
