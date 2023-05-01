using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    public int InitialX = 2;
    public int InitialY = 2;
    private int X;
    private int Y;
    public GameObject enemy;
    private FloorController floorController;
    private PositionController positionController;
    void Start(){
        X = InitialX;
        Y = InitialY;
        
        // Debug.Log(tmp.transform.position);
        transform.position = GameObject.Find("Floor 0" + InitialX + InitialY).transform.Find("Position").position/* + new Vector3(0, GetComponent<BoxCollider2D>().bounds.size.y / 2.0f, 0)*/;

        floorController = GameObject.FindWithTag("GameController").GetComponent<FloorController>();
        positionController = GameObject.FindWithTag("GameController").GetComponent<PositionController>();
    }

    public void Move(int dx, int dy){
        if(floorController.isAccessable(X + dx, Y + dy, false)){
            X = X + dx;
            Y = Y + dy;
            positionController.set(enemy, floorController.get(X, Y, false));
        }
    }

    void Update(){
        
    }
    public int getX(){
        return X;
    }
    public int getY(){
        return Y;
    }
}
