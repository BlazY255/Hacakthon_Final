using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public TMP_InputField xInputField;
    public TMP_InputField yInputField;
    public TMP_Text description;

    public bool isLaserPc;
    
    public List<PlatformData> platformDataList;

    [System.Serializable]
    public class PlatformData
    {
        public List<int> XValues;
        public List<int> YValues;
        public int PlatformId;
        public string Description;
    }

    private void Start()
    {
        xInputField.onValueChanged.AddListener(CheckInput);
        yInputField.onValueChanged.AddListener(CheckInput);
    }

    private void CheckInput(string input)
    {

        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        int value;
        if (int.TryParse(input, out value))
        {
            if (value > 998)
            {
                value = 998;
            }
        }

        TMP_InputField inputField = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject
            .GetComponent<TMP_InputField>();
        inputField.text = value.ToString();
    }

    public void CheckAnswers()
    {
        int xValue = 0;
        int.TryParse(xInputField.text, out xValue);

        int yValue = 0;
        int.TryParse(yInputField.text, out yValue);

        foreach (var data in platformDataList)
        {
            if (data.XValues.Contains(xValue) && data.YValues.Contains(yValue))
            {
                GameManager.instance.levelManager.SetPlatformActive(data.PlatformId, true, isLaserPc);
                return;
            }
        }
    }
}