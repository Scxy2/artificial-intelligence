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
        private string filePath = "AstarSteps.txt"; // Statik olmayan de�i�ken
        private int stepCounter = 0; // Statik olmayan de�i�ken

        public Form1()
        {
            InitializeComponent();
            panels = new Panel[] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map_load();
        }

        // Sudoku tahtas�n� ve butonlar� olu�tur
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

        // Buton olu�tur
        private Button btn_create(int x, int y, int z)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Size = new Size(50, 50);
            if (z != 0)
            {
                btn.Text = z.ToString();
                btn.Enabled = false;  // �nceden belirlenmi� h�creler
            }
            return btn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�ok yak�nda");
        }

        // A* algoritmas�n�n ba�lat�lmas�
        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(filePath, "A* Algoritmas� Ad�mlar�:\n"); // Dosyay� temizle ve ba�l�k yaz
            stepCounter = 0; // Ad�m sayac�n� s�f�rla
            if (Astar.Astar_Sudoku(map, this))
            {
                File.AppendAllText(filePath, "Sudoku ba�ar�yla ��z�ld�!\n");
                MessageBox.Show("Sudoku ba�ar�yla ��z�ld�!");
            }
            else
            {
                File.AppendAllText(filePath, "Sudoku ��z�lemedi.\n");
                MessageBox.Show("Sudoku ��z�lemedi.");
            }
        }

        // Sudoku tahtas�n� g�ncelleme
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

        // A* algoritmas�n�n Sudoku ��z�m�
        class Astar
        {
            // Bo� h�cre bulma
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
                return null; // Bo� h�cre yoksa
            }

            // Maliyet (g) fonksiyonu: ��z�len h�crelerin say�s�
            private static int Cost(int[,] board)
            {
                int cost = 0;
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (board[row, col] != 0)
                        {
                            cost++;  // Dolu h�creler say�l�r
                        }
                    }
                }
                return cost;
            }

            // Heuristic (h) fonksiyonu: Kalan bo� h�cre say�s�
            private static int Heuristic(int[,] board)
            {
                int heuristic = 0;
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            heuristic++;  // Bo� h�creleri sayar
                        }
                    }
                }
                return heuristic;
            }

            // A* algoritmas� ile Sudoku ��zme
            public static bool Astar_Sudoku(int[,] board, Form1 form)
            {
                var emptyCell = Bos_hucre(board);
                if (emptyCell == null)
                {
                    return true; // T�m h�creler dolu, ��z�m bulundu
                }

                int row = emptyCell.Value.Item1;
                int col = emptyCell.Value.Item2;

                // 1'den 9'a kadar her rakam� deneyelim
                for (int num = 1; num <= 9; num++)
                {
                    if (IsValid(board, row, col, num))
                    {
                        board[row, col] = num;

                        // Sudoku tahtas�n� g�ncelleyin
                        form.UpdateBoard(board);
                        form.stepCounter++; // Ad�m say�s�n� art�r
                        File.AppendAllText(form.filePath, $"Ad�m {form.stepCounter}: {num} yerle�tirildi ({row + 1}, {col + 1})\n");

                        // Ge�erli ��z�m bulunduysa devam et
                        if (Astar_Sudoku(board, form))
                        {
                            return true;
                        }

                        // Ge�ersizse geri al
                        board[row, col] = 0; // Geri al
                        File.AppendAllText(form.filePath, $"Ad�m {form.stepCounter}: {num} geri al�nd� ({row + 1}, {col + 1})\n");
                        form.UpdateBoard(board);
                    }
                }

                return false; // Ge�erli ��z�m yoksa
            }

            // Belirtilen h�creye rakam yerle�tirilebilir mi kontrol�
            private static bool IsValid(int[,] board, int row, int col, int num)
            {
                // Sat�r, s�tun ve 3x3 kare kontrol�
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

        // Sudoku tahtas� ba�lang�� verisi
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
