using DC_POPUP;
using DC00_assm;
using DC00_WinForm;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace KFQS_Form
{
    public partial class PP_BadListCNT : DC00_WinForm.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable table = new DataTable();
        DataTable rtnDtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >

        public PP_BadListCNT()
        {
            InitializeComponent();
        }
        #endregion

        #region  PP_BadListCNT
        private void PP_BadListCNT_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성
            #region 

            _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE",       "공장",   true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE",        "품목",   true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME",        "품명",   true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            _GridUtil.InitializeGrid(this.grid3, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "공장",         true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE",  "품목",         true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "INSP",      "검사 항목",    true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "NGCOUNT",   "NG 판정 갯수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid4, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE",       "품목",           true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "LOTNO",          "LOT번호",        true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "WORKCENTERCODE", "작업장",         true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "MAKER",          "작업자",         true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "MAKEDATE",       "작업일자",       true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.SetInitUltraGridBind(grid4);

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");    //공장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #region 팝업
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER", new object[] { "1000", "FERT", "KFQS" + "", "" });
            #endregion

            #endregion
        }
        #endregion  PP_BadListCNT_Load

        #region <DoInquire>
        public override void DoInquire()
        {


            DBHelper helper = new DBHelper(false);

            try
            {
                this._GridUtil.Grid_Clear(grid2);
                this._GridUtil.Grid_Clear(grid3);


                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sItemCode  = Convert.ToString(txtItemCode_H.Text);

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("02PP_BadListCNT_S1", CommandType.StoredProcedure
                                              , helper.CreateParameter("PLANTCODE",  sPlantCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ITEMCODE",   sItemCode, DbType.String, ParameterDirection.Input)
                                              );
                this.ClosePrgForm();

                grid2.DataSource = dtTemp;
                grid2.DataBinds(dtTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void grid2_AfterRowActivate(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                this._GridUtil.Grid_Clear(grid3);
                this._GridUtil.Grid_Clear(grid4);
                string sPlantCode = Convert.ToString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemcode  = Convert.ToString(grid2.ActiveRow.Cells["ITEMCODE"].Value);

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("02PP_BadListCNT_S2", CommandType.StoredProcedure
                                              , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ITEMCODE", sItemcode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("INSPRESULT_B", "N", DbType.String, ParameterDirection.Input)
                                              );
                this.ClosePrgForm();
                grid3.DataSource = dtTemp;
                grid3.DataBinds(dtTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }



        private void grid3_AfterRowActivate(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sItemcode = Convert.ToString(grid3.ActiveRow.Cells["ITEMCODE"].Value);
                string sINSP = Convert.ToString(grid3.ActiveRow.Cells["INSP"].Value);

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("02PP_BadListCNT_S3", CommandType.StoredProcedure
                                              , helper.CreateParameter("ITEMCODE", sItemcode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("INSP",     sINSP,     DbType.String, ParameterDirection.Input)
                                              );
                this.ClosePrgForm();
                grid4.DataSource = dtTemp;
                grid4.DataBinds(dtTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
    }
}

