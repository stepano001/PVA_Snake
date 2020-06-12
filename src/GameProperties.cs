namespace PVA_Snake
{
    public enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }
    class GameProperties
    {
        public static int tileWidth { get; set; }
        public static int tileHeight { get; set; }
        public static int gameSpeed { get; set; }
        public static int score { get; set; }
        public static int foodScoreValue { get; set; }
        public static bool gameEnd { get; set; }
        public static Directions direction { get; set; }

        public GameProperties()
        {
            tileWidth = 16;
            tileHeight = 16;
            gameSpeed = 100; //Smaller number == greater speed
            score = 0;
            foodScoreValue = 100;
            gameEnd = false;
            direction = Directions.Left;
        }
    }
}
