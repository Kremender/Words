using System.Windows.Forms;

namespace Words
{
    partial class UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.lb_wordLength = new System.Windows.Forms.Label();
            this.grp_lettersCombos = new System.Windows.Forms.GroupBox();
            this.btn_generate_A = new System.Windows.Forms.Button();
            this.dg_words = new System.Windows.Forms.DataGridView();
            this.lb_filedump = new System.Windows.Forms.Label();
            this.btn_filedump = new System.Windows.Forms.Button();
            this.sfd_filedump = new System.Windows.Forms.SaveFileDialog();
            this.tbx_filedumppath = new System.Windows.Forms.TextBox();
            this.dg_excluded = new System.Windows.Forms.DataGridView();
            this.ofd_filedump = new System.Windows.Forms.OpenFileDialog();
            this.lb_fileread = new System.Windows.Forms.Label();
            this.btn_fileread = new System.Windows.Forms.Button();
            this.tab_pages = new System.Windows.Forms.TabControl();
            this.tab_page_A = new System.Windows.Forms.TabPage();
            this.tab_letters = new System.Windows.Forms.TabControl();
            this.tab_A = new System.Windows.Forms.TabPage();
            this.cb_wordLength = new Words.CustomComboBox();
            this.tab_B = new System.Windows.Forms.TabPage();
            this.lb_wordInput = new System.Windows.Forms.Label();
            this.btn_generate_B = new System.Windows.Forms.Button();
            this.tbx_letters = new System.Windows.Forms.TextBox();
            this.chx_usedictionary_A = new System.Windows.Forms.CheckBox();
            this.lbl_foundWordsValue = new System.Windows.Forms.Label();
            this.lbl_foundWordsText = new System.Windows.Forms.Label();
            this.tab_page_B = new System.Windows.Forms.TabPage();
            this.cbx_dictionaries = new System.Windows.Forms.ComboBox();
            this.lbl_dictionaryStatusValue = new System.Windows.Forms.Label();
            this.lbl_dictionaryStatusText = new System.Windows.Forms.Label();
            this.btn_filenew = new System.Windows.Forms.Button();
            this.btn_filewrite = new System.Windows.Forms.Button();
            this.sfd_filewrite = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dg_words)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_excluded)).BeginInit();
            this.tab_pages.SuspendLayout();
            this.tab_page_A.SuspendLayout();
            this.tab_letters.SuspendLayout();
            this.tab_A.SuspendLayout();
            this.tab_B.SuspendLayout();
            this.tab_page_B.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_wordLength
            // 
            this.lb_wordLength.AutoSize = true;
            this.lb_wordLength.ForeColor = System.Drawing.Color.Blue;
            this.lb_wordLength.Location = new System.Drawing.Point(4, 15);
            this.lb_wordLength.Name = "lb_wordLength";
            this.lb_wordLength.Size = new System.Drawing.Size(75, 13);
            this.lb_wordLength.TabIndex = 2;
            this.lb_wordLength.Text = "Word Length :";
            // 
            // grp_lettersCombos
            // 
            this.grp_lettersCombos.Location = new System.Drawing.Point(3, 35);
            this.grp_lettersCombos.Name = "grp_lettersCombos";
            this.grp_lettersCombos.Size = new System.Drawing.Size(356, 47);
            this.grp_lettersCombos.TabIndex = 8;
            this.grp_lettersCombos.TabStop = false;
            // 
            // btn_generate_A
            // 
            this.btn_generate_A.Enabled = false;
            this.btn_generate_A.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_generate_A.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_generate_A.Location = new System.Drawing.Point(362, 47);
            this.btn_generate_A.Name = "btn_generate_A";
            this.btn_generate_A.Size = new System.Drawing.Size(75, 27);
            this.btn_generate_A.TabIndex = 9;
            this.btn_generate_A.Text = "N";
            this.btn_generate_A.UseVisualStyleBackColor = true;
            this.btn_generate_A.Click += new System.EventHandler(this.btn_generate_A_Click);
            // 
            // dg_words
            // 
            this.dg_words.AllowUserToAddRows = false;
            this.dg_words.AllowUserToDeleteRows = false;
            this.dg_words.AllowUserToOrderColumns = true;
            this.dg_words.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_words.Location = new System.Drawing.Point(9, 145);
            this.dg_words.Name = "dg_words";
            this.dg_words.ReadOnly = true;
            this.dg_words.Size = new System.Drawing.Size(451, 291);
            this.dg_words.TabIndex = 10;
            // 
            // lb_filedump
            // 
            this.lb_filedump.AutoSize = true;
            this.lb_filedump.ForeColor = System.Drawing.Color.Blue;
            this.lb_filedump.Location = new System.Drawing.Point(6, 470);
            this.lb_filedump.Name = "lb_filedump";
            this.lb_filedump.Size = new System.Drawing.Size(73, 13);
            this.lb_filedump.TabIndex = 11;
            this.lb_filedump.Text = "Save To File :";
            // 
            // btn_filedump
            // 
            this.btn_filedump.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_filedump.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_filedump.Location = new System.Drawing.Point(87, 466);
            this.btn_filedump.Name = "btn_filedump";
            this.btn_filedump.Size = new System.Drawing.Size(27, 23);
            this.btn_filedump.TabIndex = 12;
            this.btn_filedump.Text = "<";
            this.btn_filedump.UseVisualStyleBackColor = true;
            this.btn_filedump.Click += new System.EventHandler(this.btn_filedump_Click);
            // 
            // sfd_filedump
            // 
            this.sfd_filedump.Filter = "csv files(*.csv)|*.csv|All files(*.*)|*.*";
            // 
            // tbx_filedumppath
            // 
            this.tbx_filedumppath.Enabled = false;
            this.tbx_filedumppath.Location = new System.Drawing.Point(120, 468);
            this.tbx_filedumppath.Name = "tbx_filedumppath";
            this.tbx_filedumppath.Size = new System.Drawing.Size(340, 20);
            this.tbx_filedumppath.TabIndex = 13;
            // 
            // dg_excluded
            // 
            this.dg_excluded.AllowUserToOrderColumns = true;
            this.dg_excluded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_excluded.Location = new System.Drawing.Point(9, 37);
            this.dg_excluded.Name = "dg_excluded";
            this.dg_excluded.Size = new System.Drawing.Size(455, 441);
            this.dg_excluded.TabIndex = 0;
            this.dg_excluded.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dg_excluded_CellBeginEdit);
            // 
            // ofd_filedump
            // 
            this.ofd_filedump.Filter = "Dictionary Files(*.dlc)|*.dlc|All files(*.*)|*.*";
            // 
            // lb_fileread
            // 
            this.lb_fileread.AutoSize = true;
            this.lb_fileread.ForeColor = System.Drawing.Color.Blue;
            this.lb_fileread.Location = new System.Drawing.Point(6, 13);
            this.lb_fileread.Name = "lb_fileread";
            this.lb_fileread.Size = new System.Drawing.Size(79, 13);
            this.lb_fileread.TabIndex = 1;
            this.lb_fileread.Text = "Dictionary File :";
            // 
            // btn_fileread
            // 
            this.btn_fileread.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_fileread.Location = new System.Drawing.Point(404, 8);
            this.btn_fileread.Name = "btn_fileread";
            this.btn_fileread.Size = new System.Drawing.Size(27, 23);
            this.btn_fileread.TabIndex = 2;
            this.btn_fileread.Text = "0";
            this.btn_fileread.UseVisualStyleBackColor = true;
            this.btn_fileread.Click += new System.EventHandler(this.btn_fileread_Click);
            // 
            // tab_pages
            // 
            this.tab_pages.Controls.Add(this.tab_page_A);
            this.tab_pages.Controls.Add(this.tab_page_B);
            this.tab_pages.Location = new System.Drawing.Point(12, 12);
            this.tab_pages.Name = "tab_pages";
            this.tab_pages.SelectedIndex = 0;
            this.tab_pages.Size = new System.Drawing.Size(480, 523);
            this.tab_pages.TabIndex = 15;
            // 
            // tab_page_A
            // 
            this.tab_page_A.Controls.Add(this.tab_letters);
            this.tab_page_A.Controls.Add(this.chx_usedictionary_A);
            this.tab_page_A.Controls.Add(this.lbl_foundWordsValue);
            this.tab_page_A.Controls.Add(this.lbl_foundWordsText);
            this.tab_page_A.Controls.Add(this.tbx_filedumppath);
            this.tab_page_A.Controls.Add(this.btn_filedump);
            this.tab_page_A.Controls.Add(this.lb_filedump);
            this.tab_page_A.Controls.Add(this.dg_words);
            this.tab_page_A.Location = new System.Drawing.Point(4, 22);
            this.tab_page_A.Name = "tab_page_A";
            this.tab_page_A.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_A.Size = new System.Drawing.Size(472, 497);
            this.tab_page_A.TabIndex = 0;
            this.tab_page_A.Text = "Words";
            this.tab_page_A.UseVisualStyleBackColor = true;
            // 
            // tab_letters
            // 
            this.tab_letters.Controls.Add(this.tab_A);
            this.tab_letters.Controls.Add(this.tab_B);
            this.tab_letters.Location = new System.Drawing.Point(9, 6);
            this.tab_letters.Name = "tab_letters";
            this.tab_letters.SelectedIndex = 0;
            this.tab_letters.Size = new System.Drawing.Size(451, 114);
            this.tab_letters.TabIndex = 17;
            this.tab_letters.SelectedIndexChanged += new System.EventHandler(this.tab_letters_SelectedIndexChanged);
            // 
            // tab_A
            // 
            this.tab_A.Controls.Add(this.btn_generate_A);
            this.tab_A.Controls.Add(this.grp_lettersCombos);
            this.tab_A.Controls.Add(this.cb_wordLength);
            this.tab_A.Controls.Add(this.lb_wordLength);
            this.tab_A.Location = new System.Drawing.Point(4, 22);
            this.tab_A.Name = "tab_A";
            this.tab_A.Padding = new System.Windows.Forms.Padding(3);
            this.tab_A.Size = new System.Drawing.Size(443, 88);
            this.tab_A.TabIndex = 0;
            this.tab_A.Text = "Select";
            this.tab_A.UseVisualStyleBackColor = true;
            // 
            // cb_wordLength
            // 
            this.cb_wordLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_wordLength.FormattingEnabled = true;
            this.cb_wordLength.Location = new System.Drawing.Point(85, 12);
            this.cb_wordLength.MaxLength = 1;
            this.cb_wordLength.Name = "cb_wordLength";
            this.cb_wordLength.Size = new System.Drawing.Size(121, 21);
            this.cb_wordLength.TabIndex = 7;
            this.cb_wordLength.SelectedIndexChanged += new System.EventHandler(this.cb_wordLength_SelectedIndexChanged);
            // 
            // tab_B
            // 
            this.tab_B.Controls.Add(this.lb_wordInput);
            this.tab_B.Controls.Add(this.btn_generate_B);
            this.tab_B.Controls.Add(this.tbx_letters);
            this.tab_B.Location = new System.Drawing.Point(4, 22);
            this.tab_B.Name = "tab_B";
            this.tab_B.Padding = new System.Windows.Forms.Padding(3);
            this.tab_B.Size = new System.Drawing.Size(443, 88);
            this.tab_B.TabIndex = 1;
            this.tab_B.Text = "Input";
            this.tab_B.UseVisualStyleBackColor = true;
            // 
            // lb_wordInput
            // 
            this.lb_wordInput.AutoSize = true;
            this.lb_wordInput.ForeColor = System.Drawing.Color.Blue;
            this.lb_wordInput.Location = new System.Drawing.Point(4, 15);
            this.lb_wordInput.Name = "lb_wordInput";
            this.lb_wordInput.Size = new System.Drawing.Size(335, 13);
            this.lb_wordInput.TabIndex = 16;
            this.lb_wordInput.Text = "Word Length : 9 characters max. | Allowed Characters : a-z && A-Z only";
            // 
            // btn_generate_B
            // 
            this.btn_generate_B.Enabled = false;
            this.btn_generate_B.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_generate_B.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_generate_B.Location = new System.Drawing.Point(362, 47);
            this.btn_generate_B.Name = "btn_generate_B";
            this.btn_generate_B.Size = new System.Drawing.Size(75, 27);
            this.btn_generate_B.TabIndex = 15;
            this.btn_generate_B.Text = "N";
            this.btn_generate_B.UseVisualStyleBackColor = true;
            this.btn_generate_B.Click += new System.EventHandler(this.btn_generate_B_Click);
            // 
            // tbx_letters
            // 
            this.tbx_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.25F);
            this.tbx_letters.ForeColor = System.Drawing.Color.LightGray;
            this.tbx_letters.Location = new System.Drawing.Point(3, 41);
            this.tbx_letters.MaxLength = 9;
            this.tbx_letters.Name = "tbx_letters";
            this.tbx_letters.Size = new System.Drawing.Size(356, 40);
            this.tbx_letters.TabIndex = 0;
            this.tbx_letters.Text = "...type letters here";
            this.tbx_letters.TextChanged += new System.EventHandler(this.tbx_letters_TextChanged);
            this.tbx_letters.Enter += new System.EventHandler(this.tbx_letters_Enter);
            this.tbx_letters.Leave += new System.EventHandler(this.tbx_letters_Leave);
            // 
            // chx_usedictionary_A
            // 
            this.chx_usedictionary_A.AutoSize = true;
            this.chx_usedictionary_A.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chx_usedictionary_A.Location = new System.Drawing.Point(327, 124);
            this.chx_usedictionary_A.Name = "chx_usedictionary_A";
            this.chx_usedictionary_A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chx_usedictionary_A.Size = new System.Drawing.Size(130, 17);
            this.chx_usedictionary_A.TabIndex = 14;
            this.chx_usedictionary_A.Text = "[?Match In Dictionary]";
            this.chx_usedictionary_A.UseVisualStyleBackColor = true;
            this.chx_usedictionary_A.CheckedChanged += new System.EventHandler(this.chx_usedictionary_CheckedChanged);
            // 
            // lbl_foundWordsValue
            // 
            this.lbl_foundWordsValue.AutoSize = true;
            this.lbl_foundWordsValue.ForeColor = System.Drawing.Color.Green;
            this.lbl_foundWordsValue.Location = new System.Drawing.Point(148, 443);
            this.lbl_foundWordsValue.Name = "lbl_foundWordsValue";
            this.lbl_foundWordsValue.Size = new System.Drawing.Size(134, 13);
            this.lbl_foundWordsValue.TabIndex = 16;
            this.lbl_foundWordsValue.Text = "Dictionary Use Is Disabled!";
            // 
            // lbl_foundWordsText
            // 
            this.lbl_foundWordsText.AutoSize = true;
            this.lbl_foundWordsText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_foundWordsText.Location = new System.Drawing.Point(6, 443);
            this.lbl_foundWordsText.Name = "lbl_foundWordsText";
            this.lbl_foundWordsText.Size = new System.Drawing.Size(140, 13);
            this.lbl_foundWordsText.TabIndex = 15;
            this.lbl_foundWordsText.Text = "Dictionary Matches Found : ";
            // 
            // tab_page_B
            // 
            this.tab_page_B.Controls.Add(this.cbx_dictionaries);
            this.tab_page_B.Controls.Add(this.lbl_dictionaryStatusValue);
            this.tab_page_B.Controls.Add(this.lbl_dictionaryStatusText);
            this.tab_page_B.Controls.Add(this.btn_filenew);
            this.tab_page_B.Controls.Add(this.btn_filewrite);
            this.tab_page_B.Controls.Add(this.dg_excluded);
            this.tab_page_B.Controls.Add(this.btn_fileread);
            this.tab_page_B.Controls.Add(this.lb_fileread);
            this.tab_page_B.Location = new System.Drawing.Point(4, 22);
            this.tab_page_B.Name = "tab_page_B";
            this.tab_page_B.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_B.Size = new System.Drawing.Size(472, 497);
            this.tab_page_B.TabIndex = 1;
            this.tab_page_B.Text = "Dictionary";
            this.tab_page_B.UseVisualStyleBackColor = true;
            // 
            // cbx_dictionaries
            // 
            this.cbx_dictionaries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_dictionaries.FormattingEnabled = true;
            this.cbx_dictionaries.Location = new System.Drawing.Point(91, 10);
            this.cbx_dictionaries.Name = "cbx_dictionaries";
            this.cbx_dictionaries.Size = new System.Drawing.Size(274, 21);
            this.cbx_dictionaries.TabIndex = 19;
            this.cbx_dictionaries.SelectedIndexChanged += new System.EventHandler(this.cbx_dictionaries_SelectedIndexChanged);
            // 
            // lbl_dictionaryStatusValue
            // 
            this.lbl_dictionaryStatusValue.AutoSize = true;
            this.lbl_dictionaryStatusValue.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_dictionaryStatusValue.Location = new System.Drawing.Point(44, 481);
            this.lbl_dictionaryStatusValue.Name = "lbl_dictionaryStatusValue";
            this.lbl_dictionaryStatusValue.Size = new System.Drawing.Size(27, 13);
            this.lbl_dictionaryStatusValue.TabIndex = 18;
            this.lbl_dictionaryStatusValue.Text = "N/A";
            // 
            // lbl_dictionaryStatusText
            // 
            this.lbl_dictionaryStatusText.AutoSize = true;
            this.lbl_dictionaryStatusText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_dictionaryStatusText.Location = new System.Drawing.Point(6, 481);
            this.lbl_dictionaryStatusText.Name = "lbl_dictionaryStatusText";
            this.lbl_dictionaryStatusText.Size = new System.Drawing.Size(41, 13);
            this.lbl_dictionaryStatusText.TabIndex = 17;
            this.lbl_dictionaryStatusText.Text = "State : ";
            // 
            // btn_filenew
            // 
            this.btn_filenew.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_filenew.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_filenew.Location = new System.Drawing.Point(371, 8);
            this.btn_filenew.Name = "btn_filenew";
            this.btn_filenew.Size = new System.Drawing.Size(27, 23);
            this.btn_filenew.TabIndex = 5;
            this.btn_filenew.Text = "R";
            this.btn_filenew.UseVisualStyleBackColor = true;
            this.btn_filenew.Click += new System.EventHandler(this.btn_filenew_Click);
            // 
            // btn_filewrite
            // 
            this.btn_filewrite.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_filewrite.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_filewrite.Location = new System.Drawing.Point(437, 8);
            this.btn_filewrite.Name = "btn_filewrite";
            this.btn_filewrite.Size = new System.Drawing.Size(27, 23);
            this.btn_filewrite.TabIndex = 4;
            this.btn_filewrite.Text = "<";
            this.btn_filewrite.UseVisualStyleBackColor = true;
            this.btn_filewrite.Click += new System.EventHandler(this.btn_filewrite_Click);
            // 
            // sfd_filewrite
            // 
            this.sfd_filewrite.Filter = "Dictionary Files(*.dlc)|*.dlc|All files(*.*)|*.*";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 546);
            this.Controls.Add(this.tab_pages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator";
            ((System.ComponentModel.ISupportInitialize)(this.dg_words)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_excluded)).EndInit();
            this.tab_pages.ResumeLayout(false);
            this.tab_page_A.ResumeLayout(false);
            this.tab_page_A.PerformLayout();
            this.tab_letters.ResumeLayout(false);
            this.tab_A.ResumeLayout(false);
            this.tab_A.PerformLayout();
            this.tab_B.ResumeLayout(false);
            this.tab_B.PerformLayout();
            this.tab_page_B.ResumeLayout(false);
            this.tab_page_B.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label lb_wordLength;
        private CustomComboBox cb_wordLength;
        private GroupBox grp_lettersCombos;
        private Button btn_generate_A;
        private DataGridView dg_words;
        private Label lb_filedump;
        private Button btn_filedump;
        private SaveFileDialog sfd_filedump;
        private TextBox tbx_filedumppath;
        private Button btn_fileread;
        private Label lb_fileread;
        private DataGridView dg_excluded;
        private OpenFileDialog ofd_filedump;
        private TabControl tab_pages;
        private TabPage tab_page_A;
        private TabPage tab_page_B;
        private Button btn_filewrite;
        private SaveFileDialog sfd_filewrite;
        private Button btn_filenew;
        private CheckBox chx_usedictionary_A;
        private Label lbl_foundWordsValue;
        private Label lbl_foundWordsText;
        private Label lbl_dictionaryStatusValue;
        private Label lbl_dictionaryStatusText;
        private TabControl tab_letters;
        private TabPage tab_A;
        private TabPage tab_B;
        private TextBox tbx_letters;
        private Button btn_generate_B;
        private Label lb_wordInput;
        private ComboBox cbx_dictionaries;
    }
}

