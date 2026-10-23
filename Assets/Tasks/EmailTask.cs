using System.Threading.Tasks;
using UnityEngine;

namespace Environment.Tasks{ 
[CreateAssetMenu(fileName = "EmailTask", menuName = "Scriptable Objects/EmailTask")]
public class EmailTask : Task
{
  [SerializeField] private string taskDescription = "Keep up with your correspondences";
  [SerializeField] ScriptableObject beastCoin;
        public int beastAmount = 50000;
     public override void Execute()
     {
        //beastCoin.AddCoins(beastAmount);
     }


}
}