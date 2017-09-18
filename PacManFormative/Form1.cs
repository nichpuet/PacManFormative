using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

// Nick Puetz | PacMan Formative | 14/09/17
namespace PacManFormative
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Sets the button to invisible
            playButton.Visible = false;

            //Sets up the pens, fonts, and brushes
            Graphics formGraphics = this.CreateGraphics();
            Pen drawPen = new Pen(Color.Blue, 5);
            Pen darkPen = new Pen(Color.Black, 5);
            Pen yellowPen = new Pen(Color.Yellow, 5);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
            SolidBrush darkBrush = new SolidBrush(Color.Black);
            Font drawFont = new Font("Ubuntu", 16, FontStyle.Bold);

            //draws the borders of the pacman track
            formGraphics.DrawLine(drawPen, 0,25,300,25);
            formGraphics.DrawLine(drawPen, 297, 25, 297, 200);
            formGraphics.DrawLine(drawPen, 0, 125, 200, 125);
            formGraphics.DrawLine(drawPen, 197, 125, 197, 200);

            //Runs the loop for pacman moving the right side of the screen. also declares the variable used to move the x location of pacman
            int locationX = 0;
            for (int x = 0; x <= 1; x++){
                
                //draws pacman then sleeps, adds 50 to the x coord and draws a black pacman shape over the top of the last pacman.
                formGraphics.DrawPie(yellowPen, locationX, 50, 50, 50, 30, 300);
                formGraphics.FillPie(yellowBrush, locationX, 50, 50, 50, 30, 300);
                
                Thread.Sleep(500);
                
                formGraphics.DrawPie(darkPen, locationX, 50, 50, 50, 30, 300);
                formGraphics.FillPie(darkBrush, locationX, 50, 50, 50, 30, 300);

                locationX += 50;
                
                //draws an ellipse where the next pacman should be aswell as doing the same as the last comment with an ellipse
                formGraphics.DrawEllipse(yellowPen, locationX, 50, 50, 50);
                formGraphics.FillEllipse(yellowBrush, locationX, 50, 50, 50);

                Thread.Sleep(500);

                formGraphics.DrawEllipse(darkPen, locationX, 50, 50, 50);
                formGraphics.FillEllipse(darkBrush, locationX, 50, 50, 50);

                locationX += 50;

            }
            // draws pacman looking down instead of to the right.
            formGraphics.DrawPie(yellowPen,222, 50, 50, 50, 120,300);
            formGraphics.FillPie(yellowBrush, 222, 50, 50, 50, 120,300);

            Thread.Sleep(500);
            //covers the last pacman with a black pacman
            formGraphics.DrawPie(darkPen, 222, 50, 50, 50, 120, 300);
            formGraphics.FillPie(darkBrush, 222, 50, 50, 50, 120, 300);
            
            //establishes the variable for Y coord and adds 50 to it
            int locationY = 50;
            locationY += 50;

            for (int y = 0; y <= 1; y++)
            {
                //does the same as the last for loop but going down the track and adds 50 to the Y
                formGraphics.DrawEllipse(yellowPen, 222, locationY, 50, 50);
                formGraphics.FillEllipse(yellowBrush, 222, locationY, 50, 50);

                Thread.Sleep(500);

                formGraphics.DrawEllipse(darkPen, 222, locationY, 50, 50);
                formGraphics.FillEllipse(darkBrush, 222, locationY, 50, 50);

                locationY += 50;

                formGraphics.DrawPie(yellowPen, 222, locationY, 50, 50, 120, 300);
                formGraphics.FillPie(yellowBrush, 222, locationY, 50, 50, 120, 300);

                Thread.Sleep(500);

                formGraphics.DrawPie(darkPen, 222, locationY, 50, 50, 120, 300);
                formGraphics.FillPie(darkBrush, 222, locationY, 50, 50, 120, 300);

                locationY += 50;
            }
            //draws the congratulations under the pacman track.
            formGraphics.DrawString("Congratulations", drawFont, yellowBrush, 10,150);
        }
    }
}
