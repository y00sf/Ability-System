using UnityEngine;

public class AbilityControl : MonoBehaviour
{
    private Ability[] abilities = new Ability[4];
    public Player player;
    private float _lastTime = -100;
    private void Start()
    {
        abilities[0] = new Ability_DoubleJump(5);
    }

    private void Update()
    {
        _lastTime = -abilities[0].cooutdown;
        if(Input.GetKeyDown(KeyCode.Alpha1) && Time.time - _lastTime > abilities[0].cooutdown)
        {
            _lastTime = Time.time;
            abilities[0].Base(player);
        }
    }
}
