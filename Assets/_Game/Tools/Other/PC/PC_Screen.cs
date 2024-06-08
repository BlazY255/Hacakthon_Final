using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class PC_Screen : MonoBehaviour
{
    public float screenUpTime;
    public RectTransform screen;
    public GameObject text;
    public GameObject screenOnButton;

    public CodePanel codePanel;
    public int currentId;
    
    public float timeToColor;
    
    private float screenCurrentPos;
    private Interactable.InteractableType type = Interactable.InteractableType.PC;
    
    private void Awake()
    {
        screenCurrentPos = screen.anchoredPosition.y;
    }
    public void LaunchScreenUp()
    {
        StartCoroutine(MoveScreenUp());
    }
    public void LaunchScreenDown()
    {
        screenOnButton.GetComponent<Image>().DOColor(Color.red, timeToColor).onComplete += () =>
        {
            StartCoroutine(MoveScreenDown());
        };
    }

    //screen movement
    private IEnumerator MoveScreenUp()
    {
        codePanel.xInputField.text = "";
        codePanel.yInputField.text = "";
        codePanel.description.text = "";

        // Find the corresponding PlatformData and update the description
        foreach (var data in codePanel.platformDataList)
        {
            if (data.PlatformId == currentId)
            {
                codePanel.description.text = data.Description;
                break;
            }
        }
        float elapsedTime = 0;
        float duration = screenUpTime;
        Vector2 startPosition = screen.anchoredPosition; 
        Vector2 targetPosition = new Vector2(screen.anchoredPosition.x, -150); 

        while (elapsedTime < duration)
        {
            Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);
            
            screen.anchoredPosition = newPosition;
            
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }

        screen.anchoredPosition = targetPosition;
        screenOnButton.GetComponent<Image>().DOColor(Color.green, timeToColor).onComplete += () =>
        {
            text.SetActive(true);
        };
    }
    
    private IEnumerator MoveScreenDown()
    {
        text.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        
        float elapsedTime = 0;
        float duration = screenUpTime;
        Vector2 startPosition = screen.anchoredPosition;
        Vector2 targetPosition = new Vector2(screen.anchoredPosition.x, screenCurrentPos);

        while (elapsedTime < duration)
        {
            Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);

            screen.anchoredPosition = newPosition;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        screen.anchoredPosition = targetPosition;
        GameManager.instance.UIManager.EnableUseButton(true,type);
        codePanel.CheckAnswers();
        screen.transform.parent.gameObject.SetActive(false); 
    }
}
