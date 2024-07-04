using Microsoft.IdentityModel.Tokens;
using PROJECT.Repositorys;
using PROJECT.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class FormVehicles : Form
    {

        private int index;
        private bool update;

        private int serial;
        public FormVehicles(int investserial)
        {
            update = false;
            serial = investserial;
            InitializeComponent();

        }
        private int generateSerial()
        {
            int max = 0;
            using (var context = new InvEntitie())
            {
                var vehicles = context.Vehicles.ToList();
                foreach (var vehicle in vehicles)
                {
                    if (vehicle.SerialNb == serial && vehicle.Vid > max) max = vehicle.Vid;
                }
            }
            return max + 1;
        }
        private void FormVehicles_Load(object sender, EventArgs e)
        {
            Vid.Text = generateSerial().ToString();
            serialNB.Text = serial.ToString();
            dataGridView1.Rows.Clear();

            using (var context = new InvEntitie())
            {
                var vehicles = context.Vehicles.ToList();

                foreach (var vehicle in vehicles)
                {
                    dataGridView1.Rows.Add(

                        vehicle.Vid,
                        vehicle.SerialNb,
                        vehicle.ActualNb,
                        vehicle.CodeDesc,
                        vehicle.Proddate,
                        vehicle.Chassis,
                        vehicle.Motor,
                        vehicle.Dateaquisition,
                        vehicle.PreMiseCirc,
                        vehicle.ColorDesc,
                        vehicle.Brand,
                        vehicle.Model,
                        vehicle.UtilisDesc,
                        vehicle.Name,
                        vehicle.Lastname,
                        vehicle.NoRegProp,
                        vehicle.Address,
                        vehicle.CityId,
                        vehicle.DistrictId,
                        vehicle.GovernateId,
                        vehicle.MotherName,
                        vehicle.TelProp,
                        vehicle.AgeProp,
                        vehicle.BirthPlace,
                        vehicle.Horsservice
                        );

                }
            }

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            var serial = 0;
            var hors = 0;

            if (serialNB.Text.Length != 0 || HORSSERVICE.Text.Length != 0)
            {
                try
                {
                    serial = int.Parse(serialNB.Text);
                }
                catch { serial = 0; }
                try
                {
                    hors = int.Parse(HORSSERVICE.Text);
                }
                catch { hors = 0; }
            }
            Vid.Text = generateSerial().ToString();
            var vehicle = new Vehicle
            {
                Vid = int.Parse(Vid.Text.ToString()),
                SerialNb = serial,
                ActualNb = ActualNB.Text,
                CodeDesc = CodeDESC.Text,
                Proddate = PRODDATE.Text,
                Chassis = Chassis.Text,
                Motor = Motor.Text,
                Dateaquisition = dateaquisition.Text,
                PreMiseCirc = PreMiseCirc.Text,
                ColorDesc = ColorDesc.Text,
                Brand = Brand.Text,
                Model = Model.Text,
                UtilisDesc = UtilisDesc.Text,
                Name = name.Text,
                Lastname = lastname.Text,
                NoRegProp = "",
                Address = Address.Text,
                CityId = CityID.Text,
                DistrictId = DistrictID.Text,
                GovernateId = GovernateID.Text,
                MotherName = MotherName.Text,
                TelProp = TelProp.Text,
                AgeProp = AgeProp.Text,
                BirthPlace = BirthPlace.Text,
                Horsservice = hors

            };

            using (var context = new InvEntitie())
            {

                context.Vehicles.Add(vehicle);
                context.SaveChanges();
            }
            dataGridView1.Rows.Add(

                       vehicle.Vid,
                       vehicle.SerialNb,
                       vehicle.ActualNb,
                       vehicle.CodeDesc,
                       vehicle.Proddate,
                       vehicle.Chassis,
                       vehicle.Motor,
                       vehicle.Dateaquisition,
                       vehicle.PreMiseCirc,
                       vehicle.ColorDesc,
                       vehicle.Brand,
                       vehicle.Model,
                       vehicle.UtilisDesc,
                       vehicle.Name,
                       vehicle.Lastname,
                       vehicle.NoRegProp,
                       vehicle.Address,
                       vehicle.CityId,
                       vehicle.DistrictId,
                       vehicle.GovernateId,
                       vehicle.MotherName,
                       vehicle.TelProp,
                       vehicle.AgeProp,
                       vehicle.BirthPlace,
                       vehicle.Horsservice
                       );
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {


                if (MessageBox.Show("are you need to delete this entry", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    {
                        try
                        {
                            int vehicleid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                            using (var context = new InvEntitie())
                            {
                                var target = context.Vehicles.Find(vehicleid);
                                if (target != null)
                                {
                                    context.Vehicles.Remove(target);
                                    context.SaveChanges();

                                }
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("there is an error in deleting this record");
                        }
                    }
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.SelectedRows[0];
            index = row.Index;
            if (!update)
            {
                update = true;
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    Vid.Text = row.Cells[0].Value.ToString();
                    serialNB.Text = row.Cells[1].Value.ToString();
                    ActualNB.Text = row.Cells[2].Value.ToString();
                    CodeDESC.Text = row.Cells[3].Value.ToString();
                    PRODDATE.Text = row.Cells[4].Value.ToString();
                    Chassis.Text = row.Cells[5].Value.ToString();
                    Motor.Text = row.Cells[6].Value.ToString();
                    dateaquisition.Text = row.Cells[7].Value.ToString();
                    PreMiseCirc.Text = row.Cells[8].Value.ToString();
                    ColorDesc.Text = row.Cells[9].Value.ToString();
                    Brand.Text = row.Cells[10].Value.ToString();
                    Model.Text = row.Cells[11].Value.ToString();
                    UtilisDesc.Text = row.Cells[12].Value.ToString();
                    name.Text = row.Cells[13].Value.ToString();
                    lastname.Text = row.Cells[14].Value.ToString();
                    //NoRegProp.Text = row.Cells[15].Value.ToString();
                    Address.Text = row.Cells[16].Value.ToString();
                    CityID.Text = row.Cells[17].Value.ToString();
                    DistrictID.Text = row.Cells[18].Value.ToString();
                    GovernateID.Text = row.Cells[19].Value.ToString();
                    MotherName.Text = row.Cells[20].Value.ToString();
                    TelProp.Text = row.Cells[21].Value.ToString();
                    AgeProp.Text = row.Cells[22].Value.ToString();
                    BirthPlace.Text = row.Cells[23].Value.ToString();
                    HORSSERVICE.Text = row.Cells[24].Value.ToString();
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (update)
            {
                update = false;
                if (MessageBox.Show("are you need to save the changes", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = dataGridView1.Rows[index];
                    int vid = Convert.ToInt32(row.Cells[0].Value.ToString());
                    if (row != null)
                    {
                        row.Cells[0].Value = Vid.Text;
                        row.Cells[1].Value = serialNB.Text;
                        row.Cells[2].Value = ActualNB.Text;
                        row.Cells[3].Value = CodeDESC.Text;
                        row.Cells[4].Value = PRODDATE.Text;
                        row.Cells[5].Value = Chassis.Text;
                        row.Cells[6].Value = Motor.Text;
                        row.Cells[7].Value = dateaquisition.Text;
                        row.Cells[8].Value = PreMiseCirc.Text;
                        row.Cells[9].Value = ColorDesc.Text;
                        row.Cells[10].Value = Brand.Text;
                        row.Cells[11].Value = Model.Text;
                        row.Cells[12].Value = UtilisDesc.Text;
                        row.Cells[13].Value = name.Text;
                        row.Cells[14].Value = lastname.Text;
                        //  row.Cells[15].Value = NoRegProp.Text ;
                        row.Cells[16].Value = Address.Text;
                        row.Cells[17].Value = CityID.Text;
                        row.Cells[18].Value = DistrictID.Text;
                        row.Cells[19].Value = GovernateID.Text;
                        row.Cells[20].Value = MotherName.Text;
                        row.Cells[21].Value = TelProp.Text;
                        row.Cells[22].Value = AgeProp.Text;
                        row.Cells[23].Value = BirthPlace.Text;
                        row.Cells[24].Value = HORSSERVICE.Text;
                    }
                    var serial = 0;
                    var hors = 0;

                    if (serialNB.Text.Length != 0 || HORSSERVICE.Text.Length != 0)
                    {
                        try
                        {
                            serial = int.Parse(serialNB.Text);
                        }
                        catch { serial = 0; }
                        try
                        {
                            hors = int.Parse(HORSSERVICE.Text);
                        }
                        catch { hors = 0; }
                    }
                    using (var context = new InvEntitie())
                    {
                        var target = context.Vehicles.FirstOrDefault((v) => v.Vid == vid);
                        target.Vid = int.Parse(Vid.Text.ToString());
                        target.SerialNb = serial;
                        target.ActualNb = ActualNB.Text;
                        target.CodeDesc = CodeDESC.Text;
                        target.Proddate = PRODDATE.Text;
                        target.Chassis = Chassis.Text;
                        target.Motor = Motor.Text;
                        target.Dateaquisition = dateaquisition.Text;
                        target.PreMiseCirc = PreMiseCirc.Text;
                        target.ColorDesc = ColorDesc.Text;
                        target.Brand = Brand.Text;
                        target.Model = Model.Text;
                        target.UtilisDesc = UtilisDesc.Text;
                        target.Name = name.Text;
                        target.Lastname = lastname.Text;
                        //       target.NoRegProp = NoRegProp.Text;
                        target.Address = Address.Text;
                        target.CityId = CityID.Text;
                        target.DistrictId = DistrictID.Text;
                        target.GovernateId = GovernateID.Text;
                        target.MotherName = MotherName.Text;
                        target.TelProp = TelProp.Text;
                        target.AgeProp = AgeProp.Text;
                        target.BirthPlace = BirthPlace.Text;
                        target.Horsservice = hors;
                        context.SaveChanges();
                        Refresh();
                    }
                }


                Vid.Text = "";
                serialNB.Text = "";
                ActualNB.Text = "";
                CodeDESC.Text = "";
                PRODDATE.Text = "";
                Chassis.Text = "";
                Motor.Text = "";
                dateaquisition.Text = "";
                PreMiseCirc.Text = "";
                ColorDesc.Text = "";
                Brand.Text = "";
                Model.Text = "";
                UtilisDesc.Text = "";
                name.Text = "";
                lastname.Text = "";
                //    NoRegProp.Text = "";
                Address.Text = "";
                CityID.Text = "";
                DistrictID.Text = "";
                GovernateID.Text = "";
                MotherName.Text = "";
                TelProp.Text = "";
                AgeProp.Text = "";
                BirthPlace.Text = "";
                HORSSERVICE.Text = "";

            }
            else
            {
                MessageBox.Show("there is know selected item");
            }
        }





        private void FormVehicles_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void TelProp_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context = new InvEntitie())
            {
                var vehicles = context.Vehicles.ToList();

                foreach (var vehicle in vehicles)
                {
                    if (vehicle.SerialNb == serial && vehicle.TelProp == TelProp.Text)
                    {
                        dataGridView1.Rows.Add(

                            vehicle.Vid,
                            vehicle.SerialNb,
                            vehicle.ActualNb,
                            vehicle.CodeDesc,
                            vehicle.Proddate,
                            vehicle.Chassis,
                            vehicle.Motor,
                            vehicle.Dateaquisition,
                            vehicle.PreMiseCirc,
                            vehicle.ColorDesc,
                            vehicle.Brand,
                            vehicle.Model,
                            vehicle.UtilisDesc,
                            vehicle.Name,
                            vehicle.Lastname,
                            vehicle.NoRegProp,
                            vehicle.Address,
                            vehicle.CityId,
                            vehicle.DistrictId,
                            vehicle.GovernateId,
                            vehicle.MotherName,
                            vehicle.TelProp,
                            vehicle.AgeProp,
                            vehicle.BirthPlace,
                            vehicle.Horsservice
                            );
                    }
                }
            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context = new InvEntitie())
            {
                var vehicles = context.Vehicles.ToList();

                foreach (var vehicle in vehicles)
                {
                    if (vehicle.SerialNb == serial && vehicle.Name == name.Text)
                    {
                        dataGridView1.Rows.Add(

                            vehicle.Vid,
                            vehicle.SerialNb,
                            vehicle.ActualNb,
                            vehicle.CodeDesc,
                            vehicle.Proddate,
                            vehicle.Chassis,
                            vehicle.Motor,
                            vehicle.Dateaquisition,
                            vehicle.PreMiseCirc,
                            vehicle.ColorDesc,
                            vehicle.Brand,
                            vehicle.Model,
                            vehicle.UtilisDesc,
                            vehicle.Name,
                            vehicle.Lastname,
                            vehicle.NoRegProp,
                            vehicle.Address,
                            vehicle.CityId,
                            vehicle.DistrictId,
                            vehicle.GovernateId,
                            vehicle.MotherName,
                            vehicle.TelProp,
                            vehicle.AgeProp,
                            vehicle.BirthPlace,
                            vehicle.Horsservice
                            );
                    }
                }
            }
        }

        private void ActualNB_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context = new InvEntitie())
            {
                var vehicles = context.Vehicles.ToList();

                foreach (var vehicle in vehicles)
                {
                    if (vehicle.SerialNb == serial && vehicle.ActualNb == ActualNB.Text)
                    {
                        dataGridView1.Rows.Add(

                            vehicle.Vid,
                            vehicle.SerialNb,
                            vehicle.ActualNb,
                            vehicle.CodeDesc,
                            vehicle.Proddate,
                            vehicle.Chassis,
                            vehicle.Motor,
                            vehicle.Dateaquisition,
                            vehicle.PreMiseCirc,
                            vehicle.ColorDesc,
                            vehicle.Brand,
                            vehicle.Model,
                            vehicle.UtilisDesc,
                            vehicle.Name,
                            vehicle.Lastname,
                            vehicle.NoRegProp,
                            vehicle.Address,
                            vehicle.CityId,
                            vehicle.DistrictId,
                            vehicle.GovernateId,
                            vehicle.MotherName,
                            vehicle.TelProp,
                            vehicle.AgeProp,
                            vehicle.BirthPlace,
                            vehicle.Horsservice
                            );
                    }
                }
            }
        }
    }
}
