using PROJECT.Repositorys.Models;
using PROJECT.Repositorys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using PROJECT.Repositorys.Controler;

namespace PROJECT
{
    public partial class FormInvest : Form
    {
        private bool update;
        private int index;
        public FormInvest()
        {
            InitializeComponent();

        }



        private void FormInvest_ResizeEnd(object sender, EventArgs e)
        {
            Menu.Height = this.Height;
        }
        private void FormInvest_SizeChanged(object sender, EventArgs e)
        {
            Menu.Height = this.Height;
        }
        private void FormInvest_FormClosed(object sender, FormClosedEventArgs e)
        {
            (new Home()).Show();
        }
        private void FillComboBox()
        {
            List<string> invests_elements = new List<string>();

            using (var context = new InvEntitie())
            {
                var invests = context.Invests.ToList();
                foreach (var invest in invests)
                {
                    if (!invests_elements.Contains(invest.Crime))
                    {
                        invests_elements.Add(invest.Crime);
                        crime_comboBox.Items.Add(invest.Crime);

                    }

                }
            }
        }
        private void FormInvest_Load(object sender, EventArgs e)
        {
            FillComboBox();
            this.Text = "FormInvest";
            Menu.Height = this.Height;
           
            dataGridView_Invest.Rows.Clear();
                using (var context = new InvEntitie())
                {
                    var invests = context.Invests.ToList();
                    foreach (var invest in invests)
                    {


                        dataGridView_Invest.Rows.Add(
                         invest.Serial, invest.Dfile, invest.Dmahdar, invest.Crime, invest.Madbout, invest.Resume, invest.Rem

                            );

                    }
                }
         

        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            crime_comboBox.Text = "";
        }
        private void vehl_Click(object sender, EventArgs e)
        {
            if (dataGridView_Invest.SelectedRows.Count > 0)
            {
                this.Hide();
                (new FormVehicles(Convert.ToInt32(dataGridView_Invest.SelectedRows[0].Cells[0].Value.ToString()))).ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("there is no selected row");
            }

        }
        private void InvPers_Click(object sender, EventArgs e)
        {
            if (dataGridView_Invest.SelectedRows.Count > 0)
            {
                this.Hide();
                (new FormPerson(Convert.ToInt32(dataGridView_Invest.SelectedRows[0].Cells[0].Value.ToString()))).ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("there is no selected row");
            }

        }

        private async void insertbtn_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
                 {
                     if (MessageBox.Show("Are you need to insert the new investigation information ? ", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         try
                         {
                             int serial = 1;
                             int max = 0;
                             using (var context = new InvEntitie())
                             {

                                 var invests = context.Invests.ToList();

                                 foreach (var Invest in invests)
                                 {
                                     if (max < Invest.Serial)
                                     {
                                         max = Convert.ToInt32(Invest.Serial);
                                     }

                                 }
                             }
                             max += 1;
                             string isresume = "N";
                             string ismadbout = "N";
                             string crime_text = "";
                             if (madbout_field.Checked)
                             {
                                 ismadbout = "Y";
                             }
                             if (resume_field.Checked)
                             {
                                 isresume = "Y";
                             }
                             if (Crime_field.Text.Length > 0)
                             {
                                 crime_text = Crime_field.Text;
                             }
                             if (crime_comboBox.SelectedIndex > -1)
                             {
                                 crime_text = crime_comboBox.Items[crime_comboBox.SelectedIndex].ToString();
                             }
                             var invest = new Invest
                             {
                                 Serial = max,
                                 Dfile = Dfile_field.Value,
                                 Dmahdar = Dmahdar_field.Value,
                                 Crime = crime_text,
                                 Madbout = ismadbout,
                                 Resume = isresume,
                                 Rem = Rem_field.Text
                             };
                             using (var context = new InvEntitie())
                             {

                                 context.Invests.Add(invest);
                                 context.SaveChanges();
                             }
                             dataGridView_Invest.Rows.Add(
                                 invest.Serial, invest.Dfile, invest.Dmahdar, invest.Crime, invest.Madbout, invest.Resume, invest.Rem
                                    );
                         }
                         catch
                         {
                             MessageBox.Show("there is error is the field");
                         }
                     }
                     else
                     {
                         MessageBox.Show("operation was canceled");
                     }
                     Resetform();
                 });

        }

        private async void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView_Invest.SelectedRows.Count > 0)
            {


                if (MessageBox.Show("are you need to delete this entry", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        int investserial = Convert.ToInt32(dataGridView_Invest.SelectedRows[0].Cells["serial_column"].Value);

                        await Invest_controler.Delete(investserial);
                        await InvestPer_controler.Delete(investserial);
                        await ImageFace_controler.Delete(investserial);
                        await Vehicle_controler.Delete(investserial);
                        await InvWorld_controler.Delete(investserial);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("there is an error in deleting this record");
                        return;
                    }
                    FormInvest_Load(sender, e);
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

        private void FillFieldByInvest(int ser)
        {
            using (var context = new InvEntitie())
            {
                var invests = context.Invests;
                var target = invests.Find(ser);
                serial_field.Text = target.Serial.ToString();
                Dfile_field.Text = target.Dfile.ToString();
                Dmahdar_field.Text = target.Dmahdar.ToString();
                Crime_field.Text = target.Crime.ToString();
                madbout_field.Checked = (target.Madbout == "Y") ? true : false;
                resume_field.Checked = (target.Resume == "Y") ? true : false;
                Rem_field.Text = target.Rem.ToString();
            }
        }
        private void Update()
        {
            var row = dataGridView_Invest.Rows[index];
            int investSerial = Convert.ToInt32(row.Cells[0].Value.ToString());
            string isresume;
            string ismadbout;
            string crime_text = "";
            ismadbout = (madbout_field.Checked) ? "Y" : "N";
            isresume = (resume_field.Checked) ? "Y" : "N";
            crime_text = (Crime_field.Text.Count() > 0) ? Crime_field.Text : "";
            if (crime_comboBox.SelectedIndex > -1)
            {
                crime_text = crime_comboBox.Items[crime_comboBox.SelectedIndex].ToString();
            }
            if (row != null)
            {
                row.Cells[0].Value = serial_field.Text;
                row.Cells[1].Value = Dfile_field.Text;
                row.Cells[2].Value = Dmahdar_field.Text;
                row.Cells[3].Value = crime_text;
                row.Cells[4].Value = ismadbout;
                row.Cells[5].Value = isresume;
                row.Cells[6].Value = Rem_field.Text;

            }
            using (var context = new InvEntitie())
            {
                var target = context.Invests.FirstOrDefault(v => v.Serial == investSerial);

                context.Update(target);
                target.Serial = investSerial;
                target.Dfile = Dfile_field.Value;
                target.Dmahdar = Dmahdar_field.Value;
                target.Crime = Crime_field.Text;
                target.Madbout = ismadbout;
                target.Resume = isresume;
                target.Rem = Rem_field.Text;
                context.SaveChanges();
                Refresh();
            }
        }
        private async void editbtn_Click(object sender, EventArgs e)
        {

            var row = dataGridView_Invest.SelectedRows[0];
            index = row.Index;

            await Task.Run(() =>
            {
                if (MessageBox.Show("Are you need to  the update selected investigation information ? ", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataGridView_Invest.SelectedRows.Count > 0)
                    {
                        Update();

                    }
                    else
                    {
                        MessageBox.Show("there is no selected an row!");
                    }
                }
                else
                {
                    MessageBox.Show("operation was canceled");
                }
                Resetform();

            });




        }
        private void Resetform()
        {
            serial_field.Text = "";
            Dfile_field.Text = "";
            Dmahdar_field.Text = "";
            Crime_field.Text = "";
            Rem_field.Text = "";
            madbout_field.Checked = false;
            resume_field.Checked = false;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Refresh();
            Resetform();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            FormInvest_Load(sender, e);
        }

        private void word_Click(object sender, EventArgs e)
        {
            if (dataGridView_Invest.SelectedRows.Count > 0)
            {
                this.Hide();
                (new FormWord(Convert.ToInt32(dataGridView_Invest.SelectedRows[0].Cells[0].Value.ToString()))).ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("there is no selected row");
            }


        }

        private void dataGridView_Invest_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Invest.SelectedRows.Count > 0)
            {
                try
                {
                    FillFieldByInvest(Convert.ToInt32(dataGridView_Invest.SelectedRows[0].Cells[0].Value));
                }
                catch
                {
                    FormInvest_Load(sender, e);
                }
            }

        }
    }
}
