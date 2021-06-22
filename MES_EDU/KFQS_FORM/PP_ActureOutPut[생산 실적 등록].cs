#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_ActureOutPut
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
    public partial class PP_ActureOutPut : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();
        string plantCode = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_ActureOutPut()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_ActureOutPut_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시 번호", true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목 코드", true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획수량", true, GridColDataType_emu.Double, 120, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "양품수량", true, GridColDataType_emu.Double, 120, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY", "불량수량", true, GridColDataType_emu.Double, 100, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "투입LOT", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENT", "투입품목", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENTQTY", "투입양", true, GridColDataType_emu.Double, 100, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUNITCODE", "투입단위", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS", "작업 상태", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUSCODE", "작업 상태", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER", "작업자", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "최초 가동 시작 시간", true, GridColDataType_emu.DateTime24, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "작업 상태 지시 종료 시간", true, GridColDataType_emu.DateTime24, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion


            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_Workcenter_Code();  // 작업장 번호 

            Common.FillComboboxMaster(this.cboWorkcenterCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName/*밸류 멤버*/, rtnDtTemp.Columns["CODE_NAME"].ColumnName/*디스플레이 멤버*/, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.Standard_CODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("WHCODE");     //입고 창고
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            // 품목코드 
            //FP  : 완제품
            //OM  : 외주가공품
            //R/M : 원자재
            //S/M : 부자재(H / W)
            //SFP : 반제품
            rtnDtTemp = _Common.GET_ItemCodeFERT_Code("R/M");

            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btbman = new BizTextBoxManager();
            btbman.PopUpAdd(txtWorkerID, txtWorkerName, "WORKER_MASTER", new object[] { "", "", "", "", "" });

            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantcode = Convert.ToString(cboPlantCode.Value);
                string sWorkcentercode = Convert.ToString(cboWorkcenterCode.Value);
                string sStartDate = string.Format("{0:yyyy-MM-01}", dtpStart.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);
                string sOrderNo = Convert.ToString(txtOrderNo.Text);

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("11PP_ActureOutPut_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("WORKCENTERCODE", sWorkcentercode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                                          );
                this.ClosePrgForm();
                if (dtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = dtTemp;
                    grid1.DataBinds(dtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
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

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
        }
        #endregion


        private void btnLotIn_Click(object sender, EventArgs e)
        {
            // LOT 투입
            if (this.grid1.ActiveRow == null) return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                string sItemcode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sLotno = Convert.ToString(txtInLotNo.Text);
                string sWorkercenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);

                string sOrderno = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
                string sUnitCode = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                string sInFlag = Convert.ToString(btnLotIn.Text);
                string sWorker = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);


                if (sInFlag == "투입")
                {
                    sInFlag = "IN";
                }
                else sInFlag = "OUT";

                helper.ExecuteNoneQuery("11PP_ActureOutput_I1", CommandType.StoredProcedure,
                                        helper.CreateParameter("PLANTCODE", "1000", DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("ITEMCODE", sItemcode, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("LOTNO", sLotno, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("WORKCENTERCODE", sWorkercenterCode, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("ORDERNO", sOrderno, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("INFLAG", sInFlag, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("MAKER", sWorker, DbType.String, ParameterDirection.Input)
                                      );

                helper.Commit();
                ShowDialog(helper.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);


            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString(), DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void btnWorker_Click_1(object sender, EventArgs e)
        {
            //작업자 등록 시작
            if (grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow == null)
            {
                ShowDialog("작업지시 선택후 진행", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            string sWorkerID = txtWorkerID.Text.ToString();
            if (sWorkerID == "")
            {
                ShowDialog("작업자를 선택 후 진행하세요. ", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            //DB에 등록하기 위한 변수 지정

            string sOrderNo = grid1.ActiveRow.Cells["ORDERNO"].Value.ToString();
            string sWorkCenterCode = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("04PP_ActureOutput_I2", CommandType.StoredProcedure,
                     helper.CreateParameter("PLANTCODE", "1000", DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("WORKER", sWorkerID, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
               );

                helper.Commit();
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    ShowDialog(helper.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);

                }
                else
                {
                    helper.Rollback();
                    ShowDialog(helper.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog($"{ex}", DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }

        }

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            // 그리드 행 활성화시 동작
            if (Convert.ToString(this.grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value) == "R")
            {
                btnRunStop.Text = "비가동";
            }
            else btnRunStop.Text = "가동";

            string sMatLotno = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            if (sMatLotno != "")
            {
                txtInLotNo.Text = sMatLotno;
                btnLotIn.Text = "투입취소";
            }
            else
            {
                txtInLotNo.Text = "";
                btnLotIn.Text = "투입";
            }
            txtWorkerID.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            txtWorkerName.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKERNAME"].Value);
        }

        private void btnRunStop_Click(object sender, EventArgs e)
        {
            // 가동/비가동 등록
            DBHelper helper = new DBHelper("", true);
            try
            {
                string sStatus = "R";
                if (btnRunStop.Text == "비가동") sStatus = "S";
                helper.ExecuteNoneQuery("11PP_ActureOutput_U1", CommandType.StoredProcedure
                                      , helper.CreateParameter("PLANTCODE", "1000", DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("ORDERNO", Convert.ToString(this.grid1.ActiveRow.Cells["ORDERNO"].Value), DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("ITEMCODE", Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("UNITCODE", Convert.ToString(this.grid1.ActiveRow.Cells["UNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("STATUS", sStatus, DbType.String, ParameterDirection.Input)
                                      );
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    ShowDialog("정상적으로 등록 되었습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                }
                else
                {
                    helper.Rollback();
                    ShowDialog("데이터 등록 중 오류가 발생 하였습니다." + helper.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            // 생산실적 등록
            if (this.grid1.ActiveRow == null)
            {
                ShowDialog("작업지시를 선택 하세요.", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            double dProdQty = 0; // 누적 양품수량
            double dErrorQty = 0; // 누적 불량수량
            double dTProdQty = 0; // 누적 양품수량
            double dTErrorQty = 0; // 누적 불량수량
            double dOrderQty = 0; // 작업지시 수량
            double dInQty = 0; // 투입 LOT 잔량

            string sProdQty = Convert.ToString(this.grid1.ActiveRow.Cells["PRODQTY"].Value).Replace(",", "");
            double.TryParse(sProdQty, out dProdQty);

            string sBadQty = Convert.ToString(this.grid1.ActiveRow.Cells["BADQTY"].Value).Replace(",", "");
            double.TryParse(sBadQty, out dErrorQty);

            string sTProdQty = Convert.ToString(txtProduct.Text);
            double.TryParse(sTProdQty, out dTProdQty);

            string sTBadQty = Convert.ToString(txtBad.Text);
            double.TryParse(sTBadQty, out dTErrorQty);

            string sOrderQty = Convert.ToString(this.grid1.ActiveRow.Cells["PLANQTY"].Value).Replace(",", "");
            double.TryParse(sOrderQty, out dOrderQty);

            string sInQty = Convert.ToString(this.grid1.ActiveRow.Cells["COMPONENTQTY"].Value).Replace(",", "");
            double.TryParse(sInQty, out dInQty);

            if (dInQty == 0)
            {
                ShowDialog("투입한 LOT 이 존재하지 않습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }

            if ((dTProdQty + dTErrorQty) == 0)
            {
                ShowDialog("실적 수량을 입력하세요", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }

            if (dOrderQty < (dProdQty + dErrorQty) + (dTProdQty + dTErrorQty))
            {
                ShowDialog("생산 수량 및 불량 수량의 합계가 지시수량보다 많습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("11PP_ActureOutput_U2", CommandType.StoredProcedure
                                                              , helper.CreateParameter("PLANTCODE", "1000", DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("ORDERNO", Convert.ToString(this.grid1.ActiveRow.Cells["ORDERNO"].Value), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("ITEMCODE", Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("UNITCODE", Convert.ToString(this.grid1.ActiveRow.Cells["UNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("PRODQTY", dTProdQty, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("ERRORQTY", dTErrorQty, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("MATLOTNO", Convert.ToString(this.grid1.ActiveRow.Cells["MATLOTNO"].Value), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("CITEMCODE", Convert.ToString(this.grid1.ActiveRow.Cells["COMPONENT"].Value), DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("CUNITCODE", Convert.ToString(this.grid1.ActiveRow.Cells["CUNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                                              );
                if (helper.RSCODE != "S")
                {
                    helper.Rollback();
                    ShowDialog(helper.RSMSG);
                    return;
                }
                helper.Commit();
                ShowDialog("생산실적 등록을 완료 하였습니다.", DialogForm.DialogType.OK);
                DoInquire();
                //txtInLotNo.Text = "";
                txtProduct.Text = "";
                txtBad.Text = "";
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString(), DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void btnOrderClose_Click(object sender, EventArgs e)
        {
            // 작업지시 종료

            if (grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow == null) return;
            if (Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value) != "")
            {
                ShowDialog("LOT 투입 취소 후 진행하세요.", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            // 가동 일 경우 종료 안되도록 확인
            if (Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value) == "R")
            {
                ShowDialog("비가동 등록 후 진행 하세요.", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("11PP_ActureOutput_U3", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", plantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERNO", Convert.ToString(this.grid1.ActiveRow.Cells["ORDERNO"].Value), DbType.String, ParameterDirection.Input)
                                                                    );
                if (helper.RSCODE != "S")
                {
                    helper.Rollback();
                    ShowDialog(helper.RSMSG);
                    return;
                }
                helper.Commit();
                ShowDialog("상태 등록을 완료 하였습니다.", DialogForm.DialogType.OK);
                DoInquire();

                txtProduct.Text = "";
                txtBad.Text = "";
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString(), DC00_WinForm.DialogForm.DialogType.OK);

            }
            finally
            {
                helper.Close();
            }
        }
    }
}