#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP_ProductPlan
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
    public partial class AP_ProductPlan : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public AP_ProductPlan()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void AP_ProductPlan_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",              true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "계획번호",             true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "생산품목",           true, GridColDataType_emu.VarChar, 300, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획수량",            true, GridColDataType_emu.Double, 100, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위",               true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",       true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "확정",                    true, GridColDataType_emu.CheckBox, 100, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호",        true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "확정일시",          true, GridColDataType_emu.DateTime24, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERWORKER", "확정자",          true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERCLOSEFLAG", "지시종료여부", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자",                true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시",           true, GridColDataType_emu.DateTime24, 120, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자"         ,      true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시",           true, GridColDataType_emu.DateTime24, 120, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("YESNO");     // 지시 종료 여부
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERCLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            Common.FillComboboxMaster(this.cmbOrderCloseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            rtnDtTemp = _Common.GET_Workcenter_Code();     //작업장
            Common.FillComboboxMaster(this.cmbWorkCenterCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                string sPlantCode      = DBHelper.nvlString(this.cboPlantCode.Value);
                string sWorkcenterCode       = DBHelper.nvlString(this.cmbWorkCenterCode.Value);
                string sOrderno          = DBHelper.nvlString(txtOrderNo.Text);
                string sOrderCloseFlag = DBHelper.nvlString(cmbOrderCloseFlag.Value);


                rtnDtTemp = helper.FillTable("04AP_ProductPlan_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",   sPlantCode,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode,   DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ORDERNO", sOrderno,      DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ORDERCLOSEFLAG", sOrderCloseFlag,      DbType.String, ParameterDirection.Input)
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




