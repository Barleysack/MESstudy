#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 생산출고 등록/취소
//   Name Space   : 
//   Created Date : 
//   Made By      : 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DC00_assm;
using DC_POPUP;
using DC00_WinForm;

#endregion

namespace KFQS_Form
{
    public partial class WM_StockWM : DC00_WinForm.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable table         = new DataTable();
        DataTable rtnDtTemp     = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >

        public WM_StockWM()
        {
            InitializeComponent();
            //BizTextBoxManager btbManager = new BizTextBoxManager();

            //btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER", new object[] { cboPlantCode, "" });


        }
        #endregion

        #region  WM_StockWM
        private void WM_StockWM_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성
            #region 
            
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",             "상차 등록",        true, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true  );
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "공장",        true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPFLAG",        "상차 여부",       true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "품목",        true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",        "품목명",      true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",           "LOTNO",      true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE",        "품목타입",    true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",          "창고코드",    true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true ,false );
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME",          "창고명",      true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",        "수량",     true, GridColDataType_emu.VarChar,  70, 100, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",        "단위",        true, GridColDataType_emu.VarChar,  50, 100, Infragistics.Win.HAlign.Center, true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",          "등록자",      true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",        "등록일시",    true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false );
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  //사업장

            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");



            rtnDtTemp =_Common.Standard_CODE("YESNO");
            Common.FillComboboxMaster(this.cboLoadFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "SHIPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkerID,
                                txtWorkerName,
                                "WORKER_MASTER"
                                , new object[] { "", "", "", "", "" });

            btbManager.PopUpAdd(txtCustCode, txtCustName, "CUST_MASTER", new object[] { "1000", "", "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "ITEM_MASTER", new object[] { "1000", "" });

            this.cboPlantCode.Value = "1000";




            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
           
            #endregion
        }
        #endregion  WM_StockWM_Load
        
        #region <TOOL BAR AREA >




        public override void DoInquire()
        {   
            
            
            this._GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sSrart     = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sEnd       = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);

                

                rtnDtTemp = helper.FillTable("04WM_StockWM_S1", CommandType.StoredProcedure
                                              , helper.CreateParameter("PLANTCODE", Convert.ToString("1000"), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ITEMCODE", Convert.ToString(txtItemCode.Value), DbType.String, ParameterDirection.Input)

                                            , helper.CreateParameter("LOTNO", Convert.ToString(TXTLOTNO.Text), DbType.String, ParameterDirection.Input)

                                            , helper.CreateParameter("STARTDATE", Convert.ToString(dtStart_H.Value), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ENDDATE", Convert.ToString(dtEnd_H.Value), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("SHIPFLAG", Convert.ToString(cboLoadFlag.Value), DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                this.ClosePrgForm();
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

        
        
        #region <METHOD AREA>
        #endregion
        public override void DoSave()
        {

            DataTable dt = new DataTable();

                dt = grid1.chkChange();
                if (dt == null)
                    return;

            DBHelper helper = new DBHelper("", false);

            try
            {
                //base.DoSave();

                if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++ )
                {
                    if (Convert.ToString(dt.Rows[i]["CHK"]) == "0") continue;

                    helper.ExecuteNoneQuery("04WM_StockWM_U1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE",      Convert.ToString("1000"), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("LOTNO"     ,     Convert.ToString(dt.Rows[i]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ITEMCODE" ,      Convert.ToString(dt.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("SHIPQTY",        Convert.ToString(dt.Rows[i]["STOCKQTY"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CARNO"	,      Convert.ToString(txtCarNo.Text), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CUSTCODE",      Convert.ToString(txtCustCode.Text), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("WORKER"    ,     Convert.ToString(txtWorkerID.Text), DbType.String, ParameterDirection.Input)
                                           );

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }
                }

                helper.Commit();
                this.ShowDialog("데이터가 저장 되었습니다.", DialogForm.DialogType.OK);
                this.ClosePrgForm();
                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                
            }
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            
            }

        private void gbxHeader_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton1_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = grid1.chkChange();
            if (dt == null)
                return;

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
                    if (Convert.ToString(dt.Rows[i]["CHK"]) == "0") continue;

                    helper.ExecuteNoneQuery("04WM_StockWM_U2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE", Convert.ToString("1000"), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("LOTNO", Convert.ToString(dt.Rows[i]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ITEMCODE", Convert.ToString(dt.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("SHIPQTY", Convert.ToString(dt.Rows[i]["STOCKQTY"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CARNO", Convert.ToString(txtCarNo.Text), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CUSTCODE", Convert.ToString(txtCustCode.Text), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("WORKER", Convert.ToString(txtWorkerID.Text), DbType.String, ParameterDirection.Input)
                                           );

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }
                }

                helper.Commit();
                this.ShowDialog("데이터가 저장 되었습니다.", DialogForm.DialogType.OK);
                this.ClosePrgForm();
                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
    }
    }


