using System;
using SplashKitSDK;

namespace _Game2048
{
    public class Program
    {
        public static void Main()
        {

            Window gameWindow = new Window("2048 Game", 800, 800);
            Game2048 game = new Game2048();

            while (!gameWindow.CloseRequested)
            {
                game.Reset();

                while (!gameWindow.CloseRequested && !game.IsGameOver())
                //&& !game.IsGameOver()
                {
                    gameWindow.Clear(Color.White);

                    if (SplashKit.KeyTyped(KeyCode.WKey) || SplashKit.KeyTyped(KeyCode.UpKey))
                    {
                        game.Move(Direction.Up);
                    }
                    else if (SplashKit.KeyTyped(KeyCode.SKey) || SplashKit.KeyTyped(KeyCode.DownKey))
                    {
                        game.Move(Direction.Down);
                    }
                    else if (SplashKit.KeyTyped(KeyCode.AKey) || SplashKit.KeyTyped(KeyCode.LeftKey))
                    {
                        game.Move(Direction.Left);
                    }
                    else if (SplashKit.KeyTyped(KeyCode.DKey) || SplashKit.KeyTyped(KeyCode.RightKey))
                    {
                        game.Move(Direction.Right);
                    }
                    // else if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                    // {
                    //     gameWindow.Close();
                    // }
                    game.Draw();
                    gameWindow.Refresh(60);
                    SplashKit.ProcessEvents();
                }
                SplashKit.Delay(5000);
            }
            //gameWindow.Close();
        }
    }


// public enum Direction
// {
//     Up,
//     Down,
//     Left,
//     Right
// }
// public class Game2048
// {
//     private int[,] _board;
//     private bool _hasMoved;
//     public Game2048()
//     {
//         _board = new int[4, 4];
//         _hasMoved = false;
//     }

//     public void Reset()
//     {

//         for (int row = 0; row < 4; row++)
//         {
//             for (int col = 0; col < 4; col++)
//             {
//                 _board[row, col] = 0;
//             }
//         }

//         AddRandomTile();
//         AddRandomTile();
//     }

//     private void MoveTile(int row, int col, int rowOffset, int colOffset)
//     {
//         while (_board[row, col] != 0)
//         {
//             int newRow = row + rowOffset;
//             int newCol = col + colOffset;

//             if (newRow < 0 || newRow >= 4 || newCol < 0 || newCol >= 4)
//             {
//                 break;
//             }

//             if (_board[newRow, newCol] == 0)
//             {
//                 _board[newRow, newCol] = _board[row, col];
//                 _board[row, col] = 0;
//                 row = newRow;
//                 col = newCol;
//                 _hasMoved = true;
//             }
//             else if (_board[newRow, newCol] == _board[row, col])
//             {
//                 _board[newRow, newCol] *= 2;
//                 _board[row, col] = 0;
//                 _hasMoved = true;
//                 break;
//             }
//             else
//             {
//                 break;
//             }
//         }
//     }

//     public void Move(Direction direction)
//     {
//         switch (direction)
//         {
//             case Direction.Up:
//                 for (int col = 0; col < 4; col++)
//                 {
//                     for (int row = 1; row < 4; row++)
//                     {
//                         MoveTile(row, col, -1, 0);
//                     }
//                 }
//                 break;
//             case Direction.Down:
//                 for (int col = 0; col < 4; col++)
//                 {
//                     for (int row = 2; row >= 0; row--)
//                     {
//                         MoveTile(row, col, 1, 0);
//                     }
//                 }
//                 break;
//             case Direction.Left:
//                 for (int row = 0; row < 4; row++)
//                 {
//                     for (int col = 1; col < 4; col++)
//                     {
//                         MoveTile(row, col, 0, -1);
//                     }
//                 }
//                 break;
//             case Direction.Right:
//                 for (int row = 0; row < 4; row++)
//                 {
//                     for (int col = 2; col >= 0; col--)
//                     {
//                         MoveTile(row, col, 0, 1);
//                     }
//                 }
//                 break;
//         }

//         if (_hasMoved)
//         {
//             AddRandomTile();
//         }
//     }

//     private void AddRandomTile()
//     {
//         List<(int row, int col)> emptySpaces = new List<(int, int)>();
//         for (int i = 0; i < 4; i++)
//         {
//             for (int j = 0; j < 4; j++)
//             {
//                 if (_board[i, j] == 0)
//                 {
//                     emptySpaces.Add((i, j));
//                 }
//             }
//         }
//         if (emptySpaces.Count == 0) return;
//         Random random = new Random();
//         (int row, int col) = emptySpaces[random.Next(emptySpaces.Count)];
//         _board[row, col] = random.Next(1, 3) * 2;
//     }

//     private bool CanMove()
//     {
//         for (int row = 0; row < 4; row++)
//         {
//             for (int col = 0; col < 4; col++)
//             {
//                 if (_board[row, col] == 0)
//                 {
//                     return true;
//                 }
//                 if (row < 3 && _board[row, col] == _board[row + 1, col])
//                 {
//                     return true;
//                 }
//                 if (col < 3 && _board[row, col] == _board[row, col + 1])
//                 {
//                     return true;
//                 }
//             }
//         }

//         return false;
//     }

//     public void Draw()
//     {
//         int cellSize = 150;
//         int cellPadding = 16;

//         for (int row = 0; row < 4; row++)
//         {
//             for (int col = 0; col < 4; col++)
//             {
//                 int x = col * cellSize + cellPadding;
//                 int y = row * cellSize + cellPadding;

//                 SplashKit.FillRectangle(Color.Gray, x, y, cellSize - cellPadding, cellSize - cellPadding);

//                 if (_board[row, col] != 0)
//                 {
//                     string text = _board[row, col].ToString();
//                     int textSize = cellSize / 2;
//                     Color textColor;
//                     if (_board[row, col] == 4)
//                     {
//                         textColor = Color.White;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 2)
//                     {
//                         textColor = Color.Black;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 8)
//                     {
//                         textColor = Color.Green;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 16)
//                     {
//                         textColor = Color.LightBlue;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 32)
//                     {
//                         textColor = Color.DarkBlue;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 64)
//                     {
//                         textColor = Color.Pink;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 128)
//                     {
//                         textColor = Color.Yellow;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 256)
//                     {
//                         textColor = Color.Orange;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 512)
//                     {
//                         textColor = Color.Red;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 1024)
//                     {
//                         textColor = Color.DarkKhaki;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                     else if (_board[row, col] == 2048)
//                     {
//                         textColor = Color.MediumSeaGreen;
//                         SplashKit.DrawText(text, textColor, "Arial.ttf", textSize, x + (cellSize - cellPadding) / 2 - (SplashKit.TextWidth(text, "Arial.ttf", textSize) / 2), y + (cellSize - cellPadding) / 2 - (int)(SplashKit.TextHeight(text, "Arial.ttf", (int)textSize) / 2));
//                     }
//                 }
//             }
//         }

//         bool gameOver = IsGameOver();
//         if (gameOver)
//         {
//             int textSize = cellSize / 2;
//             string gameOverText = "Game Over";

//             SplashKit.DrawText(gameOverText, Color.DarkRed, "Arial.ttf", textSize, cellSize * 2 - (SplashKit.TextWidth(gameOverText, "Arial.ttf", textSize) / 2), cellSize * 2 - (SplashKit.TextHeight(gameOverText, "Arial.ttf", textSize) / 2));
//         }
//     }

//     public bool HasWon()
//     {
//         for (int row = 0; row < 4; row++)
//         {
//             for (int col = 0; col < 4; col++)
//             {
//                 if (_board[row, col] == 2048)
//                 {
//                     return true;
//                 }
//             }
//         }

//         return false;
//     }

//     public bool IsGameOver()
//     {
//         return !CanMove() || HasWon();
//     }
// }
}