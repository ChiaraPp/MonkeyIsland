using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using static MonkeyIslandApi.ApiServer;
using static MonkeyIslandApi.Structure;

namespace MonkeyIslandApi
{
    public partial class Form1 : Form
    {
        #region Variables

        private int sum = 0;
        ApiCaller caller = new ApiCaller();
        ApiServer listener = new ApiServer();

        #endregion


        #region Form Methods

        public Form1()
        {
            InitializeComponent();
            //aggancio gli eventi ai metodi che li registrano
            listener.EventListeningError += Listener_EventListeningError;
            listener.EventPostReceived += Listener_EventPostReceived;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            messageLabel.Visible = false;
            pictureBox.Image = Properties.Resources.first;
            breakButton.Visible = false;
            listAction.Items.Add("Click \"START\" to get the item to open the box ");

            startButton.Enabled = true;

            if (caller.Open(Properties.Settings.Default.urlConnection))
            {
                Console.WriteLine("Client Api successfully created");

                if (listener.Start(Properties.Settings.Default.urlServer))
                {
                    startButton.Enabled = true;
                }
                else
                {
                    startButton.Enabled = false;
                }

            }
            else
            {
                startButton.Enabled = false;
                listAction.Items.Add("Client Api failed to create, not possibile to continue");
            }

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            caller.Close();
            listener.Stop();
        }

        #endregion


        #region Events Methods

        private void Listener_EventListeningError(object sender, EventArgs e)
        {
            Console.WriteLine("Error reading post call response");
        }

        private void Listener_EventPostReceived(object sender, PostReceivedEventArgs e)
        {
            messageLabel.Visible = true;
            messageLabel.Text = $"Congratulations! Your key is {e.BodyResult}";
            listAction.Items.Add("You have successfully broken the box.");
            listAction.Items.Add($"Your key is {e.BodyResult}");
            Console.WriteLine($"The key received is {e.BodyResult}");
        }

        #endregion


        #region Buttons Methods

        private void startButton_Click(object sender, EventArgs e)
        {
            messageLabel.Visible = false;
            if (getApiCall(this, new EventArgs()))
            {
                pictureBox.Image= Properties.Resources.second;
                startButton.Visible = false;
                breakButton.Visible = true;
            }             
        }

        private void breakButton_Click(object sender, EventArgs e)
        {
            messageLabel.Visible = false;
            if (postApiCall(this, new EventArgs()))
            {
                pictureBox.Image = Properties.Resources.third;
                startButton.Visible = false;
                breakButton.Visible = false;
            } else
            {
                messageLabel.Visible = true;
                messageLabel.Text = "Try to break the box again";
            }
        }


        #endregion


        #region Call Methods

        private bool getApiCall(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = caller.ApiClient.GetAsync(Properties.Settings.Default.API_KEY).Result; //effetuo la chiamata e registro la risposta 
                httpResponseMessage.EnsureSuccessStatusCode(); //se la risposta alla chiamata genera False viene generata un'eccezione
                string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                GetReturnStructure resp = JsonConvert.DeserializeObject<GetReturnStructure>(result);

                sum = magicNumberSum(resp.magicNumbers);
                listAction.Items.Add("Item obtained successfully. Start breaking the box");
                Console.WriteLine($"The numbers are {String.Join(",", resp.magicNumbers)} and their sum is {sum}");

                return true;

            }
            catch
            {
                return false;
            }
        }
        
        private bool postApiCall(object sender, EventArgs e)
        {
            PostStructure tmp = new PostStructure()
            {
                sum = sum,
                callBackUrl = Properties.Settings.Default.urlCallBack,
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(tmp), Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage httpResponseMessage = caller.ApiClient.PostAsync(Properties.Settings.Default.API_KEY, jsonContent).Result; //effetuo la chiamata e registro la risposta 
                httpResponseMessage.EnsureSuccessStatusCode(); //se la risposta alla chiamata genera False viene generata un'eccezione
                string result = httpResponseMessage.Content.ReadAsStringAsync().Result;

                breakButton.Visible = false;

                return true;

            }
            catch
            {
                return false;
            }
        }

        #endregion


        #region Helpers

        private int magicNumberSum(int[] magicNumbers)
        {
            int sum = 0;
            foreach (int i in magicNumbers)
            {
                sum += i;
            }

            return sum;
        }

        #endregion

    }
}
