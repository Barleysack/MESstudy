#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_ActualOutProduct
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
    public partial class PP_ActualOutProduct : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_ActualOutProduct()
        {
            InitializeComponent();
        }
        #endregion
        //MRP 자재 소요량 예측 및 관리자재 소요량 계획은 제조 프로세스를 관리하는 데 사용되는 생산 계획,
        //일정 및 재고 관리 시스템입니다.
        //대부분의 MRP 시스템은 소프트웨어 기반이지만 수동으로 MRP를 수행 할 수도 있습니다.
        //워크 센터 코드? 
        #region < FORM EVENTS >
        private void PP_ActualOutProduct_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",     true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목",     true, GridColDataType_emu.VarChar,    140, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품목명",   true, GridColDataType_emu.VarChar,    140, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",       "LOTNO",     true, GridColDataType_emu.VarChar,   120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",         "입고창고", true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",       "재고수량", true, GridColDataType_emu.Double,     100, 120, Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",       "단위",     true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",       "거래처",   true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME",       "거래처명", true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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



                

                rtnDtTemp = helper.FillTable("04PP_ActualOutPut_S1", CommandType.StoredProcedure
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
    }
}




