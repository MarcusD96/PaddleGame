using UnityEngine;

public class BaseEntity : MonoBehaviour {
    protected float moveSpeed, rotSpeed;
    protected int hp = 1;

    public int GetHP() { return hp; }
    public void SetHP(int _hp) { hp = _hp; }

    public void ReduceHP(int _reduction) { //only use for enemys
        hp -= _reduction;
    } 

    public float GetMoveSpeed() { return moveSpeed; }
    public void SetMoveSpeed(float _moveSpeed) { moveSpeed =  _moveSpeed; }
    public float GetRotSpeed() { return rotSpeed; }
    public void SetRotSpeed(float _rotSpeed) { rotSpeed = _rotSpeed; }
}