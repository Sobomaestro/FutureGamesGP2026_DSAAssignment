using Environment;
using Environment.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;
namespace Environment
{
    public class ComputerTaskPanel : MonoBehaviour
    {

        [SerializeField] Computer computer;
        [SerializeField] Button taskBtn;
        [SerializeField] Button eMailBtn;
        [SerializeField] Button gameBtn;
        [SerializeField] TextMeshProUGUI textBox;
        [SerializeField] CanvasGroup beast;
        [SerializeField] TextMeshProUGUI mailInput;
        [SerializeField] Transform InputPanel;
        [SerializeField] Button mailSend;
        [SerializeField] CanvasGroup mailPanel;
        [SerializeField] Canvas computerUI;
        [SerializeField] playerTaskManager taskManager;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private int gameClickCounter; 
        void Awake()
        {
            mailPanel.interactable = false;
        }
        void Update()
        {
            if (Input.GetButton("Cancel"))
            {
                computerUI.enabled = false;
            }
        }
        public void EmailBtn()
        {
            string beastMail = "Hello, This is mr baest. Thanks you for watchig all of my vidos. You aer bigest fan, i rewrad you with free $BeastCoins$. Replay with yor credit card detaels, teh dtae of your berfth, the naem of yiur fisrt pet, an ur favriote clolr";
            mailPanel.interactable = true;
            beast.alpha = 1;
            textBox.text = beastMail;
        }
        public void TaskBtn()
        {
            mailPanel.interactable = false;
            beast.alpha = 0;
            string printThis = computer.AddTask();
            textBox.text = "Current Task: " + printThis;
        }
        public void GamesBtn()
        {
            beast.alpha = 0;
            gameClickCounter++;
            if (gameClickCounter <= 10)
            {
                textBox.text = "Not until you have completed all of your tasks....";
            }
            else if (gameClickCounter >= 24)
            {
                
#if UNITY_EDITOR
                if (EditorApplication.isPlaying)
                { EditorApplication.ExitPlaymode(); }
#endif
                Application.Quit();
            }
            else if (gameClickCounter >= 20)
            {
                textBox.text = "You have been warned...";
            }
            else if (gameClickCounter >= 10)
            {
                textBox.text = "HR has been notified on your work ethics, if you proceed with this behavior we will take action regarding your employment.";                
            }
            
            
        }
        public void SendBtn()
        {
            textBox.text += "\r\n - - - - - - - - -  \r\n " + mailInput.text.ToString();
            mailInput.text = " ";
            mailPanel.interactable = false;
            beast.alpha = 0;
            Task currentTask = taskManager.TaskExecutor();
            currentTask.Execute();
        }
        public void ExitBtn()
        {
            computerUI.enabled = false;
        }

    }
}