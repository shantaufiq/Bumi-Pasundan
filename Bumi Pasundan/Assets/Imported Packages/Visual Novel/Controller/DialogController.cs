using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BumiPasundan;

public enum TypingStatus
{
    stopped, running, start
}

public class DialogController : MonoBehaviour
{
    public int _index;
    [Header("Dialog Components")]
    public List<DisplayCharComponents> CharacterDialog;
    public List<MDialog> DialogStage;
    // public List<AudioSource> Audios = new List<AudioSource>();
    public TypingStatus typingstatus;
    public float typingSpeed;

    public DialogTrigger _dialogHandler;

    // [Header("UI Object")]
    // public GameObject DialogComponents;
    // public GameObject ButtonNext;
    // public GameObject ButtonPrevious;


    private void Awake()
    {
        typingstatus = TypingStatus.stopped;
        _index = 0;
    }


    // private void Start() => SetAudiosClip();

    private void Update()
    {
        if (typingstatus == TypingStatus.start)
        {
            for (int i = 0; i < DialogStage.Count; i++)
            {
                if (i == _index)
                {
                    StartCoroutine(TypingEffect(i));
                }
            }
        }

        BtnToggleActivation();
    }

    public void SetAudiosClip()
    {
        // for (int i = 0; i < DialogStage.Count; i++)
        // {
        //     Audios.Add(gameObject.AddComponent<AudioSource>());
        //     Audios[i].clip = DialogStage[i].AudioClip;
        // }
    }

    public IEnumerator TypingEffect(int index)
    {
        typingstatus = TypingStatus.running;

        foreach (var text in CharacterDialog)
        {
            text.DialogText.text = "";
        }

        // Audios[_index].Play();

        foreach (char l in DialogStage[_index].Dialog.ToCharArray())
        {
            ToggleOnOffDialog(DialogStage[_index].CharacterID, l);

            yield return new WaitForSeconds(typingSpeed);
        }
        typingstatus = TypingStatus.stopped;
    }

    public void ToggleOnOffDialog(int charid, char l)
    {
        for (int i = 0; i < CharacterDialog.Count; i++)
        {
            if (i == charid)
            {
                CharacterDialog[i].ToggleIsOn(l);
            }
            else
            {
                CharacterDialog[i].ToggleIsOff();
            }
        }
    }

    public void NextDialog()
    {
        if (typingstatus == TypingStatus.running) return;

        if (_index != DialogStage.Count - 1)
        {
            _index = _index < DialogStage.Count - 1 ? _index + 1 : DialogStage.Count - 1;
            typingstatus = TypingStatus.start;
        }
        else if (_index == DialogStage.Count - 1)
        {
            foreach (var item in CharacterDialog)
            {
                item.gameObject.SetActive(false);
            }

            _dialogHandler.Player.gameObject.SetActive(true);
            _dialogHandler.ButtonUIComponents.SetActive(true);

            DialogStage.Clear();
        }
    }

    public void PreviousDialog()
    {
        if (_index == 0 || typingstatus == TypingStatus.running) return;
        _index = _index > 0 ? _index - 1 : 0;
        typingstatus = TypingStatus.start;
    }

    public void BtnToggleActivation()
    {
        var statEnd = _index == DialogStage.Count - 1 ? false : true;
        // ButtonNext.SetActive(statEnd);

        var statFirst = _index == 0 ? false : true;
        // ButtonPrevious.SetActive(statFirst);
    }

    public void StartDialog()
    {
        // DialogComponents.SetActive(true);
        typingstatus = TypingStatus.start;
    }
}
