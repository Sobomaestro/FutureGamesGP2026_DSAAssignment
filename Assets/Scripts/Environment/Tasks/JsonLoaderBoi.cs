using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "JsonReader", menuName = "JsonReader Task")]
    public class JsonLoaderBoi : Task {
        [SerializeField] private string textToPrint;
        [SerializeField] private TextAsset jsonFile;

        public string JsonTransfer() {

            return jsonFile.ToString();

        }
        public override void Execute() {

        }
    }
}
