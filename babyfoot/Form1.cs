using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static babyfoot.ClassBalle;
using System.Data.SqlClient;

namespace babyfoot
{
    public partial class Form1 : Form
    {
        int i = 1;
        int j = 0;
        int resR;
        int resB;
        int lastX = 0;
        int lastY = 0;
        int ntour = 0;
        int score_Joueur1 = 0;
        int score_Joueur2 = 0;
        public Form1()
        {
            InitializeComponent();
            this.initializeScore();
            this.initializeArgent();
            this.getStarted();
            this.updateScore();

            //equipes bleu
            int gardienB_X = gardienB.Location.X;
            int gardienB_Y = gardienB.Location.Y;

            int defenseB_X = defenseB.Location.X;
            int defenseB_Y = defenseB.Location.Y;

            int centreB_X = centreB.Location.X;
            int centreB_Y = centreB.Location.Y;

            int attaquantB_X = attaquantB.Location.X;
            int attaquantB_Y = attaquantB.Location.Y;

            //equipes rouge
            int gardienR_X = this.gardienR.Location.X;
            int gardienR_Y = this.gardienR.Location.Y;

            int defenseR_X = defenseR.Location.X;
            int defenseR_Y = defenseR.Location.Y;

            int centreR_X = centreR.Location.X;
            int centreR_Y = centreR.Location.Y;

            int attaquantR_X = attaquantR.Location.X;
            int attaquantR_Y = attaquantR.Location.Y;
            System.Diagnostics.Debug.WriteLine(gardienR_X + "" + gardienR_Y);

            
            //rouge
            int C_gardienR_X = gardienR_X + gardienR.Width / 2;
            int C_gardienR_Y = gardienR_Y + gardienR.Height / 2;
            System.Diagnostics.Debug.WriteLine(C_gardienR_X + " " + C_gardienR_Y);

            int C_defenseR_X = defenseR_X + defenseR.Width / 2;
            int C_defenseR_Y = defenseR_Y + defenseR.Height / 2;
            System.Diagnostics.Debug.WriteLine(C_defenseR_X + " " + C_defenseR_Y);

            int C_centreR_X = centreR_X + centreR.Width / 2;
            int C_centreR_Y = centreR_Y + centreR.Height / 2;
            System.Diagnostics.Debug.WriteLine(C_centreR_X + " " + C_centreR_Y);

            int C_attaquantR_X = attaquantR_X + attaquantR.Width / 2;
            int C_attaquantR_Y = attaquantR_Y + attaquantR.Height / 2;
            System.Diagnostics.Debug.WriteLine(C_attaquantR_X + " " + C_attaquantR_Y);


            //bleu
            int C_gardienB_X = gardienB_X + gardienB.Width / 2;
            int C_gardienB_Y = gardienB_Y + gardienB.Height / 2;
            System.Diagnostics.Debug.WriteLine(C_gardienB_X + " " + C_gardienB_Y);

            int C_defenseB_X = defenseB_X + defenseB.Width / 2;
            int C_defenseB_Y = defenseB_Y + defenseB.Height / 2;
            System.Diagnostics.Debug.WriteLine(C_defenseB_X + " " + C_defenseB_Y);

            int C_centreB_X = centreB_X + centreB.Width / 2;
            int C_centreB_Y = centreB_Y + centreB.Height / 2;
            System.Diagnostics.Debug.WriteLine(C_centreB_X + " " + C_centreB_Y);

            int C_attaquantB_X = attaquantB_X + attaquantB.Width / 2;
            int C_attaquantB_Y = attaquantB_Y + attaquantB.Height / 2;
            System.Diagnostics.Debug.WriteLine(C_attaquantB_X + " " + C_attaquantB_Y);

            List<PictureBox> equipeR = new List<PictureBox>();
            equipeR.Add(gardienR);
            equipeR.Add(defenseR);
            equipeR.Add(centreR);
            equipeR.Add(attaquantR);

            List<PictureBox> equipeB = new List<PictureBox>();
            equipeB.Add(gardienB);
            equipeB.Add(defenseB);
            equipeB.Add(centreB);
            equipeB.Add(attaquantB);

        }

        public void initGame(int equipe)
        {
            j = 0;
            lastY = 0;
            lastX = 0;
            System.Diagnostics.Debug.WriteLine(equipe);
            if(equipe % 2 == 0)
            {
                ClassJoueur joueur = new ClassJoueur(gardienR);
                int posX = gardienR.Location.X + gardienR.Width /2;
                int posY = gardienR.Location.Y + gardienR.Height /2;
                System.Diagnostics.Debug.WriteLine(equipe + " " + posX + " " + posY);
                this.balle.Location = new Point(posX-20, posY-20);
            }
            else
            {
                ClassJoueur joueur = new ClassJoueur(gardienB);
                int posX = gardienB.Location.X + gardienB.Width / 2;
                int posY = gardienB.Location.Y + gardienB.Height / 2;
                this.balle.Location = new Point(posX-20, posY-20);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void insertPoint(int k)
        {
            k = i;
            if (k % 2 == 0)
            {
                resR += 1;
                this.insertScore(resR, "Joueur1", "Joueur2");
            }
            else
            {
                resB += 1;
                this.insertScore(resB, "Joueur2", "Joueur1");
            }
        }

        private void insertScore(int res, String Joueur_Gagnant, String Joueur_Perdant)
        {
            if(ntour < 5)
            {
                ntour++;
                string connectionString = "Data Source=DESKTOP-U4RVM70;Initial Catalog=babyfoot;Integrated Security=True";
                string query = "UPDATE SCORE SET SCORE = @score WHERE id = @id";
                string update_argent = "UPDATE SCORE SET ARGENT = @argent WHERE id = @id";
                string my_argent = "SELECT ARGENT FROM SCORE WHERE id = @id";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@score", res);
                        command.Parameters.AddWithValue("@id", Joueur_Gagnant);
                        int rowsAffected = command.ExecuteNonQuery();
                    }  
                }
                this.updateScore();
                if (Joueur_Gagnant == "Joueur1")
                {
                    score_Joueur1++;
                    if(score_Joueur1 >= 3) {
                        this.changeArgent("Joueur1");
                        this.updateScore();
                        MessageBox.Show("La partie est terminée, Joueur1 a gagné"); this.continuer(); 
                    }
                }
                else
                {
                    score_Joueur2++;
                    if (score_Joueur2 >= 3) {
                        this.changeArgent("Joueur2");
                        this.updateScore();
                        MessageBox.Show("La partie est terminée, Joueur2 a gagné"); this.continuer(); 
                    }
                }
            }  
        }

        private void continuer()
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous continuer à jouer ?", "Continuer", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                i = 1;
                j = 0;
                resR = 0;
                resB = 0;
                lastX = 0;
                lastY = 0;
                ntour = 0;
                score_Joueur1 = 0;
                score_Joueur2 = 0;
               
                this.initializeScore();
                this.getStarted();
                this.updateScore();
            }else if(dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }
        

        private void initializeScore()
        {
            string connectionString = "Data Source=DESKTOP-U4RVM70;Initial Catalog=babyfoot;Integrated Security=True";
            string query = "UPDATE SCORE SET SCORE = 0";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int rowsAffected1 = command.ExecuteNonQuery();
                }
            }
        }

        private void initializeArgent()
        {
            string connectionString = "Data Source=DESKTOP-U4RVM70;Initial Catalog=babyfoot;Integrated Security=True";
            string query = "UPDATE SCORE SET ARGENT = 5000";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int rowsAffected1 = command.ExecuteNonQuery();
                }
            }
        }

        public void getStarted()
        {
            string connectionString = "Data Source=DESKTOP-U4RVM70;Initial Catalog=babyfoot;Integrated Security=True";
            string update_argent = "UPDATE SCORE SET ARGENT = @argent WHERE id = @id";
            string my_argent = "SELECT ARGENT FROM SCORE WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command2 = new SqlCommand(my_argent, connection);
                command2.Parameters.AddWithValue("@id", "Joueur1");
                double argent = 0;
                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        argent = Convert.ToDouble(reader["argent"]);
                    }
                }
                using (SqlCommand command1 = new SqlCommand(update_argent, connection))
                {
                    command1.Parameters.AddWithValue("@argent", argent - 500);
                    command1.Parameters.AddWithValue("@id", "Joueur1");
                    int rowsAffected1 = command1.ExecuteNonQuery();
                }

                SqlCommand command3 = new SqlCommand(my_argent, connection);
                command3.Parameters.AddWithValue("@id", "Joueur2");
                using (SqlDataReader reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        argent = Convert.ToDouble(reader3["argent"]);
                    }
                }
                using (SqlCommand command4 = new SqlCommand(update_argent, connection))
                {
                    command4.Parameters.AddWithValue("@argent", argent - 500);
                    command4.Parameters.AddWithValue("@id", "Joueur2");
                    int rowsAffected = command4.ExecuteNonQuery();
                }
            }
        }

        public void changeArgent(String Joueur1)
        {
            string connectionString = "Data Source=DESKTOP-U4RVM70;Initial Catalog=babyfoot;Integrated Security=True";
            //string query = "UPDATE SCORE SET SCORE = @score WHERE id = @id";
            string update_argent = "UPDATE SCORE SET ARGENT = @argent WHERE id = @id";
            string my_argent = "SELECT ARGENT FROM SCORE WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command2 = new SqlCommand(my_argent, connection);
                command2.Parameters.AddWithValue("@id", Joueur1);
                double argent = 0;
                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        argent = Convert.ToDouble(reader["argent"]);
                    }
                }
                using (SqlCommand command1 = new SqlCommand(update_argent, connection))
                {
                    command1.Parameters.AddWithValue("@argent", argent + 400);
                    command1.Parameters.AddWithValue("@id", Joueur1);
                    int rowsAffected1 = command1.ExecuteNonQuery();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            List<PictureBox> equipeR = new()
            {
                defenseR,
                centreR,
                attaquantR
            };

            List<PictureBox> equipeB = new()
            {
                defenseB,
                centreB,
                attaquantB
            };

            if (e.KeyCode == Keys.Up)
            {
                this.balle.Top -= 140;
                /*StreamWriter sw = new StreamWriter("log.txt");
                sw.WriteLine(ballCenterX);
                sw.Close();*/
                lastX = this.balle.Location.X;
                lastY = this.balle.Location.Y;
                System.Diagnostics.Debug.WriteLine("hello world");
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.balle.Top += 140;
            }
            else if (e.KeyCode == Keys.Left)
            {
                if(equipeR.Count > j)
                {
                    PictureBox pic = equipeR.ElementAt(j);
                    this.LRmouvement(pic);
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (equipeB.Count > j)
                { 
                    PictureBox pic = equipeB.ElementAt(j);
                    this.LRmouvement(pic);
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                initGame(i);
                i += 1;
            }
            else if(e.KeyCode == Keys.T)
            {
                int last_index = i;
                if(i%2 == 0)
                {
                    int posX = gardienR.Location.X;
                    this.initializePlace(posX + 50, i);
                }
                else
                {
                    int posX = gardienB.Location.X;
                    this.initializePlace(posX - 50, i);
                }
            }
        }

        private void initializePlace(int positionX, int i)
        {
            int balle_y = balle.Location.Y;
            this.balle.Location = new Point(positionX, balle_y);
            this.insertPoint(i);
        }

        private void LRmouvement(PictureBox pic)
        {
            if (lastY == 0)
            {
                int posY = gardienR.Location.Y + gardienR.Height / 2;
                int x = pic.Location.X;
                this.balle.Location = new Point(x, posY - 20);
                j++;
            }
            else
            {
                int x = pic.Location.X;
                this.balle.Location = new Point(x, lastY);
                j++;
            }
        }

        private void pictureBox2_Click(object sender, KeyEventArgs e)
        {

        }

        private void gardienR_Click(object sender, KeyEventArgs e)
        {

        }

        private void updateScore()
        {
            string connectionString = "Data Source=DESKTOP-U4RVM70;Initial Catalog=babyfoot;Integrated Security=True";
            string query = "SELECT nom, score, argent FROM score";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string equipe = reader.GetString(0);
                    int score = reader.GetInt32(1);
                    double argent = (double)reader.GetDecimal(2);

                    if (equipe == "Joueur1")
                    {
                        label1.Text = score.ToString();
                        argent1.Text = argent.ToString();
                    }
                    else if (equipe == "Joueur2")
                    {
                        label2.Text = score.ToString();
                        argent2.Text = argent.ToString();
                    }
                }

                reader.Close();
            }
        }
    }
}
