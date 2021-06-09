#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM_StockOUT
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
    public partial class MM_StockOUT : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public MM_StockOUT()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void MM_StockOUT_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택",              true, GridColDataType_emu.CheckBox, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",              true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "입고일자", true, GridColDataType_emu.DateTime24, 120, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "생산품목", true, GridColDataType_emu.VarChar, 300, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "생산품목", true, GridColDataType_emu.VarChar, 300, 120, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO",             true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
           
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "수량",            true, GridColDataType_emu.Double, 100, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위",               true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고",       true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);

            
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_ItemCodeFERT_Code("ROH");
            Common.FillComboboxMaster(this.CMBITEMCODE, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.Standard_CODE("WHCODE", "MINORCODE = 'WH003'");
            Common.FillComboboxMaster(this.CMBWH, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("STORAGELOCCODE", "RELCODE1 = 'WH003'");
            Common.FillComboboxMaster(this.CMBStorageLOC, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");




           

            // 품목코드 
            //FP  : 완제품
            //OM  : 외주가공품
            //R/M : 원자재
            //S/M : 부자재(H / W)
            //SFP : 반제품
            rtnDtTemp = _Common.GET_ItemCodeFERT_Code("FERT");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.SelectedIndex = 1;
            #endregion
        }
        #endregion


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
                string sPlantCode      = DBHelper.nvlString(this.cboPlantCode.Value);
                string sItemCode      = DBHelper.nvlString(this.CMBITEMCODE.Value);
                
                string sLOTNO = DBHelper.nvlString(txtLOTno.Text);
                string sStart = string.Format("{0:yyyy-MM-dd}", DTPSTART.Value);
                string sEnd = string.Format("{0:yyyy-MM-dd}", DTPEND.Value);


                DTPSTART.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);


                rtnDtTemp = helper.FillTable("04MM_StockOUT_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",   sPlantCode,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMCODE", sItemCode,   DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("LOTNO", sLOTNO,      DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("STARTDATE", sStart, DbType.String, ParameterDirection.Input),
                                      helper.CreateParameter("ENDDATE", sEnd, DbType.String, ParameterDirection.Input));
                

                                    

               this.ClosePrgForm();
                this.grid1.DataSource = rtnDtTemp;


                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);

                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다", DC00_WinForm.DialogForm.DialogType.OK);

                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(),DialogForm.DialogType.OK);    
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            try
            {
                this.grid1.InsertRow();
                this.grid1.SetDefaultValue("PLANTCODE", this.plantCode);

                grid1.ActiveRow.Cells["PLANNO"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["CHK"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ORDERNO"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ORDERWORKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                

            }
            catch (Exception EX)
            {

                ShowDialog($"{EX}");
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {   
           if (Convert.ToString(grid1.ActiveRow.Cells["CHK"].Value) == "1")
            {
                ShowDialog("작업지시 확정 내역을 취소 후 삭제하십쇼", DialogForm.DialogType.OK);
                return;
            }
            base.DoDelete();
            grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            this.grid1.UpdateData();
            DataTable DtTemp = new DataTable();
            DtTemp = grid1.chkChange();
            DBHelper HPHP = new DBHelper("", true);
            try
            {
                this.Focus();

                if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in DtTemp.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            HPHP.ExecuteNoneQuery("04MM_StockOUT_D1", CommandType.StoredProcedure
                                                                    , HPHP.CreateParameter("PLANTCODE", plantCode, DbType.String, ParameterDirection.Input)
                                                                    , HPHP.CreateParameter("PLANNO", drRow["PLANNO"], DbType.String, ParameterDirection.Input)
                                                                    );

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            string sErrorMsg = string.Empty;
                            if (Convert.ToString(drRow["ITEMCODE"]) == "")
                            {
                                sErrorMsg += "품목 ";
                            }
                            if (Convert.ToString(drRow["PLANQTY"]) == "")
                            {
                                sErrorMsg += "수량 ";
                            }
                            if (Convert.ToString(drRow["WORKCENTERCODE"]) == "")
                            {
                                sErrorMsg += "작업장 ";
                            }
                            if (sErrorMsg != "")
                            {
                                this.ClosePrgForm();
                                ShowDialog(sErrorMsg + "을 입력하지 않았습니다", DialogForm.DialogType.OK);
                                return;
                            }
                            HPHP.ExecuteNoneQuery("04MM_StockOUT_I1", CommandType.StoredProcedure
                                                  , HPHP.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , HPHP.CreateParameter("ITEMCODE", drRow["ITEMCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , HPHP.CreateParameter("PLANQTY", Convert.ToString(drRow["PLANQTY"]).Replace(",", ""), DbType.String, ParameterDirection.Input)
                                                  , HPHP.CreateParameter("UNITCODE", drRow["UNITCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , HPHP.CreateParameter("WORKCENTERCODE", drRow["WORKCENTERCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , HPHP.CreateParameter("MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            string sOrderFalg = string.Empty;
                            if (Convert.ToString(drRow["CHK"]).ToUpper() == "1") sOrderFalg = "Y";
                            else sOrderFalg = "N";

                            HPHP.ExecuteNoneQuery("04MM_StockOUT_U1", CommandType.StoredProcedure
                                                  , HPHP.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , HPHP.CreateParameter("PLANNO", drRow["PLANNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , HPHP.CreateParameter("ORDERFLAG", sOrderFalg, DbType.String, ParameterDirection.Input)
                                                  , HPHP.CreateParameter("EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );


                            #endregion
                            break;
                    }
                }
                if (HPHP.RSCODE != "S")
                {
                    this.ClosePrgForm();
                    HPHP.Rollback();
                    this.ShowDialog(HPHP.RSMSG, DialogForm.DialogType.OK);
                    return;
                }
                HPHP.Commit();
                this.ClosePrgForm();
                this.ShowDialog("R00002", DialogForm.DialogType.OK);    // 데이터가 저장 되었습니다.
                DoInquire();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                HPHP.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                HPHP.Close();
            }
        }
        #endregion

        
    }
}




