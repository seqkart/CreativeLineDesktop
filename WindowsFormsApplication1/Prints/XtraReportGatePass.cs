using System.Drawing;

namespace WindowsFormsApplication1.FormReports
{
    public partial class XtraReportGatePass : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportGatePass(
            string _employee_code,
            int _serial_id,
            string _employee_code_desc,
            string _employee_dept,
            string _employee_unit,
            string _employee_contact,
            string _employee_status,
            string _time_out,
            string _time_in,
            Image image)
        {
            InitializeComponent();

            PrintLogWin.PrintLog("employee_code : " + _employee_code);
            PrintLogWin.PrintLog("serial_id : " + _serial_id + string.Empty);

            rptEmpCode.Text = _employee_code;
            rptEmpCodeDesc.Text = _employee_code_desc;
            rptEmpDept.Text = _employee_dept;
            rptEmpUnit.Text = _employee_unit;
            rptEmpContact.Text = _employee_contact;
            rptStatus.Text = _employee_status;
            rptTimeOut.Text = _time_out;
            rptTimeIn.Text = _time_in;
            rptPictureBox.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(image);

        }


    }
}
