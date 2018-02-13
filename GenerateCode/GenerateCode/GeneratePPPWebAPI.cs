using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenerateCode.Services;

namespace GenerateCode
{
    public partial class GeneratePPPWebAPI : Form
    {
        public GeneratePPPWebAPI()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            #region 參數宣告
            string controllerName = ControllerName.Text;
            string mainTable = MainTable.Text;
            string subTables = SubTables.Text;
            List<string> subTableList = new List<string>();
            List<string> searchListActionList = new List<string>();
            bool checkGenerateSearchList = GenerateSearchList.Checked;
            bool checkGenerateDetail = GenerateDetail.Checked;
            bool checkGenerateTokenFilter = GenerateTokenFilter.Checked;
            bool checkGenerateDataPermission = GenerateDataPermission.Checked;
            #endregion

            #region 流程
            if (Active_Add.Checked)
            {
                searchListActionList.Add("Add");
            }
            if (Active_Edit.Checked)
            {
                searchListActionList.Add("Edit");
            }
            if (Active_View.Checked)
            {
                searchListActionList.Add("View");
            }
            if (Active_Delete.Checked)
            {
                searchListActionList.Add("Delete");
            }

            if (!String.IsNullOrWhiteSpace(subTables))
            {
                subTableList = subTables.Split(',').ToList();
            }
            GenerateWebCodeService.CreatePathes(controllerName);
            GenerateWebCodeService.GenerateCode(controllerName, checkGenerateSearchList, checkGenerateDetail, searchListActionList);
            GenerateWebAPICodeService.CreatePathes(controllerName);
            GenerateWebAPICodeService.GenerateCode(controllerName, mainTable, subTableList, checkGenerateSearchList, checkGenerateDetail, checkGenerateTokenFilter, checkGenerateDataPermission);
            #endregion
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
