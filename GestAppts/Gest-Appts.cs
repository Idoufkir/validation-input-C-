using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace GestAppts
{
    public partial class GestAppt : Form
    {

        public int id;
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

        private void GetUsersRecord()
        {
            SqlConnection con = new SqlConnection("Data Source=ANDROID_76A9751;Initial Catalog=gestAppt;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("Select * from [insert-data] ORDER BY id DESC", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxNom.Text) || string.IsNullOrEmpty(textBoxPrenom.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxTele.Text) || string.IsNullOrEmpty(textBoxDateDeNaissance.Text) || string.IsNullOrEmpty(cmbpays.Text) || string.IsNullOrEmpty(cmbville.Text) || string.IsNullOrEmpty(specialite.Text))
            {
                MessageBox.Show("please insert your information", "warnnaing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=ANDROID_76A9751;Initial Catalog=gestAppt;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into  [insert-data] (nom, prenom, email, tele, datenaissance, pays, ville, spct) values ('" + textBoxNom.Text + "', '" + textBoxPrenom.Text + "' ,'" + textBoxEmail.Text + "','" + textBoxTele.Text + "','" + textBoxDateDeNaissance.Text + "','" + cmbpays.Text + "','" + cmbville.Text + "','" + specialite.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("the user information is saved ", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("user information is unsaved", "warnnaing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                GetUsersRecord();
                ResetData();
            }



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

        private void ResetData()
        {
            id = 0;
            textBoxNom.Text = string.Empty;
            textBoxPrenom.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxTele.Text = string.Empty;
            textBoxDateDeNaissance.Text = string.Empty;
            cmbpays.Text = string.Empty;
            cmbville.Text = string.Empty;
            specialite.Text = string.Empty;

            textBoxNom.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBoxNom.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBoxPrenom.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBoxTele.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBoxDateDeNaissance.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            cmbpays.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            cmbville.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            specialite.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }



        private void Form_Load(object sender, EventArgs e)
        {
            GetUsersRecord();
        }

    }
}
