using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider slider;
    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = controller.maxHp; // 플레이어의 최대 체력
        slider.minValue = 0;
    }

    public void SliderValueChange(int creentHp)
    {
        slider.value = creentHp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
