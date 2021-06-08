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
    public partial class BM_WORKLIST : DC00_WinForm.BaseMDIChildForm
    {
        //그리드 세팅 도와주는 함수 클래스
        UltraGridUtil _gridUtil = new UltraGridUtil();

        //공장 변수 입력
        //private sPlantCode = LoginInfo.
        public BM_WORKLIST()
        {
            InitializeComponent();
        }

        private void BM_WORKLIST_Load(object sender, EventArgs e)
        {
            //그리드를 세팅한다.
            try
            {
                _gridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _gridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "WORKERID", "작업자ID", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "BANCODE", "작업반", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "GRPID", "그룹", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "부서", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "PHONENO", "연락처", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "INDATE", "입사일", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "OUTDATE", "퇴사일", true,
                    GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true,
                   GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _gridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true,
                   GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                _gridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true,
                   GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                _gridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true,
                   GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                _gridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true,
                   GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                _gridUtil.SetInitUltraGridBind(grid1);

                Common _Common = new Common();
                DataTable dttemp = new DataTable();
                dttemp = _Common.Standard_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cmb_plant, dttemp, dttemp.Columns["CODE_ID"].ColumnName,
                    dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                dttemp = _Common.Standard_CODE("BANCODE");
                Common.FillComboboxMaster(this.cmb_workplace, dttemp, dttemp.Columns["CODE_ID"].ColumnName,
                    dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                dttemp = _Common.Standard_CODE("USEFLAG");
                Common.FillComboboxMaster(this.cmb_UseFlag, dttemp, dttemp.Columns["CODE_ID"].ColumnName,
                    dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                dttemp = _Common.Standard_CODE("DEPTCODE");
                dttemp = _Common.Standard_CODE("GRPID");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", dttemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "BANCODE", dttemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", dttemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", dttemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "GRPID", dttemp, "CODE_ID", "CODE_NAME");
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
                dttemp = helper.FillTable("04BM_WorkList_S1", CommandType.StoredProcedure,
                    helper.CreateParameter("PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input),
                helper.CreateParameter("WORKERID", sWorkerId, DbType.String, ParameterDirection.Input),
                helper.CreateParameter("WORKERNAME", sWorkerName, DbType.String, ParameterDirection.Input),
                helper.CreateParameter("BANCODE", sBancode, DbType.String, ParameterDirection.Input),
                helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                this.ClosePrgForm();
                if (dttemp.Rows.Count > 0)
                {
                    grid1.DataSource = dttemp;
                    grid1.DataBinds(dttemp);

                }
                else
                {
                    _gridUtil.Grid_Clear(grid1);
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
            this.grid1.InsertRow();
            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = "1000";
            this.grid1.ActiveRow.Cells["GRPID"].Value = "SW";
            this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
            this.grid1.ActiveRow.Cells["INDATE"].Value = DateTime.Now.ToString("yyyy-mm-dd");
            grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;



            

        }
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();

        }
        public override void DoSave()
        {
            base.DoSave();
            DataTable dttemp = new DataTable();
            dttemp = grid1.chkChange();
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
                    if (Convert.ToString(drrow["WORKID"]) == String.Empty)
                    {
                        this.ClosePrgForm();
                        this.ShowDialog("작업자 ID를 입력하세요", DC00_WinForm.DialogForm.DialogType.OK);
                        return;
                    }
                    switch (drrow.RowState)
                    {
                        case DataRowState.Deleted:
                            drrow.RejectChanges();
                            helper.ExecuteNoneQuery("04BM_WorkList_D1", CommandType.StoredProcedure,
                                helper.CreateParameter("PLANTCODE", Convert.ToString(drrow["PLANTCODE"]),
                                DbType.String, ParameterDirection.Input),

                                helper.CreateParameter("WORKERID", Convert.ToString(drrow["WORKERID"]),
                                DbType.String, ParameterDirection.Input));
                                
                              

                            break;
                        case DataRowState.Added:
                            helper.ExecuteNoneQuery("04BM_WorkList_I1"
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
                            helper.ExecuteNoneQuery("04BM_WorkList_U1"
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
                        
                    }
                }
                if (helper.RSCODE == "S")
                {
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

