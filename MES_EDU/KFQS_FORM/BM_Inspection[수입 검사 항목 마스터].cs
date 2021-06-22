#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM_Inspection
//   Form Name    : 자재 재고관리 
//   Name Space   : KFQS_Form
//   Created Date : 2020/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KFQS_Form
{
    public partial class BM_Inspection : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();

        #endregion


        #region < CONSTRUCTOR >
        public BM_Inspection()
        {
            InitializeComponent();
        }
        #endregion


   
        private void BM_Inspection_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            DBHelper helper = new DBHelper(false);

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE"  , "검사코드"   , true, GridColDataType_emu.VarChar, 110, 120, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDETAIL", "검사내용"   , true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR"    , "수정자"     , true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE"  , "수정일시"   , true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER"     , "MAKER"      , true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE"  , "MAKEDATE"   , true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            rtnDtTemp = helper.FillTable("18BM_Inspection_S1", CommandType.StoredProcedure);

            this.ClosePrgForm();
            this.grid1.DataSource = rtnDtTemp;


            #region ▶ COMBOBOX ◀



            #endregion





            #endregion
        }
        


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DoFind();
        }
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1);
                rtnDtTemp = helper.FillTable("18BM_Inspection_S1", CommandType.StoredProcedure);

                this.ClosePrgForm();
                this.grid1.DataSource = rtnDtTemp;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoDelete()
        {
            
            base.DoDelete();
            grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            this.grid1.InsertRow();

            this.grid1.ActiveRow.Cells["MAKER"].Value = LoginInfo.UserID;

            grid1.ActiveRow.Cells["INSPCODE"].Activation = Activation.AllowEdit;
            grid1.ActiveRow.Cells["INSPDETAIL"].Activation = Activation.AllowEdit;
            grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
        }
        public override void DoSave()
        {
            this.grid1.UpdateData();

            DataTable dtTemp = new DataTable();
            dtTemp = grid1.chkChange();

            if (dtTemp == null) return;

            DBHelper helper = new DBHelper("", true);
            try
            {
                this.Focus();

                if (this.ShowDialog("등록한 데이터를 저장 하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dtTemp.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("BM_4_Inspection_D1", CommandType.StoredProcedure
                                                                     , helper.CreateParameter("INSPCODE"    , drRow["INSPCODE"], DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("INSPDETAIL"  , drRow["INSPDETAIL"]   , DbType.String, ParameterDirection.Input)
                                                                     );

                            #endregion
                            break;
                        
                        case DataRowState.Added:
                            #region 추가
                            string sErrorMsg = string.Empty;
                            if (Convert.ToString(drRow["INSPCODE"]) == "")
                            {
                                sErrorMsg += "검사코드 ";
                            }
                            if (Convert.ToString(drRow["INSPDETAIL"]) == "")
                            {
                                sErrorMsg += "검사내용 ";
                            }
                            
                            if (sErrorMsg != "")
                            {
                                this.ClosePrgForm();
                                ShowDialog(sErrorMsg + "을 입력하지 않았습니다", DialogForm.DialogType.OK);
                                return;
                            }
                            helper.ExecuteNoneQuery("BM_4_Inspection_I1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("INSPCODE"  , drRow["INSPCODE"].ToString()   , DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("INSPDETAIL", drRow["INSPDETAIL"].ToString() , DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)

                                                  );

                            #endregion 
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("BM_4_Inspection_U1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("INSPCODE", drRow["INSPCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("INSPDETAIL", drRow["INSPDETAIL"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );


                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE != "S")
                {
                    this.ClosePrgForm();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    return;
                }
                helper.Commit();
                this.ClosePrgForm();
                this.ShowDialog("R00002", DialogForm.DialogType.OK);    // 데이터가 저장 되었습니다.
                DoInquire();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }



        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>








    }
}




#endregion