using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_8_1
{
    public partial class Form1 : Form
    {
        int score; //initialize variables for score, score list, and average
        int total = 0;
        int average = 0;
        List<int> scorelist = new List<int>(); //create list for score list

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) //close button
        {
            this.Close(); //exit
        }

        private void btnAdd_Click(object sender, EventArgs e) //add button
        {
            try
            {
                if (IsValidData()) //validation for add button
                {

                    score = int.Parse(txtScore.Text);
                    scorelist.Add(score);

                    for (int index = 0; index < score; index++)
                    {
                        index += score;
                    }
                    scorelist.Count();
                    scorelist.Sort();
                    total += score;
                    average = (int)total / scorelist.Count(); //equation to find average
                    txtTotal.Text = total.ToString(); //bringing entered text to textbox for total, count, and average
                    txtCount.Text = scorelist.Count.ToString();
                    txtAverage.Text = average.ToString(); 
                    txtScore.Focus(); //give score textbox focus
                    txtScore.Text = ""; //blank score textbox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n" +
                    ex.StackTrace, "Exception");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e) //new display box for score list
        {
            string scoreList = ""; 

            foreach (int d in scorelist)
                scoreList += d.ToString() + "\n"; //every time user enters scores, they show in list
            MessageBox.Show(scoreList, "Score List"); //calls new messagebox to display Score List
        }
        public bool IsInt (TextBox textBox, string name) //validation for numbers
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + "must be an integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        public bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max) //validation for range between 1 and 100
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        public bool IsValidData() 
        {
            return
                IsInt(txtScore, "Score") &&
                IsWithinRange(txtScore, "Score", 1, 100); 

        }

        private void btnClear_Click(object sender, EventArgs e) //clear button
        {
            txtAverage.Text = ""; //clears each textbox
            txtCount.Text = "";
            txtScore.Text = "";
            txtTotal.Text = "";
            scorelist.Clear(); //clear score list
        }
    }
}