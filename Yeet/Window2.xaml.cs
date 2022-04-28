using System;
using YeetClass;
using System.Windows;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Generic;
using Point = System.Windows.Point;

namespace Yeet
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Recipe recipe;
        MainWindow main;
        List<Recipe> clo;
        public Window2(List<Recipe> ompa)
        {
            InitializeComponent();
            display(ompa) ;
        }
        private void display(List<Recipe> mane)
        {
            System.Windows.Forms.NotifyIcon klao = new System.Windows.Forms.NotifyIcon();
            var rand = new Random();
            PictureBox img = new PictureBox();
            //Recipe coca = clark.getList()[clark.getRad()];
            img.Load(mane[rand.Next(0,10)].getImage());
            img.Show();
            img.Left+=150;
            img.Top += 150;
        }
    }
}
