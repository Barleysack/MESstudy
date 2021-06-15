#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_ActureOutProduct
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
    public partial class PP_ActureOutProduct : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_ActureOutProduct()
        {
            InitializeComponent();
        }
        #endregion
        //MRP 자재 소요량 예측 및 관리자재 소요량 계획은 제조 프로세스를 관리하는 데 사용되는 생산 계획,
        //일정 및 재고 관리 시스템입니다.
        //대부분의 MRP 시스템은 소프트웨어 기반이지만 수동으로 MRP를 수행 할 수도 있습니다.
        //워크 센터 코드? 
        #region < FORM EVENTS >
        private void PP_ActureOutProduct_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",                         "작업지시 번호",            true, GridColDataType_emu.VarChar,       140, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",                        "품목 코드",                true, GridColDataType_emu.VarChar,       140, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY",                         "계획수량",                 true, GridColDataType_emu.Double,        120, 120, Infragistics.Win.HAlign.Right,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",                       "공장",                     true, GridColDataType_emu.VarChar,       120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",                         "양품수량",                 true, GridColDataType_emu.Double,        120, 120, Infragistics.Win.HAlign.Right,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",                          "불량수량",                 true, GridColDataType_emu.Double,        100, 120, Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",                        "단위",                     true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",                        "투입LOT",                     true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENT",                       "투입품목",                 true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENTQTY",                    "투입양",                   true, GridColDataType_emu.Double,        100, 120, Infragistics.Win.HAlign.Right,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUNITCODE",                       "투입단위",                 true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",                  "작업장",                   true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS",                      "작업 상태",                true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",                      "작업자명",                 true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUSCODE",                  "작업 상태",                true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",                          "작업자",                   true, GridColDataType_emu.VarChar,       100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE",                       "최초 가동 시작 시간",      true, GridColDataType_emu.DateTime24,    100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE",                         "작업 상태 지시 종료 시간", true, GridColDataType_emu.DateTime24,    100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_Workcenter_Code();  // 작업장 번호 

            Common.FillComboboxMaster(this.cboWCC, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName/*밸류 멤버*/, rtnDtTemp.Columns["CODE_NAME"].ColumnName/*디스플레이 멤버*/, "ALL", "");
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

            #endregion

            #region ▶ POP-UP ◀


            BizTextBoxManager btbman = new BizTextBoxManager();
            btbman.PopUpAdd(txtWID, txtWorkerName, "WORKER_MASTER", new object[] { "", "", "", "", "" });



            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
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
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);
                string sWCC = DBHelper.nvlString(this.cboWCC.Value);
                string sSD = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sED = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);
                string sON = DBHelper.nvlString(this.txtOrderNum.Text);    
                


                

                rtnDtTemp = helper.FillTable("04PP_ActureOutPut_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",   sPlantCode,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("WORKCENTERCODE", sWCC,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("STARTDATE", sSD,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ENDDATE", sED,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ORDERNO", sON,  DbType.String, ParameterDirection.Input)
                                    


                                    );

               this.ClosePrgForm();
                this.grid1.DataSource = rtnDtTemp;
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

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            //바코드 발행
            if (grid1.ActiveRow == null) return; //선택된 행이 없을 경우 종료
            DataRow drrow = ((DataTable)this.grid1.DataSource).NewRow();
            drrow["ITEMCODE"] = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);
            drrow["ITEMNAME"] = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMNAME"].Value);
            drrow["CUSTNAME"] = Convert.ToString(this.grid1.ActiveRow.Cells["CUSTNAME"].Value);
            drrow["STOCKQTY"] = Convert.ToString(this.grid1.ActiveRow.Cells["STOCKQTY"].Value);
            drrow["MATLOTNO"] = Convert.ToString(this.grid1.ActiveRow.Cells["MATLOTNO"].Value);
            drrow["UNITCODE"] = Convert.ToString(this.grid1.ActiveRow.Cells["UNITCODE"].Value);

            //바코드 디자인 선언
            Report_LotBacode repBarcode = new Report_LotBacode();
            //레포트 북 선언 
            Telerik.Reporting.ReportBook repbook = new Telerik.Reporting.ReportBook();
            //바코드 디자이너에 데이터 등록
            repBarcode.DataSource = drrow;
            //레포트 북에 디자이너 등록
            repbook.Reports.Add(repBarcode);
            //미리보기 창 활성화
            ReportViewer repViewer = new ReportViewer(repbook, 1);
            repViewer.ShowDialog();

        }

        private void BTNworker_Click(object sender, EventArgs e)
        {
            //작업자 등록 시작
            if (grid1.Rows.Count == 0) return;
            if(grid1.ActiveRow == null)
            {
                ShowDialog("작업지시 선택후 진행", DC00_WinForm.DialogForm.DialogType.OK);
                return; 
            }
            string sWID = txtWID.Text.ToString();
            if(sWID == "")
            {
                ShowDialog("작업자를 선택 후 진행하세요. ", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            //DB에 등록하기 위한 변수 지정

            string sON = grid1.ActiveRow.Cells["ORDERNO"].Value.ToString();
            string sWCC = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            DBHelper HP = new DBHelper("", true);
            try
            {
                HP.ExecuteNoneQuery(    "04PP_ActureOutput_I2",              CommandType.StoredProcedure,
                    HP.CreateParameter( "PLANTCODE", "1000",              DbType.String,ParameterDirection.Input)
                    ,HP.CreateParameter("WORKER",                   sWID, DbType.String,ParameterDirection.Input)
                    ,HP.CreateParameter("ORDERNO",                  sON,  DbType.String,ParameterDirection.Input)
                    ,HP.CreateParameter("WORKCENTERCODE",           sWCC, DbType.String,ParameterDirection.Input)
                );

                HP.Commit();
                if (HP.RSCODE == "S")
                {
                    HP.Commit();
                    ShowDialog(HP.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);

                }
                else
                {
                    HP.Rollback();
                    ShowDialog(HP.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                HP.Rollback();
                ShowDialog($"{ex}", DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally
            {
                HP.Close();
            }
        }
        //JUST-IN-TIME의 개념.

        private void BtnLotNOin_Click(object sender, EventArgs e)
        {
            //MES는 LOT을 관리할 수 있기 때문에 특별한 것이다.
            //LOT 투입
            if (this.grid1.ActiveRow == null) return;
            DBHelper HP = new DBHelper("", true);
            try
            {
                //변수 선언
             string sIC = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
             string sLN = DBHelper.nvlString(txtInLotNo.Text);
             string sWCC = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
             string sON= DBHelper.nvlString(grid1.ActiveRow.Cells["ORDERNO"].Value);
             string sUC = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCODE"].Value);
             string sIF = DBHelper.nvlString(BtnLotNOin.Text);
                string sW = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKER"].Value);

                if( sIF == "투입")
                {
                    sIF = "IN";
                }
                else
                {
                    sIF = "OUT";
                }
                     HP.ExecuteNoneQuery(             "04PP_ActureOutput_I1",         CommandType.StoredProcedure,
                     HP.CreateParameter(              "PLANTCODE",            "1000", DbType.String,  ParameterDirection.Input)
                   , HP.CreateParameter(              "ITEMCODE",               sIC,  DbType.String,  ParameterDirection.Input)
                   , HP.CreateParameter(              "LOTNO",                  sLN,  DbType.String,  ParameterDirection.Input)
                   , HP.CreateParameter(              "WORKCENTERCODE",        sWCC,  DbType.String,  ParameterDirection.Input)
                   , HP.CreateParameter(              "UNITCODE",               sUC,  DbType.String,  ParameterDirection.Input)
                   , HP.CreateParameter(              "INFLAG",                 sIF,  DbType.String,  ParameterDirection.Input)
                   , HP.CreateParameter(              "ORDERNO",                sON,  DbType.String,  ParameterDirection.Input)
                   , HP.CreateParameter(              "MAKER",                 sWCC,  DbType.String,  ParameterDirection.Input)
               );
                ShowDialog(HP.RSMSG, DC00_WinForm.DialogForm.DialogType.OK);
                HP.Commit();
                DoInquire();

            }
            catch (Exception ex)
            {

                HP.Rollback();
                ShowDialog(ex.ToString(), DC00_WinForm.DialogForm.DialogType.OK);

            }
            finally
            {
                HP.Close();
            }
        }

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            if (DBHelper.nvlString(this.grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value) == "R")
            {
                Btn_Run.Text = "비가동";
            }
            else Btn_Run.Text = "가동";
            string sMatLotNo = DBHelper.nvlString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            if (sMatLotNo != "")
            {
                txtInLotNo.Text = sMatLotNo;
                BtnLotNOin.Text = "투입취소";




            }
            else
            {
                txtInLotNo.Text = "";
                BtnLotNOin.Text = "투입";
            }
            txtWID.Text = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKER"].Value);
            txtWorkerName.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKERNAME"].Value);

        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {
            //가동/비가동 등록!!!!!!
            DBHelper HP = new DBHelper("", false);
            try
            {
                string sSt = "R"; //run/stop
                if (Btn_Run.Text == "비가동")
                {
                    sSt = "S";

                    HP.ExecuteNoneQuery("04PP_ActureOutput_U1", CommandType.StoredProcedure
                                                              , HP.CreateParameter("PLANTCODE"     , plantCode, DbType.String, ParameterDirection.Input)
                                                              , HP.CreateParameter("WORKCENTERCODE", Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value), DbType.String, ParameterDirection.Input)
                                                              , HP.CreateParameter("ORDERNO"       , Convert.ToString(this.grid1.ActiveRow.Cells["ORDERNO"].Value), DbType.String, ParameterDirection.Input)
                                                              , HP.CreateParameter("ITEMCODE"      , Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                              , HP.CreateParameter("UNITCODE"      , Convert.ToString(this.grid1.ActiveRow.Cells["IUNITCODE"].Value), DbType.String, ParameterDirection.Input)
                                                              , HP.CreateParameter("STATUS"        , sSt, DbType.String, ParameterDirection.Input)
                                                                    );
                    DoInquire();

                }
            }
            catch (Exception ex)
            {

                HP.Rollback();
                ShowDialog(e.ToString());
            }
            finally
            {
                HP.Close();
            }
        }
    }
}




