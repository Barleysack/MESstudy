namespace KFQS_Form
{
    partial class MM_StockOUT
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.lblPlantCode = new DC00_Component.SLabel();
            this.lblItemCode = new DC00_Component.SLabel();
            this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grid1 = new DC00_Component.Grid(this.components);
            this.lblWorkerName_H = new DC00_Component.SLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.CMBStorageLOC = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel2 = new DC00_Component.SLabel();
            this.CMBWH = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel3 = new DC00_Component.SLabel();
            this.DTPSTART = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.DTPEND = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.sLabel1 = new DC00_Component.SLabel();
            this.CMBITEMCODE = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel4 = new DC00_Component.SLabel();
            this.txtLOTno = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CMBStorageLOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMBWH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTPSTART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTPEND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMBITEMCODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLOTno)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txtLOTno);
            this.gbxHeader.Controls.Add(this.CMBITEMCODE);
            this.gbxHeader.Controls.Add(this.sLabel4);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.DTPEND);
            this.gbxHeader.Controls.Add(this.DTPSTART);
            this.gbxHeader.Controls.Add(this.ultraGroupBox1);
            this.gbxHeader.Controls.Add(this.lblWorkerName_H);
            this.gbxHeader.Controls.Add(this.cboPlantCode);
            this.gbxHeader.Controls.Add(this.lblItemCode);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Location = new System.Drawing.Point(3, 3);
            this.gbxHeader.Size = new System.Drawing.Size(1292, 152);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(3, 155);
            this.gbxBody.Size = new System.Drawing.Size(1292, 620);
            // 
            // lblPlantCode
            // 
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance6;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(23, 22);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(83, 23);
            this.lblPlantCode.TabIndex = 181;
            this.lblPlantCode.Text = "공장";
            // 
            // lblItemCode
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance1;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(300, 25);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(83, 23);
            this.lblItemCode.TabIndex = 184;
            this.lblItemCode.Text = "LOT넘버";
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode.Location = new System.Drawing.Point(112, 21);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(145, 32);
            this.cboPlantCode.TabIndex = 0;
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
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            appearance29.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance29;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance33;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance34;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance35.BackColor2 = System.Drawing.SystemColors.Control;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance35.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance35;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance36;
            appearance43.BackColor = System.Drawing.SystemColors.Highlight;
            appearance43.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance43;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance44.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance44;
            appearance57.BorderColor = System.Drawing.Color.Silver;
            appearance57.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance57;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance58.BackColor = System.Drawing.SystemColors.Control;
            appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance58.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance58.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance58;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance59.BackColor = System.Drawing.SystemColors.Window;
            appearance59.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance59;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance61.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance61;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1280, 608);
            this.grid1.TabIndex = 6;
            this.grid1.TabStop = false;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblWorkerName_H
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.lblWorkerName_H.Appearance = appearance5;
            this.lblWorkerName_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkerName_H.DbField = "cboUseFlag";
            this.lblWorkerName_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkerName_H.Location = new System.Drawing.Point(557, 29);
            this.lblWorkerName_H.Name = "lblWorkerName_H";
            this.lblWorkerName_H.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.lblWorkerName_H.Size = new System.Drawing.Size(117, 23);
            this.lblWorkerName_H.TabIndex = 186;
            this.lblWorkerName_H.Text = "입/출고일자";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.CMBStorageLOC);
            this.ultraGroupBox1.Controls.Add(this.sLabel2);
            this.ultraGroupBox1.Controls.Add(this.CMBWH);
            this.ultraGroupBox1.Controls.Add(this.sLabel3);
            this.ultraGroupBox1.Location = new System.Drawing.Point(21, 86);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1065, 65);
            this.ultraGroupBox1.TabIndex = 190;
            // 
            // CMBStorageLOC
            // 
            this.CMBStorageLOC.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CMBStorageLOC.Location = new System.Drawing.Point(386, 27);
            this.CMBStorageLOC.Name = "CMBStorageLOC";
            this.CMBStorageLOC.Size = new System.Drawing.Size(145, 32);
            this.CMBStorageLOC.TabIndex = 192;
            // 
            // sLabel2
            // 
            appearance85.FontData.BoldAsString = "False";
            appearance85.FontData.UnderlineAsString = "False";
            appearance85.ForeColor = System.Drawing.Color.Black;
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance85;
            this.sLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(277, 27);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(103, 23);
            this.sLabel2.TabIndex = 193;
            this.sLabel2.Text = "출고저장위치";
            // 
            // CMBWH
            // 
            this.CMBWH.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CMBWH.Location = new System.Drawing.Point(91, 20);
            this.CMBWH.Name = "CMBWH";
            this.CMBWH.Size = new System.Drawing.Size(145, 32);
            this.CMBWH.TabIndex = 190;
            // 
            // sLabel3
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance2;
            this.sLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(2, 29);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(83, 23);
            this.sLabel3.TabIndex = 191;
            this.sLabel3.Text = "출고창고";
            // 
            // DTPSTART
            // 
            this.DTPSTART.Location = new System.Drawing.Point(680, 19);
            this.DTPSTART.Name = "DTPSTART";
            this.DTPSTART.Size = new System.Drawing.Size(110, 35);
            this.DTPSTART.TabIndex = 191;
            // 
            // DTPEND
            // 
            this.DTPEND.Location = new System.Drawing.Point(820, 19);
            this.DTPEND.Name = "DTPEND";
            this.DTPEND.Size = new System.Drawing.Size(105, 35);
            this.DTPEND.TabIndex = 192;
            // 
            // sLabel1
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance3;
            this.sLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel1.DbField = "cboUseFlag";
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(783, 29);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(28, 23);
            this.sLabel1.TabIndex = 193;
            this.sLabel1.Text = "~";
            // 
            // CMBITEMCODE
            // 
            this.CMBITEMCODE.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CMBITEMCODE.Location = new System.Drawing.Point(112, 59);
            this.CMBITEMCODE.Name = "CMBITEMCODE";
            this.CMBITEMCODE.Size = new System.Drawing.Size(145, 32);
            this.CMBITEMCODE.TabIndex = 194;
            // 
            // sLabel4
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.sLabel4.Appearance = appearance4;
            this.sLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel4.DbField = null;
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel4.Location = new System.Drawing.Point(23, 60);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(83, 23);
            this.sLabel4.TabIndex = 195;
            this.sLabel4.Text = "품-목";
            // 
            // txtLOTno
            // 
            this.txtLOTno.Location = new System.Drawing.Point(389, 17);
            this.txtLOTno.Name = "txtLOTno";
            this.txtLOTno.Size = new System.Drawing.Size(143, 35);
            this.txtLOTno.TabIndex = 196;
            // 
            // MM_StockOUT
            // 
            this.ClientSize = new System.Drawing.Size(1298, 778);
            this.Name = "MM_StockOUT";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "생산 계획 및 확정";
            this.Load += new System.EventHandler(this.MM_StockOUT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CMBStorageLOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMBWH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTPSTART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTPEND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMBITEMCODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLOTno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DC00_Component.SLabel lblPlantCode;
        private DC00_Component.SLabel lblItemCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private DC00_Component.Grid grid1;
        private DC00_Component.SLabel lblWorkerName_H;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLOTno;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor CMBITEMCODE;
        private DC00_Component.SLabel sLabel4;
        private DC00_Component.SLabel sLabel1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor DTPEND;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor DTPSTART;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor CMBStorageLOC;
        private DC00_Component.SLabel sLabel2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor CMBWH;
        private DC00_Component.SLabel sLabel3;
    }
}
