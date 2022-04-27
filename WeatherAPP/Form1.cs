using AppCore.Interface;
using Domain.Entities.Weather;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPP
{
    public partial class Form1 : Form
    {
        IWeatherService weatherService;
        public Form1(IWeatherService  weatherService)
        {
            this.weatherService = weatherService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Root root = weatherService.GetWeather(textBox1.Text);
                pictureBox1.ImageLocation = "https://openweathermap.org/img/w/" + root.weather[0].Icon + ".png";
                lblCondition.Text = root.weather[0].Main;
                lblDetails.Text = root.weather[0].Description;
                lblSunrise.Text = convertLongToDate(root.sys.Sunrise).ToShortTimeString();
                lblSunset.Text = convertLongToDate(root.sys.Sunset).ToShortTimeString();
                lblPessure.Text = root.main.Pressure.ToString();
                lblWind.Text = root.wind.Speed.ToString();
                lblTemp.Text = root.main.Temp.ToString() + "°C";
                lblTempMax.Text = root.main.Temp_Max.ToString() + "°C";
                lblTempMin.Text = root.main.Temp_Min.ToString() + "°C";
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("La ciudad o país no ha sido encontrado");
            }


            

        }
        DateTime convertLongToDate(long date)
        {
            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            time = time.AddSeconds(date).ToLocalTime();
            return time;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblCondition_Click(object sender, EventArgs e)
        {

        }

        private void LblTempMin_Click(object sender, EventArgs e)
        {

        }

        private void LblTempMax_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click_1(object sender, EventArgs e)
        {

        }

        private void Label2_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
