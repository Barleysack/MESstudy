
namespace KFQS_Form
{
    partial class MM_PoMake
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.cmb_plant = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cmb_CUST_PLACE = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.TXT_poNum = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.grid1 = new DC00_Component.Grid(this.components);
            this.DTPSTART = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.DTPEND = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_plant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_CUST_PLACE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_poNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTPSTART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTPEND)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.ultraLabel3);
            this.gbxHeader.Controls.Add(this.DTPEND);
            this.gbxHeader.Controls.Add(this.ultraLabel2);
            this.gbxHeader.Controls.Add(this.DTPSTART);
            this.gbxHeader.Controls.Add(this.ultraLabel6);
            this.gbxHeader.Controls.Add(this.TXT_poNum);
            this.gbxHeader.Controls.Add(this.ultraLabel4);
            this.gbxHeader.Controls.Add(this.cmb_CUST_PLACE);
            this.gbxHeader.Controls.Add(this.ultraLabel1);
            this.gbxHeader.Controls.Add(this.cmb_plant);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 201);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 201);
            this.gbxBody.Size = new System.Drawing.Size(1136, 624);
            // 
            // cmb_plant
            // 
            this.cmb_plant.Location = new System.Drawing.Point(130, 63);
            this.cmb_plant.Name = "cmb_plant";
            this.cmb_plant.Size = new System.Drawing.Size(195, 35);
            this.cmb_plant.TabIndex = 0;
            this.cmb_plant.Text = "ultraComboEditor1";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(38, 67);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "공장";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(391, 67);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel4.TabIndex = 5;
            this.ultraLabel4.Text = "거래처";
            // 
            // cmb_CUST_PLACE
            // 
            this.cmb_CUST_PLACE.Location = new System.Drawing.Point(484, 63);
            this.cmb_CUST_PLACE.Name = "cmb_CUST_PLACE";
            this.cmb_CUST_PLACE.Size = new System.Drawing.Size(185, 35);
            this.cmb_CUST_PLACE.TabIndex = 4;
            this.cmb_CUST_PLACE.Text = "ultraComboEditor2";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(751, 109);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel6.TabIndex = 9;
            this.ultraLabel6.Text = "발주 번호";
            // 
            // TXT_poNum
            // 
            this.TXT_poNum.Location = new System.Drawing.Point(857, 105);
            this.TXT_poNum.Name = "TXT_poNum";
            this.TXT_poNum.Size = new System.Drawing.Size(267, 35);
            this.TXT_poNum.TabIndex = 8;
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance1;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance10.BackColor = System.Drawing.SystemColors.Highlight;
            appearance10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)(((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance8;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance5.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance11;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 612);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // DTPSTART
            // 
            this.DTPSTART.DateButtons.Add(dateButton2);
            this.DTPSTART.Location = new System.Drawing.Point(857, 43);
            this.DTPSTART.Name = "DTPSTART";
            this.DTPSTART.NonAutoSizeHeight = 32;
            this.DTPSTART.Size = new System.Drawing.Size(121, 32);
            this.DTPSTART.TabIndex = 10;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(984, 45);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(100, 32);
            this.ultraLabel2.TabIndex = 11;
            this.ultraLabel2.Text = "~";
            // 
            // DTPEND
            // 
            this.DTPEND.DateButtons.Add(dateButton1);
            this.DTPEND.Location = new System.Drawing.Point(1003, 43);
            this.DTPEND.Name = "DTPEND";
            this.DTPEND.NonAutoSizeHeight = 32;
            this.DTPEND.Size = new System.Drawing.Size(121, 32);
            this.DTPEND.TabIndex = 12;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(751, 45);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 13;
            this.ultraLabel3.Text = "발주 일자";
            // 
            // MM_PoMake
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "MM_PoMake";
            this.Text = "작업자 마스터";
            this.Load += new System.EventHandler(this.MM_PoMake_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmb_plant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_CUST_PLACE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_poNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTPSTART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTPEND)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmb_plant;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TXT_poNum;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmb_CUST_PLACE;
        private DC00_Component.Grid grid1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo DTPEND;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo DTPSTART;
    }
}
