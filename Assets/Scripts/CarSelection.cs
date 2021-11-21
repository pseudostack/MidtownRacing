using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CarSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    public int currentCar;

    //public Slider SpeedSlider;
    //public Slider MassSlider;
   // public Slider TorqueSlider;

    private void Awake()
    {
        SelectCar(0);
    }

    private void SelectCar(int _index)
    {
        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount-1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        SelectCar(currentCar);
    }
    public void Ready()
    {
        Invoke("Ready2", 1f);
      
        
    }
    void Ready2()
    {
        SceneManager.LoadScene("Level2");
        PlayerPrefs.SetInt("Carid", currentCar);

        //if (PlayerPrefs.GetInt("mid") == 0)
        //{
           // SceneManager.LoadScene("Level1");
            //PlayerPrefs.SetInt("Carid", currentCar);
       // }
       // else
       // {
           // SceneManager.LoadScene("Level2");
           // PlayerPrefs.SetInt("Carid", currentCar);
        //}
    }
    
    private void Update()
    {
        if(currentCar == 0)
        {
          
            //SpeedSlider.value = 164;
            //TorqueSlider.value = 4200;
            //MassSlider.value = 2100;
            //TopSpeed.text = "MaxSpeed: 180 KPH";

            //Mass.text = "Mass: 1800 kg";

        }
        if (currentCar == 1)
        {
          
            //SpeedSlider.value = 156;
            //TorqueSlider.value = 2800;
            //MassSlider.value = 1500;

            //TopSpeed.text = "MaxSpeed: 156 KPH";
            //Mass.text = "Mass: 1200 kg";
        }
        
    }
}
