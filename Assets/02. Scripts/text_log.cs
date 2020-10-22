using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Dialogue
{
    // 여러줄을 쓸 수 있게 해준다.
    [TextArea]
    public string dialogue;
}

public class text_log : MonoBehaviour
{
    static public int npc_talk_int = 0;
    Boolean justOne = false;
    public Text txt_Dialogue;
    public Button button_1;
    public Button button_2;
    public Button button_3;
    // [SerializeField] 을 달면 유니티 inspector 창에서 해당 변수를 조작 할 수 있다.

    static public bool isDialogue = true;

    // 대화가 얼마나 진행 되었는지 확인
    private int count = 0;

    static private String[] dialogue; // 대화가 들어가는 배열

    private void Awake()
    {
        dialogue = new String[100];
        // 처음 intro 대사
        dialogue[0] = "[농부]\n\n안녕하세요 플레이어님 반가워요";
        dialogue[1] = "[농부]\n\n날씨가 아주 화창하군요! 감자 심기 좋은날이네요";
        dialogue[2] = "[농부]\n\n그럼 지금 감자 심기를 배워 보도록 하겠습니다.";
        dialogue[3] = "[농부]\n\n혹시 추가적으로 감자에 관해 알고 싶다면 앞에 저를 레이저 포인터로 클릭 해주세요";
        dialogue[4] = "[농부]\n\n레이저 포인터는 뒤로가기 버튼을 클릭하면 켜집니다.";
        dialogue[5] = "[농부]\n\n다시 누르면 꺼집니다.";
        dialogue[6] = "[농부]\n\n레이저 포인터가 켜져있는 상태로, 리모컨의 큰 원을 클릭하세요 ";
        dialogue[7] = "[농부]\n\n그럼 레이저 포인터가 가르키고 있는 대상과 상호 작용 할 수 있게 됩니다.";
        dialogue[8] = "[농부]\n\n준비가 되었다면 저에게 알려주세요";
        // 대화 끝에 null을 넣어서 대화가 끝났음을 알린다.
        dialogue[9] = "";
        dialogue[10] = "end";
        dialogue[12] = "[농부]\n\n무었을 도와드릴까요?";
        dialogue[13] = "[농부]\n\n무었을 도와드릴까요?";
        dialogue[14] = "[농부]\n\n무었을 도와드릴까요?";

    }
    private void Start()
    {
        this.gameObject.SetActive(false);
        button_1.gameObject.SetActive(false);
        button_2.gameObject.SetActive(false);
        button_3.gameObject.SetActive(false);

        Debug.Log("dialogue.length = " + dialogue.Length);
        ShowDialogue(0);
    }

    public void ShowDialogue(int count_)
    {
        count = count_;
        NextDialogue();
    }
    public void talk_npc()
    {
        button_1.gameObject.SetActive(true);
        button_2.gameObject.SetActive(true);
        button_3.gameObject.SetActive(true);
        count = 12;
        txt_Dialogue.text = dialogue[count];
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count];
        count++;
    }



    void Update()
    {
        if (npc_talk_int == 1 && justOne == false)
        {
            talk_npc();
            justOne = true;
        }
        else if (npc_talk_int == 2)
        {
            button_1.gameObject.SetActive(false);
            button_2.gameObject.SetActive(false);
            button_3.gameObject.SetActive(false);
            justOne = false;
        }

        // count 가 12면 선택지 대화 진행중이라 막아 둔다.
        if (isDialogue && count != 12)
        {
            if (dialogue[count].Equals("end"))
            {
                npc_talk_int = 1;
            }
            //if (OVRInput.GetDown(OVRInput.Button.One))
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (count < dialogue.Length)
                    NextDialogue();
            }
        }
    }
}