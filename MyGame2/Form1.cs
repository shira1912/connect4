using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame2
{
    public partial class Form1 : Form
    {
        private TextBox usernameT;
        private TextBox passwordT;
        private TextBox firstNameT;
        private TextBox lastNameT;
        private TextBox usernameTL;
        private TextBox passwordTL;
        private TextBox emailT;
        private ComboBox cityC;
        private ComboBox genderC;
        private Label usernameL;
        private Label passwordL;
        private Label usernameLL;
        private Label passwordLL;
        private Label firstNameL;
        private Label lastNameL;
        private Label emailL;
        private Label cityL;
        private Label genderL;
        private Button signUpB2;
        private Button loginB2;

        ConnectionToSql connectToSql;
        private Player1 p1;

        public Form1()
        {
            InitializeComponent();
            connectToSql = new ConnectionToSql();
        }

        private void loginB1_Click(object sender, EventArgs e)
        {
            usernameTL = new TextBox();
            usernameTL.Location = new System.Drawing.Point(40, 50);
            usernameTL.Name = "usernameTL";
            usernameTL.Size = new System.Drawing.Size(100, 20);
            usernameTL.TabIndex = 2;
            Controls.Add(usernameTL);

            passwordTL = new TextBox();
            passwordTL.Location = new System.Drawing.Point(40, 80);
            passwordTL.Name = "passwordTL";
            passwordTL.Size = new System.Drawing.Size(100, 20);
            passwordTL.TabIndex = 2;
            Controls.Add(passwordTL);

            usernameLL = new Label();
            usernameLL.AutoSize = true;
            usernameLL.Location = new System.Drawing.Point(150, 50);
            usernameLL.Name = "usernameLL";
            usernameLL.Size = new System.Drawing.Size(35, 13);
            usernameLL.TabIndex = 2;
            usernameLL.Text = "username";
            Controls.Add(usernameLL);

            passwordLL = new Label();
            passwordLL.AutoSize = true;
            passwordLL.Location = new System.Drawing.Point(150, 80);
            passwordLL.Name = "passwordLL";
            passwordLL.Size = new System.Drawing.Size(35, 13);
            passwordLL.TabIndex = 2;
            passwordLL.Text = "password";
            Controls.Add(passwordLL);

            loginB2 = new Button();
            loginB2.Location = new System.Drawing.Point(144, 142);
            loginB2.Name = "loginB2";
            loginB2.Size = new System.Drawing.Size(75, 23);
            loginB2.TabIndex = 0;
            loginB2.Text = "Login";
            loginB2.UseVisualStyleBackColor = true;
            loginB2.Click += new System.EventHandler(this.loginB2_Click);
            Controls.Add(loginB2);

            Controls.Remove(signUpB1);
            Controls.Remove(loginB1);

        }
        private void signUpB1_Click(object sender, EventArgs e)
        {
            usernameT = new TextBox();
            usernameT.Location = new System.Drawing.Point(40, 50);
            usernameT.Name = "usernameT";
            usernameT.Size = new System.Drawing.Size(100, 20);
            usernameT.TabIndex = 2;
            Controls.Add(usernameT);

            passwordT = new TextBox();
            passwordT.Location = new System.Drawing.Point(40, 80);
            passwordT.Name = "passwordT";
            passwordT.Size = new System.Drawing.Size(100, 20);
            passwordT.TabIndex = 2;
            Controls.Add(passwordT);

            firstNameT = new TextBox();
            firstNameT.Location = new System.Drawing.Point(40, 110);
            firstNameT.Name = "firstNameT";
            firstNameT.Size = new System.Drawing.Size(100, 20);
            firstNameT.TabIndex = 2;
            Controls.Add(firstNameT);

            lastNameT = new TextBox();
            lastNameT.Location = new System.Drawing.Point(40, 140);
            lastNameT.Name = "lastNameT";
            lastNameT.Size = new System.Drawing.Size(100, 20);
            lastNameT.TabIndex = 2;
            Controls.Add(lastNameT);

            emailT = new TextBox();
            emailT.Location = new System.Drawing.Point(40, 170);
            emailT.Name = "emailT";
            emailT.Size = new System.Drawing.Size(100, 20);
            emailT.TabIndex = 2;
            Controls.Add(emailT);

            List<string> israeliCities = new List<string>
    {
        "", "Afula", "Akko", "Arad", "Ariel", "Ashdod", "Ashkelon", "Bat Yam", "Beer Sheva", "Beit Shean", "Beit Shemesh", "Betar Illit", "Bnei Berak", "Dimona", "Eilat", "Elad", "Givatayim", "Hadera", "Haifa", "Harish", "Herzliya", "Hod HaSharon", "Holon", "Jerusalem", "Karmiel", "Kfar Sava", "Kiryat Ata", "Kiryat Bialik", "Kiryat Gat", "Kiryat Malachi", "Kiryat Motzkin", "Kiryat Ono", "Kiryat Shemone", "Kiryat Yam", "Lod", "Maale Adumim", "Maalot Tarshiha", "Migdal HaEmek", "Modiin", "Nahariya", "Nazareth", "Nes Ziona", "Nesher", "Netanya", "Netivot", "Nof Hagalil", "Ofakim", "Or Akiva", "Or Yehuda", "Petah Tikva", "Qalansawe", "Raanana", "Rahat", "Ramat Hasharon", "Ramat-Gan", "Ramla", "Rehovot", "Rishon Lezion", "Rosh Ha'ayin", "Sakhnin", "Sderot", "Shefaram", "Taibeh", "Tamra", "Tel Aviv", "Tiberias", "Tira", "Tirat Carmel", "Tsfat", "Umm al-Fahm", "Yavne", "Yehud-Monosson", "Yokneam"
    };

            cityC = new ComboBox();
            cityC.FormattingEnabled = true;
            cityC.Location = new System.Drawing.Point(40, 200);
            cityC.Name = "cityC";
            cityC.Size = new System.Drawing.Size(100, 20);
            cityC.TabIndex = 2;
            cityC.DataSource = israeliCities;
            Controls.Add(cityC);

            genderC = new ComboBox();
            genderC.FormattingEnabled = true;
            genderC.Location = new System.Drawing.Point(40, 230);
            genderC.Name = "genderC";
            genderC.Size = new System.Drawing.Size(100, 20);
            genderC.TabIndex = 2;
            genderC.Items.Add("male");
            genderC.Items.Add("female");
            genderC.Items.Add("other");
            Controls.Add(genderC);

            usernameL = new Label();
            usernameL.AutoSize = true;
            usernameL.Location = new System.Drawing.Point(150, 50);
            usernameL.Name = "usernameL";
            usernameL.Size = new System.Drawing.Size(35, 13);
            usernameL.TabIndex = 2;
            usernameL.Text = "username";
            Controls.Add(usernameL);

            passwordL = new Label();
            passwordL.AutoSize = true;
            passwordL.Location = new System.Drawing.Point(150, 80);
            passwordL.Name = "passwordL";
            passwordL.Size = new System.Drawing.Size(35, 13);
            passwordL.TabIndex = 2;
            passwordL.Text = "password";
            Controls.Add(passwordL);

            firstNameL = new Label();
            firstNameL.AutoSize = true;
            firstNameL.Location = new System.Drawing.Point(150, 110);
            firstNameL.Name = "firstNameL";
            firstNameL.Size = new System.Drawing.Size(35, 13);
            firstNameL.TabIndex = 2;
            firstNameL.Text = "first Name";
            Controls.Add(firstNameL);

            lastNameL = new Label();
            lastNameL.AutoSize = true;
            lastNameL.Location = new System.Drawing.Point(150, 140);
            lastNameL.Name = "lastNameL";
            lastNameL.Size = new System.Drawing.Size(35, 13);
            lastNameL.TabIndex = 2;
            lastNameL.Text = "last Name";
            Controls.Add(lastNameL);

            emailL = new Label();
            emailL.AutoSize = true;
            emailL.Location = new System.Drawing.Point(150, 170);
            emailL.Name = "emailL";
            emailL.Size = new System.Drawing.Size(35, 13);
            emailL.TabIndex = 2;
            emailL.Text = "email";
            Controls.Add(emailL);

            cityL = new Label();
            cityL.AutoSize = true;
            cityL.Location = new System.Drawing.Point(150, 200);
            cityL.Name = "cityL";
            cityL.Size = new System.Drawing.Size(35, 13);
            cityL.TabIndex = 2;
            cityL.Text = "city";
            Controls.Add(cityL);

            genderL = new Label();
            genderL.AutoSize = true;
            genderL.Location = new System.Drawing.Point(150, 230);
            genderL.Name = "genderL";
            genderL.Size = new System.Drawing.Size(35, 13);
            genderL.TabIndex = 2;
            genderL.Text = "gender";
            Controls.Add(genderL);

            signUpB2 = new Button();
            signUpB2.Location = new System.Drawing.Point(40, 260);
            signUpB2.Name = "signUpB2";
            signUpB2.Size = new System.Drawing.Size(75, 23);
            signUpB2.TabIndex = 0;
            signUpB2.Text = "Sign Up";
            signUpB2.UseVisualStyleBackColor = true;
            signUpB2.Click += new System.EventHandler(this.signUpB2_Click);
            Controls.Add(signUpB2);

            Controls.Remove(signUpB1);
            Controls.Remove(loginB1);

        }

        private void loginB2_Click(object sender, EventArgs e)
        {
            if (connectToSql.IsExist(usernameTL.Text))
            {
                if (connectToSql.IsMatchingPass(usernameTL.Text, passwordTL.Text))
                {
                    MessageBox.Show("You have logged in!");
                    p1 = new Player1();
                    p1.Show();
                }
                else
                    MessageBox.Show("password or username is incorrect");
            }
            else
                MessageBox.Show("password or username is incorrect");

        }

        private void signUpB2_Click(object sender, EventArgs e)
        {
            if (usernameT.Text != "")
            {
                if (!connectToSql.IsExist(usernameT.Text))
                {
                    // Get the selected city from the ComboBox
                    string selectedCity = cityC.SelectedItem?.ToString();  // Use ToString() to get the city as a string

                    if (!string.IsNullOrEmpty(selectedCity))
                    {
                        connectToSql.InsertNewUser(usernameT.Text, passwordT.Text, firstNameT.Text, lastNameT.Text, emailT.Text, selectedCity, genderC.Text);
                        MessageBox.Show("You have signed up");
                        Controls.Clear();
                        Controls.Add(signUpB1);
                        Controls.Add(loginB1);
                    }
                    else
                    {
                        MessageBox.Show("Please select a city from the list");
                    }
                }
                else
                {
                    MessageBox.Show("Username already exists, choose a different username");
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled");
            }
        }
    }

}
