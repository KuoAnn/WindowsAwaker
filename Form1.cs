using System.Reflection;
using System.Runtime.InteropServices;

namespace Awaker
{
    public partial class Form1 : Form
    {
        private static bool IsKeepAwake = false;
        private static string ModeText = string.Empty;

        // �T�Υ�v�Ҧ�
        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern uint SetThreadExecutionState(EXECUTION_STATE state);

        public Form1()
        {
            InitializeComponent();

            this.FormClosing += (obj, e) => UseNormalMode();

            UseAwakeMode();
            DestroyCountdown();
        }

        private Icon GetEmbeddedIcon(string iconName)
        {
            // ���o���O�귽
            var assembly = Assembly.GetExecutingAssembly();
            var iconStream = assembly.GetManifestResourceStream(iconName);

            if (iconStream != null)
            {
                return new Icon(iconStream);
            }

            return SystemIcons.Exclamation;
        }

        public uint UseNormalMode()
        {
            IsKeepAwake = false;
            ButtonSwitch.BackColor = Color.OrangeRed;
            ModeText = "Normal Mode";
            ButtonSwitch.Text = ModeText;

            this.Icon = GetEmbeddedIcon("Awaker.icon.moon.ico");

            return SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED |
                EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                EXECUTION_STATE.ES_CONTINUOUS);
        }

        public uint UseAwakeMode()
        {
            IsKeepAwake = true;
            ButtonSwitch.BackColor = Color.GreenYellow;
            ModeText = "Awake Mode";
            ButtonSwitch.Text = ModeText;

            this.Icon = GetEmbeddedIcon("Awaker.icon.sun.ico");

            return SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }

        private System.Timers.Timer DestroyCountdown()
        {
            DateTime now = DateTime.Now;
            // �p��Z�� 18:00 ���ɶ����j
            TimeSpan timeRemaining = (DateTime)new(now.Year, now.Month, now.Day, 18, 0, 0) - now;

            if (timeRemaining.TotalSeconds <= 0)
            {
                timeRemaining = (DateTime)new(now.Year, now.Month, now.Day, 23, 59, 59) - now;
            }

            var timer = new System.Timers.Timer(timeRemaining.TotalMilliseconds);
            timer.Elapsed += (sender, e) =>
            {
                UseNormalMode();

                if (sender != null)
                {
                    ((System.Timers.Timer)sender).Stop();
                }

                Environment.Exit(0);
            };

            timer.Start();
            return timer;
        }

        private void ButtonSwitch_Click(object sender, EventArgs e)
        {
            if (IsKeepAwake)
            {
                UseNormalMode();
            }
            else
            {
                DestroyCountdown();
                UseAwakeMode();
            }
        }
    }

    // �w�q���檬�A
    [FlagsAttribute]
    public enum EXECUTION_STATE : uint
    {
        NONE = 0,
        ES_AWAYMODE_REQUIRED = 0x00000040,
        ES_CONTINUOUS = 0x80000000,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_SYSTEM_REQUIRED = 0x00000001
        // Legacy flag, should not be used.
        // ES_USER_PRESENT = 0x00000004
    }
}