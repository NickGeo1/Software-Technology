using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DietApp
{
    public partial class Form3 : Form
    {
        // Assuming you have an instance of Form3 available or can create a new instance
        public static DailyProgram Monday = null;
        public static DailyProgram Tuesday = null;
        public static DailyProgram Wednesday = null;
        public static DailyProgram Thursday = null;
        public static DailyProgram Friday = null;
        public static DailyProgram Saturday = null;
        public static DailyProgram Sunday = null;
        bool flag = true;

        public Form3()
        {
            InitializeComponent();

            if (Form1.user_type.Equals("Patient"))
            {
                button1.Visible= false;
            }
            settoolip();
        }

        private void settoolip()
        {
            ToolTip toolTip = new ToolTip();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flag==true)
            {
                Application.Exit();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Form1.user_type.Equals("Nutritionist"))
            {
                flag= false;
                this.Close();
                Form2 form2 = new Form2(); 
                form2.Show();
            }
            else
            {
                flag = false;
                this.Close();
                Form1 form1= new Form1();
                form1.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Users.viewPlan(maskedTextBox1.Text);
            if (Sunday != null)
            {
                breakfast_sun.Text = Sunday.breakfast.foodname;
                toolTip1 = new ToolTip();
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Sunday.breakfast.kcal + Environment.NewLine + "fats:" + Sunday.breakfast.fats + Environment.NewLine + "protein:" + Sunday.breakfast.protein + Environment.NewLine + "carbs:" + Sunday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Sunday.breakfast.kcal);

                lunch_sun.Text = Sunday.lunch.foodname;
                toolTip1.SetToolTip(lunch_sun, "kcal:" + Sunday.lunch.kcal + Environment.NewLine + "fats:" + Sunday.lunch.fats + Environment.NewLine + "protein:" + Sunday.lunch.protein + Environment.NewLine + "carbs:" + Sunday.lunch.carbohydrates + Environment.NewLine + "includes:" + Sunday.lunch.kcal);

                snack_sun.Text = Sunday.snack.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Sunday.snack.kcal + Environment.NewLine + "fats:" + Sunday.snack.fats + Environment.NewLine + "protein:" + Sunday.snack.protein + Environment.NewLine + "carbs:" + Sunday.snack.carbohydrates + Environment.NewLine + "includes:" + Sunday.snack.kcal);

                dinner_sun.Text = Sunday.dinner.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Sunday.dinner.kcal + Environment.NewLine + "fats:" + Sunday.dinner.fats + Environment.NewLine + "protein:" + Sunday.dinner.protein + Environment.NewLine + "carbs:" + Sunday.dinner.carbohydrates + Environment.NewLine + "includes:" + Sunday.dinner.kcal);


                breakfast_mon.Text = Monday.breakfast.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Monday.breakfast.kcal + Environment.NewLine + "fats:" + Monday.breakfast.fats + Environment.NewLine + "protein:" + Monday.breakfast.protein + Environment.NewLine + "carbs:" + Monday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Monday.breakfast.kcal);

                lunch_mon.Text = Monday.lunch.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Monday.lunch.kcal + Environment.NewLine + "fats:" + Monday.lunch.fats + Environment.NewLine + "protein:" + Monday.lunch.protein + Environment.NewLine + "carbs:" + Monday.lunch.carbohydrates + Environment.NewLine + "includes:" + Monday.lunch.kcal);

                snack_mon.Text = Monday.snack.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Monday.snack.kcal + Environment.NewLine + "fats:" + Monday.snack.fats + Environment.NewLine + "protein:" + Monday.snack.protein + Environment.NewLine + "carbs:" + Monday.snack.carbohydrates + Environment.NewLine + "includes:" + Monday.snack.kcal);

                dinner_mon.Text = Monday.dinner.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Monday.dinner.kcal + Environment.NewLine + "fats:" + Monday.dinner.fats + Environment.NewLine + "protein:" + Monday.dinner.protein + Environment.NewLine + "carbs:" + Monday.dinner.carbohydrates + Environment.NewLine + "includes:" + Monday.dinner.kcal);


                breakfast_tue.Text = Tuesday.breakfast.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Tuesday.breakfast.kcal + Environment.NewLine + "fats:" + Tuesday.breakfast.fats + Environment.NewLine + "protein:" + Tuesday.breakfast.protein + Environment.NewLine + "carbs:" + Tuesday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Tuesday.breakfast.kcal);

                lunch_tue.Text = Tuesday.lunch.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Tuesday.lunch.kcal + Environment.NewLine + "fats:" + Tuesday.lunch.fats + Environment.NewLine + "protein:" + Tuesday.lunch.protein + Environment.NewLine + "carbs:" + Tuesday.lunch.carbohydrates + Environment.NewLine + "includes:" + Tuesday.lunch.kcal);

                snack_tue.Text = Tuesday.snack.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Tuesday.snack.kcal + Environment.NewLine + "fats:" + Tuesday.snack.fats + Environment.NewLine + "protein:" + Tuesday.snack.protein + Environment.NewLine + "carbs:" + Tuesday.snack.carbohydrates + Environment.NewLine + "includes:" + Tuesday.snack.kcal);

                dinner_tue.Text = Tuesday.dinner.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Tuesday.dinner.kcal + Environment.NewLine + "fats:" + Tuesday.dinner.fats + Environment.NewLine + "protein:" + Tuesday.dinner.protein + Environment.NewLine + "carbs:" + Tuesday.dinner.carbohydrates + Environment.NewLine + "includes:" + Tuesday.dinner.kcal);


                breakfast_wed.Text = Wednesday.breakfast.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Wednesday.breakfast.kcal + Environment.NewLine + "fats:" + Wednesday.breakfast.fats + Environment.NewLine + "protein:" + Wednesday.breakfast.protein + Environment.NewLine + "carbs:" + Wednesday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Wednesday.breakfast.kcal);

                lunch_wed.Text = Wednesday.lunch.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Wednesday.lunch.kcal + Environment.NewLine + "fats:" + Wednesday.lunch.fats + Environment.NewLine + "protein:" + Wednesday.lunch.protein + Environment.NewLine + "carbs:" + Wednesday.lunch.carbohydrates + Environment.NewLine + "includes:" + Wednesday.lunch.kcal);

                snack_wed.Text = Wednesday.snack.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Wednesday.snack.kcal + Environment.NewLine + "fats:" + Wednesday.snack.fats + Environment.NewLine + "protein:" + Wednesday.snack.protein + Environment.NewLine + "carbs:" + Wednesday.snack.carbohydrates + Environment.NewLine + "includes:" + Wednesday.snack.kcal);

                dinner_wed.Text = Wednesday.dinner.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Wednesday.dinner.kcal + Environment.NewLine + "fats:" + Wednesday.dinner.fats + Environment.NewLine + "protein:" + Wednesday.dinner.protein + Environment.NewLine + "carbs:" + Wednesday.dinner.carbohydrates + Environment.NewLine + "includes:" + Wednesday.dinner.kcal);


                breakfast_thu.Text = Thursday.breakfast.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Thursday.breakfast.kcal + Environment.NewLine + "fats:" + Thursday.breakfast.fats + Environment.NewLine + "protein:" + Thursday.breakfast.protein + Environment.NewLine + "carbs:" + Thursday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Thursday.breakfast.kcal);

                lunch_thu.Text = Thursday.lunch.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Thursday.lunch.kcal + Environment.NewLine + "fats:" + Thursday.lunch.fats + Environment.NewLine + "protein:" + Thursday.lunch.protein + Environment.NewLine + "carbs:" + Thursday.lunch.carbohydrates + Environment.NewLine + "includes:" + Thursday.lunch.kcal);

                snack_thu.Text = Thursday.snack.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Thursday.snack.kcal + Environment.NewLine + "fats:" + Thursday.snack.fats + Environment.NewLine + "protein:" + Thursday.snack.protein + Environment.NewLine + "carbs:" + Thursday.snack.carbohydrates + Environment.NewLine + "includes:" + Thursday.snack.kcal);

                dinner_thu.Text = Thursday.dinner.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Thursday.dinner.kcal + Environment.NewLine + "fats:" + Thursday.dinner.fats + Environment.NewLine + "protein:" + Thursday.dinner.protein + Environment.NewLine + "carbs:" + Thursday.dinner.carbohydrates + Environment.NewLine + "includes:" + Thursday.dinner.kcal);


                breakfast_fri.Text = Friday.breakfast.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Friday.breakfast.kcal + Environment.NewLine + "fats:" + Friday.breakfast.fats + Environment.NewLine + "protein:" + Friday.breakfast.protein + Environment.NewLine + "carbs:" + Friday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Friday.breakfast.kcal);

                lunch_fri.Text = Friday.lunch.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Friday.lunch.kcal + Environment.NewLine + "fats:" + Friday.lunch.fats + Environment.NewLine + "protein:" + Friday.lunch.protein + Environment.NewLine + "carbs:" + Friday.lunch.carbohydrates + Environment.NewLine + "includes:" + Friday.lunch.kcal);

                snack_fri.Text = Friday.snack.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Friday.snack.kcal + Environment.NewLine + "fats:" + Friday.snack.fats + Environment.NewLine + "protein:" + Friday.snack.protein + Environment.NewLine + "carbs:" + Friday.snack.carbohydrates + Environment.NewLine + "includes:" + Friday.snack.kcal);

                dinner_fri.Text = Friday.dinner.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Friday.dinner.kcal + Environment.NewLine + "fats:" + Friday.dinner.fats + Environment.NewLine + "protein:" + Friday.dinner.protein + Environment.NewLine + "carbs:" + Friday.dinner.carbohydrates + Environment.NewLine + "includes:" + Friday.dinner.kcal);


                breakfast_sat.Text = Saturday.breakfast.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Saturday.breakfast.kcal + Environment.NewLine + "fats:" + Saturday.breakfast.fats + Environment.NewLine + "protein:" + Saturday.breakfast.protein + Environment.NewLine + "carbs:" + Saturday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Saturday.breakfast.kcal);

                lunch_sat.Text = Saturday.lunch.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Saturday.lunch.kcal + Environment.NewLine + "fats:" + Saturday.lunch.fats + Environment.NewLine + "protein:" + Saturday.lunch.protein + Environment.NewLine + "carbs:" + Saturday.lunch.carbohydrates + Environment.NewLine + "includes:" + Saturday.lunch.kcal);

                snack_sat.Text = Saturday.snack.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Saturday.snack.kcal + Environment.NewLine + "fats:" + Saturday.snack.fats + Environment.NewLine + "protein:" + Saturday.snack.protein + Environment.NewLine + "carbs:" + Saturday.snack.carbohydrates + Environment.NewLine + "includes:" + Saturday.snack.kcal);

                dinner_sat.Text = Saturday.dinner.foodname;
                toolTip1.SetToolTip(breakfast_sun, "kcal:" + Saturday.dinner.kcal + Environment.NewLine + "fats:" + Saturday.dinner.fats + Environment.NewLine + "protein:" + Saturday.dinner.protein + Environment.NewLine + "carbs:" + Saturday.dinner.carbohydrates + Environment.NewLine + "includes:" + Saturday.dinner.kcal);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

    }
    
}
