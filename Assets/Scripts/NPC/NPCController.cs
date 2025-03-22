using UnityEngine;

namespace WinterUniverse
{
    public class NPCController : PawnController
    {
        public override void Initialize()
        {
            base.Initialize();
            Initialize("Wanderer");
        }

        public void Initialize(string npcConfig)
        {
            foreach (StateCreator sc in GameManager.StaticInstance.ConfigsManager.GetStateCreator(npcConfig).States)
            {
                _status.StateHolder.SetStateValue(sc.Config.Key, sc.Value);
            }
        }
    }
}