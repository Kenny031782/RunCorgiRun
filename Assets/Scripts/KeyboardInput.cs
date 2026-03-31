using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    public PoopPlacer PoopPlacer;
  
    // Update is called once per frame
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        
        // if pressed w
        if (keyboard.wKey.isPressed)
        {
            Corgi.MoveManually(Vector2.up);
            
        }
        if (keyboard.sKey.isPressed)
        {
            Corgi.MoveManually(Vector2.down);

        }
        if (keyboard.aKey.isPressed)
        {
            Corgi.MoveManually(Vector2.left);

        }
        if (keyboard.dKey.isPressed)
        {
            Corgi.MoveManually(Vector2.right);

        }
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            PoopPlacer.Place(Corgi.GetPosition());

        }
    }
}
