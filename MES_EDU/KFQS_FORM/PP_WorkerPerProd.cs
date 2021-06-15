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
    public partial class PP_WorkerPerProd : DC00_WinForm.BaseMDIChildForm
    {
        // 그리드를 셋팅 할 수 있도록 도와주는 함수 클래스
        UltraGridUtil _GridUtil = new UltraGridUtil();
        //공장 변수 입력
        //private sPlantCode = LoginInfo.
        public PP_WorkerPerProd()
        {
            InitializeComponent();
        }

        private void PP_WorkerPerProd_Load(object sender, EventArgs e)
        {
            // 그리드를 셋팅한다.
            try
            {
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",                true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER",         "작업자",               true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE",        "생산일자",           true, GridColDataType_emu.DateTime24, 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목 코드",           true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품명",                true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "생산수량",            true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",            true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TOTALQTY",       "총생산량",            true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "BADRATE",       "불량률",               true, GridColDataType_emu.VarChar,    130, 130, Infragistics.Win.HAlign.Right, true, false);

                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",              true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명",            true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);


               
                _GridUtil.InitColumnUltraGrid(grid1, "MAKETIME",      "생산일시", true, GridColDataType_emu.DateTime24,160, 130, Infragistics.Win.HAlign.Left, true, false);
               
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
                string sStartDate      = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEndDate        = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);
        


                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("04PP_WorkerProduct_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE",      sPlantCode,      DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("WORKER",      txtWorkerID.Text,      DbType.String, ParameterDirection.Input)
                                    
                                          , helper.CreateParameter("STARTDATE", sStartDate,      DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("ENDDATE", sEndDate,      DbType.String, ParameterDirection.Input)
                                        





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
                helper.ExecuteNoneQuery("00PP_WorkerPerProd_I2", CommandType.StoredProcedure,
                                        helper.CreateParameter("PLANTCODE",       "1000",          DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("WORKER",         sWorkId,         DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("ORDERNO",        sOrederNo,       DbType.String, ParameterDirection.Input),
                                        helper.CreateParameter("WORKCENTERCODE", sWOrkcentercode, DbType.String, ParameterDirection.Input)
                                        );
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
            }
            finally 
            { 
                helper.Close(); 
            }
        }

       
        

        

        

        
    }
}
