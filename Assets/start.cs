using System.Collections;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject RightController, LeftController, DefaultC, Manager;
    // Use this for initialization
    void Awake()
    {
        //GameObject RightController= Instantiate(Resources.Load("RightHandInputControl")) as GameObject;
        //GameObject LeftController = Instantiate(Resources.Load("LeftHandInputControl")) as GameObject;
        //GameObject DefaultC = Instantiate(Resources.Load("DefaultCursor")) as GameObject;
        //GameObject Manager = Instantiate(Resources.Load("InputManager")) as GameObject;
        //DontDestroyOnLoad(RightController);
        //DontDestroyOnLoad(LeftController);
        //DontDestroyOnLoad(DefaultC);
        //DontDestroyOnLoad(Manager);

    }


    // Update is called once per frame
    public void StartButton()
    {
        Invoke("startgames", .5f);//몇초뒤 이 함수를 실행하냐

    }
    void startgames()
    {
        if (DestroyFQ.DesInstance != null)
            DestroyFQ.DesInstance.DesFQ();
        if (DestroyMC.DesInstance != null)
            DestroyMC.DesInstance.DesMC();
        if (DestroyIM.DesInstance!=null)
          DestroyIM.DesInstance.DesIM();
        if (DestroyLIC.DesInstance != null)
            DestroyLIC.DesInstance.DesLIC();
        if (DestroyRIC.DesInstance != null)
            DestroyRIC.DesInstance.DesRIC();
        if (DestroyDC.DesInstance != null)
            DestroyDC.DesInstance.DesDC();
        Destroy(gameObject);
        Application.LoadLevel("Lv1");//씬이 넘어감
    }
    public void isExit()
    {
        Application.Quit();
    }
}
