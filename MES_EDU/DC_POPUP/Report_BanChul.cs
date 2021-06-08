using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
//MES는 항상 변한다.
//작업지시가 최종적으로 내려가는 곳을 작업장이라고 부른다.
//생산 계획을 내려 어떤 작업장이 효율을 낼 수 있는지 파악 후 적절한 작업지시를 확정짓는다.
//품목: 원자재(가공 전), 반제품(공정 중), 제품(최종적으로 고객에게 나갈 수 있는 물건), 상품(팔 수 있는 상태)
//품질관리?
//4M MAN MATERIAL(원자재) METHOD MACHINE\
//ROH/HALB/FERT
//UPH : 시간당 해당 품목 생산량
//사이클 타임: 1개 만들어지는데 걸리는 시간
//적정재고: 우리 공장 창고에 이정도까진 있어도 된다- 
//최소한으로 이만큼으로 있어야하는 재고
//유상사급/무상사급이란?

namespace DC_POPUP
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for XWM2200R1.
    /// </summary>
    public partial class Report_BanChul : Telerik.Reporting.Report
    {
        public Report_BanChul()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}
