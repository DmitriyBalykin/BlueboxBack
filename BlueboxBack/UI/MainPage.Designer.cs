using BlueboxBack.Core;
namespace BlueboxBack.UI
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalHintsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.showLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightHeadersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.additionalHintsToolStripMenuItem,
            this.levelToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "Меню";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.newToolStripMenuItem.Text = "Новая игра";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // additionalHintsToolStripMenuItem
            // 
            this.additionalHintsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLinesToolStripMenuItem,
            this.highlightHeadersToolStripMenuItem});
            this.additionalHintsToolStripMenuItem.Name = "additionalHintsToolStripMenuItem";
            this.additionalHintsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.additionalHintsToolStripMenuItem.Text = "Дополнительные подсказки";
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.difficultToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.levelToolStripMenuItem.Text = "Сложность";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            // 
            // layoutPanel
            // 
            this.layoutPanel.AutoSize = true;
            this.layoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutPanel.ColumnCount = 2;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutPanel.Location = new System.Drawing.Point(13, 28);
            this.layoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 2;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.Size = new System.Drawing.Size(150, 150);
            this.layoutPanel.TabIndex = 1;
            // 
            // showLinesToolStripMenuItem
            // 
            this.showLinesToolStripMenuItem.Checked = global::BlueboxBack.Properties.Settings.Default.ShowLines;
            this.showLinesToolStripMenuItem.CheckOnClick = true;
            this.showLinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLinesToolStripMenuItem.Name = "showLinesToolStripMenuItem";
            this.showLinesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.showLinesToolStripMenuItem.Text = "Показывать строки";
            // 
            // highlightHeadersToolStripMenuItem
            // 
            this.highlightHeadersToolStripMenuItem.Checked = global::BlueboxBack.Properties.Settings.Default.HighlightHeaders;
            this.highlightHeadersToolStripMenuItem.CheckOnClick = true;
            this.highlightHeadersToolStripMenuItem.Name = "highlightHeadersToolStripMenuItem";
            this.highlightHeadersToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.highlightHeadersToolStripMenuItem.Text = "Подсвечивать заголовки";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Checked = global::BlueboxBack.Properties.Settings.Default.IsEasyGame;
            this.easyToolStripMenuItem.CheckOnClick = true;
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.easyToolStripMenuItem.Text = "Легкая";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.easyToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Checked = global::BlueboxBack.Properties.Settings.Default.IsMediumGame;
            this.mediumToolStripMenuItem.CheckOnClick = true;
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediumToolStripMenuItem.Text = "Средняя";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // difficultToolStripMenuItem
            // 
            this.difficultToolStripMenuItem.Checked = global::BlueboxBack.Properties.Settings.Default.IsHardGame;
            this.difficultToolStripMenuItem.CheckOnClick = true;
            this.difficultToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.difficultToolStripMenuItem.Name = "difficultToolStripMenuItem";
            this.difficultToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.difficultToolStripMenuItem.Text = "Сложная";
            this.difficultToolStripMenuItem.Click += new System.EventHandler(this.difficultToolStripMenuItem_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(617, 632);
            this.Controls.Add(this.layoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlueboxBack";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem additionalHintsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightHeadersToolStripMenuItem;
    }
}