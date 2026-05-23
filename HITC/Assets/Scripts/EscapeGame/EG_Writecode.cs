using TMPro;
using UnityEngine;

public class EG_Writecode : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mTMP;
    [SerializeField] AudioClip mErrorSound;
    [SerializeField] AudioClip mSuccessSound;
    private string mInputCode = ""; 
    private string mtheCode = "123";
    private AudioSource mAS;
    private void Awake()
    {
        mAS = GetComponent<AudioSource>();
    }

    public void onButtonPressedWriteNumber(string value)
    {
        if(mInputCode.Length >= 3)
        {
            mAS.PlayOneShot(mAS.clip);// Son d'erreur
            return;
        }

        mInputCode += value;
        updateDisplay();
        Debug.Log("Code saisi : " + mInputCode);
    }
    public void onButtonPressedDelete()
    {
        if (mInputCode.Length > 0)
        {
            mInputCode = mInputCode.Substring(0, mInputCode.Length - 1);
            updateDisplay();
        }
        else
        {
            mAS.PlayOneShot(mErrorSound);// Son d'erreur
        }
    }
    public void onButtonPressedValidate()
    {
        if (mInputCode.Equals(mtheCode))
        {
            Debug.Log("Code correct !");
            mAS.PlayOneShot(mSuccessSound);
            // Code pour ouvrir la porte ou déclencher l'événement
        }
        else
        {
            Debug.Log("Code incorrect !");
            mAS.PlayOneShot(mErrorSound);// Son d'erreur
            mInputCode = "";
            updateDisplay();
        }
    }
    private void updateDisplay()
    {
        mTMP.text = mInputCode + new string('_', 3 - mInputCode.Length);
    }
}
