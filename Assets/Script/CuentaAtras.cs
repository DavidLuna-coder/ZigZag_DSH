using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _numberOfSprites;
    private const string BUTTON_TAG = "btn_start";
    // Start is called before the first frame update
    void Start()
    {
        _image.gameObject.SetActive(false);
        _button.onClick.AddListener(StartCountdown);               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartCountdown()
    {
        //_image.gameObject.SetActive(true);
        _button.gameObject.SetActive(false);
         StartCoroutine(Countdown());
    }

    private IEnumerator Countdown(){
        for (int i = 0; i < _numberOfSprites.Length; i++)
        {
            _image.sprite = _numberOfSprites[i];
            _image.gameObject.SetActive(true);
            //wait one second
            yield return new WaitForSeconds(1);
            _image.gameObject.SetActive(false);
        }
        SceneManager.LoadScene("Scene2");
    }

}
