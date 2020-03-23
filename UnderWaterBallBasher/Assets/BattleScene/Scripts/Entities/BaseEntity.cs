using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour {
    protected float moveSpeed, rotSpeed;
    protected int hp = 1;
    public GameObject damage;

    public int GetHP() { return hp; }
    public void SetHP(int _hp) { hp = _hp; }

    public void ReduceHP(int _reduction, Vector3 pos) { //only use for enemys
        hp -= _reduction;

    } 

    public float GetMoveSpeed() { return moveSpeed; }
    public void GetMoveSpeed(float _moveSpeed) { moveSpeed =  _moveSpeed; }
    public float GetRotSpeed() { return rotSpeed; }
    public void GetRotSpeed(float _rotSpeed) { rotSpeed = _rotSpeed; }
}