using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PROJECT.Repositorys;
using PROJECT.Repositorys.Controler;
using PROJECT.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Serial
//serpers
//Fname
//Lname
//Father
//mother
//NAtion
//Reg
//Pbirth
//Dbirth
//Resid
//Adrs
//Attr
//Exst
//Arch
//Nickname
//Occupation
//Idnum
//Mobilno
//Status
//Gender
namespace PROJECT
{
    public partial class FormPerson : Form
    {
        private int NextSerper;
        private int serialFromInvest;
        private int index;

        public FormPerson(int a)
        {

            serialFromInvest = a;
            InitializeComponent();
            serial_field.Text = serialFromInvest.ToString();
            NextSerper = GetNextSerpers();
            serper_field.Text = NextSerper.ToString();

        }
        private bool verify()
        {
            bool DbirthisInteger = IsValidInteger(DBirth_field.Text, out int defaul);

            if (Reg_field.Text == "" || Fname_field.Text == "" || NickName_field.Text == "" || !DbirthisInteger || Idnum_field.Text == "" || Mobileno_field.Text == "")
            {
                MessageBox.Show("no valid field");
                return false;
            }
            return true;

        }
        private int GetNextSerpers()
        {
            int max = 0;
            using (var context = new InvEntitie())
            {
                var persons = context.Invpersons.ToList();

                foreach (var person in persons)
                {
                    if (person.Serial.ToString() == serialFromInvest.ToString() && max < person.Serpers)
                    {
                        max = person.Serpers;
                    }
                }
            }
            return max + 1;
        }
        private bool IsValidInteger(string input, out int result)
        {
            return int.TryParse(input, out result);
        }
        private void FormPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
        private void FormPerson_Load(object sender, EventArgs e)
        {
            Attr_controler.PopulateattrDDL(Attr_field);
            Village_controler.PopulateNationDDL(Resid_field);
            Village_controler.PopulateNationDDL(PBirth_field);
            Nation_controler.PopulateNationDDL(Nation_field);
            FillDataGrid();
        }
        private void HandleComboBoxSelectionChanged(ComboBox comboBox)
        {
            string selectedValue = comboBox.SelectedItem.ToString();
            DialogResult result = MessageBox.Show($"Do you want to update the text box with the selected value: {selectedValue}?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                comboBox.Text = selectedValue;
            }
        }
        private void ResetForm()
        {
            Fname_field.Text = "";
            Lname_field.Text = "";
            Mother_field.Text = "";
            Father_field.Text = "";
            Attr_field.Text = "";
            Adrs_field.Checked = false;
            DBirth_field.Text = "";
            Exst_field.Checked = false;
            Gender_field.Text = "";
            Idnum_field.Text = "";
            Mobileno_field.Text = "";
            Nation_field.Text = "";
            NickName_field.Text = "";
            PBirth_field.Text = "";
            Occupation_Field.Text = "";
            Reg_field.Text = "";
            Resid_field.Text = "";
            Status_field.Text = "";
        }
        private void ClearDefaultText(object sender, string DefaultText)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == DefaultText)
            {
                textBox.Text = string.Empty;
            }
        }
        private void faceimgbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView_Person.SelectedRows.Count > 0)
            {
                this.Hide();
                (new FormImage(Convert.ToInt32(dataGridView_Person.SelectedRows[0].Cells[1].Value.ToString()), serialFromInvest)).ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("there is no selected row");
            }
        }
        private async Task RemoveChars(int investserial, int personserial)
        {
            await InvestPer_controler.Delete(investserial, personserial);
        }
        private async void deletebtn_Click(object sender, EventArgs e)
        {

            if (dataGridView_Person.SelectedRows.Count > 0)
            {


                if (MessageBox.Show("are you need to delete this entry", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {

                        int investserial = Convert.ToInt32(dataGridView_Person.SelectedRows[0].Cells["serial_column"].Value);
                        int personserial = Convert.ToInt32(dataGridView_Person.SelectedRows[0].Cells["serpers_column"].Value);
                        await RemoveChars(investserial, personserial);
                        NextSerper = GetNextSerpers();
                        await ImageFP_controler.Delete(investserial, personserial);
                        await ImageFace_controler.Delete(investserial, personserial);
                        serper_field.Text = NextSerper.ToString();
                        FormPerson_Load(sender, e);
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
        private async void FillFieldByPerson(int ser, int serp)
        {
            string attr;
            string nation;
            using (var context = new InvEntitie())
            {
                var target = context.Invpersons.FirstOrDefault(v => (v.Serial == ser && v.Serpers == serp));

                if (target.Attr == null) attr = "";
                else attr = await Attr_controler.GetAttrLabel(target.Attr ?? 0);
                if (target.Nation == null) nation = "";
                else nation = await Nation_controler.GetNationLabel(Convert.ToInt32(target.Nation));
                serial_field.Text = ser.ToString();
                serper_field.Text = serp.ToString();
                Fname_field.Text = target.Fname;
                Lname_field.Text = target.Lname;
                Mother_field.Text = target.Mother;
                Father_field.Text = target.Father;
                Attr_field.Text = attr;
                Adrs_field.Checked = false;
                DBirth_field.Text = target.Dbirth.ToString();
                Exst_field.Checked = false;
                Gender_field.Text = target.Gender;
                Idnum_field.Text = target.Idnum;
                Mobileno_field.Text = target.Mobileno;
                Nation_field.Text = nation;
                NickName_field.Text = target.Nickname;
                PBirth_field.Text = target.Pbirth;
                Reg_field.Text = target.Reg;
                Resid_field.Text = target.Resid;
                Occupation_Field.Text = target.Occupation;
                Status_field.Text = target.Status;
                if (target.Adrs == "Y") Adrs_field.Checked = true;
                if (target.Exst == 1) Exst_field.Checked = true;
            }
        }
        private async void editbtn_Click(object sender, EventArgs e)
        {

            var row = dataGridView_Person.SelectedRows[0];
            index = row.Index;

            await Task.Run(() =>
            {
                if (MessageBox.Show("Are you need to  the update selected investigation information ? ", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataGridView_Person.SelectedRows.Count > 0)
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
                ResetForm();
            });



        }
        private async void Update()
        {
            int ser = 0, serp = 0;
            var row = dataGridView_Person.Rows[index];
            ser = Convert.ToInt32(row.Cells["serial_column"].Value);
            serp = Convert.ToInt32(row.Cells["serpers_column"].Value);
            using (var context = new InvEntitie())
            {
                var person = context.Invpersons.FirstOrDefault(v => (v.Serial == ser && v.Serpers == serp));
                int nation, attr;
                context.Update(person);
                person.Serial = ser;
                person.Serpers = serp;
                person.Fname = Fname_field.Text;
                person.Lname = Lname_field.Text;
                person.Father = Father_field.Text;
                person.Mother = Mother_field.Text;
                person.Nation = (nation = await Nation_controler.GetNationId(Nation_field)) == -1 ? null : nation;
                person.Reg = Reg_field.Text;
                person.Pbirth = PBirth_field.Text;
                person.Dbirth = Convert.ToInt32(DBirth_field.Text);
                person.Resid = Resid_field.Text;
                person.Adrs = (Adrs_field.Checked) ? "Y" : "N";
                person.Attr = (attr = await Attr_controler.GetAttrId(Attr_field)) == -1 ? null : attr;
                person.Exst = (Exst_field.Checked) ? 1 : 0;
                person.Idnum = Idnum_field.Text;
                //Arch ??
                person.Arch = 0;
                person.Nickname = NickName_field.Text;
                person.Occupation = Occupation_Field.Text;
                person.Mobileno = Mobileno_field.Text;
                person.Status = Status_field.Text;
                person.Gender = Gender_field.Text;
                context.SaveChanges();



                if (row != null)
                {

                    row.Cells["Fname_column"].Value = person.Fname;
                    row.Cells["Lname_column"].Value = person.Lname;
                    row.Cells["Father_column"].Value = person.Father;
                    row.Cells["Mother_column"].Value = person.Mother;
                    row.Cells["Nation_column"].Value = await Nation_controler.GetNationLabel(Convert.ToInt32(person.Nation));
                    row.Cells["DBirth_column"].Value = person.Dbirth;
                    row.Cells["PBirth_column"].Value = person.Pbirth;
                    row.Cells["Reg_column"].Value = person.Reg;
                    row.Cells["Resid_column"].Value = person.Resid;
                    row.Cells["Adrs_column"].Value = person.Adrs;
                    row.Cells["Attr_column"].Value = person.Attr;
                    row.Cells["Exst_column"].Value = person.Exst;
                    row.Cells["Arch_column"].Value = person.Arch;
                    row.Cells["Nickname_column"].Value = person.Nickname;
                    row.Cells["Occupation_column"].Value = person.Occupation;
                    row.Cells["Mobileno_column"].Value = person.Mobileno;
                    row.Cells["Status_column"].Value = person.Status;
                    row.Cells["Gender_column"].Value = person.Gender;
                }
            }
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            Refresh();
        }
        private async void Insertbtn_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                if (verify())
                {
                    if (MessageBox.Show("Are you need to insert the new investigation information ? ", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            int nation, attr;
                            var person = new Invperson();
                            person.Serial = serialFromInvest;
                            person.Serpers = NextSerper;
                            person.Fname = Fname_field.Text;
                            person.Lname = Lname_field.Text;
                            person.Father = Father_field.Text;
                            person.Mother = Mother_field.Text;
                            person.Nation = (nation = await Nation_controler.GetNationId(Nation_field)) == -1 ? null : nation; ;
                            person.Reg = Reg_field.Text;
                            person.Pbirth = PBirth_field.Text;
                            person.Dbirth = Convert.ToInt32(DBirth_field.Text);
                            person.Resid = Resid_field.Text;
                            person.Adrs = (Adrs_field.Checked) ? "Y" : "N";
                            person.Attr = (attr = await Attr_controler.GetAttrId(Attr_field)) == -1 ? null : attr;
                            person.Exst = (Exst_field.Checked) ? 1 : 0;
                            person.Arch = 0;
                            person.Idnum = Idnum_field.Text;
                            person.Nickname = NickName_field.Text;
                            person.Occupation = Occupation_Field.Text;
                            person.Mobileno = Mobileno_field.Text;
                            person.Status = Status_field.Text;
                            person.Gender = Gender_field.Text;
                            using (var context = new InvEntitie())
                            {
                                context.Invpersons.Add(person);
                                context.SaveChanges();

                            }
                            FillDataGrid();
                            ResetForm();
                            NextSerper = GetNextSerpers();
                            serper_field.Text = NextSerper.ToString();
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("there is error in the field");
                        }

                    }
                    else
                    {
                        MessageBox.Show("operation was canceled");
                    }
                }
            });
        }
        private async void FillDataGrid()
        {
            await Task.Run(async () =>
            {
                dataGridView_Person.Rows.Clear();
                using (var context = new InvEntitie())
                {
                    string attr;
                    foreach (var Person in context.Invpersons.ToList())
                    {


                        if (Person.Serial == serialFromInvest)
                        {
                            if (Person.Attr == null) attr = "";
                            else attr = await Attr_controler.GetAttrLabel(Person.Attr ?? 0);
                            dataGridView_Person.Rows.Add(
                                serialFromInvest, Person.Serpers,
                                Person.Fname, Person.Lname, Person.Father, Person.Mother, await Nation_controler.GetNationLabel(Convert.ToInt32(Person.Nation)), Person.Reg, Person.Pbirth, Person.Dbirth,
                                Person.Resid, attr, Person.Adrs, Person.Exst, Person.Arch, Person.Nickname, Person.Occupation, Person.Idnum, Person.Mobileno, Person.Status, Person.Gender
                                );
                        }
                    }
                }
            });
        }
        private void PBirth_field_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleComboBoxSelectionChanged(PBirth_field);
        }
        private void Resid_field_SelectedIndexChanged(object sender, EventArgs e)
        {

            HandleComboBoxSelectionChanged(Resid_field);
        }
        private void dataGridView_Person_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView_Person.SelectedRows.Count > 0)
            {
                int a = Convert.ToInt32(dataGridView_Person.SelectedRows[0].Cells["serial_column"].Value);
                int b = Convert.ToInt32(dataGridView_Person.SelectedRows[0].Cells["serpers_column"].Value);

                try
                {
                    if (a != 0)
                    {
                        FillFieldByPerson(a, b);
                    }
                    else FormPerson_Load(sender, e);
                }
                catch { FormPerson_Load(sender, e); }

            }
        }

        private void fpbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView_Person.SelectedRows.Count > 0)
            {
                this.Hide();
                (new FormImagesFP(Convert.ToInt32(dataGridView_Person.SelectedRows[0].Cells[1].Value.ToString()), serialFromInvest)).ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("there is no selected row");
            }
        }
    }
}
