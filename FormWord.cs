using Microsoft.Web.WebView2.Core;
using PROJECT.Repositorys;
using PROJECT.Repositorys.Controler;
using PROJECT.Repositorys.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class FormWord : Form
    {
        private int serial;
        bool load ;
        public FormWord(int investserial)
        {
            serial = investserial;
          
            InitializeComponent();
            populatechecklistbox();
        }
 private async void FormWord_Load(object sender, EventArgs e)
        { 
            load = true;
            checkedListBox1.Enabled = false;
            textBox1.Text = serial.ToString();
            listView1.Items.Clear();
            
            await FillLists();
            BindToMadboutDataSet();
            checkedListBox1.Enabled = true;
            load = false;
        }
        private async Task BindToMadboutDataSet()
        {
            await Task.Run(async () =>
            {
                dataGridView1.Rows.Clear();
                using (var context = new InvEntitie())
                {
                    string attr;
                    foreach (var world in context.Invworlds.ToList())
                    {


                        if (world.Serial == serial)
                        {

                            dataGridView1.Rows.Add(
                               world.Code, world.Serial, world.Id);
                        }
                    }
                }
            });
        }
        private async Task FillLists()
        {
           
               using (var context = new InvEntitie())
               {
                   List<int> Codes = new List<int>();
                   foreach (var invworld in context.Invworlds.ToList())
                   {
                       if (serial == invworld.Serial)
                       {
                           Codes.Add(invworld.Code);
                       }

                   }

                   for (int i = 0; i < checkedListBox1.Items.Count; i++)
                   {
                       int code = WorldKey_controler.GetWorldKeyCode(checkedListBox1.Items[i].ToString()).Result;
                      if(!Codes.Contains(code) && checkedListBox1.GetItemChecked(i))
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                       if (Codes.Contains(code))
                       {
                           load = true;
                        checkedListBox1.SetItemChecked(i, true);
                    }
                   }
                populatelistview(Codes);
            }
            
        }
        private int generateSerial()
        {
            int max = 0;
            using (var context = new InvEntitie())
            {
                var invworlds = context.Invworlds.ToList();

                foreach (var iw in invworlds)
                {
                    if (iw.Serial.ToString() == serial.ToString() && max < iw.Id)
                    {
                        max = iw.Id;
                    }
                }
            }
            return max + 1;
        }
        private async void populatelistview(List<int> Codes)
        {
          
                listView1.Items.Clear();
              
                for(int i=0;i<Codes.Count;i++)
            {
              
                listView1.Items.Add(WorldKey_controler.GetWorldKeyLabel(Codes[i]).Result);
            }
        }
        private async void populatechecklistbox()
        {
            using (var context = new InvEntitie()){
                       var worlds=context.Worldkeys.ToList();
                        foreach(var item in worlds)
                        {
                            checkedListBox1.Items.Add(item.Label);
                        }
            }
       
            
        }
        private async void Delete_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {


                if (MessageBox.Show("are you need to delete this entry", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {

                        int investserial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Serial_column"].Value);
                        int codeworld = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Code_column"].Value);
                         InvWorld_controler.Delete(investserial, codeworld).Wait();
                        FormWord_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("there is an error in deleting this record");
                        return;
                    }
                    MessageBox.Show("operation done successfuly");

                }
                else
                {
                    MessageBox.Show("operation was canceled");
                }
            }
            else
            {
                MessageBox.Show("there is no selected row");
            }

        }

        private async void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {

                if (!load)
                {
                    checkedListBox1.Enabled = false;
                    
                    string itemName = checkedListBox1.Items[e.Index].ToString();

                    bool newItemChecked = e.NewValue == CheckState.Checked;
                    if (newItemChecked)
                    {
                        //it know be checked
                        var newinvworld = new Invworld
                        {
                            Serial = serial,
                            Id = generateSerial(),
                            Code = WorldKey_controler.GetWorldKeyCode(itemName).Result
                        };
                        using (var context = new InvEntitie())
                        {

                            context.Invworlds.Add(newinvworld);
                            context.SaveChanges();
                           
                        }
                        MessageBox.Show("item added successfully");
                    }
                    else
                    {
                        // item know is unchecked
                        InvWorld_controler.Delete(serial, WorldKey_controler.GetWorldKeyCode(itemName).Result).Wait();
                        MessageBox.Show("item deleted successfully");
                    }
                    
                    checkedListBox1.Enabled = true;
               FormWord_Load(sender, e);
                }
            }
            catch { MessageBox.Show("there is some problem"); }
                
        }
    }
}
