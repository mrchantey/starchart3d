using UnityEngine;


namespace Ahoy{

    public class Gen010LogAction:MonoBehaviour{
        public string prefix = "gen010 log action";
        public void Log(gen010 val){
            Debug.Log($"{prefix}: {val}");
        }

    }
}