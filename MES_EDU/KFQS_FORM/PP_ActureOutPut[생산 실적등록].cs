using DC00_assm;
using DC_POPUP;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KFQS_Form
{
    public partial class PP_ActureOutPut : DC00_WinForm.BaseMDIChildForm
    {
        // 그리드를 셋팅 할 수 있도록 도와주는 함수 클래스
        UltraGridUtil _GridUtil = new UltraGridUtil();
        //공장 변수 입력
        //private sPlantCode = LoginInfo.
        public PP_ActureOutPut()
        {
            InitializeComponent();
        }

        private void PP_ActureOutPut_Load(object sender, EventArgs e)
        {
            // 그리드를 셋팅한다.
            try
            {
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",                true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "작업지시 번호",       true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목 코드",           true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY",        "계획수량",            true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "양품수량",            true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",            true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",       "단위",                true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",       "투입LOT",             true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "COMPONENT",      "투입품목",            true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "COMPONENTQTY",   "투입 수량",           true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUNITCODE",      "투입단위",            true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",              true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUSCODE", "상태코드",            true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS",     "상태",                true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKER",         "작업자",              true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",     "작업자명",            true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE",      "최초 가동 시작 시간", true, GridColDataType_emu.DateTime24,160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE",        "작업지시  종료 시간", true, GridColDataType_emu.DateTime24,160, 130, Infragistics.Win.HAlign.Left, true, false);
                //셋팅 내역 그리드와 바인딩
                _GridUtil.SetInitUltraGridBind(grid1); //셋팅 내역 그리드와 바인딩

                Common _Common = new Common();
                DataTable dtTemp = new DataTable();
                // PLANTCODE 기준정보 가져와서 데이터 테이블에 추가.
                dtTemp = _Common.Standard_CODE("PLANTCODE"); 
                // 데이터 테이블에 있는 데이터를 해당 콤보박스에 추가.
                Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp, 
                                          dtTemp.Columns["CODE_ID"].ColumnName, 
                                          dtTemp.Columns["CODE_NAME"].ColumnName, 
                                          "ALL","");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");

                // 작업장 마스터 데이터 가져와서 임시 테이블에 등록
                dtTemp = _Common.GET_Workcenter_Code();  // 작업장

                // 콤보박스 컨트롤에 가져온 데이터 등록
                Common.FillComboboxMaster(this.cboWorkcenterCode, 
                                          dtTemp, dtTemp.Columns["CODE_ID"].ColumnName,
                                          dtTemp.Columns["CODE_NAME"].ColumnName, 
                                          "ALL", "");

                // 그리드 해당 컬럼에 콤보박스 유형으로 셋팅
                UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", dtTemp, "CODE_ID", "CODE_NAME");

                #region ▶ POP-UP ◀
                BizTextBoxManager btbManager = new BizTextBoxManager();
                btbManager.PopUpAdd(txtWorkerID, 
                                    txtWorkerName, 
                                    "WORKER_MASTER"
                                    ,new object[] { "", "", "", "", "" });
                #endregion

            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
        }

        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode      = Convert.ToString(cboPlantCode_H.Value);
                string sWorkcentercode = Convert.ToString(cboWorkcenterCode.Value);
                string sStartDate      = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEndDate        = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);
                string sOrderNo        = Convert.ToString(txtOrderNo.Text);


                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("00PP_ActureOutPut_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE",      sPlantCode,      DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("WORKCENTERCODE", sWorkcentercode, DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("STARTDATE",      sStartDate,      DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("ENDDATE",        sEndDate,        DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("ORDERNO",        sOrderNo,        DbType.String, ParameterDirection.Input)
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
            catch(Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {
           
        }

        public override void DoDelete()
        {
          
        }

        public override void DoSave()
        {
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            // 작업자 등록 시작
            if (grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow == null)
            {
                ShowDialog("작업지시를 선택 후 진행 하세요.", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }

            string sWorkId = txtWorkerID.Text.ToString();
            if (sWorkId == "")
            {
                ShowDialog("작업자를 선택후 진행하세요.", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            // DB 에 등록하기 위한 변수 지정
            string sOrederNo       = grid1.ActiveRow.Cells["ORDERNO"].Value.ToString();
            string sWOrkcentercode = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();

            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("00PP_ActureOutput_I2", CommandType.StoredProcedure,
                                        helper.CreateParameter("PLANTCODE",       "1000",          DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("WORKER",         sWorkId,         DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("ORDERNO",        sOrederNo,       DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("WORKCENTERCODE", sWOrkcentercode, DbType.String, ParameterDirection.Input)
                                        );
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    ShowDialog(helper.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);
                    DoInquire();
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
            }
            finally 
            { 
                helper.Close(); 
            }
        }

        private void btnLotIn_Click(object sender, EventArgs e)
        {
            // LOT 투입
            if (this.grid1.ActiveRow == null) return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                string sItemcode         = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sLotno            = Convert.ToString(txtInLotNo.Text);
                string sWorkercenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);

                string sOrderno  = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
                string sUnitCode = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                string sInFlag   = Convert.ToString(btnLotIn.Text);
                string sWorker   = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
                if (sInFlag == "투입")
                {
                    sInFlag = "IN";
                }
                else sInFlag = "OUT";

                helper.ExecuteNoneQuery("00PP_ActureOutput_I1", CommandType.StoredProcedure,
                                        helper.CreateParameter("PLANTCODE",       "1000",            DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("ITEMCODE",       sItemcode,         DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("LOTNO",          sLotno,            DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("WORKCENTERCODE", sWorkercenterCode, DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("ORDERNO",        sOrderno,          DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("UNITCODE",       sUnitCode,         DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("INFLAG",         sInFlag,           DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("MAKER",          sWorker,           DbType.String, ParameterDirection.Input)
                                        );
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    ShowDialog(helper.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);
                    DoInquire();
                }
                else
                {
                    helper.Rollback();
                    ShowDialog(helper.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);
                }

                helper.Commit();
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

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
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
            txtWorkerID.Text   = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            txtWorkerName.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKERNAME"].Value);

        }

        private void btnRunStop_Click(object sender, EventArgs e)
        {
            // 가동 / 비가동 등록
            DBHelper helper = new DBHelper("", true);
            try
            {
                string sStatus = "R";
                if (btnRunStop.Text == "비가동") sStatus = "S";
                helper.ExecuteNoneQuery("00PP_ActureOutput_U1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE",      "1000",                                                               DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ORDERNO",        Convert.ToString(this.grid1.ActiveRow.Cells["ORDERNO"].Value),        DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE",       Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value),       DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UNITCODE",       Convert.ToString(this.grid1.ActiveRow.Cells["UNITCODE"].Value),      DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("STATUS",         sStatus,                                                              DbType.String, ParameterDirection.Input)
                                                                    );

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    ShowDialog("정상적으로 등록 되어부러써"+helper.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);
                    DoInquire();

                }
                else
                {
                    helper.Rollback();
                    ShowDialog("데이터 등록중 오류 발생!", DC00_WinForm.DialogForm.DialogType.OK);
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
            if (this.grid1.ActiveRow == null)
            {

                ShowDialog("작업지시를 선택하시오", DC00_WinForm.DialogForm.DialogType.OK);
                return;

            }
            double dProdQTY =          0;
            double dErrorqty =         0;
            double dtotal =            0;
            double dtotalerror =       0;
            double dOrder =            0;
            double dInQty =            0; //투입 lot 잔량

            string sProdQTY = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PRODQTY"].Value).Replace(",", "");
            double.TryParse(sProdQTY, out dProdQTY);

            String SBADQTY = Convert.ToString(this.grid1.ActiveRow.Cells["BADQTY"].Value).Replace(",", "");
            Double.TryParse(SBADQTY, out dErrorqty);

            string STOTAL = Convert.ToString(txtProduct.Text).Replace(",", "");
            Double.TryParse(STOTAL, out dtotal);

            string ETOTAL = Convert.ToString(txtBad.Text).Replace(",", "");
            Double.TryParse(ETOTAL, out dtotalerror);

            String Sorder = Convert.ToString(this.grid1.ActiveRow.Cells["PLANQTY"].Value).Replace(",", "");
            Double.TryParse(Sorder, out dOrder);

            String inqty = Convert.ToString(this.grid1.ActiveRow.Cells["COMPONENTQTY"].Value).Replace(",", "");
            Double.TryParse(inqty, out dInQty);

            if (dInQty == 0)
            {
                ShowDialog("투입된 lot이 존재하지 않습니다.",DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            if ((dtotal+dtotalerror) == 0)
            {
                ShowDialog("실적 수량을 입력하시오. ", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }

            if(dOrder < ((dProdQTY + dErrorqty) + (dtotal + dtotalerror)))
            {
                ShowDialog("생산수량 및 불량수량의 합계가 지시 수량보다 많습니다." , DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("PP_4_ActureOutput_U2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", "1000", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ORDERNO", Convert.ToString(this.grid1.ActiveRow.Cells["ORDERNO"].Value), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODE", Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UNITCODE", Convert.ToString(this.grid1.ActiveRow.Cells["UNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PRODQTY", dtotal, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("BADQTY", dtotalerror, DbType.String, ParameterDirection.Input)
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
                ShowDialog("상태 등록을 완료 하였습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                DoInquire();
                txtInLotNo.Text = "";
                txtProduct.Text = "";
                txtBad.Text = "";
            }
            catch (Exception ex)
            {

                ShowDialog($"오류!.{ex}", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }

        }

        private void btnOrderClose_Click(object sender, EventArgs e)
        {
            //작업지시 종료
            if (grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow == null) return;
            if (DBHelper.nvlString(grid1.ActiveRow.Cells["MATLOTNO"].Value)!= "")
            {
                ShowDialog("LOT 투입 취소 후 진해앟세요 .", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            if (Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value) == "R")
            {
                ShowDialog("비가동 등록 후 진행하세요 .", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }

            DBHelper HP = new DBHelper("", true);
            try
            {
                HP.ExecuteNoneQuery("04PP_ActureOutput_U3", CommandType.StoredProcedure
                                                                    , HP.CreateParameter("PLANTCODE", "1000", DbType.String, ParameterDirection.Input)
                                                                    , HP.CreateParameter("WORKCENTERCODE", Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                                    , HP.CreateParameter("ORDERNO", Convert.ToString(this.grid1.ActiveRow.Cells["ORDERNO"].Value), DbType.String, ParameterDirection.Input)
                                                                    );
                if (HP.RSCODE != "S")
                {
                    HP.Rollback();
                    ShowDialog(HP.RSMSG);
                    return;
                }
                HP.Commit();
                ShowDialog("상태 등록을 완료 하였습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                DoInquire();
                txtInLotNo.Text = "";
                txtProduct.Text = "";
                txtBad.Text = "";
            }
            catch (Exception)
            {

                HP.Rollback();
                ShowDialog(HP.RSMSG);
                return;
            }
        }
    }
}
