#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM_InspectionPerItem
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
using System.Data.SqlClient;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KFQS_Form
{
    public partial class WM_InspectionPerItem : DC00_WinForm.BaseMDIChildForm
    {
        private SqlConnection Connect = null;       // 접속 정보 객체 명명
                                                    // 접속 주소
        private string strConn = "Data Source=222.235.141.8; Initial Catalog=KFQS_MES_2021;User ID=kfqs1;Password=1234";

        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();

        string plantCode = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public WM_InspectionPerItem()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void WM_InspectionPerItem_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 110, 120, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드", true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPFLAG", "검사필요여부", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "최종검사결과", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "수입검사 항목 코드", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPDETAIL", "수입검사 내용", true, GridColDataType_emu.VarChar, 200, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, false, false);

            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region ▶ COMBOBOX ◀

            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            DBHelper dBHelper = new DBHelper(false);
            string sINSPcode = "";
            string sINSPDetail = "";


            Connect = new SqlConnection(strConn);
            Connect.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select INSPCODE   AS CODE_ID , INSPDETAIL AS CODE_NAME from TB_4_INSPMaster", Connect);
            DataTable AtTemp = new DataTable();
            adapter.Fill(AtTemp);

            UltraGridUtil.SetComboUltraGrid(this.grid2, "INSPCODE", AtTemp, "CODE_ID", "CODE_ID");

            UltraGridUtil.SetComboUltraGrid(this.grid2, "INSPDETAIL", AtTemp, "CODE_NAME", "CODE_NAME");


            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER", new object[] { cboPlantCode, "FERT", "", "" });
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >X`
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
                _GridUtil.Grid_Clear(grid2);
                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sItemCode = Convert.ToString(txtItemCode_H.Value);
                if (sItemCode == "")
                {
                    sItemCode = "KFQS";
                }
                string sItemType = "FERT";


                rtnDtTemp = helper.FillTable("WM_InspectionPerItem_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                    );

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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            try
            {
                this.grid2.InsertRow();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

            base.DoDelete();
            grid2.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            this.grid2.UpdateData();
            DataTable dt = (DataTable)grid2.DataSource;
            DBHelper helper = new DBHelper("", false);

            try
            {
                //base.DoSave();

                if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    helper.ExecuteNoneQuery("WM_InspectionPerItem_U1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("INSPCODE", Convert.ToString(dt.Rows[i]["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("INSPDETAIL", Convert.ToString(dt.Rows[i]["INSPDETAIL"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ITEMCODE", Convert.ToString(dt.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("PLANTCODE", Convert.ToString(dt.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                            );

                    if (helper.RSCODE == "E")
                    {
                        this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }
                }

                helper.Commit();
                this.ShowDialog("저장에 성공했습니다", DialogForm.DialogType.OK);
                this.ClosePrgForm();
                DoInquire();
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
        #endregion

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sInspFlag = Convert.ToString(grid1.ActiveRow.Cells["INSPFLAG"].Value);
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);

                if (sInspFlag == "무검사")
                {
                    _GridUtil.Grid_Clear(grid2);
                    return;
                }
                else
                {
                    rtnDtTemp = helper.FillTable("WM__4_InspectionPerItem_S2", CommandType.StoredProcedure
                                        , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                        );


                    this.ClosePrgForm();
                    this.grid2.DataSource = rtnDtTemp;
                }
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
    }
}





