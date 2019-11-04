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
        int shooted =0;

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        Random rnd = new Random();

        List<Enemy_box> enemies = new List<Enemy_box>();
       
        public MainWindow()
        {
            InitializeComponent();
            gamestatus_text.Visibility = Visibility.Hidden;
            gun_check.IsChecked = true;
            
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Interval = TimeSpan.FromMilliseconds(50);
            

            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);
            enemies.Add(enemy4);

            




        }

        private void Start_game()
        {
            timer.Start();
            foreach (Enemy_box E in enemies)
            {
                E.Hp = 100;
                E.X = E.Margin.Left; //rnd.Next(0, Convert.ToInt32(game_background.ActualWidth));
                E.Y = E.Margin.Top; //rnd.Next(0, Convert.ToInt32(game_background.ActualHeight));
                E.Margin = new Thickness(E.X, E.Y, 0, 0);
                E.Speed = rnd.Next(1, 15);
                E.Visibility = Visibility.Visible;
            }
            scope.Visibility = Visibility.Visible;
            score = 0;
            time = 0;
            shooted = 0;
            time_info.Visibility = Visibility.Visible;
            score_box.Visibility = Visibility.Visible;
            gamestatus_text.Visibility = Visibility.Hidden;

        }
        private void timer_tick(object sender, EventArgs e)
        {
            time_info.Text = "Time: " + time;
            score_box.Text = "Score: " + score;
            time++;
            score--;

            scope.Margin = new Thickness(GetMouse().X - 80, GetMouse().Y - 80, 0,0);
          

            foreach(Enemy_box E in enemies){

                E.X += rnd.Next(Convert.ToInt32(-E.Speed), Convert.ToInt32(E.Speed));
                E.Y += rnd.Next(Convert.ToInt32(-E.Speed), Convert.ToInt32(E.Speed));
                E.Margin = new Thickness(E.X, E.Y, 0,0);
                if(IsShooted(scope.Margin, E.Margin))
                {
                    score += 10;

                    if(gun_check.IsChecked.Value)
                    {
                        E.Hp -= 10;
                    }
                    else if(shootgun_check.IsChecked.Value)
                    {
                        E.Hp -= 50;
                    }

                    
                }

                if (E.Hp <= 0)
                {
                    score += 100;
                    E.Visibility = Visibility.Hidden;
                    E.Hp = 100000;
                    shooted++;
                }

            }

            if(shooted == 4)
            {
                gamestatus_text.Text = "Victory\nScore: " + score +"\nTime: " + time;
                gamestatus_text.Visibility = Visibility.Visible;
                score_box.Visibility = Visibility.Hidden;
                time_info.Visibility = Visibility.Hidden;
                scope.Visibility = Visibility.Hidden;
                timer.Stop();
            }

            if(time >= 100)
            {
                gamestatus_text.Text = "Game Over\nScore: " + score + "\nTime: " + time;
                gamestatus_text.Visibility = Visibility.Visible;
                score_box.Visibility = Visibility.Hidden;
                time_info.Visibility = Visibility.Hidden;
                scope.Visibility = Visibility.Hidden;
                timer.Stop();
            }
            
        }
        
        private bool IsShooted(Thickness target, Thickness scope)
        {
            if (Math.Abs(center(target).X - center(scope).X) < 20 & Math.Abs(center(target).Y - center(scope).Y) < 20 & Mouse.LeftButton == MouseButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        Point center(Thickness m)
        {
            return new Point((m.Top - m.Bottom) / 2, (m.Left - m.Right) / 2);
        }

        private Point GetMouse()
        {
            Point p = Mouse.GetPosition(Application.Current.MainWindow);

            return p;
        }

        private void gun_check_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {
            Start_game();
        }
    }
}
