using System;
using System.Windows.Forms;

namespace DietApp
{
    public partial class Form3 : Form
    {
        // Assuming you have an instance of Form3 available or can create a new instance
        public static DailyProgram Monday;
        public static DailyProgram Tuesday;
        public static DailyProgram Wednesday;
        public static DailyProgram Thursday;
        public static DailyProgram Friday;
        public static DailyProgram Saturday;
        public static DailyProgram Sunday;
        bool flag = true;

        public Form3()
        {
            InitializeComponent();

            if (Form1.user_type.Equals("Patient"))
            {
                button1.Visible = false;
            }
            settoolip();
        }

        private void settoolip()
        {
            ToolTip toolTip = new ToolTip();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flag == true)
            {
                Application.Exit();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Form1.user_type.Equals("Nutritionist"))
            {
                flag = false;
                this.Close();
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                flag = false;
                this.Close();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();

            Users.viewPlan(maskedTextBox1.Text);
            breakfast_sun.Text = Sunday.breakfast.foodname.Replace(" ", "\n");
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(breakfast_sun, "kcal:" + Sunday.breakfast.kcal + Environment.NewLine + "fats:" + Sunday.breakfast.fats + Environment.NewLine + "protein:" + Sunday.breakfast.protein + Environment.NewLine + "carbs:" + Sunday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Sunday.breakfast.kcal);

            lunch_sun.Text = Sunday.lunch.foodname.Replace(" ", "\n");
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(lunch_sun, "kcal:" + Sunday.lunch.kcal + Environment.NewLine + "fats:" + Sunday.lunch.fats + Environment.NewLine + "protein:" + Sunday.lunch.protein + Environment.NewLine + "carbs:" + Sunday.lunch.carbohydrates + Environment.NewLine + "includes:" + Sunday.lunch.kcal);

            snack_sun.Text = Sunday.snack.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(snack_sun, "kcal:" + Sunday.snack.kcal + Environment.NewLine + "fats:" + Sunday.snack.fats + Environment.NewLine + "protein:" + Sunday.snack.protein + Environment.NewLine + "carbs:" + Sunday.snack.carbohydrates + Environment.NewLine + "includes:" + Sunday.snack.kcal);

            dinner_sun.Text = Sunday.dinner.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(dinner_sun, "kcal:" + Sunday.dinner.kcal + Environment.NewLine + "fats:" + Sunday.dinner.fats + Environment.NewLine + "protein:" + Sunday.dinner.protein + Environment.NewLine + "carbs:" + Sunday.dinner.carbohydrates + Environment.NewLine + "includes:" + Sunday.dinner.kcal);


            breakfast_mon.Text = Monday.breakfast.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(breakfast_mon, "kcal:" + Monday.breakfast.kcal + Environment.NewLine + "fats:" + Monday.breakfast.fats + Environment.NewLine + "protein:" + Monday.breakfast.protein + Environment.NewLine + "carbs:" + Monday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Monday.breakfast.kcal);

            lunch_mon.Text = Monday.lunch.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(lunch_mon, "kcal:" + Monday.lunch.kcal + Environment.NewLine + "fats:" + Monday.lunch.fats + Environment.NewLine + "protein:" + Monday.lunch.protein + Environment.NewLine + "carbs:" + Monday.lunch.carbohydrates + Environment.NewLine + "includes:" + Monday.lunch.kcal);

            snack_mon.Text = Monday.snack.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(snack_mon, "kcal:" + Monday.snack.kcal + Environment.NewLine + "fats:" + Monday.snack.fats + Environment.NewLine + "protein:" + Monday.snack.protein + Environment.NewLine + "carbs:" + Monday.snack.carbohydrates + Environment.NewLine + "includes:" + Monday.snack.kcal);

            dinner_mon.Text = Monday.dinner.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(dinner_mon, "kcal:" + Monday.dinner.kcal + Environment.NewLine + "fats:" + Monday.dinner.fats + Environment.NewLine + "protein:" + Monday.dinner.protein + Environment.NewLine + "carbs:" + Monday.dinner.carbohydrates + Environment.NewLine + "includes:" + Monday.dinner.kcal);


            breakfast_tue.Text = Tuesday.breakfast.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(breakfast_tue, "kcal:" + Tuesday.breakfast.kcal + Environment.NewLine + "fats:" + Tuesday.breakfast.fats + Environment.NewLine + "protein:" + Tuesday.breakfast.protein + Environment.NewLine + "carbs:" + Tuesday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Tuesday.breakfast.kcal);

            lunch_tue.Text = Tuesday.lunch.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(lunch_tue, "kcal:" + Tuesday.lunch.kcal + Environment.NewLine + "fats:" + Tuesday.lunch.fats + Environment.NewLine + "protein:" + Tuesday.lunch.protein + Environment.NewLine + "carbs:" + Tuesday.lunch.carbohydrates + Environment.NewLine + "includes:" + Tuesday.lunch.kcal);

            snack_tue.Text = Tuesday.snack.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(snack_tue, "kcal:" + Tuesday.snack.kcal + Environment.NewLine + "fats:" + Tuesday.snack.fats + Environment.NewLine + "protein:" + Tuesday.snack.protein + Environment.NewLine + "carbs:" + Tuesday.snack.carbohydrates + Environment.NewLine + "includes:" + Tuesday.snack.kcal);

            dinner_tue.Text = Tuesday.dinner.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(dinner_tue, "kcal:" + Tuesday.dinner.kcal + Environment.NewLine + "fats:" + Tuesday.dinner.fats + Environment.NewLine + "protein:" + Tuesday.dinner.protein + Environment.NewLine + "carbs:" + Tuesday.dinner.carbohydrates + Environment.NewLine + "includes:" + Tuesday.dinner.kcal);


            breakfast_wed.Text = Wednesday.breakfast.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(breakfast_wed, "kcal:" + Wednesday.breakfast.kcal + Environment.NewLine + "fats:" + Wednesday.breakfast.fats + Environment.NewLine + "protein:" + Wednesday.breakfast.protein + Environment.NewLine + "carbs:" + Wednesday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Wednesday.breakfast.kcal);

            lunch_wed.Text = Wednesday.lunch.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(lunch_wed, "kcal:" + Wednesday.lunch.kcal + Environment.NewLine + "fats:" + Wednesday.lunch.fats + Environment.NewLine + "protein:" + Wednesday.lunch.protein + Environment.NewLine + "carbs:" + Wednesday.lunch.carbohydrates + Environment.NewLine + "includes:" + Wednesday.lunch.kcal);

            snack_wed.Text = Wednesday.snack.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(snack_wed, "kcal:" + Wednesday.snack.kcal + Environment.NewLine + "fats:" + Wednesday.snack.fats + Environment.NewLine + "protein:" + Wednesday.snack.protein + Environment.NewLine + "carbs:" + Wednesday.snack.carbohydrates + Environment.NewLine + "includes:" + Wednesday.snack.kcal);

            dinner_wed.Text = Wednesday.dinner.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(dinner_wed, "kcal:" + Wednesday.dinner.kcal + Environment.NewLine + "fats:" + Wednesday.dinner.fats + Environment.NewLine + "protein:" + Wednesday.dinner.protein + Environment.NewLine + "carbs:" + Wednesday.dinner.carbohydrates + Environment.NewLine + "includes:" + Wednesday.dinner.kcal);


            breakfast_thu.Text = Thursday.breakfast.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(breakfast_thu, "kcal:" + Thursday.breakfast.kcal + Environment.NewLine + "fats:" + Thursday.breakfast.fats + Environment.NewLine + "protein:" + Thursday.breakfast.protein + Environment.NewLine + "carbs:" + Thursday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Thursday.breakfast.kcal);

            lunch_thu.Text = Thursday.lunch.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(lunch_thu, "kcal:" + Thursday.lunch.kcal + Environment.NewLine + "fats:" + Thursday.lunch.fats + Environment.NewLine + "protein:" + Thursday.lunch.protein + Environment.NewLine + "carbs:" + Thursday.lunch.carbohydrates + Environment.NewLine + "includes:" + Thursday.lunch.kcal);

            snack_thu.Text = Thursday.snack.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(snack_thu, "kcal:" + Thursday.snack.kcal + Environment.NewLine + "fats:" + Thursday.snack.fats + Environment.NewLine + "protein:" + Thursday.snack.protein + Environment.NewLine + "carbs:" + Thursday.snack.carbohydrates + Environment.NewLine + "includes:" + Thursday.snack.kcal);

            dinner_thu.Text = Thursday.dinner.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(dinner_thu, "kcal:" + Thursday.dinner.kcal + Environment.NewLine + "fats:" + Thursday.dinner.fats + Environment.NewLine + "protein:" + Thursday.dinner.protein + Environment.NewLine + "carbs:" + Thursday.dinner.carbohydrates + Environment.NewLine + "includes:" + Thursday.dinner.kcal);


            breakfast_fri.Text = Friday.breakfast.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(breakfast_fri, "kcal:" + Friday.breakfast.kcal + Environment.NewLine + "fats:" + Friday.breakfast.fats + Environment.NewLine + "protein:" + Friday.breakfast.protein + Environment.NewLine + "carbs:" + Friday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Friday.breakfast.kcal);

            lunch_fri.Text = Friday.lunch.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(lunch_fri, "kcal:" + Friday.lunch.kcal + Environment.NewLine + "fats:" + Friday.lunch.fats + Environment.NewLine + "protein:" + Friday.lunch.protein + Environment.NewLine + "carbs:" + Friday.lunch.carbohydrates + Environment.NewLine + "includes:" + Friday.lunch.kcal);

            snack_fri.Text = Friday.snack.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(snack_fri, "kcal:" + Friday.snack.kcal + Environment.NewLine + "fats:" + Friday.snack.fats + Environment.NewLine + "protein:" + Friday.snack.protein + Environment.NewLine + "carbs:" + Friday.snack.carbohydrates + Environment.NewLine + "includes:" + Friday.snack.kcal);

            dinner_fri.Text = Friday.dinner.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(dinner_fri, "kcal:" + Friday.dinner.kcal + Environment.NewLine + "fats:" + Friday.dinner.fats + Environment.NewLine + "protein:" + Friday.dinner.protein + Environment.NewLine + "carbs:" + Friday.dinner.carbohydrates + Environment.NewLine + "includes:" + Friday.dinner.kcal);


            breakfast_sat.Text = Saturday.breakfast.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(breakfast_sat, "kcal:" + Saturday.breakfast.kcal + Environment.NewLine + "fats:" + Saturday.breakfast.fats + Environment.NewLine + "protein:" + Saturday.breakfast.protein + Environment.NewLine + "carbs:" + Saturday.breakfast.carbohydrates + Environment.NewLine + "includes:" + Saturday.breakfast.kcal);

            lunch_sat.Text = Saturday.lunch.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(lunch_sat, "kcal:" + Saturday.lunch.kcal + Environment.NewLine + "fats:" + Saturday.lunch.fats + Environment.NewLine + "protein:" + Saturday.lunch.protein + Environment.NewLine + "carbs:" + Saturday.lunch.carbohydrates + Environment.NewLine + "includes:" + Saturday.lunch.kcal);

            snack_sat.Text = Saturday.snack.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(snack_sat, "kcal:" + Saturday.snack.kcal + Environment.NewLine + "fats:" + Saturday.snack.fats + Environment.NewLine + "protein:" + Saturday.snack.protein + Environment.NewLine + "carbs:" + Saturday.snack.carbohydrates + Environment.NewLine + "includes:" + Saturday.snack.kcal);

            dinner_sat.Text = Saturday.dinner.foodname.Replace(" ", "\n");
            toolTip1.SetToolTip(dinner_sat, "kcal:" + Saturday.dinner.kcal + Environment.NewLine + "fats:" + Saturday.dinner.fats + Environment.NewLine + "protein:" + Saturday.dinner.protein + Environment.NewLine + "carbs:" + Saturday.dinner.carbohydrates + Environment.NewLine + "includes:" + Saturday.dinner.kcal);


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
