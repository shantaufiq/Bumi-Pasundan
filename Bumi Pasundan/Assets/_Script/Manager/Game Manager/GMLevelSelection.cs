namespace BumiPasundan
{
    public class GMLevelSelection : GameManager
    {
        public static GMLevelSelection instance;
        public int level;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            SoundManager.Instance.PlayMusic();
        }

        public void PlayLevelCutScene(int _level)
        {
            level = _level;
        }
    }
}
