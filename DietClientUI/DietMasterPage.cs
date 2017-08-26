using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Diet.Business.Model;
using Diet.Common;
using Diet.Business.Contract;
using EvoPdf;
using System.IO;
using System.Diagnostics;

namespace DietClientUI
{
    public partial class DietMasterPage : Form
    {
        DataSet dtSearchMaster = new DataSet();
        public DietMasterPage()
        {
            InitializeComponent();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvPatient.Rows.GetRowCount(DataGridViewElementStates.Selected);

            Int32 selectedCellCount = dgvPatient.GetCellCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                int selRowIndex = dgvPatient.SelectedRows[0].Index;


                PatientInfo.PatientID = Convert.ToInt16("0" + dgvPatient.Rows[selRowIndex].Cells[0].Value);
                
            }

            if (selectedCellCount > 0)
            {
                int selRowIndex = dgvPatient.SelectedCells[0].RowIndex;


                PatientInfo.PatientID = Convert.ToInt16("0" + dgvPatient.Rows[selRowIndex].Cells[0].Value);

            }

            //if (PatientInfo.PatientID != 0)
            //{
            //    BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            //    {
            //        dtSearchMaster = DietMasterManager.GetDietMaster(PatientInfo.PatientID);
            //    });

            //    dgvPatient.DataSource = dtSearchMaster;
            //}
            //else
            //{
            //    BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            //    {
            //        dtSearchMaster = DietMasterManager.SearchPatients("", "ALL");
            //    });

            //    dgvPatient.DataSource = dtSearchMaster;
                
            //}

        }

        

        private void DietMaster_Load(object sender, EventArgs e)
        {
            dgvPatient.Width = (this.Width / 100) * 90;
            dgvPatient.Height = (this.Width / 100) * 30;

            //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            //{
            //    dtSearchMaster = DietMasterManager.SearchPatients("", "ALL");
            //});

            dgvPatient.DataSource = dtSearchMaster;
        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiet diet = new frmDiet();
            diet.Show();
        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DietMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtSearchById_TextChanged(object sender, EventArgs e)
        {
            //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            //{
            //    dtSearchMaster=DietMasterManager.SearchPatients(txtSearchById.Text.Trim(),"ID");
            //});

            //dgvPatient.DataSource = dtSearchMaster;
            
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            //{
            //    dtSearchMaster = DietMasterManager.SearchPatients(txtSearchByName.Text.Trim(), "NAME");
            //});

            dgvPatient.DataSource = dtSearchMaster;
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void tmLoadPatienData_Tick(object sender, EventArgs e)
        {

        }

        private void prgbarLoadPatientData_Click(object sender, EventArgs e)
        {

        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            //{
            //    dtSearchMaster = DietMasterManager.SearchPatients(txtSearchById.Text.Trim(), "ALL");
            //});

            dgvPatient.DataSource = dtSearchMaster;
        }

    }
}
