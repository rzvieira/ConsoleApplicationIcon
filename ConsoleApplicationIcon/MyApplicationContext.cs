using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleApplicationIcon
{
    class MyApplicationContext : ApplicationContext
    {
        //Component declarations
        private System.Windows.Forms.NotifyIcon _trayIcon;
        private ContextMenuStrip _trayIconContextMenu;
        private ToolStripMenuItem _closeMenuItem;

        public MyApplicationContext()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
            _trayIcon.Visible = true;

            _trayIcon.ShowBalloonTip(10000);
        }

        private void InitializeComponent()
        {
            _trayIcon = new System.Windows.Forms.NotifyIcon();

            _trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            _trayIcon.BalloonTipText = "Recalculando Indicadores, clique para ver detalhes.";
            _trayIcon.BalloonTipTitle = "Recalculo de Indicadores";
            _trayIcon.Text = "Recalculando Indicadores";

            //The icon is added to the project resources
            _trayIcon.Icon = Resource.Task_Icon;

            //Optional - handle doubleclicks on the icon
            _trayIcon.MouseDoubleClick += _trayIcon_MouseDoubleClick;

            //Optional - Add a context menu to the _trayIcon
            _trayIconContextMenu = new ContextMenuStrip();
            _closeMenuItem = new ToolStripMenuItem();
            _trayIconContextMenu.SuspendLayout();

            //trayiconContextMenu
            _trayIconContextMenu.Items.AddRange(new ToolStripItem[] { _closeMenuItem });
            _trayIconContextMenu.Name = "TrayIconContextMenu";
            _trayIconContextMenu.Size = new Size(153, 70);

            //closeMenuItem
            _closeMenuItem.Name = "CloseMenuItem";
            _closeMenuItem.Size = new Size(152, 22);
            _closeMenuItem.Text = "Parar Recalculo de Indicadores";
            _closeMenuItem.Click += new EventHandler(CloseMenuItem);

            _trayIconContextMenu.ResumeLayout(false);
            _trayIcon.ContextMenuStrip = _trayIconContextMenu;


        }

        private void CloseMenuItem(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja parar o recalculo de indicadores?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void _trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Here you can do stuff if the tray icon is doubleclicked
            //_trayIcon.ShowBalloonTip(10000);

            Form frm = new Form();
            frm.ShowDialog(new NotifyIcon());
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            _trayIcon.Visible = false;
        }
    }
}
