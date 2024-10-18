using System;
namespace Astar_ile_Sudoku
{
    public partial class Form1 : Form
    {
        int[,] map = Sudoku_environment.Sudoku_map1;
        Panel[] panels;

        public Form1()
        {
            InitializeComponent();
            panels = new Panel[] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map_load();
        }

        private void map_load()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Her hücrenin hangi panele ait olduðunu formülle bulalým
                    int panelIndex = (i / 3) * 3 + (j / 3);

                    // Panel içindeki konumu hesapla (lokal koordinatlar)
                    int localX = (i % 3) * 50;
                    int localY = (j % 3) * 50;

                    Button k = btn_create(localY, localX, map[i, j]);
                    panels[panelIndex].Controls.Add(k);
                }
            }
        }

        private Button btn_create(int x, int y, int z)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Size = new Size(50, 50);
            if (z != 0)
            {
                btn.Text = z.ToString();
                btn.Enabled = false;  // Önceden belirlenmiþ hücreler deðiþtirilmesin
            }
            return btn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çok Yakýnda");
        }
    }

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