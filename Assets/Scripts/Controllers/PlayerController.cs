using System.Text;
using UnityEngine;

public class PlayerController : Controller

{
    public KeyCode teleportKey;//t

    public KeyCode moveForwardLocal; //w

    public KeyCode moveBackwardLocal; //s

    public KeyCode rotateClockwise;//d

    public KeyCode rotateCounterClockwise; //a

    public KeyCode moveForwardWorld; //Uparrow

    public KeyCode moveBackwardWorld; //Down arrow

    public KeyCode moveRightWorld; //rightarrow

    public KeyCode moveLeftWorld; //left arrow

    public KeyCode turboOption1; //leftShitf

    public KeyCode turboOption2; //right Shift

    public override void MakeDecisions()
    {
        if (Input.GetKey(turboOption1) || Input.GetKey(turboOption2))
        {
            //fast versions
            if (Input.GetKey(moveForwardLocal))
            {
                pawn.MoveForwardLocalTurbo();
            }
            if (Input.GetKey(moveBackwardLocal))
            {
                pawn.MoveBackwardLocalTurbo();
            }
            if (Input.GetKey(rotateClockwise))
            {
                pawn.RotateClockwiseTurbo();
            }
            if (Input.GetKey(rotateCounterClockwise))
            {
                pawn.RotateCounterClockwiseTurbo();
            }
        }
        else
        {
            //normal speeds
            if (Input.GetKey(moveForwardLocal))
            {
                pawn.MoveForwardLocal();
            }
            if (Input.GetKey(moveBackwardLocal))
            {
                pawn.MoveBackwardLocal();
            }
            if (Input.GetKey(rotateClockwise))
            {
                pawn.RotateClockwise();
            }
            if (Input.GetKey(rotateCounterClockwise))
            {
                pawn.RotateCounterClockwise();
            }

        }
        if (Input.GetKeyDown(moveForwardWorld))
        {
            pawn.MoveForwardWorld();
        }
        if (Input.GetKeyDown(moveBackwardWorld))
        {
            pawn.MoveBackwardWorld();
        }
        if (Input.GetKeyDown(moveLeftWorld))
        {
            pawn.MoveLeftWorld();
        }
        if (Input.GetKeyDown(moveRightWorld))
        {
            pawn.MoveRightWorld();
        }

        //Teleport keys
        if (Input.GetKeyDown(teleportKey))
        {
            pawn.Teleport();
        }
    }

 
    public override void Start()
    {
    
    }

   

    public override void Update()
    {
        MakeDecisions();
    }
}
