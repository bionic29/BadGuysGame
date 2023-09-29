using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue1 : MonoBehaviour
{
    public Text dialogueText;
    public Image Thumbnail;
    public string[] Ments;
    public Sprite[] thumbImages;
    public GameObject Next;
    int count = 0;

    public bool dialogueDone;
    // Start is called before the first frame update
    void OnEnable()
    {
        Time.timeScale = 0;
        StartMent();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Next.activeInHierarchy && Input.GetKeyDown(KeyCode.Space) && count < Ments.Length-1)
        {
            count++;
            StartCoroutine(typing());
        }
        else if (Next.activeInHierarchy && Input.GetKeyDown(KeyCode.Space) && count >= Ments.Length-1)
        {
            dialogueDone = true;
            gameObject.SetActive(false);
        }
    }


    void StartMent()
    {
        StartCoroutine(typing());
    }
    IEnumerator typing()
    {
        Next.SetActive(false);
        Thumbnail.sprite = thumbImages[count];
        for (int i = 0; i <= Ments[count].Length; i++)
        {

            dialogueText.text = Ments[count].Substring(0, i);
            //Sfile.PlayOneShot(audios[1]);
            if (Input.GetKey(KeyCode.Space))
            {
                yield return null;

            }
            else
            {
                yield return new WaitForSecondsRealtime(0.01f);
            }

        }
        Next.SetActive(true);
        
    }
}
