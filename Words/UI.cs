using Facet.Combinatorics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace Words
{
    public partial class UI : Form
    {
        Color clr_ok = Color.Green;
        Color clr_warn = Color.DarkOrange;
        Color clr_error = Color.Red;
        Color clr_editing = Color.Purple;
        Color clr_create = Color.Blue;

        string load_ok = "Loaded!";
        string load_error = "Load Error!";
        string load_warn = "Warning : Too Many Columns Found In Dictionary File. Only First Column Will Be Used!";

        public UI()
        {
            InitializeComponent();

            //initialize application path and settings
            initApplicationSetup();

            //read dictionary settings and setup file
            initApplicationDictionary();
            //initDictionary();

            //initialize combos with letters
            feedWordLength();
        }

        private string getApplicationWorkingDirectory()
        {
            string appDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            return appDirectory;
        }

        private string addDictionary(string dictionary)
        {

            string dictionariesFilePathsString = readDictionaryPath();

            List < string > dictionariesFilePathsList = new List<string>();

            //add entry atop of existing entries
            if (File.Exists(dictionary.Trim()))
            {
                if (dictionariesFilePathsString.Contains(dictionary.Trim()))
                {
                    dictionariesFilePathsString = dictionariesFilePathsString.Replace(dictionary.Trim(), "");
                    dictionariesFilePathsString = dictionariesFilePathsString.Replace("||", "|");
                }
                dictionariesFilePathsList.Add(dictionary.Trim());
            }

            //add existing entries
            foreach (var dic in dictionariesFilePathsString.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (File.Exists(dic.Trim()))
                {
                    dictionariesFilePathsList.Add(dic.Trim());
                }
            }

            cbx_dictionaries.DataSource = dictionariesFilePathsList;

            dictionariesFilePathsString = string.Join("|", dictionariesFilePathsList.ToArray());

            writeDictionaryPath(dictionariesFilePathsString);

            return dictionariesFilePathsString;

        }

        private string deleteDictionary(string dictionary)
        {

            string dictionariesFilePathsString = readDictionaryPath();

            List<string> dictionariesFilePathsList = new List<string>();

            //add entry atop of existing entries
            if (dictionariesFilePathsString.Contains(dictionary.Trim()))
            {
                dictionariesFilePathsString = dictionariesFilePathsString.Replace(dictionary.Trim(), "");
                dictionariesFilePathsString = dictionariesFilePathsString.Replace("||", "|");
            }

            //add existing entries
            foreach (var dic in dictionariesFilePathsString.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (File.Exists(dic.Trim()))
                {
                    dictionariesFilePathsList.Add(dic.Trim());
                }
            }

            cbx_dictionaries.DataSource = dictionariesFilePathsList;

            dictionariesFilePathsString = string.Join("|", dictionariesFilePathsList.ToArray());

            writeDictionaryPath(dictionariesFilePathsString);

            return dictionariesFilePathsString;

        }

        private void initDictionary()
        {

            string dictionariesFilePathsString = readDictionaryPath();

            List<string> dictionariesFilePathsList = new List<string>();

            foreach (var dic in dictionariesFilePathsString.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (File.Exists(dic.Trim()))
                {
                    dictionariesFilePathsList.Add(dic.Trim());
                }
            }

            cbx_dictionaries.DataSource = dictionariesFilePathsList;

        }

        private void initApplicationDictionary()
        {

            initDictionary();

            if (cbx_dictionaries.SelectedItem == null)
            {

            }
            else
            {
                string dictionaryFilePath = cbx_dictionaries.SelectedItem.ToString();

                //check on empty path
                if (File.Exists(dictionaryFilePath))
                {
                    //read dictionary contents
                    if (readFromCsv(dictionaryFilePath, dg_excluded) == 1)
                    {
                        addDictionary(dictionaryFilePath);
                        lbl_dictionaryStatusValue.ForeColor = clr_ok;
                        lbl_dictionaryStatusValue.Text = load_ok;
                    }
                    else if (readFromCsv(dictionaryFilePath, dg_excluded) == 2)
                    {
                        //save path into config
                        addDictionary(dictionaryFilePath);
                        lbl_dictionaryStatusValue.ForeColor = clr_warn;
                        lbl_dictionaryStatusValue.Text = load_warn;
                    }
                    else
                    {
                        lbl_dictionaryStatusValue.ForeColor = clr_error;
                        lbl_dictionaryStatusValue.Text = load_error;
                    }
                }

            }
        }

        private string readDictionaryPath()
        {
            string appDirectory;
            appDirectory = getApplicationWorkingDirectory();

            string appSettingsFileName;
            appSettingsFileName = "settings.xml";

            string appSettingsPath = appDirectory + "\\" + appSettingsFileName;
            string pstrValueToRead = "dictionarypath";

            string dictionaryFilePath = ReadValueFromXML(pstrValueToRead, appSettingsPath);
            return dictionaryFilePath;
        }

        private void writeDictionaryPath(string dictionaryPath)
        {
            string appDirectory;
            appDirectory = getApplicationWorkingDirectory();

            string appSettingsFileName;
            appSettingsFileName = "settings.xml";

            string appSettingsPath = appDirectory + "\\" + appSettingsFileName;
            string pstrValueToRead = "dictionarypath";

            WriteValueToXML(pstrValueToRead, dictionaryPath, appSettingsPath);

        }

        private void initApplicationSetup()
        {
            string appDirectory;
            appDirectory = getApplicationWorkingDirectory();

            string appSettingsFileName;
            appSettingsFileName = "settings.xml";

            string appSettingsPath = appDirectory + "\\" + appSettingsFileName;
            //File settingsFileObject;

            if (!File.Exists(appSettingsPath))
            {
                //write settings file if it didn't exist
                StringBuilder sb = new StringBuilder();
                //string dictionaryFileName = "dictionary.dic";
                //string dictionaryPath = appDirectory + "\\" + dictionaryFileName;
                //construct settings file content
                sb.Append("<settings>");
                sb.Append("<dictionarypath>");
                //sb.Append(dictionaryPath);
                sb.Append("</dictionarypath>");
                sb.Append("</settings>");
                //write settings to new file
                StreamWriter sw = new StreamWriter(appSettingsPath);
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
        }

        private void initDataGrid(DataGridView dg)
        {
            dg.DataSource = null;
            dg.Columns.Add("Word", "Word");
        }

        private static string ReadValueFromXML(string pstrValueToRead, string settingsFilePath)
        {
            try
            {
                //settingsFilePath is a string variable storing the path of the settings file 
                XPathDocument doc = new XPathDocument(settingsFilePath);
                XPathNavigator nav = doc.CreateNavigator();
                // Compile a standard XPath expression
                XPathExpression expr;
                expr = nav.Compile(@"/settings/" + pstrValueToRead);
                XPathNodeIterator iterator = nav.Select(expr);
                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    return iterator.Current.Value;
                }
                return string.Empty;
            }
            catch
            {
                //do some error logging here if needed 
                return string.Empty;
            }
        }

        private static bool WriteValueToXML(string pstrValueToRead, string pstrValueToWrite, string settingsFilePath)
        {
            try
            {
                //settingsFilePath is a string variable storing the path of the settings file 
                XmlTextReader reader = new XmlTextReader(settingsFilePath);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                //we have loaded the XML, so it's time to close the reader.
                reader.Close();
                XmlNode oldNode;
                XmlElement root = doc.DocumentElement;
                oldNode = root.SelectSingleNode("/settings/" + pstrValueToRead);
                oldNode.InnerText = pstrValueToWrite;
                doc.Save(settingsFilePath);
                return true;
            }
            catch
            {
                //properly you need to log the exception here. But as this is just an
                //example, I am not doing that. 
                return false;
            }
        }

        private string[] createLettersArray()
        {
            List<string> list = new List<string>();

            for (char c = 'A'; c <= 'Z'; c++)
            {
                list.Add(c.ToString());
            }

            string[] array = list.ToArray();

            return array;
        }

        // Initialize "cb_wordLength".
        private void feedWordLength()
        {

            int i_length = 9; // array size of 10 (0-9)
            string[] s_length = new string[i_length];

            for (int i = 0; i < i_length; i++)
            {
                s_length[i] = (i + 1).ToString();
            }

            cb_wordLength.Items.AddRange(s_length);

            //
            cb_wordLength.BeforeUpdate += new System.ComponentModel.CancelEventHandler(cb_wordLength_BeforeUpdate);

        }

        //get word from letters as list
        private List<string> getWordFromLetters()
        {
            List<string> list = new List<string>();

            //loop thru combos to get selected letters
            for (int i = 0; i <= this.grp_lettersCombos.Controls.Count - 1; i++)
            {
                list.Add(this.grp_lettersCombos.Controls[i].Text.ToString());
            }

            return list;

        }

        private List<string> getWordFromWord()
        {
            List<string> list = new List<string>();
            string word;
            //loop thru combos to get selected letters
            //for (int i = 0; i <= this.grp_lettersCombos.Controls.Count - 1; i++)
            //{
            //    list.Add(this.grp_lettersCombos.Controls[i].Text.ToString());
            //}

            word = tbx_letters.Text.ToString().ToUpper();

            for (int i = 0; i < word.Length; i++)
            { 
                list.Add(word[i].ToString());
            }

            return list;

        }

        //feed letters label
        private void feedLettersLabel()
        {
            string s_letters = "Letters : ";

            //loop thru combos to get selected letters
            for (int i = 0; i <= this.grp_lettersCombos.Controls.Count - 1; i++)
            {
                s_letters = s_letters + this.grp_lettersCombos.Controls[i].Text;
            }

            //this.lb_letters.Text = s_letters;

        }

        private void cb_wordLength_BeforeUpdate(object sender, System.EventArgs e)
        {


            //create local variable from sending object e.g. combobox
            CustomComboBox cb_sender = (CustomComboBox)sender;


            //get previous and current seletions by index
            int prevIndex = cb_sender.mPrevIndex;
            int currIndex = cb_sender.SelectedIndex;

            //remove redundant letters combos (combos already existed and currently less number of letters than before)
            if (prevIndex > -1 && prevIndex > currIndex)
            {
                //purge all previously programatically created combos starting with "cbl_"
                for (int i = prevIndex; i > currIndex; i--)
                {
                    this.grp_lettersCombos.Controls[i].Dispose();
                }
            }
            else
            {

                //user selected number of words
                int cbl_startPoint_X = 7;
                int cbl_startPoint_Y = 15;
                int cbl_distancePoint_X = 38;

                if (prevIndex == -1)
                {
                    //no previous combos existed, set first combo index
                    prevIndex = 0;
                }
                else
                {
                    //previous combos existed, set next combo index after last one
                    prevIndex = prevIndex + 1;
                }

                //create letters array from comboboxes
                string[] a_letters = createLettersArray();

                for (int i = prevIndex; i <= currIndex; i++)
                {

                    ComboBox cbl = new System.Windows.Forms.ComboBox();

                    cbl.FormattingEnabled = false;
                    cbl.Location = new System.Drawing.Point(cbl_startPoint_X + (i * cbl_distancePoint_X), cbl_startPoint_Y);
                    cbl.MaxLength = 1;
                    cbl.Name = "cbl_" + i.ToString();
                    cbl.Size = new System.Drawing.Size(36, 21);
                    cbl.TabIndex = 1;
                    cbl.Text = "?";

                    cbl.Items.AddRange(a_letters);

                    cbl.SelectedValueChanged += new System.EventHandler(cbl_letter_SelectedValueChanged);

                    this.grp_lettersCombos.Controls.Add(cbl);
                }

            }

            feedLettersLabel();

        }

        private void cbl_letter_SelectedValueChanged(object sender, System.EventArgs e)
        {
            feedLettersLabel();
        }

        private List<StringOrderValueTag> getWords(int typeOfInput)
        {
            int counter;
            //bool tag;
            //bool dictionaryLoaded;
            bool inDictionary;
            bool searchDictionary;

            int wordCellOrder = 0;
            int dictionaryMatchesCount = 0;

            List<string> l_list = new List<string>();

            switch (typeOfInput)
            {
                case 0:
                    l_list = getWordFromLetters();
                    break;

                case 1:
                    l_list = getWordFromWord();
                    break;

                default:
                    l_list = null;
                    break;
            }


            List<StringOrderValueTag> w_list = new List<StringOrderValueTag>();
            List<string> l_excluded = new List<string>();
            Permutations<string> permutations = new Permutations<string>(l_list);

            counter = 0;
            searchDictionary = false;
            inDictionary = false;
            

            if (chx_usedictionary_A.Checked) // & cbx_dictionaries.SelectedItem.ToString() != "")
            {
                searchDictionary = true;

                foreach (DataGridViewRow item in dg_excluded.Rows)
                {
                    if (item.Cells[wordCellOrder].Value != null)
                    {
                        l_excluded.Add(item.Cells[wordCellOrder].Value.ToString());
                    }
                }
            }

            foreach (IList<string> p in permutations)
            {

                counter += 1;

                StringBuilder word = new StringBuilder();

                foreach (var letter in p)
                {
                    word.Append(letter);
                }


                if (searchDictionary)
                {
                    inDictionary = l_excluded.Contains(word.ToString());
                }

                if (inDictionary)
                {
                    dictionaryMatchesCount += 1;
                }

                w_list.Add(new StringOrderValueTag(counter,word.ToString(), inDictionary));

                
            }

            if (chx_usedictionary_A.Checked)
            { 
                lbl_foundWordsValue.Text = dictionaryMatchesCount.ToString();
            }

            return w_list;
        }

        private int readFromCsv(string filePath, DataGridView dg)
        //private bool readFromCsv(string filePath, DataGridView dg)
        {

            bool tooManyColumns;

            try
            {

                if (dg.Columns.Count > 0)
                {
                    dg.Columns.Clear();
                }
                
                var dt = new DataTable();

                tooManyColumns = false;

                // Creating the columns
                foreach (var headerLine in File.ReadLines(filePath).Take(1))
                {
                    if (headerLine != "")
                    {
                        if (!tooManyColumns)
                        {
                            if (headerLine.Contains(","))
                            {
                                tooManyColumns = true;
                            }
                        }

                        foreach (var headerItem in headerLine.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            dt.Columns.Add(headerItem.Trim());
                        }
                    }
                }

                // Adding the rows
                foreach (var line in File.ReadLines(filePath).Skip(1))
                {
                    if (line != "")
                    {
                        if (!tooManyColumns)
                        {
                            if (line.Contains(","))
                            {
                                tooManyColumns = true;
                            }
                        }
                        dt.Rows.Add(line.Split(','));
                    }
                }

                dg.DataSource = dt;

                //return true;
                if (tooManyColumns)
                {
                    return 2;
                }
                else
                { 
                    return 1;
                }

            }
            catch
            {
                //return false;
                return 0;
            }

        }

        private bool writeToCsv(string filePath, DataGridView dg)
        {
            try
            {

                int columnCount = dg.ColumnCount;
                string columnNames = "";
                string[] output = new string[dg.RowCount + 1];

                for (int i = 0; i < columnCount; i++)
                {
                    if (i != columnCount - 1)
                    {
                        columnNames += dg.Columns[i].Name.ToString() + ",";
                    }
                    else
                    {
                        columnNames += dg.Columns[i].Name.ToString();
                    }

                }

                output[0] += columnNames;

                int dg_rowCount;
                if (dg.AllowUserToAddRows)
                {
                    dg_rowCount = dg.RowCount - 1;
                }
                else
                {
                    dg_rowCount = dg.RowCount;
                }

                for (int i = 1; (i - 1) < dg_rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        if (j != columnCount - 1)
                        {
                                output[i] += dg.Rows[i - 1].Cells[j].Value.ToString().ToUpper() + ",";                         
                        }
                        else
                        {
                                output[i] += dg.Rows[i - 1].Cells[j].Value.ToString().ToUpper();
                        }

                    }
                }

                System.IO.File.WriteAllLines(filePath, output, System.Text.Encoding.UTF8);

                return true;

            }
            catch
            {
                return false;
            }

        }

        private void btn_filedump_Click(object sender, EventArgs e)
        {

            if (sfd_filedump.ShowDialog() == DialogResult.OK)
            {
                string file = sfd_filedump.FileName.ToString();
                //string file = "c:\\Users\\Kirby\\Documents\\words.dic";

                //check on empty path
                if (file != "")
                {
                    if (writeToCsv(file, dg_words))
                    {
                        //show save path & filename
                        tbx_filedumppath.Text = file;
                        //show mwssage
                        MessageBox.Show("Words Saved To File!", "Info :");
                    }
                    else
                    {
                        //show save path & filename
                        tbx_filedumppath.Text = "";
                        //show mwssage
                        MessageBox.Show("Words Not Saved To File!", "Error :");
                    }
                }
            }
        }

        private void btn_fileread_Click(object sender, EventArgs e)
        {

            if (ofd_filedump.ShowDialog() == DialogResult.OK)
            {

                string file = ofd_filedump.FileName.ToString();
 
                //check on empty path
                if (file != "")
                {
                    //read dictionary contents
                    //if (readDictionaryFile(file, dg_excluded))
                    if (readFromCsv(file, dg_excluded) == 1)
                    {
                        //save path into config
                        //writeDictionaryPath(file);
                        addDictionary(file);
                        //show save path
                        //tbx_filereadpath.Text = file;
                        //show mwssage
                        //MessageBox.Show("Dictionary Loaded!", "Info :");
                        lbl_dictionaryStatusValue.ForeColor = clr_ok;
                        lbl_dictionaryStatusValue.Text = load_ok;
                    }
                    else if (readFromCsv(file, dg_excluded) == 2)
                    {
                        //save path into config
                        //writeDictionaryPath(file);
                        addDictionary(file);
                        //show save path
                        //tbx_filereadpath.Text = file;
                        //show mwssage
                        //MessageBox.Show("Dictionary Loaded!", "Info :");
                        lbl_dictionaryStatusValue.ForeColor = clr_warn;
                        lbl_dictionaryStatusValue.Text = load_warn;
                    }
                    else
                    {
                        //save path into config
                        //writeDictionaryPath(file);
                        //show save path
                        //tbx_filereadpath.Text = "";
                        //show mwssage
                        //MessageBox.Show("Error In Reading Dictionary. Dictionary Not Loaded!", "Info :");
                        lbl_dictionaryStatusValue.ForeColor = clr_error;
                        lbl_dictionaryStatusValue.Text = load_error;
                    }
                }

            }
        }

        private void btn_filewrite_Click(object sender, EventArgs e)
        {

            string save_ok = "Saved!";
            string save_error = "Save Error!";

            //string dictionaryFilePath = tbx_filereadpath.Text;
            string dictionaryFilePath = cbx_dictionaries.SelectedItem.ToString();

            //given dictionary file exits and is already opened in UI so just owerwrite it
            if (File.Exists(dictionaryFilePath))
            {
                //if (writeDictionaryFile(dictionaryFilePath, dg_excluded))
                if(writeToCsv(dictionaryFilePath, dg_excluded))
                {
                    //reload dictionary after save
                    readFromCsv(dictionaryFilePath, dg_excluded);
                    //show mwssage
                    //MessageBox.Show("Dictionary Saved!", "Info :");
                    lbl_dictionaryStatusValue.ForeColor = clr_ok;
                    lbl_dictionaryStatusValue.Text = save_ok;
                }
                else
                {
                    //show mwssage
                    //MessageBox.Show("Dictionary Not Saved!", "Error :");
                    lbl_dictionaryStatusValue.ForeColor = clr_error;
                    lbl_dictionaryStatusValue.Text = save_error;
                }
            }
            else
            { 
                //given dictionary file doesn't exists
                if (sfd_filewrite.ShowDialog() == DialogResult.OK)
                {

                    dictionaryFilePath = sfd_filewrite.FileName.ToString();

                    //check on empty path
                    if (dictionaryFilePath != "")
                    {
                        if (writeToCsv(dictionaryFilePath, dg_excluded))
                        {
                            //reload dictionary after save
                            readFromCsv(dictionaryFilePath, dg_excluded);
                            //save path into config
                            //writeDictionaryPath(dictionaryFilePath);
                            addDictionary(dictionaryFilePath);
                            //show save path & filename
                            //tbx_filereadpath.Text = dictionaryFilePath;
                            //show mwssage
                            //MessageBox.Show("Dictionary Saved!", "Info :");
                            lbl_dictionaryStatusValue.ForeColor = clr_ok;
                            lbl_dictionaryStatusValue.Text = save_ok;
                        }
                        else
                        {
                            //show save path & filename
                            //tbx_filereadpath.Text = "";
                            //show message
                            //MessageBox.Show("Dictionary Not Saved!", "Error :");
                            lbl_dictionaryStatusValue.ForeColor = clr_error;
                            lbl_dictionaryStatusValue.Text = save_error;
                        }
                    }
                }
            }

        }

        private void btn_filenew_Click(object sender, EventArgs e)
        {

            string create_ok = "Dictionary Created!";
            string create_error = "Dictionary Creation Error!";

            string dictionaryFilePath;
            
            //dg_excluded.Columns.Clear();
            initDataGrid(dg_excluded);

            //given dictionary file doesn't exists
            if (sfd_filewrite.ShowDialog() == DialogResult.OK)
            {

                dictionaryFilePath = sfd_filewrite.FileName.ToString();

                //check on empty path
                if (dictionaryFilePath != "")
                {
                    if (writeToCsv(dictionaryFilePath, dg_excluded))
                    {
                        //reload dictionary after save
                        readFromCsv(dictionaryFilePath, dg_excluded);
                        //save path into config
                        //writeDictionaryPath(dictionaryFilePath);
                        addDictionary(dictionaryFilePath);
                        //show save path & filename
                        //tbx_filereadpath.Text = dictionaryFilePath;
                        //show mwssage
                        //MessageBox.Show("Dictionary Created!", "Info :");
                        lbl_dictionaryStatusValue.ForeColor = clr_create;
                        lbl_dictionaryStatusValue.Text = create_ok;
                    }
                    else
                    {
                        //show save path & filename
                        //tbx_filereadpath.Text = "";
                        //show mwssage
                        //MessageBox.Show("Dictionary Not Created!", "Error :");
                        lbl_dictionaryStatusValue.ForeColor = clr_error;
                        lbl_dictionaryStatusValue.Text = create_error;
                    }
                }
            }
        }

        private void chx_usedictionary_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_usedictionary_A.Checked)
            {
                lbl_foundWordsValue.Text = "N/A";
            }
            else
            {
                lbl_foundWordsValue.Text = "Dictionary Use Is Disabled!";
            }
            
        }

        private void dg_excluded_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            lbl_dictionaryStatusValue.ForeColor = clr_editing;
            lbl_dictionaryStatusValue.Text = "Editing!";
        }

        private void tbx_letters_TextChanged(object sender, EventArgs e)
        {

            if (tbx_letters.Text != "" && tbx_letters.Text != "...type letters here")
            {
                string input;
                bool isValid;

                input = tbx_letters.Text;
                isValid = Regex.IsMatch(input, @"^[a-zA-Z]+$");

                if (isValid)
                {
                    //btn_lettersValid.Text = "V";
                    tbx_letters.ForeColor = Color.Green;
                    btn_generate_B.Enabled = true;
                    //btn_generate_B.FlatStyle = FlatStyle.Standard;
                }
                else
                {
                    //btn_lettersValid.Text = "I";
                    tbx_letters.ForeColor = Color.Red;
                    btn_generate_B.Enabled = false;
                    //btn_generate_B.ForeColor = Color.Red;
                    //btn_generate_B.FlatStyle = FlatStyle.Flat;
                }
            }
            else
            {
                btn_generate_B.Enabled = false;
            } 

        }

        private void btn_generate_A_Click(object sender, EventArgs e)
        {
            List<StringOrderValueTag> w_list = new List<StringOrderValueTag>(getWords(0));

            dg_words.DataSource = w_list;
        }

        private void btn_generate_B_Click(object sender, EventArgs e)
        {
            List<StringOrderValueTag> w_list = new List<StringOrderValueTag>(getWords(1));

            dg_words.DataSource = w_list;
        }

        private void tab_letters_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg_words.DataSource = null;
        }

        private void tbx_letters_Enter(object sender, EventArgs e)
        {
            if (tbx_letters.Text == "...type letters here")
            { 
                tbx_letters.Text = "";
            }
        }

        private void tbx_letters_Leave(object sender, EventArgs e)
        {
            if (tbx_letters.Text == "")
            {
                tbx_letters.ForeColor = Color.LightGray;
                tbx_letters.Text = "...type letters here";
            }
        }

        private void cbx_dictionaries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string file = cbx_dictionaries.SelectedItem.ToString();

            //check on empty path
            if (File.Exists(file))
            {
                if (readFromCsv(file, dg_excluded) == 1)
                {
                    addDictionary(file);
                    lbl_dictionaryStatusValue.ForeColor = clr_ok;
                    lbl_dictionaryStatusValue.Text = load_ok;
                }
                else if (readFromCsv(file, dg_excluded) == 2)
                {
                    addDictionary(file);
                    lbl_dictionaryStatusValue.ForeColor = clr_warn;
                    lbl_dictionaryStatusValue.Text = load_warn;
                }
                else
                {
                    lbl_dictionaryStatusValue.ForeColor = clr_error;
                    lbl_dictionaryStatusValue.Text = load_error;
                }
            }
            else
            {
                deleteDictionary(file);
                lbl_dictionaryStatusValue.ForeColor = clr_error;
                lbl_dictionaryStatusValue.Text = load_error;
            }
        }

        private void cb_wordLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_generate_A.Enabled= true;
        }
    }
}
