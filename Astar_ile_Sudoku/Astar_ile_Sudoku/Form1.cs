using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Astar_ile_Sudoku
{
    public partial class Form1 : Form
    {
        int[,] map = Sudoku_environment.Sudoku_map1;
        private static Panel[] panels;
        private static List<Button> buttons = new List<Button>();
        private string filePath = "AstarSteps.txt"; // Statik olmayan deðiþken
        private int stepCounter = 0; // Statik olmayan deðiþken

        public Form1()
        {
            InitializeComponent();
            panels = new Panel[] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map_load();
        }

        // Sudoku tahtasýný ve butonlarý oluþtur
        private void map_load()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int panelIndex = (i / 3) * 3 + (j / 3);
                    int localX = (i % 3) * 50;
                    int localY = (j % 3) * 50;

                    Button k = btn_create(localY, localX, map[i, j]);
                    buttons.Add(k);
                    panels[panelIndex].Controls.Add(k);
                }
            }
        }

        // Buton oluþtur
        private Button btn_create(int x, int y, int z)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Size = new Size(50, 50);
            if (z != 0)
            {
                btn.Text = z.ToString();
                btn.Enabled = false;  // Önceden belirlenmiþ hücreler
            }
            return btn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çok yakýnda");
        }

        // A* algoritmasýnýn baþlatýlmasý
        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(filePath, "A* Algoritmasý Adýmlarý:\n"); // Dosyayý temizle ve baþlýk yaz
            stepCounter = 0; // Adým sayacýný sýfýrla
            if (Astar.Astar_Sudoku(map, this))
            {
                File.AppendAllText(filePath, "Sudoku baþarýyla çözüldü!\n");
                MessageBox.Show("Sudoku baþarýyla çözüldü!");
            }
            else
            {
                File.AppendAllText(filePath, "Sudoku çözülemedi.\n");
                MessageBox.Show("Sudoku çözülemedi.");
            }
        }

        // Sudoku tahtasýný güncelleme
        public void UpdateBoard(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttons[i * 9 + j].Text = board[i, j] == 0 ? "" : board[i, j].ToString();
                }
            }
        }

        // A* algoritmasýnýn Sudoku çözümü
        class Astar
        {
            // Boþ hücre bulma
            private static (int, int)? Bos_hucre(int[,] board)
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            return (row, col);
                        }
                    }
                }
                return null; // Boþ hücre yoksa
            }

            // Maliyet (g) fonksiyonu: Çözülen hücrelerin sayýsý
            private static int Cost(int[,] board)
            {
                int cost = 0;
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (board[row, col] != 0)
                        {
                            cost++;  // Dolu hücreler sayýlýr
                        }
                    }
                }
                return cost;
            }

            // Heuristic (h) fonksiyonu: Kalan boþ hücre sayýsý
            private static int Heuristic(int[,] board)
            {
                int heuristic = 0;
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            heuristic++;  // Boþ hücreleri sayar
                        }
                    }
                }
                return heuristic;
            }

            // A* algoritmasý ile Sudoku çözme
            public static bool Astar_Sudoku(int[,] board, Form1 form)
            {
                var emptyCell = Bos_hucre(board);
                if (emptyCell == null)
                {
                    return true; // Tüm hücreler dolu, çözüm bulundu
                }

                int row = emptyCell.Value.Item1;
                int col = emptyCell.Value.Item2;

                // 1'den 9'a kadar her rakamý deneyelim
                for (int num = 1; num <= 9; num++)
                {
                    if (IsValid(board, row, col, num))
                    {
                        board[row, col] = num;

                        // Sudoku tahtasýný güncelleyin
                        form.UpdateBoard(board);
                        form.stepCounter++; // Adým sayýsýný artýr
                        File.AppendAllText(form.filePath, $"Adým {form.stepCounter}: {num} yerleþtirildi ({row + 1}, {col + 1})\n");

                        // Geçerli çözüm bulunduysa devam et
                        if (Astar_Sudoku(board, form))
                        {
                            return true;
                        }

                        // Geçersizse geri al
                        board[row, col] = 0; // Geri al
                        File.AppendAllText(form.filePath, $"Adým {form.stepCounter}: {num} geri alýndý ({row + 1}, {col + 1})\n");
                        form.UpdateBoard(board);
                    }
                }

                return false; // Geçerli çözüm yoksa
            }

            // Belirtilen hücreye rakam yerleþtirilebilir mi kontrolü
            private static bool IsValid(int[,] board, int row, int col, int num)
            {
                // Satýr, sütun ve 3x3 kare kontrolü
                for (int x = 0; x < 9; x++)
                {
                    if (board[row, x] == num || board[x, col] == num)
                    {
                        return false;
                    }
                }
                int startRow = row - row % 3;
                int startCol = col - col % 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i + startRow, j + startCol] == num)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        // Sudoku tahtasý baþlangýç verisi
        class Sudoku_environment
        {
            public static int[,] Sudoku_map1 = {
                {0,0,9,0,0,0,0,0,2},
                {8,7,5,0,0,0,0,0,0},
                {0,0,1,0,0,0,3,0,9},
                {0,0,0,0,0,0,7,0,0},
                {0,0,0,5,0,7,0,9,0},
                {1,0,0,8,0,0,5,0,0},
                {4,0,0,0,0,9,0,0,0},
                {0,0,0,0,3,0,0,4,6},
                {0,8,0,0,1,0,0,0,0}
            };
        }
    }
}
