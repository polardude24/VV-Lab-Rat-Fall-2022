using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonController : MonoBehaviour
{
    public GameObject settings;
    public GameObject settingsHover;
    public GameObject play;
    public GameObject playHover;
    public GameObject quit;
    public GameObject quitHover;
    public void Update()
    {
        if (IsPointerOverUIObject() == 1)
        {

            settingsHover.SetActive(true);
            settings.SetActive(false);

        }
        else if (IsPointerOverUIObject() == 2)
        {
            playHover.SetActive(true);
            play.SetActive(false);
        }
        else if (IsPointerOverUIObject() == 3)
        {
            quitHover.SetActive(true);
            quit.SetActive(false);
        }
        else
        {
            playHover.SetActive(false);
            play.SetActive(true);
            settingsHover.SetActive(false);
            settings.SetActive(true);
            quitHover.SetActive(false);
            quit.SetActive(true);
        }
    }
    public static int IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        foreach(var result in results)
        {
            if(result.gameObject.name == "SettingsButton")
            {
                return 1;
            }
            if (result.gameObject.name == "PlayButton")
            {
                return 2;
            }
            if (result.gameObject.name == "QuitButton")
            {
                return 3;
            }
        }
        return 0;
    }

}
