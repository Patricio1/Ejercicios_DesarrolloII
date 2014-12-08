using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamePuzzle
/*Ing. Teran 095013739  2828940  */
{
    public partial class FrmMain : Form
    {
        private int CrrentPictureNumber;
        private Point EmptyLocation;
        private MyButton[] ButtonArray;
        private bool YouWin;
        private int NumberOfMoves;
        private FrmShowCurrentImage MyFrmShowCurrentImage;
        public event EventHandler CurrentImageChanged;

        public FrmMain()
        {
            InitializeComponent();
            
        }

        

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAboutBox F = new FrmAboutBox();
            F.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.LoadNewGame();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadNewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void myButton_LocationChanged(object sender, EventArgs e)
        {
            MyButton A = sender as MyButton;
            YouWin = true;
            int ButtonNumber;
            this.NumberOfMoves++;
            for (int i = 0; i < 4; i++)
            {
                if (YouWin == false)
                    break;
                else for (int j = 0; j < 4; j++)
                    {
                        ButtonNumber = i * 5 + j;
                        if (i == 4 && j == 4)
                            break;
                        else if (GetNumber(ButtonArray[ButtonNumber].Location.X, ButtonArray[ButtonNumber].Location.Y) == ButtonArray[ButtonNumber].Number)
                            continue;
                        else
                        {
                            YouWin = false;
                            break;
                        }
                    }
            }
            if (YouWin)
            {

                if (MessageBox.Show("Usted ha ganado el juego en " + this.NumberOfMoves.ToString() + " Movimientos\n\rQuiere jugar otra vez ?", "Felicitaciones", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    this.LoadNewGame();
                else
                    this.Close();
            }
        }

        private void myButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((b.Location.X - 75 == EmptyLocation.X) && (b.Location.Y == EmptyLocation.Y))
            {
                b.Location = EmptyLocation;
                EmptyLocation.X += 75;
                this.Focus();
            }
            else if (b.Location.X + 75 == EmptyLocation.X && (b.Location.Y == EmptyLocation.Y))
            {
                b.Location = EmptyLocation;
                EmptyLocation.X -= 75;
                this.Focus();
            }
            else if (b.Location.Y - 75 == EmptyLocation.Y && (b.Location.X == EmptyLocation.X))
            {
                b.Location = EmptyLocation;
                EmptyLocation.Y += 75;
                this.Focus();
            }

            else if (b.Location.Y + 75 == EmptyLocation.Y && (b.Location.X == EmptyLocation.X))
            {
                b.Location = EmptyLocation;
                EmptyLocation.Y -= 75;
                this.Focus();
            }
        }

        private void LoadNewGame()
        {
            this.myButton1.Location = new System.Drawing.Point(20, 40);
            this.myButton2.Location = new System.Drawing.Point(95, 40);
            this.myButton3.Location = new System.Drawing.Point(170, 40);
            this.myButton4.Location = new System.Drawing.Point(245, 40);  
            //ELEMENTO BACIO
            this.myButton5.Location = new System.Drawing.Point(245, 265);           
            this.myButton6.Location = new System.Drawing.Point(95, 115);    
            this.myButton7.Location = new System.Drawing.Point(170, 115);            
            this.myButton8.Location = new System.Drawing.Point(245, 115);           
            this.myButton9.Location = new System.Drawing.Point(20, 190);         
            this.myButton10.Location = new System.Drawing.Point(95, 190);
            this.myButton11.Location = new System.Drawing.Point(170, 190);           
            this.myButton12.Location = new System.Drawing.Point(245, 190);           
            this.myButton13.Location = new System.Drawing.Point(20, 265);          
           this.myButton14.Location = new System.Drawing.Point(95, 265);      
            this.myButton15.Location = new System.Drawing.Point(170, 265);

            if (this.CrrentPictureNumber == 7)
                this.CrrentPictureNumber = 1;
            else
                this.CrrentPictureNumber++;

            this.EmptyLocation = new Point(20, 115);//
            this.NumberOfMoves = 0;
            this.ButtonArray = new MyButton[15];

            this.ButtonArray[0] = this.myButton1;
            this.ButtonArray[1] = this.myButton2;
            this.ButtonArray[2] = this.myButton3;
            this.ButtonArray[3] = this.myButton4;
            this.ButtonArray[4] = this.myButton5;
            this.ButtonArray[5] = this.myButton6;
            this.ButtonArray[6] = this.myButton7;
            this.ButtonArray[7] = this.myButton8;
            this.ButtonArray[8] = this.myButton9;
            this.ButtonArray[9] = this.myButton10;
            this.ButtonArray[10] = this.myButton11;
            this.ButtonArray[11] = this.myButton12;
            this.ButtonArray[12] = this.myButton13;
            this.ButtonArray[13] = this.myButton14;
            this.ButtonArray[14] = this.myButton15;
          

            Random r = new Random();
            int[] a = new int[15];
            int i = 0;
            int b;
            bool exist;
            while (i != a.Length)
            {
                exist = false;
                b = (r.Next(15) + 1);
                for (int j = 0; j < a.Length; j++)
                    if (a[j] == b) exist = true;
                if (!exist) a[i++] = b;
            }
            for (int j = 0; j < a.Length; j++)
                ButtonArray[j].Number = a[j];
          
            int Number;
            int Row, Column;
            for (int k = 0; k < 4; k++)
                for (int j = 0; j < 4; j++)
                {
                    if (k == 3)
                        if (j == 3) break;
                    Number = ButtonArray[k * 4 + j].Number; //Get The Number Of Button
                    Row = (Number - 1) / 5;
                    Column = (Number - 1) - (Row * 5);
                   

                }
           
        }

        private int GetNumber(int x, int y)
        {
            int a, b;
            if (y == 40) // y-->Row
                a = 0;
            else
                a = (y - 40) / 75;

            if (x == 20) // x-->Column
                b = 0;
            else
                b = (x - 20) / 75;
            int Number = a * 5 + b + 1;
            return Number;
        }

     
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.MyFrmShowCurrentImage != null)
                this.MyFrmShowCurrentImage.Dispose();
        }
         public void resolver()
        {
            #region mover_piezas
            for (int i = 0; i <= 10000000; i++)
                this.myButton9.Location = new Point(20, 115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton10.Location = new Point(20, 190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton11.Location = new Point(95, 190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(170, 190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton6.Location = new Point(170, 115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton11.Location = new Point(95, 115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton10.Location = new Point(95, 190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton9.Location = new Point(20, 190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(20, 115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton2.Location = new Point(20, 40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton11.Location = new Point(95, 40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(95, 115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton9.Location = new Point(20, 115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton10.Location = new Point(20, 190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(95, 190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton11.Location = new Point(95, 115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton2.Location = new Point(95, 40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton9.Location = new Point(20, 40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton11.Location = new Point(20, 115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton2.Location = new Point(95, 115);
            for (int i = 0; i <= 10000000; i++)

            this.myButton3.Location = new Point(95, 40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton6.Location = new Point(170,40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton8.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton6.Location = new Point(245,40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton3.Location = new Point(170,40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton2.Location = new Point(95,40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton11.Location = new Point(95,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton10.Location = new Point(20,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(20,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton8.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton3.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton2.Location = new Point(170,40);
            for (int i = 0; i <= 10000000; i++)
            this.myButton11.Location = new Point(95,40);
            for (int i = 0; i <= 10000000; i++)

            this.myButton3.Location = new Point(95,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton12.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton5.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton15.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton14.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton8.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton5.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton15.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton14.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton8.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton13.Location = new Point(20,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton8.Location = new Point(20,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton5.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)

            this.myButton1.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton5.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton13.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton10.Location = new Point(20,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton3.Location = new Point(20,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(95,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton13.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton5.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton13.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton5.Location = new Point(95,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton13.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton13.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton12.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)

            this.myButton15.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton14.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton14.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton14.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton12.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton15.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton12.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton15.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton1.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton12.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
            this.myButton15.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton14.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton15.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton14.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton13.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton8.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton10.Location = new Point(20,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton7.Location = new Point(20,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton8.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
            this.myButton4.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton13.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
            this.myButton14.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton1.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton15.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton13.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton8.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton1.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton15.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton13.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton13.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton13.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton13.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)

             this.myButton4.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton5.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton1.Location = new Point(95,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton15.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton15.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton14.Location = new Point(245,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton1.Location = new Point(170,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton5.Location = new Point(95,115);
            for (int i = 0; i <= 10000000; i++)
             this.myButton8.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton15.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton13.Location = new Point(245,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton15.Location = new Point(245,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton8.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton8.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton10.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton7.Location = new Point(20,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(20,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton10.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton8.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton10.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton12.Location = new Point(95,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton7.Location = new Point(20,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton8.Location = new Point(20,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton4.Location = new Point(95,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton10.Location = new Point(170,265);
            for (int i = 0; i <= 10000000; i++)
             this.myButton13.Location = new Point(170,190);
            for (int i = 0; i <= 10000000; i++)
             this.myButton15.Location = new Point(245,190);
            MessageBox.Show("Juego Terminado");


#endregion




        }

         private void ToolStripMenuItemShowCurrntImagr_Click(object sender, EventArgs e)
         {
             resolver();
         }
    }

    public class MyButton : Button
    {
        private int number;

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
               // this.Text = value.ToString();
                //this.number = value;
            }
        }

        public MyButton()
        {
        }

       
    }

    
}
