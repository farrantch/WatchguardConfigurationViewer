using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using FireboxConfigVisualizer;

namespace FirewallConfigVisualizer
{
    public partial class FirewallGui : Form
    {
        public XDocument configFile;
        public Profile profile;

        public List<AbsPolicy> AbsPolicyList;
        public List<AliasMember> AliasFromList;
        public List<AliasMember> AliasToList;
        public List<AddressMember> AddressFromList;
        public List<AddressMember> AddressToList;
        public List<ServiceMember> ServiceList;
        public List<NatMember> NatList;

        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        private SolidBrush reportsBackgroundBrushSelected = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        private SolidBrush reportsBackgroundBrush = new SolidBrush(Color.White);
        private SolidBrush backgroundBlock = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#F5BABA"));
        private SolidBrush backgroundAllow = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#BAF5BC"));
        private SolidBrush backgroundProxy = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#F2F5BA"));
        private SolidBrush backgroundBlockSelected = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#A80000"));
        private SolidBrush backgroundAllowSelected = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#08A800"));
        private SolidBrush backgroundProxySelected = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#A3A800"));

        public ListViewColumnSorter lvwColumnSorter;

        public string SearchString;

        public FirewallGui()
        {
            InitializeComponent();

            AbsPolicyList = new List<AbsPolicy>();
            AliasFromList = new List<AliasMember>();
            AliasToList = new List<AliasMember>();
            AddressFromList = new List<AddressMember>();
            AddressToList = new List<AddressMember>();
            ServiceList = new List<ServiceMember>();
            NatList = new List<NatMember>();

            this.BackColor = Color.LightGray;

            listViewService.View = View.Details;

            lvwColumnSorter = new ListViewColumnSorter();
            this.listViewService.ListViewItemSorter = lvwColumnSorter;

            SearchString = "";
        }

        private void bnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Firebox Config File|*.xml";
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    configFile = XDocument.Load(openFileDialog.FileName);
                    xmlStatus.Text = "Loaded";
                    xmlStatus.ForeColor = System.Drawing.Color.Green;

                    var serializer = new XmlSerializer(typeof(Profile));

                    using (var stream = new StringReader(configFile.ToString()))
                    using (var reader = XmlReader.Create(stream))
                    {
                        profile = (Profile)serializer.Deserialize(reader);
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Load Failure");
                }
            }

            foreach (Alias a in profile.Aliases)
                foreach (AliasMember am in a.AliasMembers)
                    am.highlight = false;

            foreach (Address ad in profile.Addresses)
                foreach (AddressMember adm in ad.AddressMembers)
                    adm.highlight = false;

            PopulateArrays();
        }

        private void PopulateArrays()
        {
            foreach (AbsPolicy abs in profile.AbsPolicies)
            {
                AbsPolicyList.Add(abs);
            }

            RefreshGui();
        }

        private void RefreshGui()
        {
            listBoxPolicy.DataSource = null;
            listBoxPolicy.DataSource = AbsPolicyList;
            tbPolicyListCount.Text = AbsPolicyList.Count + " policies";
        }

        private void listBoxPolicy_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < listBoxPolicy.Items.Count)
            {
                string text = listBoxPolicy.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (AbsPolicyList[index].Firewall == "Allow")
                {
                    if (selected)
                        backgroundBrush = backgroundAllowSelected;
                    else
                        backgroundBrush = backgroundAllow;
                }
                else if (AbsPolicyList[index].Firewall == "Proxy")
                {
                    if (selected)
                        backgroundBrush = backgroundProxySelected;
                    else
                        backgroundBrush = backgroundProxy;
                }
                else
                {
                    if (selected)
                        backgroundBrush = backgroundBlockSelected;
                    else
                        backgroundBrush = backgroundBlock;
                }

                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
                g.DrawString(text, e.Font, foregroundBrush, listBoxPolicy.GetItemRectangle(index).Location);
            }

            e.DrawFocusRectangle();
        }

        private void listBoxAddressFrom_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;
            string text = listBoxAddressFrom.Items[index].ToString();
            bool highlight = AddressFromList[index].highlight;
            Graphics g = e.Graphics;

            //background
            SolidBrush backgroundBrush = reportsBackgroundBrush;
            g.FillRectangle(backgroundBrush, e.Bounds);

            //text
            SolidBrush textColor;
            if (highlight)
                textColor = new SolidBrush(Color.Red);
            else
                textColor = reportsForegroundBrush;
            g.DrawString(text, e.Font, textColor, listBoxAddressFrom.GetItemRectangle(index).Location);

            e.DrawFocusRectangle();
        }

        private void listBoxAddressTo_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;
            string text = listBoxAddressTo.Items[index].ToString();
            bool highlight = AddressToList[index].highlight;
            Graphics g = e.Graphics;

            //background
            SolidBrush backgroundBrush = reportsBackgroundBrush;
            g.FillRectangle(backgroundBrush, e.Bounds);

            //text
            SolidBrush textColor;
            if (highlight)
                textColor = new SolidBrush(Color.Red);
            else
                textColor = reportsForegroundBrush;
            g.DrawString(text, e.Font, textColor, listBoxAddressTo.GetItemRectangle(index).Location);

            e.DrawFocusRectangle();
        }

        private void listBoxPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxPolicy.SelectedIndex;
            if (index >= 0)
            {
                AliasFromList.Clear();
                AliasToList.Clear();
                ServiceList.Clear();

                PopulateAlias1stRow();

                AbsPolicy abs = AbsPolicyList[index];

                // Refresh Aliases
                foreach (Alias al in profile.Aliases)
                {
                    List<Address> addresses = GetAddresses(al);

                    if (abs.FromAlias[0] == al.Name)
                    {
                        foreach (AliasMember am in al.AliasMembers)
                        {
                            // If Address
                            if (am.Address != null)
                            {
                                if (al.Name.Split('.')[0] != am.Address.Split('.')[0])
                                {
                                    AliasFromList.Add(am);
                                }
                            }
                            else
                                AliasFromList.Add(am);
                        }
                    }
                    else if (abs.ToAlias[0] == al.Name)
                    {
                        foreach (AliasMember am in al.AliasMembers)
                        {
                            // If Address
                            if (am.Address != null)
                            {
                                if (al.Name.Split('.')[0] != am.Address.Split('.')[0])
                                {
                                    AliasToList.Add(am);
                                }
                            }
                            else
                                AliasToList.Add(am);
                        }
                    }
                    else
                    {

                    }
                }

                // Refresh Services
                foreach (Service s in profile.Services)
                {
                    if (abs.Service == s.Name)
                    {
                        listViewService.BeginUpdate();
                        listViewService.Items.Clear();
                        foreach (ServiceMember sm in s.ServiceMembers)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = sm.GetServerPort();
                            lvi.SubItems.Add(s.Name);
                            lvi.SubItems.Add(sm.GetProtocol());
                            listViewService.Items.Add(lvi);
                        }

                        //SortServiceListView();

                        listViewService.EndUpdate();
                        listViewService.Refresh();
                    }
                }

                listBoxAliasFrom.DataSource = null;
                listBoxAliasTo.DataSource = null;
                listBoxAliasFrom.DataSource = AliasFromList;
                listBoxAliasTo.DataSource = AliasToList;
                listBoxAliasFrom.SelectedIndex = 0;
                listBoxAliasTo.SelectedIndex = 0;
                richTextBoxDescription.Text = abs.Description;
            }
        }

        private void PopulateAlias1stRow()
        {
            AliasMember AmFrom = new AliasMember();
            AmFrom.AliasName = "All";
            AliasFromList.Add(AmFrom);

            AliasMember AmTo = new AliasMember();
            AmFrom.AliasName = "All";
            AliasToList.Add(AmTo);
        }

        private void listBoxAliasFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxAliasFrom.SelectedIndex;
            if (index >= 0)
            {
                AddressFromList.Clear();

                AliasMember alm = AliasFromList[index];

                if (alm.Type == 1)
                {
                    foreach (Address ad in profile.Addresses)
                    {
                        if (alm.Address == ad.Name)
                        {
                            foreach (AddressMember adm in ad.AddressMembers)
                            {
                                AddressFromList.Add(adm);
                            }
                        }
                    }
                }

                // Alias
                else if (alm.Type == 2)
                {
                    AliasMember alm2 = AliasFromList[index];

                    foreach (Alias a in profile.Aliases)
                    {
                        if (alm2.AliasName == a.Name)
                        {
                            foreach (AliasMember am in a.AliasMembers)
                            {
                                foreach (Address ad in profile.Addresses)
                                {
                                    if (am.Address == ad.Name)
                                    {
                                        foreach (AddressMember addmem in ad.AddressMembers)
                                        {
                                            AddressFromList.Add(addmem);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // All Addresses
                else
                {
                    int selectedPolicy = listBoxPolicy.SelectedIndex;
                    AbsPolicy abs = AbsPolicyList[selectedPolicy];
                    var test = 0;
                    foreach (Alias al in profile.Aliases)
                    {
                        if (al.Name == abs.FromAlias[0])
                        {
                            foreach (AliasMember alm2 in al.AliasMembers)
                            {
                                if (alm2.Type == 1)
                                {
                                    foreach (Address add in profile.Addresses)
                                    {
                                        if (add.Name == alm2.Address)
                                        {
                                            foreach (AddressMember adm in add.AddressMembers)
                                            {
                                                AddressFromList.Add(adm);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    int count = 0;
                    foreach (AliasMember alm2 in AliasFromList)
                    {
                        if (count != 0)
                        {
                            foreach (Alias al in profile.Aliases)
                            {
                                if (alm2.AliasName == al.Name)
                                {
                                    foreach (AliasMember alm3 in al.AliasMembers)
                                    {
                                        foreach (Address add in profile.Addresses)
                                        {
                                            if (alm3.Address == add.Name)
                                            {
                                                foreach (AddressMember adm in add.AddressMembers)
                                                    AddressFromList.Add(adm);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        count++;
                    }
                }

                listBoxAddressFrom.DataSource = null;
                listBoxAddressFrom.DataSource = AddressFromList;
            }
        }

        private void listBoxAliasTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxAliasTo.SelectedIndex;
            if (index >= 0)
            {
                AddressToList.Clear();

                AliasMember alm = AliasToList[index];
               
                // Address
                if (alm.Type == 1)
                {
                    foreach (Address ad in profile.Addresses)
                    {
                        if (alm.Address == ad.Name)
                        {
                            foreach (AddressMember adm in ad.AddressMembers)
                            {
                                AddressToList.Add(adm);
                            }
                        }
                    }
                }

                // Alias
                if (alm.Type == 2)
                {
                    AliasMember alm2 = AliasToList[index];

                    foreach (Alias a in profile.Aliases)
                    {
                        if (alm2.AliasName == a.Name)
                        {
                            foreach (AliasMember am in a.AliasMembers)
                            {
                                foreach (Address ad in profile.Addresses)
                                {
                                    if (am.Address == ad.Name)
                                    {
                                        foreach (AddressMember addmem in ad.AddressMembers)
                                        {
                                            AddressToList.Add(addmem);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // All Addresses
                else
                {
                    int selectedPolicy = listBoxPolicy.SelectedIndex;
                    AbsPolicy abs = AbsPolicyList[selectedPolicy];
                    foreach (Alias al in profile.Aliases)
                    {
                        if (al.Name == abs.ToAlias[0])
                        {
                            foreach (AliasMember alm2 in al.AliasMembers)
                            {
                                if (alm2.Type == 1)
                                {
                                    foreach (Address add in profile.Addresses)
                                    {
                                        if (add.Name == alm2.Address)
                                        {
                                            foreach (AddressMember adm in add.AddressMembers)
                                            {
                                                AddressToList.Add(adm);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    int count = 0;
                    foreach (AliasMember alm2 in AliasToList)
                    {
                        if (count != 0)
                        {
                            foreach (Alias al in profile.Aliases)
                            {
                                if (alm2.AliasName == al.Name)
                                {
                                    foreach (AliasMember alm3 in al.AliasMembers)
                                    {
                                        foreach (Address add in profile.Addresses)
                                        {
                                            if (alm3.Address == add.Name)
                                            {
                                                foreach (AddressMember adm in add.AddressMembers)
                                                    AddressToList.Add(adm);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        count++;
                    }
                }

                listBoxAddressTo.DataSource = null;
                listBoxAddressTo.DataSource = AddressToList;
            }
        }

        private void listViewService_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            IPAddress ip;

            if (tbSearch.Text.Length < 1)
                MessageBox.Show("Search Empty");

            else if (IPAddress.TryParse(tbSearch.Text, out ip))
            {
                SearchIpAddress(tbSearch.Text);
            }

            else
                SearchText(tbSearch.Text);

        }

        private void SearchText(string p)
        {
            throw new NotImplementedException();
        }

        private void SearchIpAddress(string searchString)
        {
            ClearLists();
            SetAllMembersFalse();

            PopulateAlias1stRow();
            SearchString = searchString;

            foreach (AbsPolicy absp in profile.AbsPolicies)
            {
                //From
                foreach (Alias al in profile.Aliases.Where(z => z.Name == absp.FromAlias[0]))
                {
                    foreach (AliasMember alm in al.AliasMembers)
                    {
                        //If Address
                        if (alm.Type == 1)
                        {
                            foreach (Address add in profile.Addresses.Where(y => y.Name == alm.Address))
                            {
                                foreach (AddressMember adm in add.AddressMembers)
                                {
                                    // If Single Address
                                    if (adm.Type == 1)
                                    {
                                        if (adm.HostIPAddress == searchString)
                                        {
                                            adm.highlight = true;
                                            alm.highlight = true;
                                            AbsPolicyList.Add(absp);
                                        }
                                    }

                                    else if (adm.Type == 2)
                                    {
                                        IPAddress network = IPAddress.Parse(adm.IPNetworkAddress);
                                        IPAddress search = IPAddress.Parse(searchString);
                                        IPAddress netmask = IPAddress.Parse(adm.NetMask);
                                        if (IPAddressExtensions.IsInSameSubnet(network, search, netmask))
                                        {
                                            adm.highlight = true;
                                            alm.highlight = true;
                                            AbsPolicyList.Add(absp);
                                        }
                                    }

                                    else if (adm.Type == 3)
                                    {

                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }
                }

                //To
                foreach (Alias al in profile.Aliases.Where(z => z.Name == absp.ToAlias[0]))
                {
                    foreach (AliasMember alm in al.AliasMembers)
                    {
                        if (alm.Type == 1)
                        {
                            foreach (Address add in profile.Addresses.Where(y => y.Name == alm.Address))
                            {
                                foreach (AddressMember adm in add.AddressMembers)
                                {
                                    // If Single Address
                                    if (adm.Type == 1)
                                    {
                                        if (adm.HostIPAddress == searchString)
                                        {
                                            adm.highlight = true;
                                            alm.highlight = true;
                                            AbsPolicyList.Add(absp);
                                        }
                                    }

                                    else if (adm.Type == 2)
                                    {
                                        IPAddress network = IPAddress.Parse(adm.IPNetworkAddress);
                                        IPAddress search = IPAddress.Parse(searchString);
                                        IPAddress netmask = IPAddress.Parse(adm.NetMask);
                                        if (IPAddressExtensions.IsInSameSubnet(network, search, netmask))
                                        {
                                            adm.highlight = true;
                                            alm.highlight = true;
                                            AbsPolicyList.Add(absp);
                                        }
                                    }

                                    else if (adm.Type == 3)
                                    {

                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }

            UpdateListBoxes();
            tbPolicyListCount.Text = AbsPolicyList.Count + " policies";
            listBoxAliasFrom.SelectedIndex = 0;
            listBoxAliasTo.SelectedIndex = 0;
            listBoxPolicy.SelectedIndex = 0;
        }

        private void FirewallGui_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearLists();
            SetAllMembersFalse();
            PopulateArrays();
            UpdateListBoxes();
        }

        private void ClearLists()
        {
            AbsPolicyList.Clear();
            AliasFromList.Clear();
            AliasToList.Clear();
            AddressFromList.Clear();
            AddressToList.Clear();
        }

        private void UpdateListBoxes()
        {
            listBoxAliasFrom.DataSource = null;
            listBoxAliasFrom.DataSource = AliasFromList;
            listBoxAliasTo.DataSource = null;
            listBoxAliasTo.DataSource = AliasToList;
            listBoxAddressFrom.DataSource = null;
            listBoxAddressFrom.DataSource = AddressFromList;
            listBoxAddressTo.DataSource = null;
            listBoxAddressTo.DataSource = AddressToList;
            listBoxPolicy.DataSource = null;
            listBoxPolicy.DataSource = AbsPolicyList;
        }

        public List<Address> GetAddresses(Alias alias)
        {
            List<Address> addresses = new List<Address>();

            foreach (AliasMember alm in alias.AliasMembers)
            {
                if (alm.Type == 1)
                {
                    addresses.Concat(profile.Addresses.Where(z => z.Name == alm.Address));
                }

                if (alm.Type == 2)
                {
                    addresses.Concat(GetAddresses(profile.Aliases.Find(z => z.Name == alm.AliasName)));
                }
            }

            return addresses;
        }

        public void SetAllMembersFalse()
        {
            foreach (Alias a in profile.Aliases)
                foreach (AliasMember am in a.AliasMembers)
                    am.highlight = false;

            foreach (Address ad in profile.Addresses)
                foreach (AddressMember adm in ad.AddressMembers)
                    adm.highlight = false;
        }
    }
}
