using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CarSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [SerializeField] Text Infotext;

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

            Infotext.text = "OLD TAXI";

        }
        if (currentCar == 1)
        {

            Infotext.text = "90's SPORTS";
        }
        if (currentCar == 2)
        {

            Infotext.text = "COMPACT CAR";

        }
        if (currentCar == 3)
        {

            Infotext.text = "90'S SEDAN";
        }
        if (currentCar == 4)
        {

            Infotext.text = "1999 GT";
        }
        if (currentCar == 5)
        {

            Infotext.text = "SUPER CAR";
        }

    }
}
