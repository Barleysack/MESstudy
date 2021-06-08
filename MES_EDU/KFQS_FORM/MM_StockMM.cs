using DC00_assm;
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
    public partial class MM_StockMM : DC00_WinForm.BaseMDIChildForm
    {
        //그리드 세팅 도와주는 함수 클래스
        UltraGridUtil _gridUtil = new UltraGridUtil();

        //공장 변수 입력
        //private sPlantCode = LoginInfo.
        public MM_StockMM()
        {
            InitializeComponent();
        }

        private void MM_StockMM_Load(object sender, EventArgs e)
        {
            //그리드를 세팅한다.
            try
            {
                _gridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
                _gridUtil.InitColumnUltraGrid(grid2, "PLANTCODE",     "공장", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "ITEMCODE",     "품목", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "ITEMNAME",   "품목명", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "MATLOTNO",      "LOT번호", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "WHCODE",         "창고", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "STOCKQTY",      "재고수량", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "UNITCODE",        "단위", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "CUSTCODE",        "거래처", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "CUSTNAME",      "거래처명", true,                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "MAKER",       "생성자", true,                   GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid2, "MAKEDATE",       "생성일시", true,                   GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
              
                _gridUtil.SetInitUltraGridBind(grid2);

                //콤보 박스 셋팅
                Common _Common = new Common();
                DataTable dtTemp = new DataTable();
                // PLANTCODE 기준정보 가져와서 데이터 테이블에 추가
                // 데이터 테이블에 있는 데이터를 해당 콤보박스에 추가.
                // CODE_ID 벨류를 CODE_NAME로 디스 플레이
                dtTemp = _Common.Standard_CODE("PLANTCODE");                      
                Common.FillComboboxMaster(this.CMBPLANT, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");

                dtTemp = _Common.Standard_CODE("ITEMCODE");
                Common.FillComboboxMaster(this.CMBITEMCODE, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "BANCODE", dtTemp, "CODE_ID", "CODE_NAME");

               

               





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
                string sPlantcode = cmb_plant.Value.ToString();
                string sWorkerId = txt_Wnum.Text.ToString();
                string sWorkerName = txt_Wname.Text.ToString();
                string sBancode = cmb_workplace.Value.ToString();
                string sUseFlag = cmb_UseFlag.Value.ToString();

                DataTable dttemp = new DataTable();
                dttemp = helper.FillTable("04MM_StockMM_S1", CommandType.StoredProcedure,
                    helper.CreateParameter("PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input),
                helper.CreateParameter("WORKERID", sWorkerId, DbType.String, ParameterDirection.Input),
                helper.CreateParameter("WORKERNAME", sWorkerName, DbType.String, ParameterDirection.Input),
                helper.CreateParameter("BANCODE", sBancode, DbType.String, ParameterDirection.Input),
                helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.ClosePrgForm();
                if (dttemp.Rows.Count > 0)
                {
                    grid2.DataSource = dttemp;
                    grid2.DataBinds(dttemp);

                }
                else
                {
                    _gridUtil.Grid_Clear(grid2);
                    ShowDialog("조회할 데이터가 없습니다", DC00_WinForm.DialogForm.DialogType.OK);

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
            public override void DoNew()
        {
            base.DoNew();
            this.grid2.InsertRow();
            this.grid2.ActiveRow.Cells["PLANTCODE"].Value = "1000";
            this.grid2.ActiveRow.Cells["GRPID"].Value = "SW";
            this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
            this.grid2.ActiveRow.Cells["INDATE"].Value = DateTime.Now.ToString("yyyy-mm-dd");
            grid2.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            grid2.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid2.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            grid2.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;



            

        }
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid2.DeleteRow();

        }
        public override void DoSave()
        {
            base.DoSave();
            DataTable dttemp = new DataTable();
            dttemp = grid2.chkChange();
            if (dttemp.Rows.Count == 0) { return; }
            DBHelper helper = new DBHelper("", true);
            try
            {
                //해당 내역을 저장하시겠습니까?
                if (ShowDialog("해당 사항을 저장 하시겠습니까? ",DC00_WinForm.DialogForm.DialogType.YESNO)== System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                {

                }
                foreach (DataRow drrow in dttemp.Rows)
                {
                    
                    switch (drrow.RowState)
                    {
                        case DataRowState.Deleted:
                            drrow.RejectChanges();
                            helper.ExecuteNoneQuery("04MM_StockMM_D1", CommandType.StoredProcedure,
                                helper.CreateParameter("PLANTCODE", Convert.ToString(drrow["PLANTCODE"]),
                                DbType.String, ParameterDirection.Input),

                                helper.CreateParameter("WORKERID", Convert.ToString(drrow["WORKERID"]),
                                DbType.String, ParameterDirection.Input));
                                
                              

                            break;
                        case DataRowState.Added:
                            if (Convert.ToString(drrow["WORKERID"]) == String.Empty)
                            {
                                this.ClosePrgForm();
                                this.ShowDialog("작업자 ID를 입력하세요", DC00_WinForm.DialogForm.DialogType.OK);
                                return;
                            }
                            helper.ExecuteNoneQuery("04MM_StockMM_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drrow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERID", Convert.ToString(drrow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERNAME", Convert.ToString(drrow["WORKERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("GRPID", Convert.ToString(drrow["GRPID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DEPTCODE", Convert.ToString(drrow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("BANCODE", Convert.ToString(drrow["BANCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drrow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PHONENO", Convert.ToString(drrow["PHONENO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INDATE", Convert.ToString(drrow["INDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OUTDATE", Convert.ToString(drrow["OUTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                   
                                                    );
                            break;
                        case DataRowState.Modified:
                            helper.ExecuteNoneQuery("04MM_StockMM_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drrow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERID", Convert.ToString(drrow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERNAME", Convert.ToString(drrow["WORKERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("GRPID", Convert.ToString(drrow["GRPID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DEPTCODE", Convert.ToString(drrow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("BANCODE", Convert.ToString(drrow["BANCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drrow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PHONENO", Convert.ToString(drrow["PHONENO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INDATE", Convert.ToString(drrow["INDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OUTDATE", Convert.ToString(drrow["OUTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)

                                                    );
                            break;
                        
                    }
                }
                if (helper.RSCODE == "S")
                {
                    string s = helper.RSMSG;
                    helper.Commit();
                    this.ShowDialog("등록 완료!");
                    DoInquire();

                }
                

            }
            catch (Exception ex)
            {

                ShowDialog($"{ex}");
            }
            finally
            {
                helper.Close();
            }
        }
    }
        
}

