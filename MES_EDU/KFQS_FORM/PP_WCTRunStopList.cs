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
    public partial class PP_WCTRunStopList : DC00_WinForm.BaseMDIChildForm
    {
        // 그리드를 셋팅 할 수 있도록 도와주는 함수 클래스
        UltraGridUtil _GridUtil = new UltraGridUtil();
        //공장 변수 입력
        //private sPlantCode = LoginInfo.
        public PP_WCTRunStopList()
        {
            InitializeComponent();
        }

        private void PP_WCTRunStopList_Load(object sender, EventArgs e)
        {
            // 그리드를 셋팅한다.
            try
            {
                _GridUtil.InitializeGrid(this.grid1, false,true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",              "공장",                true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",         "작업장",              true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",         "작업장명",            true, GridColDataType_emu.VarChar, 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",                "작업지시번호",        true, GridColDataType_emu.VarChar, 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",               "품목 코드",           true, GridColDataType_emu.VarChar,   130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",               "품명",                true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKER",                 "작업자",              true, GridColDataType_emu.VarChar, 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE",              "시작일시",           true, GridColDataType_emu.DateTime24, 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE",                "종료일시",             true, GridColDataType_emu.DateTime24, 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPENTTIME",              "소요시간",           true, GridColDataType_emu.VarChar, 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS",             "가동/비가동",               true, GridColDataType_emu.VarChar, 160, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",                "생산수량",            true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",                 "불량수량",            true, GridColDataType_emu.Double,    130, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK",                 "사유",                true, GridColDataType_emu.VarChar,    130, 130, Infragistics.Win.HAlign.Right, true,true);






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
                Common.FillComboboxMaster(this.cboWorkcenterCode, dtTemp,
                                          dtTemp.Columns["CODE_ID"].ColumnName,
                                          dtTemp.Columns["CODE_NAME"].ColumnName,
                                          "ALL", "");


                // 그리드 해당 컬럼에 콤보박스 유형으로 셋팅
                UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", dtTemp, "CODE_ID", "CODE_NAME");

                #region ▶ POP-UP ◀
          
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
                dtTemp = helper.FillTable("04PP_WCTRunStopList_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("WORKCENTERCODE", DBHelper.nvlString(cboWorkcenterCode.Value), DbType.String, ParameterDirection.Input)
                                          
                                          , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)






                                          );
                ;
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
            DataTable dt = new DataTable();

            dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", false);

            try
            {
                //base.DoSave();

             

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (Convert.ToString(dt.Rows[i]["WORKSTATUS"]) == "가동중")
                    {
                        ShowDialog("기계가 돌아가고 있습니다.",DC00_WinForm.DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }

                    helper.ExecuteNoneQuery("04PP_WCTRunStopList_U1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE", Convert.ToString(dt.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(dt.Rows[i]["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ORDERNO", Convert.ToString(dt.Rows[i]["ORDERNO"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("RSSEQ", Convert.ToString(dt.Rows[i]["RSSEQ"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("REMARK", Convert.ToString(dt.Rows[i]["REMARK"]), DbType.String, ParameterDirection.Input)

                                            , helper.CreateParameter("EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                            
                                            
                                            
                                            );
                                            

                    if (helper.RSCODE == "E")
                    {
                        this.ShowDialog(helper.RSMSG,DC00_WinForm.DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }
                }

                helper.Commit();
                this.ShowDialog("데이터가 저장 되었습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                this.ClosePrgForm();
                DoInquire();
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

        private void grid1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
