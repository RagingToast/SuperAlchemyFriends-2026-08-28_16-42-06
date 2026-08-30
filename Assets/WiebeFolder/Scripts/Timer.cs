using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time;
    [SerializeField] private TextMeshProUGUI text;

    void Update()
    {
       _time += Time.deltaTime;
       
       text.text = Mathf.FloorToInt(_time).ToString();
    }
}
