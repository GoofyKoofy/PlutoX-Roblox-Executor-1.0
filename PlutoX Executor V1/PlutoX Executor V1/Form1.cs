using FastColoredTextBoxNS;
using ForlornApi;

namespace PlutoX_Executor_V1
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
        public Point mouseLocation;
        public Form1()
        {
            // Enable form dragging
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);

            time.Tick += timerTick;
            time.Start();

            InitializeComponent();
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        // Handle mouse move to drag the form

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                this.Location = mousePos;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (ForlornApi.Api.IsInjected())
            {
                Status.Text = "STATUS: INJECTED";
            }
            else
            {
                Status.Text = "STATUS: NOT INJECTED";
            }

            if (ForlornApi.Api.IsRobloxOpen())
            {
                RobloxOpen.Text = "Roblox Open: ✅";
                RobloxOpen.ForeColor = Color.Black;
            }
            else
            {
                RobloxOpen.Text = "Roblox Open: ❌";
                RobloxOpen.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ForlornApi.Api.ExecuteScript(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ForlornApi.Api.Inject();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ForlornApi.Api.KillRoblox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.LanguageOption = (RichTextBoxLanguageOptions)Language.Lua;
        }
    }
}
