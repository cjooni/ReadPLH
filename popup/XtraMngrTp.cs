﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Comm;

namespace WindowsFormsApp1.popup
{
    public partial class XtraMngrTp : WindowsFormsApp1.Base.XtraBaseForm
    {
        public XtraMngrTp()
        {
            InitializeComponent();
        }

        private void XtraMngrTp_Load(object sender, EventArgs e)
        {
            LoadMngrGb();
        }


        /// <summary>
        /// 대분류 정보를 lookup Editor에 출력
        /// </summary>
        private void LoadMngrGb()
        {
            CHeader Header = new CHeader(UserInfo.UserID, "A0111A", "XtraMngrTp", "00000", "");

            DataTable data = new DataTable("section_list");

            DataColumn colSectionGroupNm = new DataColumn("mngr_gb_nm", typeof(string));

            data.Columns.Add(colSectionGroupNm);


            DataRow Dr = data.NewRow();
            Dr["mngr_gb_nm"] = "";

            data.Rows.Add(Dr);

            CParam Param = new CParam(data);

            DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

            DataTable Dt = ds.Tables["eror_dt"];
            itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
            itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

            DataTable Data = ds.Tables["Table"];

            lookUpMngrGb.Properties.DataSource = Data;            

        }



        /// <summary>
        /// 프로젝트 리스트를 조회한다.
        /// </summary>
        private void QrySectionList()
        {

            try
            {
                CHeader Header = new CHeader(UserInfo.UserID, "A0112A", "XtraMngrTp", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colMngrGb = new DataColumn("mngr_gb", typeof(Int32));
                DataColumn colMngrTpNm = new DataColumn("mngr_tp_nm", typeof(string));

                data.Columns.Add(colMngrGb);
                data.Columns.Add(colMngrTpNm);


                DataRow Dr = data.NewRow();
                Dr["mngr_gb"] = Convert.ToInt32(lookUpMngrGb.GetColumnValue("mngr_gb").ToString());
                Dr["mngr_tp_nm"] = edtMngrTpNm.Text;

                data.Rows.Add(Dr);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.QryData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                DataTable Data = ds.Tables["Table"];
                gridControl1.DataSource = Data;
            }
            catch (Exception ex)
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = ex.Message;
            }

        }


        /// <summary>
        /// 조회 Button Event를 처리한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            QrySectionList();
        }


        /// <summary>
        /// 신규 Row 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (lookUpMngrGb.Text == "NO DATA" || lookUpMngrGb.Properties.DataSource is null || lookUpMngrGb.Text.Trim() == "")
            {
                itemErrCd.Caption = "ERROR";
                itemErrMsg.Caption = "대분류 선택을 확인하세요 (no data)";


                return;
            }



            gridView1.AddNewRow();

        }


        /// <summary>
        /// Row 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteSection();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {



            DataRow Dr = gridView1.GetDataRow(e.RowHandle);
            Dr["mngr_gb_nm"] = lookUpMngrGb.Text;
            Dr["mngr_gb"] = lookUpMngrGb.GetColumnValue("mngr_gb");
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void gridView1_ShowingPopupEditForm(object sender, DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e)
        {
            foreach (Control control in e.EditForm.Controls)
            {
                if (!(control is EditFormContainer))
                {
                    continue;
                }
                foreach (Control nestedControl in control.Controls)
                {
                    if (!(nestedControl is PanelControl))
                    {
                        continue;
                    }
                    foreach (Control button in nestedControl.Controls)
                    {
                        if (!(button is SimpleButton))
                        {
                            continue;
                        }





                        if (button.Text == "취소")
                        {
                            var btnCancel = button as SimpleButton;
                            btnCancel.Click -= editFormCancelButton_Click;
                            btnCancel.Click += editFormCancelButton_Click;

                        }
                        else
                        {
                            var btnUpdate = button as SimpleButton;
                            btnUpdate.Click -= editFormUpdateButton_Click;
                            btnUpdate.Click += editFormUpdateButton_Click;
                        }


                    }
                }
            }
        }

        private void editFormUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUtil.GetFocusedFieldValue(gridView1, "mngr_tp").Trim() == "")
                {
                    InsertSection();
                }
                else
                {
                    if (XtraMessageBox.Show("정정 하시겠습니까?", "정정확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MidifySection();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void editFormCancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소");
        }

        private void MidifySection()
        {

        }

        /// <summary>
        /// 신규 중분류를 등록한다.
        /// </summary>
        private void InsertSection()
        {
            try
            {

                CHeader Header = new CHeader(UserInfo.UserID, "A0112B", "XtraMngrTp", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionMngrGb = new DataColumn("mngr_gb", typeof(Int32));                
                DataColumn colSectionMngrGbNm = new DataColumn("mngr_tp_nm", typeof(string));

                data.Columns.Add(colSectionMngrGb);
                data.Columns.Add(colSectionMngrGbNm);

                DataRow Dr = data.NewRow();

                //Dr.ItemArray = gridView1.GetFocusedDataRow().ItemArray.Clone() as object[];
                Dr["mngr_gb"] = gridView1.GetFocusedDataRow()["mngr_gb"];
                Dr["mngr_tp_nm"] = gridView1.GetFocusedDataRow()["mngr_tp_nm"];

                data.Rows.Add(Dr);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.InsertData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                if (itemErrCd.Caption == "00000")
                {
                    //DataTable dt1 = ds.Tables["Table"];
                    //edtGroupCd.Text = dt1.Rows[0]["cnt"].ToString();

                    QrySectionList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            //DataTable Data = ds.Tables["Table"];
            //gridControl1.DataSource = Data;
        }

        /// <summary>
        /// 중분류를 삭제한다.
        /// </summary>
        private void DeleteSection()
        {
            try
            {

                CHeader Header = new CHeader(UserInfo.UserID, "A0112C", "XtraMngrTp", "00000", "");

                DataTable data = new DataTable("section_list");

                DataColumn colSectionMngrGb = new DataColumn("mngr_gb", typeof(Int32));
                DataColumn colSectionMngrTp = new DataColumn("mngr_tp", typeof(Int32));
                

                data.Columns.Add(colSectionMngrGb);
                data.Columns.Add(colSectionMngrTp);


                DataRow Dr = data.NewRow();
                Dr["mngr_gb"] = Convert.ToInt32(gridView1.GetFocusedDataRow()["mngr_gb"].ToString());
                Dr["mngr_tp"] = Convert.ToInt32(gridView1.GetFocusedDataRow()["mngr_tp"].ToString());

                //Dr.ItemArray = gridView1.GetFocusedDataRow().ItemArray.Clone() as object[];

                data.Rows.Add(Dr);

                CParam Param = new CParam(data);

                DataSet ds = CTransfer.deleteData(Header, Param.GetDataSet());

                DataTable Dt = ds.Tables["eror_dt"];
                itemErrCd.Caption = Dt.Rows[0]["err_cd"].ToString();
                itemErrMsg.Caption = Dt.Rows[0]["err_msg"].ToString();

                if (itemErrCd.Caption == "00000")
                {

                    //edtGroupCd.Text = "";
                    //edtGroupNm.Text = "";

                    QrySectionList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


            //DataTable Data = ds.Tables["Table"];
            //gridControl1.DataSource = Data;
        }

 
    }
}
