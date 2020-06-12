using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace PVA_Snake
{
    public partial class Form1 : Form
    {
        // Game grid set to 28x28, each tile is 16px x 16px
        private List<Tile> snake = new List<Tile>();
        private List<string> scores = new List<string>();
        private Tile food = new Tile();

        public Form1()
        {
            InitializeComponent();

            //Parameters initialization after program launch    
            new GameProperties();

            //Initialization of timer and setting up game speed
            timer.Interval = GameProperties.gameSpeed;
            timer.Tick += UpdateScreen;
            timer.Start();

            //Loading save file
            SaveFileLoad();

            StartGame();
        }

        private void StartGame()
        {
            //New game preparation
            labelGameOver.Visible = false;
            labelHelperGameOver.Visible = false;
            new GameProperties();
            timer.Interval = GameProperties.gameSpeed;
            snake.Clear();
            labelScore.Text = GameProperties.score.ToString();

            //Player creation
            Tile head = new Tile { X = 14, Y = 14 };
            snake.Add(head);

            GenerateFood();
        }

        private void GenerateFood()
        {
            //Calculating last tile in both axes
            int maxX = (panelPlayArea.Size.Width / GameProperties.tileWidth) - 1;
            int maxY = (panelPlayArea.Size.Height / GameProperties.tileHeight) - 1;

            //Spawing food in random location
            Random random = new Random();
            food = new Tile { X = random.Next(0, maxX), Y = random.Next(0, maxY) };
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (GameProperties.gameEnd == true)
            {
                if(Input.KeyPressed(Keys.Space))
                {
                    StartGame();
                }
            }
            else
            {
                //Setting direction
                if (Input.KeyPressed(Keys.Left) && GameProperties.direction != Directions.Right)
                    GameProperties.direction = Directions.Left;
                if (Input.KeyPressed(Keys.Right) && GameProperties.direction != Directions.Left)
                    GameProperties.direction = Directions.Right;
                if (Input.KeyPressed(Keys.Up) && GameProperties.direction != Directions.Down)
                    GameProperties.direction = Directions.Up;
                if (Input.KeyPressed(Keys.Down) && GameProperties.direction != Directions.Up)
                    GameProperties.direction = Directions.Down;

                MovePlayer();
            }

            panelPlayArea.Invalidate();
        }

        private void MovePlayer()
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    //Head movement
                    switch (GameProperties.direction)
                    {
                        case Directions.Left:
                            snake[i].X--;
                            break;
                        case Directions.Right:
                            snake[i].X++;
                            break;
                        case Directions.Up:
                            snake[i].Y--;
                            break;
                        case Directions.Down:
                            snake[i].Y++;
                            break;
                    }

                    //Calculating bottom and right border
                    int maxX = panelPlayArea.Size.Width / GameProperties.tileWidth;
                    int maxY = panelPlayArea.Size.Height / GameProperties.tileHeight;

                    //Check for colission with borders
                    if (snake[i].X < 0 || snake[i].X >= maxX || snake[i].Y < 0 || snake[i].Y >= maxY)
                    {
                        Die();
                    }

                    //Check for colission with snakes body
                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                        {
                            Die();
                        }
                    }

                    //Check for colission with food
                    if (snake[i].X == food.X && snake[i].Y == food.Y)
                    {
                        Eat();
                    }
                }
                else
                {
                    //Body movement
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
        }

        private void Eat()
        {
            //Adding new tile to snakes body
            Tile tile = new Tile
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };
            snake.Add(tile);

            //Score increase
            GameProperties.score += GameProperties.foodScoreValue;
            labelScore.Text = GameProperties.score.ToString();

            //Speed increase
            if (timer.Interval != 1)
            {
                timer.Interval -= 1;
            }

            GenerateFood();
        }

        private void Die()
        {
            GameProperties.gameEnd = true;
            //Displaying players name prompt
            string name = Prompt.ShowDialog();
            //Adding score to list
            scores.Add(GameProperties.score + ":" + name);
            //Následující region použítý ze Stack Overflow
            //Score sorting
            #region
            scores = scores.Select(s => new { Str = s, Split = s.Split(':') })
            .OrderByDescending(x => int.Parse(x.Split[0]))
            .ThenBy(x => x.Split[1])
            .Select(x => x.Str)
            .ToList();
            #endregion
            //Placing score to listBox
            listBoxScores.Items.Clear();
            for (int i = 0; i < scores.Count; i++)
            {
                listBoxScores.Items.Add(scores[i]);
            }
        }

        private void panelPlayArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b = Brushes.Black;

            if (!GameProperties.gameEnd)
            {
                for (int i = 0; i < snake.Count; i++)
                {
                    //Draw snake
                    g.FillRectangle(b, new Rectangle(snake[i].X * GameProperties.tileWidth, snake[i].Y * GameProperties.tileHeight, GameProperties.tileWidth, GameProperties.tileHeight));
                    //Draw food
                    g.FillRectangle(b, new Rectangle(food.X * GameProperties.tileWidth, food.Y * GameProperties.tileHeight, GameProperties.tileWidth, GameProperties.tileHeight));
                }
            }
            else
            {
                //Displaying game over message
                labelGameOver.Visible = true;
                labelHelperGameOver.Visible = true;
            }
        }

        private void SaveFileSave()
        {
            using (StreamWriter writter = new StreamWriter(@"save/save.txt"))
            {
                foreach (string value in scores)
                {
                    writter.WriteLine(value);
                }
            }
        }

        private void SaveFileLoad()
        {
            using (StreamReader reader = new StreamReader(@"save/save.txt"))
            {
                List<string> lines = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                for (int i = 0; i < lines.Count; i++)
                {
                    scores.Add(lines[i]);
                }
                for (int i = 0; i < scores.Count; i++)
                {
                    listBoxScores.Items.Add(scores[i]);
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFileSave();
        }
    }
}