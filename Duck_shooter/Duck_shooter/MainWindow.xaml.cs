using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Duck_shooter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int score = 0;
        int time = 0;
        int recoil;
        Image img = new Image();
        BitmapImage BitImg = new BitmapImage(new Uri("wallhaven-668846.jpg", UriKind.Relative));
        

        List<Enemy_box> enemies;
       
        public MainWindow()
        {
            InitializeComponent();
            gamestatus_text.Visibility = Visibility.Hidden;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            img.Source = BitImg;


        }
        private void timer_tick(object sender, EventArgs e)
        {
            time_info.Text = "Time: " + time;
            time++;
            score--;

            Random rnd = new Random();

            Enemy_box enemy = new Enemy_box();
            enemy.Hp = 100;
            enemy.X = 34; //rnd.Next(0, Convert.ToInt32(game_background.Width));
            enemy.Y = 34; //rnd.Next(0, Convert.ToInt32(game_background.Height));
            enemy.Speed = rnd.Next(0, 5);
            enemy.Orientation = Orientation.Horizontal;
            enemy.Children.Add(img);
            enemies.Add(enemy);1
            

            

            foreach(Enemy_box E in enemies){
                E.X += 3;//rnd.Next(Convert.ToInt32(-E.Speed), Convert.ToInt32(E.Speed));
                E.Y += 3;//rnd.Next(Convert.ToInt32(-E.Speed), Convert.ToInt32(E.Speed));
                game_background.Children.Add(E);
            }

        }

        private void gun_check_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
