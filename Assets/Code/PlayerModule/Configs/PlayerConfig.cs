using UnityEngine;

namespace Code.PlayerModule.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerModule/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public float speed;
    }
}
