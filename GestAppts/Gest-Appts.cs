using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace GestAppts
{
    public partial class GestAppt : Form
    {
        public GestAppt()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void GestAppt_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=ANDROID_76A9751;Initial Catalog=gestAppt;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();



            Regexp("^[a-zA-Z]+$", textBoxNom, pc2, lblnom, "Le Nom");
            Regexp("^[a-zA-Z]+$", textBoxPrenom, pc3, lblprenom, "Le Prénom");
            Regexp("^[0-3]?[0-9].[0-3]?[0-9].(?:[0-9]{2})?[0-9]{2}$", textBoxDateDeNaissance, pc4, lbldtnc, "La Date de naissance");
            Regexp("^(06)([0-9]{8})+$", textBoxTele, pc5, lbltele, "Le N° de Téléphone");
            Regexp(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", textBoxEmail, pc8, lblmail, "L'adresse e-mail");





            if (cmbpays.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un Pays");
                return;
            }
            if (cmbville.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un ville");
                return;
            }
            if (specialite.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une spécialité");
                return;
            };





        }

        public void Regexp(string re, TextBox tb, PictureBox pc, Label lbl, string s)
        {
            Regex regex = new Regex(re);
            if(regex.IsMatch(tb.Text))
            {
                pc.Image = Properties.Resources.valide;
                lbl.ForeColor = Color.Green;
                lbl.Text = s + " est validé";
            }
            else
            {
                pc.Image = Properties.Resources.invalide;
                lbl.ForeColor = Color.Red;
                lbl.Text = s + " est invalidé";
            }
        }

        private void textBoxPays_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbpays_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbpays.Text == "MAROC")
            {
                cmbville.Items.Clear();
                cmbville.Items.Add("AGADIR");
                cmbville.Items.Add("Tiznit");
                cmbville.Items.Add("MARRAKESH");
                cmbville.Items.Add("SAFI");

            }
            if (cmbpays.Text == "USA")
            {
                cmbville.Items.Clear();
                cmbville.Items.Add("NEW YORK");
                cmbville.Items.Add("LOS SANTOS");
                cmbville.Items.Add("CHICAGO");
                cmbville.Items.Add("LAS VEGAS");

            }
            if (cmbpays.Text == "FRANCE")
            {
                cmbville.Items.Clear();
                cmbville.Items.Add("PARIS");
                cmbville.Items.Add("LILE");
                cmbville.Items.Add("BORDEAUX");
                cmbville.Items.Add("MARSEILLE");

            }


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChoixSpct_Click(object sender, EventArgs e)
        {

        }

       
    }
}
