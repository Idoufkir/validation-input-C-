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
            Regexp("^[a-zA-Z]+$", textBoxNom, pc2, lblnom, "Le Nom");
            Regexp("^[a-zA-Z]+$", textBoxPrenom, pc3, lblprenom, "Le Prénom");
            Regexp("^[0-3]?[0-9].[0-3]?[0-9].(?:[0-9]{2})?[0-9]{2}$", textBoxDateDeNaissance, pc4, lbldtnc, "La Date de naissance");
            Regexp("^(06)([0-9]{8})+$", textBoxTele, pc5, lbltele, "Le N° de Téléphone");
            Regexp("^[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,}$", textBoxEmail, pc8, lblmail, "L'adresse e-mail");







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

        
    }
}
