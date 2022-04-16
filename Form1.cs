using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chessv3._0
{
    public partial class Form1 : Form
    {

        // дизайн
            private void bt_hide_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
            private void bt_close_Click(object sender, EventArgs e) => this.Close();
            Point lastPoint;// реализация перемещения гланого окна
            private void pnl_upper_MouseMove_1(object sender, MouseEventArgs e) {
             
                if (e.Button == MouseButtons.Left) { this.Left += e.X - lastPoint.X; this.Top += e.Y - lastPoint.Y; } 
            }
            // реализация перемещения гланого окна
            private void pnl_upper_MouseDown_1(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);

        // важное
            public int[,] map = new int[8, 8];              // поле фигур 
            public Panel[,] panels = new Panel[8, 8];       // поле панелей
            public Image chessSprite;                       // спрайт с фигурами

            public int curentPlayer;                        // текущий игрок
            public bool isMoving;                           // фигура в движении?

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()      
        {
            map = new int[8, 8] // Растановка фигур
            {
                {25,24,23,22,21,23,24,25},
                {26,26,26,26,26,26,26,26},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {16,16,16,16,16,16,16,16},
                {15,14,13,12,11,13,14,15}
            };
            curentPlayer = 1; // передать ход 1му игроку
            CreateMap();
        }
        
        // создание карты
        public void CreateMap()
        {
            // удваиваем цикл for для обработки всех строк и столбцов
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    // плитка шахматной доски
                    Panel newPanel = new Panel
                    {
                        Size = new Size(60, 60),
                        Location = new Point(60 * j, 60 * i)
                    };

                    newPanel.Click += new EventHandler(FigurePress);        // привязка к каждой клетке обработчик ее нажатия

                    // Отобразить игравое поле
                    pnl_map.Controls.Add(newPanel);
                    panels[i, j] = newPanel;


                    switch (map[i, j] / 10)               // расположение фигур на доске
                    {
                        case 1:
                            chessSprite = new Bitmap(Properties.Resources.chess);
                            Image part = new Bitmap(60, 60);
                            Graphics g = Graphics.FromImage(part);
                            g.DrawImage(chessSprite, new Rectangle(0, 0, 60, 60), 0 + 150 * (map[i, j] % 10 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            newPanel.BackgroundImage = part;
                            break;

                        case 2:
                            chessSprite = new Bitmap(Properties.Resources.chess);
                            Image part1 = new Bitmap(60, 60);
                            Graphics g1 = Graphics.FromImage(part1);
                            g1.DrawImage(chessSprite, new Rectangle(0, 0, 60, 60), 0 + 150 * (map[i, j] % 10 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            newPanel.BackgroundImage = part1;
                            break;
                    }
                }
            }
            CloseSteps();
        }

        Panel prevPanel;    // предидущая нажатая панель 
        public void FigurePress(object sender, EventArgs e)
        {
            if (prevPanel != null)
                CloseSteps();
            Panel pressedPanel = sender as Panel;
            if(map[pressedPanel.Location.Y / 60, pressedPanel.Location.X /60] != 0 && map[pressedPanel.Location.Y / 60, pressedPanel.Location.X / 60] / 10 == curentPlayer)
            {
                CloseSteps();
                pressedPanel.BackColor = ColorTranslator.FromHtml("#62819b");
                DeactivateMap();
                pressedPanel.Enabled = true;
                ShowSteps(pressedPanel.Location.Y / 60, pressedPanel.Location.X / 60, map[pressedPanel.Location.Y / 60, pressedPanel.Location.X / 60]);
                if (isMoving)
                {
                    CloseSteps();
                    ActivateMap();
                    isMoving = false;
                }
                else
                    isMoving = true;
            }
            else
            {
                if (isMoving)
                {
                    int temp = map[pressedPanel.Location.Y / 60, pressedPanel.Location.X / 60];
                    map[pressedPanel.Location.Y / 60, pressedPanel.Location.X / 60] = map[prevPanel.Location.Y / 60, prevPanel.Location.X / 60];
                    map[prevPanel.Location.Y / 60, prevPanel.Location.X / 60] = temp;
                    pressedPanel.BackgroundImage = prevPanel.BackgroundImage;
                    map[prevPanel.Location.Y / 60, prevPanel.Location.X / 60] = 0;
                    prevPanel.BackgroundImage = null;
                    isMoving = false;
                    CloseSteps();
                    ActivateMap();
                    SwitchPlayer();
                }
            }
            prevPanel = pressedPanel;
        }


        public void ShowSteps(int IcurrFigure, int JcurrFigure, int currFigure)
        {
            int dir = curentPlayer == 1 ? -1 : 1;
            switch (currFigure % 10)
            {
                case 6:
                    if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure))
                    {
                        if (map[IcurrFigure + 1 * dir, JcurrFigure] == 0)
                        {
                            panels[IcurrFigure + 1 * dir, JcurrFigure].BackgroundImage = Properties.Resources.moveIcon;
                            panels[IcurrFigure + 1 * dir, JcurrFigure].Enabled = true;
                            if(InsideBorder(IcurrFigure + 2 * dir, JcurrFigure) && (IcurrFigure == 1 || IcurrFigure == 6))
                            {
                                if(map[IcurrFigure + 2 * dir, JcurrFigure] == 0)
                                {
                                    panels[IcurrFigure + 2 * dir, JcurrFigure].BackgroundImage = Properties.Resources.moveIcon;
                                    panels[IcurrFigure + 2 * dir, JcurrFigure].Enabled = true;

                                }
                            }
                        }
                    }

                    if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure + 1))
                    {
                        if (map[IcurrFigure + 1 * dir, JcurrFigure + 1] != 0 && map[IcurrFigure + 1 * dir, JcurrFigure + 1] / 10 != curentPlayer)
                        {
                            panels[IcurrFigure + 1 * dir, JcurrFigure + 1].BackColor = Color.DarkSlateGray;
                            panels[IcurrFigure + 1 * dir, JcurrFigure + 1].Enabled = true;
                        }
                    }
                    if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure - 1))
                    {
                        if (map[IcurrFigure + 1 * dir, JcurrFigure - 1] != 0 && map[IcurrFigure + 1 * dir, JcurrFigure - 1] / 10 != curentPlayer)
                        {
                            panels[IcurrFigure + 1 * dir, JcurrFigure - 1].BackColor = BackColor = Color.DarkSlateGray;
                            panels[IcurrFigure + 1 * dir, JcurrFigure - 1].Enabled = true;
                        }
                    }
                    break;
                case 5:
                    ShowVerticalHorizontal(IcurrFigure, JcurrFigure);
                    break;
                case 3:
                    ShowDiagonal(IcurrFigure, JcurrFigure);
                    break;
                case 2:
                    ShowVerticalHorizontal(IcurrFigure, JcurrFigure);
                    ShowDiagonal(IcurrFigure, JcurrFigure);
                    break;
                case 1:
                    ShowVerticalHorizontal(IcurrFigure, JcurrFigure, true);
                    ShowDiagonal(IcurrFigure, JcurrFigure, true);
                    break;
                case 4:
                    ShowHorseSteps(IcurrFigure, JcurrFigure);
                    break;
            }
        }

        public void ShowHorseSteps(int IcurrFigure, int JcurrFigure)
        {
            if (InsideBorder(IcurrFigure - 2, JcurrFigure + 1))
            {
                DeterminePath(IcurrFigure - 2, JcurrFigure + 1);
            }
            if (InsideBorder(IcurrFigure - 2, JcurrFigure - 1))
            {
                DeterminePath(IcurrFigure - 2, JcurrFigure - 1);
            }
            if (InsideBorder(IcurrFigure + 2, JcurrFigure + 1))
            {
                DeterminePath(IcurrFigure + 2, JcurrFigure + 1);
            }
            if (InsideBorder(IcurrFigure + 2, JcurrFigure - 1))
            {
                DeterminePath(IcurrFigure + 2, JcurrFigure - 1);
            }
            if (InsideBorder(IcurrFigure - 1, JcurrFigure + 2))
            {
                DeterminePath(IcurrFigure - 1, JcurrFigure + 2);
            }
            if (InsideBorder(IcurrFigure + 1, JcurrFigure + 2))
            {
                DeterminePath(IcurrFigure + 1, JcurrFigure + 2);
            }
            if (InsideBorder(IcurrFigure - 1, JcurrFigure - 2))
            {
                DeterminePath(IcurrFigure - 1, JcurrFigure - 2);
            }
            if (InsideBorder(IcurrFigure + 1, JcurrFigure - 2))
            {
                DeterminePath(IcurrFigure + 1, JcurrFigure - 2);
            }
        }
        public void ShowDiagonal(int IcurrFigure, int JcurrFigure, bool isOneStep = false)
        {
            int j = JcurrFigure + 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = JcurrFigure + 1;
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }

        public void ShowVerticalHorizontal(int IcurrFigure, int JcurrFigure, bool isOneStep = false)
        {
            for (int i = IcurrFigure + 1; i < 8; i++)
            {
                if (InsideBorder(i, JcurrFigure))
                {
                    if (!DeterminePath(i, JcurrFigure))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int i = IcurrFigure - 1; i >= 0; i--)
            {
                if (InsideBorder(i, JcurrFigure))
                {
                    if (!DeterminePath(i, JcurrFigure))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = JcurrFigure + 1; j < 8; j++)
            {
                if (InsideBorder(IcurrFigure, j))
                {
                    if (!DeterminePath(IcurrFigure, j))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = JcurrFigure - 1; j >= 0; j--)
            {
                if (InsideBorder(IcurrFigure, j))
                {
                    if (!DeterminePath(IcurrFigure, j))
                        break;
                }
                if (isOneStep)
                    break;
            }
        }

        public bool DeterminePath(int IcurrFigure, int j)
        {
            if (map[IcurrFigure, j] == 0)
            {
                panels[IcurrFigure, j].BackgroundImage = Properties.Resources.moveIcon;
                panels[IcurrFigure, j].Enabled = true;
            }
            else
            {
                if (map[IcurrFigure, j] / 10 != curentPlayer)
                {
                    panels[IcurrFigure, j].BackColor = BackColor = Color.DarkSlateGray;
                    panels[IcurrFigure, j].Enabled = true;
                }
                return false;
            }
            return true;
        }

        public bool InsideBorder(int ti, int tj)
        {
            if (ti >= 8 || tj >= 8 || ti < 0 || tj < 0)
                return false;
            return true;
        }

        public void DeactivateMap()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    panels[i, j].Enabled = false;
        }
        public void ActivateMap()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    panels[i, j].Enabled = true;
        }

        //вернуть цвета
        public void CloseSteps()
        {
            var clr1 = ColorTranslator.FromHtml("#252C38");     // белые поля
            var clr2 = ColorTranslator.FromHtml("#6A7283");     // черные 
            for (int n = 0; n < 8; n++)
                for (int m = 0; m < 8; m++)
                {
                    // сброс меток для ходов
                    if (map[n, m] / 10 == 0) panels[n, m].BackgroundImage = null;

                    // Задаем цвет клеткам поля 
                    if (n % 2 == 0) panels[n, m].BackColor = m % 2 != 0 ? clr1 : clr2;
                    else panels[n, m].BackColor = m % 2 != 0 ? clr2 : clr1;
                }
        }

        // передача ходов
        public void SwitchPlayer() {
            if (curentPlayer == 1)
                curentPlayer = 2;
            else
                curentPlayer = 1;
        }
        // рестарт
        private void restart_Click(object sender, EventArgs e) { pnl_map.Controls.Clear(); Init(); }
    }
}
