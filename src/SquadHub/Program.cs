using System;
using System.Drawing;
using System.Windows.Forms;

namespace SquadHub;
static class Program {
    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
public class MainForm : Form {
    public MainForm() {
        Text = "SquadHub";
        MinimumSize = new Size(920, 620);
        Size = new Size(1100, 720);
        BackColor = Color.FromArgb(9, 10, 15);
        ForeColor = Color.White;
        Font = new Font("Segoe UI", 10);
        var root = new TableLayoutPanel { Dock=DockStyle.Fill, ColumnCount=2, RowCount=1, Padding=new Padding(18), BackColor=BackColor };
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        Controls.Add(root);
        var side = new Panel { Dock=DockStyle.Fill, BackColor=Color.FromArgb(18,19,29), Padding=new Padding(14) };
        root.Controls.Add(side,0,0);
        side.Controls.Add(new Label { Text="SQUADHUB", Font=new Font("Segoe UI",20,FontStyle.Bold), ForeColor=Color.FromArgb(190,150,255), AutoSize=true, Location=new Point(12,18) });
        side.Controls.Add(new Label { Text="\n\n  Главная\n\n  Друзья\n\n  Игры\n\n  Лидерборд\n\n  Профиль\n\n  Настройки", Font=new Font("Segoe UI",12), ForeColor=Color.Gainsboro, AutoSize=true, Location=new Point(12,72) });
        var content = new Panel { Dock=DockStyle.Fill, Padding=new Padding(20), BackColor=Color.FromArgb(12,13,20) };
        root.Controls.Add(content,1,0);
        content.Controls.Add(new Label { Text="Привет! Добро пожаловать в SquadHub", Font=new Font("Segoe UI",23,FontStyle.Bold), ForeColor=Color.White, AutoSize=true, Location=new Point(20,18) });
        content.Controls.Add(new Label { Text="Твоя игровая компания — в одном месте.", ForeColor=Color.FromArgb(170,175,190), AutoSize=true, Location=new Point(22,65) });
        AddCard(content,"Игровое время","0 ч 00 мин",22,115);
        AddCard(content,"Друзья онлайн","Пока нет подключённых друзей",335,115);
        AddCard(content,"Сейчас играешь","Tracker пока не подключён",22,285);
        AddCard(content,"Лидерборд","Статистика появится после подключения аккаунтов",335,285);
        content.Controls.Add(new Label { Text="Это стартовая desktop-версия SquadHub. Онлайн-друзья, Discord OAuth, синхронизация и настоящий игровой трекер требуют подключения серверной части.", ForeColor=Color.FromArgb(170,175,190), AutoSize=false, Width=700, Height=100, Location=new Point(22,470) });
    }
    void AddCard(Panel host, string heading, string value, int x, int y) {
        var card = new Panel { Location=new Point(x,y), Size=new Size(285,145), BackColor=Color.FromArgb(25,26,38) };
        host.Controls.Add(card);
        card.Controls.Add(new Label { Text=heading, ForeColor=Color.FromArgb(165,170,190), AutoSize=true, Location=new Point(16,16) });
        card.Controls.Add(new Label { Text=value, ForeColor=Color.FromArgb(220,220,240), Font=new Font("Segoe UI",14,FontStyle.Bold), AutoSize=true, MaximumSize=new Size(250,90), Location=new Point(16,52) });
    }
}
