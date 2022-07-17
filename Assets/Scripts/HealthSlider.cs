using UnityEngine;
using UnityEngine.UI;
public class HealthSlider : MonoBehaviour
{
    float current = 1;
    float maximum = 1;

    [SerializeField]
    Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        SetBar();
    }

    // Update is called once per frame
    public void UpdateValues(int cur, int max)
    {
        current = 0.0f + cur;
        maximum = 0.0f + max;
        SetBar();
    }


    void SetBar() {

        bar.value = current/ maximum + 0.0f;
    }



}
