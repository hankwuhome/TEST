using GenerateCode.Models;
using GenerateCode.Repositories;
using GenerateCode.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateCode.Services
{
    static class GenerateWebAPICodeService
    {
        #region Enums
        enum EnumFileType {
            SearchInfoInit,
            SearchInfo,
            ViewDetail,
            Detail
        }
        #endregion

        #region Properties
        private static string _appPath = Path.GetDirectoryName(Application.ExecutablePath);

        private static List<string> _pathes = new List<string>()
        {
            "{0}/PPPWebAPI/Controllers",
            "{0}/PPPWebAPI/Controllers/{0}",
            "{0}/PPPWebAPI/Models",
            "{0}/PPPWebAPI/Models/ViewModels",
            "{0}/PPPWebAPI/Models/ViewModels/{0}",
            "{0}/PPPWebAPI/Repositories",
            "{0}/PPPWebAPI/Repositories/Interfaces",
            "{0}/PPPWebAPI/Services",
            "{0}/PPPWebAPI/Services/Interfaces"
        };

        #endregion

        #region Public Methods
        public static void CreatePathes(string controllerName)
        {
            #region 參數宣告
            List<string> newpathes = new List<string>();
            
            #endregion

            #region 流程
            _pathes.ForEach(path => {
                string newpath = Path.Combine(_appPath, string.Format(path, controllerName));
                FileService.CreatePath(newpath);
            });
            #endregion
        }


        public static void GenerateCode(string controllerName, string mainTableName, List<string> subTableNameList
            , bool generateSearchList, bool generateDetail
            , bool generateTokenFilter, bool generateDataPermission)
        {
            #region 參數宣告
            #endregion

            #region 流程

            #region 產生Models
            
            if (!String.IsNullOrWhiteSpace(mainTableName))
            {
                GenerateModel(controllerName, mainTableName);
            }

            if (subTableNameList != null)
            {
                if (subTableNameList.Count() > 0)
                {
                    subTableNameList.ForEach(subTableName => { GenerateModel(controllerName, subTableName); });
                }
            }

            #endregion

            #region 產生ViewModels
            if (generateSearchList)
            {
                GenerateSearchInfoInitViewModel(controllerName);
                GenerateSearchInfoViewModel(controllerName);
                GenerateSearchListViewModel(controllerName);
            }

            if (generateDetail)
            {
                GenerateDetailRequestViewModel(controllerName);
                GenerateViewDetailViewModel(controllerName, generateDataPermission);
            }
            #endregion

            #region 產生Repositories
            if (!String.IsNullOrWhiteSpace(mainTableName))
            {
                GenerateRepositoryInterface(controllerName, mainTableName, generateSearchList, generateDetail);
                GenerateRepository(controllerName, mainTableName, generateSearchList, generateDetail);
                GenerateRepositorySql(controllerName, mainTableName, generateSearchList, generateDetail);
            }

            if (subTableNameList != null)
            {
                if (subTableNameList.Count() > 0)
                {
                    subTableNameList.ForEach(subTableName => 
                    {
                        GenerateRepositoryInterface(controllerName, subTableName, false, false);
                        GenerateRepository(controllerName, subTableName, false, false);
                        GenerateRepositorySql(controllerName, subTableName, false, false);
                    });
                }
            }
            #endregion

            #region 產生Services
            GenerateServiceInterface(controllerName, generateSearchList, generateDetail);
            GenerateService(controllerName, mainTableName, generateSearchList, generateDetail);
            #endregion

            #region 產生Controllers
            GenerateController(controllerName);
            if (generateSearchList)
            {
                GenerateController(controllerName);
                GenerateSearchInfoInitController(controllerName, generateTokenFilter, generateDataPermission);
                GenerateSearchListController(controllerName, generateTokenFilter, generateDataPermission);
            }

            if (generateDetail)
            {
                GenerateViewDetailController(controllerName, generateTokenFilter, generateDataPermission);
                GenerateDetailController(controllerName, generateTokenFilter, generateDataPermission);
            }
            #endregion

            #endregion

        }
        #endregion

        #region Private Methods

        #region GenerateModel
        /// <summary>
        /// 產生Model
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="tableName"></param>
        private static void GenerateModel(string controllerName, string tableName)
        {
            #region 參數宣告
            TableSchemaRepository tableSchemaRp = new TableSchemaRepository();
            List<TableFieldViewModel> tableFieldList = new List<TableFieldViewModel>();
            string path = string.Concat(_appPath, "/", string.Format(_pathes[2], controllerName),"/");
            string filename = string.Concat(tableName, "Model.cs");
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            tableFieldList = tableSchemaRp.QueryTableFields(tableName);
            content.AppendLine("using System;                                            ");
            content.AppendLine("using System.Collections.Generic;						 ");
            content.AppendLine("using System.Linq;										 ");
            content.AppendLine("using System.Web;										 ");
            content.AppendLine("														 ");
            content.AppendLine("namespace PPPWEBAPI.Models								 ");
            content.AppendLine("{														 ");
            content.AppendLine("    /// <summary>										 ");
            content.AppendLine("    /// 									   ");
            content.AppendLine("    /// </summary>										 ");
            content.AppendLine(string.Format("    public class {0}Model : _BaseModel	 ", tableName));
            content.AppendLine("    {													 ");
            content.AppendLine("        #region Properties                                ");
            tableFieldList.ForEach(tableField => content.AppendLine(tableField.GetPropertyStr()));
            //content.AppendLine("        public PageViewModel Page = new PageViewModel();  ");
            content.AppendLine("        #endregion										  ");
            content.AppendLine("    }													 ");
            content.AppendLine("}														 ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #region GenerateViewModel

        /// <summary>
        /// Generate SearchInfoInit ViewModel
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateSearchInfoInitViewModel(string controllerName)
        {
            #region  參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[4], controllerName), "/");
            string filename = "SearchInfoInitViewModel.cs";
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;                                            ");
            content.AppendLine("using System.Collections.Generic;						 ");
            content.AppendLine("using System.ComponentModel;							 ");
            content.AppendLine("using System.Linq;										 ");
            content.AppendLine("using System.Web;										 ");
            content.AppendLine("using PPPWEBAPI.Extensions;								 ");
            content.AppendLine("														 ");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Models.ViewModels.{0} ", controllerName));
            content.AppendLine("{														 ");
            content.AppendLine("    /// <summary>										 ");
            content.AppendLine("    /// 									   ");
            content.AppendLine("    /// </summary>										 ");
            content.AppendLine("    public class SearchInfoInitViewModel				 ");
            content.AppendLine("    {													 ");
            content.AppendLine("        #region Enums									 ");
            content.AppendLine("														 ");
            content.AppendLine("        #endregion										 ");
            content.AppendLine("														 ");
            content.AppendLine("        #region Properties								 ");
            content.AppendLine("														 ");
            content.AppendLine("        #endregion										 ");
            content.AppendLine("														 ");
            content.AppendLine("        #region Public Methods							 ");
            content.AppendLine("														 ");
            content.AppendLine("        #endregion										 ");
            content.AppendLine("    }													 ");
            content.AppendLine("}														 ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion 
        }

        /// <summary>
        /// Generate SearchInfo ViewModel
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateSearchInfoViewModel(string controllerName)
        {
            #region  參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[4], controllerName), "/");
            string filename = "SearchInfoViewModel.cs";
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;                                            ");
            content.AppendLine("using System.Collections.Generic;						 ");
            content.AppendLine("using System.ComponentModel;							 ");
            content.AppendLine("using System.Linq;										 ");
            content.AppendLine("using System.Web;										 ");
            content.AppendLine("using PPPWEBAPI.Extensions;								 ");
            content.AppendLine("														 ");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Models.ViewModels.{0} ", controllerName));
            content.AppendLine("{														 ");
            content.AppendLine("    /// <summary>										 ");
            content.AppendLine("    /// 									   ");
            content.AppendLine("    /// </summary>										 ");
            content.AppendLine("    public class SearchInfoViewModel:_BaseSearchInfoViewModel				 ");
            content.AppendLine("    {													 ");
            content.AppendLine("        #region Enums									 ");
            content.AppendLine("        //要先定義SQL Sort排序欄位");
            content.AppendLine("        public enum EnumSort                                  ");
            content.AppendLine("        {													  ");
            content.AppendLine("            [Description(\"ORDER BY \")] ");
            content.AppendLine("            DEFAULT,										  ");
            content.AppendLine("        }													  ");
            content.AppendLine("        #endregion										 ");
            content.AppendLine("														 ");
            content.AppendLine("        #region Properties								 ");
            content.AppendLine("														 ");
            content.AppendLine("        #endregion										 ");
            content.AppendLine("														 ");
            content.AppendLine("        #region Public Methods							 ");
            content.AppendLine("														 ");
            content.AppendLine("        #endregion										 ");
            content.AppendLine("    }													 ");
            content.AppendLine("}														 ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion 
        }

        /// <summary>
        /// Generate SearchList ViewModel
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateSearchListViewModel(string controllerName)
        {
            #region  參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[4], controllerName), "/");
            string filename = "SearchListViewModel.cs";
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;                                            ");
            content.AppendLine("using System.Collections.Generic;						 ");
            content.AppendLine("using System.ComponentModel;							 ");
            content.AppendLine("using System.Linq;										 ");
            content.AppendLine("using System.Web;										 ");
            content.AppendLine("using PPPWEBAPI.Extensions;								 ");
            content.AppendLine("														 ");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Models.ViewModels.{0} ", controllerName));
            content.AppendLine("{														 ");
            content.AppendLine("	/// <summary>                                                    ");
            content.AppendLine("    /// 查詢結果													 ");
            content.AppendLine("    /// </summary>													 ");
            content.AppendLine("    public class SearchListViewModel : _BaseSearchListViewModel		 ");
            content.AppendLine("    {																 ");
            content.AppendLine("        #region Properties											 ");
            content.AppendLine("        /// <summary>												 ");
            content.AppendLine("        /// 查詢結果清單											   ");
            content.AppendLine("        /// </summary>												 ");
            content.AppendLine("        public List<SearchItemViewModel> SearchItemList { get; set; }");
            content.AppendLine("																	 ");
            content.AppendLine("        #endregion													 ");
            content.AppendLine("    }																 ");
            content.AppendLine("																	 ");
            content.AppendLine("    /// <summary>													 ");
            content.AppendLine("    /// 查詢結果細項												   ");
            content.AppendLine("    /// </summary>													 ");
            content.AppendLine("    public class SearchItemViewModel : _BaseViewModel				 ");
            content.AppendLine("    {																 ");
            content.AppendLine("        #region Properties											 ");
            content.AppendLine("																	 ");
            content.AppendLine("        #endregion													 ");
            content.AppendLine("    }																 ");
            content.AppendLine("}														 ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion 
        }

        /// <summary>
        /// Generate DetailRequest ViewModel
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateDetailRequestViewModel(string controllerName)
        {
            #region  參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[4], controllerName), "/");
            string filename = "DetailRequestViewModel.cs";
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;                                            ");
            content.AppendLine("using System.Collections.Generic;						 ");
            content.AppendLine("using System.ComponentModel;							 ");
            content.AppendLine("using System.Linq;										 ");
            content.AppendLine("using System.Web;										 ");
            content.AppendLine("using PPPWEBAPI.Extensions;								 ");
            content.AppendLine("														 ");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Models.ViewModels.{0} ", controllerName));
            content.AppendLine("{														 ");
            content.AppendLine("	/// <summary>                                                    ");
            content.AppendLine("    /// 查詢結果													 ");
            content.AppendLine("    /// </summary>													 ");
            content.AppendLine("    public class DetailRequestViewModel : _BaseDetailRequestViewModel		 ");
            content.AppendLine("    {																 ");
            content.AppendLine("        #region Enums									 ");
            content.AppendLine("        //要先定義SQL Sort排序欄位");
            content.AppendLine("        public enum EnumSort                                  ");
            content.AppendLine("        {													  ");
            content.AppendLine("            [Description(\"ORDER BY \")] ");
            content.AppendLine("            DEFAULT,										  ");
            content.AppendLine("        }													  ");
            content.AppendLine("        #endregion										 ");
            content.AppendLine("																	 ");
            content.AppendLine("        #region Properties											 ");
            content.AppendLine("        #endregion													 ");
            content.AppendLine("    }																 ");
             content.AppendLine("}														 ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion 
        }

        /// <summary>
        /// Generate ViewDetail ViewModel
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateViewDetailViewModel(string controllerName, bool generateDataPermission)
        {
            #region  參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[4], controllerName), "/");
            string filename = "ViewDetailViewModel.cs";
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;                                            ");
            content.AppendLine("using System.Collections.Generic;						 ");
            content.AppendLine("using System.ComponentModel;							 ");
            content.AppendLine("using System.Linq;										 ");
            content.AppendLine("using System.Web;										 ");
            content.AppendLine("using PPPWEBAPI.Extensions;								 ");
            content.AppendLine("														 ");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Models.ViewModels.{0} ", controllerName));
            content.AppendLine("{														 ");
            content.AppendLine("	/// <summary>                                                    ");
            content.AppendLine("    /// 檢視明細資料													 ");
            content.AppendLine("    /// </summary>													 ");
            content.AppendLine("    public class ViewDetailViewModel		 ");
            content.AppendLine("    {																 ");
            content.AppendLine("        #region Properties											 ");
            content.AppendLine("        /// <summary>												 ");
            content.AppendLine("        /// 明細資料											   ");
            content.AppendLine("        /// </summary>												 ");
            content.AppendLine("        public DetailViewModel Detail { get; set; }");
            content.AppendLine("        /// <summary>												 ");
            content.AppendLine("        /// 明細下拉選單											   ");
            content.AppendLine("        /// </summary>												 ");
            content.AppendLine("        public DetailOptionViewModel DetailOption { get; set; }");
            content.AppendLine("        #endregion													 ");
            content.AppendLine("    }																 ");
            content.AppendLine("														 ");
            content.AppendLine("	/// <summary>                                                    ");
            content.AppendLine("    /// 明細資料													 ");
            content.AppendLine("    /// </summary>													 ");
            if (generateDataPermission)
            {
                content.AppendLine("    public class DetailViewModel : _BaseViewModel		 ");
            }
            else
            {
                content.AppendLine("    public class DetailViewModel		 ");
            }
            content.AppendLine("    {																 ");
            content.AppendLine("        #region Properties											 ");
            content.AppendLine("        public string ActiveType { get; set; }													 ");
            content.AppendLine("        #endregion													 ");
            content.AppendLine("    }																 ");
            content.AppendLine("														 ");
            content.AppendLine("	/// <summary>                                                    ");
            content.AppendLine("    /// 明細下拉選單													 ");
            content.AppendLine("    /// </summary>													 ");
            content.AppendLine("    public class DetailOptionViewModel		 ");
            content.AppendLine("    {																 ");
            content.AppendLine("        #region Properties											 ");
            content.AppendLine("        #endregion													 ");
            content.AppendLine("    }																 ");
            content.AppendLine("}														 ");

            FileService.CreateFile(path, filename, content.ToString());
            #endregion 
        }

        #endregion

        #region GenerateRepositoryInterface
        /// <summary>
        /// Generate Repository Interface
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="tableName"></param>
        /// <param name="generateSearchList"></param>
        /// <param name="generateDetail"></param>
        private static void GenerateRepositoryInterface(string controllerName, string tableName, bool generateSearchList, bool generateDetail)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[6], controllerName), "/");
            string filename = string.Format("I{0}Repository.cs",tableName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;																						");
            content.AppendLine("using System.Collections.Generic;																	");
            content.AppendLine("using System.Linq;																					");
            content.AppendLine("using System.Text;																					");
            content.AppendLine("using System.Threading.Tasks;																		");
            content.AppendLine("using PPPWEBAPI.Models;																				");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};												", controllerName));
            content.AppendLine("namespace PPPWEBAPI.Repositories.Interfaces															");
            content.AppendLine("{																									");
            content.AppendLine(string.Format("    interface I{0}Repository : _IBaseRepository<{0}Model>						", tableName));
            content.AppendLine("    {																								");
            if (generateSearchList) content.AppendLine("        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); ");
            if (generateDetail) content.AppendLine("        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	");
            content.AppendLine(string.Format("        bool Add{0}({0}Model model);							", tableName));
            content.AppendLine(string.Format("        bool Update{0}({0}Model model);							", tableName));
            content.AppendLine(string.Format("        bool Delete{0}({0}Model model);							", tableName));
            content.AppendLine("    }																								");
            content.AppendLine("}																									");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #region GenerateRepository
        /// <summary>
        /// Generate Repository
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="tableName"></param>
        /// <param name="generateSearchList"></param>
        /// <param name="generateDetail"></param>
        private static void GenerateRepository(string controllerName, string tableName, bool generateSearchList, bool generateDetail)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[5], controllerName), "/");
            string filename = string.Format("{0}Repository.cs", tableName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;																												");
            content.AppendLine("using System.Collections.Generic;																						   ");
            content.AppendLine("using Dapper;																											   ");
            content.AppendLine("using System.Linq;																										   ");
            content.AppendLine("using System.Web;																										   ");
            content.AppendLine("using PPPWEBAPI.Models;																									   ");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};																					   ", controllerName));
            content.AppendLine("using PPPWEBAPI.Repositories.Interfaces;																				   ");
            content.AppendLine("using System.Data.SqlClient;																							   ");
            content.AppendLine("																														   ");
            content.AppendLine("namespace PPPWEBAPI.Repositories																						   ");
            content.AppendLine("{																														   ");
            content.AppendLine(string.Format("    public partial class {0}Repository : _BaseRepository<{0}Model>, I{0}Repository										   ", tableName));
            content.AppendLine("    {																													   ");
            content.AppendLine("        #region Public Methods																							   ");
            if (generateSearchList)
            {
                content.AppendLine("        public SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo)										   ");
                content.AppendLine("        {																												   ");
                content.AppendLine("            #region 參數宣告																							   ");
                content.AppendLine("            SearchListViewModel result = new SearchListViewModel();														   ");
                content.AppendLine("            #endregion																									   ");
                content.AppendLine("																														   ");
                content.AppendLine("            #region 流程																									 ");
                content.AppendLine("            var sql = QuerySearchListSql(searchInfo);																	   ");
                content.AppendLine("            result.Page = searchInfo.Page;																				   ");
                content.AppendLine("            result.SearchItemList = new List<SearchItemViewModel>();													   ");
                content.AppendLine("            using (var cn = new SqlConnection(_dbConnPPP))																   ");
                content.AppendLine("            {																											   ");
                content.AppendLine("                result.SearchItemList = cn.Query<SearchItemViewModel>(GetPagingSql(searchInfo.Page), _sqlParams).ToList(); ");
                content.AppendLine("                result.Page.TotalCount = cn.Query<int>(GetTotalCountSql(), _sqlParams).ToList().FirstOrDefault();		   ");
                content.AppendLine("            }																											   ");
                content.AppendLine("																														   ");
                content.AppendLine("            return result;																								   ");
                content.AppendLine("            #endregion																									   ");
                content.AppendLine("        }																												   ");
                content.AppendLine("																														   ");
            }

            if (generateDetail)
            {
                content.AppendLine("        public DetailViewModel QueryDetail(DetailRequestViewModel detailRequest)										   ");
                content.AppendLine("        {																												   ");
                content.AppendLine("            #region 參數宣告																							   ");
                content.AppendLine("            DetailViewModel result = new DetailViewModel();																   ");
                content.AppendLine("            #endregion																									   ");
                content.AppendLine("																														   ");
                content.AppendLine("            #region 流程																									 ");
                content.AppendLine("            QueryDetailSql(detailRequest);																				   ");
                content.AppendLine("																														   ");
                content.AppendLine("            using (var cn = new SqlConnection(_dbConnPPP))																   ");
                content.AppendLine("            {																											   ");
                content.AppendLine("                result= cn.Query<DetailViewModel>(_sqlStr.ToString(), _sqlParams).ToList().FirstOrDefault();			   ");
                content.AppendLine("            }																											   ");
                content.AppendLine("																														   ");
                content.AppendLine("            return result;																								   ");
                content.AppendLine("            #endregion																									   ");
                content.AppendLine("        }																												   ");
                content.AppendLine("																														   ");
            }

            content.AppendLine(string.Format("        public bool Add{0}({0}Model model)																				   ", tableName));
            content.AppendLine("        {																												   ");
            content.AppendLine("            #region 參數宣告																							   ");
            content.AppendLine("            var result = false;																							   ");
            content.AppendLine("            #endregion																									   ");
            content.AppendLine("																														   ");
            content.AppendLine("            #region 流程																									 ");
            content.AppendLine(string.Format("            Add{0}Sql(model);																							   ", tableName));
            content.AppendLine("            try																											   ");
            content.AppendLine("            {																											   ");
            content.AppendLine("                using (var cn = new SqlConnection(_dbConnPPP))															   ");
            content.AppendLine("                {																										   ");
            content.AppendLine("                    cn.Open();																							   ");
            content.AppendLine("                    var ExecResult = cn.Execute(_sqlStr.ToString(), _sqlParams);										   ");
            content.AppendLine("                }																										   ");
            content.AppendLine("                result = true;																							   ");
            content.AppendLine("            }																											   ");
            content.AppendLine("            catch (Exception ex)																						   ");
            content.AppendLine("            {																											   ");
            content.AppendLine("                throw ex;																								   ");
            content.AppendLine("            }																											   ");
            content.AppendLine("																														   ");
            content.AppendLine("            return result;																								   ");
            content.AppendLine("            #endregion																									   ");
            content.AppendLine("        }																												   ");
            content.AppendLine("																														   ");
            content.AppendLine(string.Format("        public bool Update{0}({0}Model model)																			   ", tableName));
            content.AppendLine("        {																												   ");
            content.AppendLine("            #region 參數宣告																							   ");
            content.AppendLine("            var result = false;																							   ");
            content.AppendLine("            #endregion																									   ");
            content.AppendLine("																														   ");
            content.AppendLine("            #region 流程																									 ");
            content.AppendLine(string.Format("            Update{0}Sql(model);																						   ", tableName));
            content.AppendLine("            try																											   ");
            content.AppendLine("            {																											   ");
            content.AppendLine("                using (var cn = new SqlConnection(_dbConnPPP))															   ");
            content.AppendLine("                {																										   ");
            content.AppendLine("                    cn.Open();																							   ");
            content.AppendLine("                    var ExecResult = cn.Execute(_sqlStr.ToString(), _sqlParams);										   ");
            content.AppendLine("                }																										   ");
            content.AppendLine("                result = true;																							   ");
            content.AppendLine("            }																											   ");
            content.AppendLine("            catch (Exception ex)																						   ");
            content.AppendLine("            {																											   ");
            content.AppendLine("                throw ex;																								   ");
            content.AppendLine("            }																											   ");
            content.AppendLine("																														   ");
            content.AppendLine("            return result;																								   ");
            content.AppendLine("            #endregion																									   ");
            content.AppendLine("        }																												   ");
            content.AppendLine("																														   ");
            content.AppendLine(string.Format("        public bool Delete{0}({0}Model model)																			   ", tableName));
            content.AppendLine("        {																												   ");
            content.AppendLine("            #region 參數宣告																							   ");
            content.AppendLine("            var result = false;																							   ");
            content.AppendLine("            #endregion																									   ");
            content.AppendLine("																														   ");
            content.AppendLine("            #region 流程																									 ");
            content.AppendLine(string.Format("            Delete{0}Sql(model);																						   ", tableName));
            content.AppendLine("            try																											   ");
            content.AppendLine("            {																											   ");
            content.AppendLine("                using (var cn = new SqlConnection(_dbConnPPP))															   ");
            content.AppendLine("                {																										   ");
            content.AppendLine("                    cn.Open();																							   ");
            content.AppendLine("                    var ExecResult = cn.Execute(_sqlStr.ToString(), _sqlParams);										   ");
            content.AppendLine("                }																										   ");
            content.AppendLine("                result = true;																							   ");
            content.AppendLine("            }																											   ");
            content.AppendLine("            catch (Exception ex)																						   ");
            content.AppendLine("            {																											   ");
            content.AppendLine("                throw ex;																								   ");
            content.AppendLine("            }																											   ");
            content.AppendLine("																														   ");
            content.AppendLine("            return result;																								   ");
            content.AppendLine("            #endregion																									   ");
            content.AppendLine("        }																												   ");
            content.AppendLine("        #endregion																										   ");
            content.AppendLine("																														   ");
            content.AppendLine("    }																													   ");
            content.AppendLine("}																														   ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        /// <summary>
        /// Generate Repository.Sql
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="tableName"></param>
        /// <param name="generateSearchList"></param>
        /// <param name="generateDetail"></param>
        private static void GenerateRepositorySql(string controllerName, string tableName, bool generateSearchList, bool generateDetail)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[5], controllerName), "/");
            string filename = string.Format("{0}Repository.sql.cs", tableName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;																								");
            content.AppendLine("using System.Collections.Generic;																		  ");
            content.AppendLine("using System.Linq;																						  ");
            content.AppendLine("using System.Text;																						  ");
            content.AppendLine("using System.Web;																						  ");
            content.AppendLine("using Dapper;																							  ");
            content.AppendLine("using PPPWEBAPI.Extensions;																				  ");
            content.AppendLine("using PPPWEBAPI.Models;																					  ");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};																	  ", controllerName));
            content.AppendLine("using PPPWEBAPI.Repositories.Interfaces;																  ");
            content.AppendLine("																										  ");
            content.AppendLine("namespace PPPWEBAPI.Repositories																		  ");
            content.AppendLine("{																										  ");
            content.AppendLine(string.Format("    public partial class {0}Repository : _BaseRepository<{0}Model>, I{0}Repository						  ", tableName));
            content.AppendLine("    {																									  ");
            content.AppendLine("        #region Private Methods																			  ");
            if (generateSearchList)
            {
                content.AppendLine("        private bool QuerySearchListSql(SearchInfoViewModel searchInfo)									  ");
                content.AppendLine("        {																								  ");
                content.AppendLine("            // 設定主SQL, _sqlStr 中不可以包含 ORDER BY													 ");
                content.AppendLine("            _sqlStr = new StringBuilder();																  ");
                content.AppendLine("            //_sqlStr.Append(\" 主要SQL語法 \");															  ");
                content.AppendLine("																										  ");
                content.AppendLine("            //設定排序SQL																				  ");
                content.AppendLine("            _sqlOrderByStr = searchInfo.GetOrderByFromSort(SearchInfoViewModel.EnumSort.DEFAULT);		  ");
                content.AppendLine("																										  ");
                content.AppendLine("            //設定參數 																					  ");
                content.AppendLine("            _sqlParams = new Dapper.DynamicParameters();												  ");
                content.AppendLine("            //_sqlParams.Add(\"參數\", searchInfo.參數);													  ");
                content.AppendLine("																										  ");
                content.AppendLine("            return true;																				  ");
                content.AppendLine("        }																								  ");
                content.AppendLine("																										  ");
            }
            if (generateDetail)
            {
                content.AppendLine("        private bool QueryDetailSql(DetailRequestViewModel detailRequest)								  ");
                content.AppendLine("        {																								  ");
                content.AppendLine("            // 設定主SQL, _sqlStr 中不可以包含 ORDER BY													 ");
                content.AppendLine("            _sqlStr = new StringBuilder();																  ");
                content.AppendLine("            //_sqlStr.Append(\"主要SQL語法 \");															  ");
                content.AppendLine("																										  ");
                content.AppendLine("            //設定排序SQL																				  ");
                content.AppendLine("            //_sqlOrderByStr = detailRequest.GetOrderByFromSort(DetailRequestViewModel.EnumSort.DEFAULT); ");
                content.AppendLine("																										  ");
                content.AppendLine("            //設定參數 																					  ");
                content.AppendLine("            _sqlParams = new Dapper.DynamicParameters();												  ");
                content.AppendLine("            //_sqlParams.Add(\"參數\", detailRequest.參數);												  ");
                content.AppendLine("            return true;																				  ");
                content.AppendLine("        }																								  ");
                content.AppendLine("																										  ");
            }
            content.AppendLine(string.Format("        private bool Add{0}Sql({0}Model model)															  ", tableName));
            content.AppendLine("        {																								  ");
            content.AppendLine("            // 設定主SQL, _sqlStr 中不可以包含 ORDER BY													 ");
            content.AppendLine("            _sqlStr = new StringBuilder();																  ");
            content.AppendLine("            //_sqlStr.Append(\"主要SQL語法 \");															  ");
            content.AppendLine("																										  ");
            content.AppendLine("            //設定參數 																					  ");
            content.AppendLine("            _sqlParams = new Dapper.DynamicParameters();												  ");
            content.AppendLine("            //_sqlParams.Add(\"參數\", model.參數);														  ");
            content.AppendLine("            return true;																				  ");
            content.AppendLine("        }																								  ");
            content.AppendLine("																										  ");
            content.AppendLine(string.Format("        private bool Update{0}Sql({0}Model model)														  ", tableName));
            content.AppendLine("        {																								  ");
            content.AppendLine("            // 設定主SQL												 ");
            content.AppendLine("            _sqlStr = new StringBuilder();																  ");
            content.AppendLine("            //_sqlStr.Append(\"主要SQL語法 \");															  ");
            content.AppendLine("																										  ");
            content.AppendLine("            //設定參數 																					  ");
            content.AppendLine("            _sqlParams = new Dapper.DynamicParameters();												  ");
            content.AppendLine("            //_sqlParams.Add(\"參數\", model.參數);														  ");
            content.AppendLine("            return true;																				  ");
            content.AppendLine("        }																								  ");
            content.AppendLine("																										  ");
            content.AppendLine(string.Format("        private bool Delete{0}Sql({0}Model model)														  ", tableName));
            content.AppendLine("        {																								  ");
            content.AppendLine("            // 設定主SQL												 ");
            content.AppendLine("            _sqlStr = new StringBuilder();																  ");
            content.AppendLine("            //_sqlStr.Append(\"主要SQL語法 \");															  ");
            content.AppendLine("																										  ");
            content.AppendLine("            //設定參數 																					  ");
            content.AppendLine("            _sqlParams = new Dapper.DynamicParameters();												  ");
            content.AppendLine("            //_sqlParams.Add(\"參數\", model.參數);														  ");
            content.AppendLine("            return true;																				  ");
            content.AppendLine("        }																								  ");
            content.AppendLine("																										  ");
            content.AppendLine("        #endregion																						  ");
            content.AppendLine("																										  ");
            content.AppendLine("    }																									  ");
            content.AppendLine("}																										  ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #region GenerateServiceInterface
        /// <summary>
        /// Generate Service Interface
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="generateSearchList"></param>
        /// <param name="generateDetail"></param>
        public static void GenerateServiceInterface(string controllerName, bool generateSearchList, bool generateDetail)
        {
            #region 參數宣告
            string path = string.Concat(_appPath, "/", string.Format(_pathes[8], controllerName), "/");
            string filename = string.Format("I{0}Service.cs", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;																						");
            content.AppendLine("using System.Collections.Generic;																	");
            content.AppendLine("using System.Linq;																					");
            content.AppendLine("using System.Text;																					");
            content.AppendLine("using System.Threading.Tasks;																		");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};												", controllerName));
            content.AppendLine("namespace PPPWEBAPI.Services.Interfaces															");
            content.AppendLine("{																									");
            content.AppendLine(string.Format("    interface I{0}Service 						", controllerName));
            content.AppendLine("    {																								");
            if (generateSearchList)
            {
                content.AppendLine("        SearchInfoInitViewModel QuerySearchInfoInit(); ");
                content.AppendLine("        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); ");
            }
            if (generateDetail)
            {
                content.AppendLine("        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	");
                content.AppendLine("        DetailOptionViewModel QueryDetailOption(); ");
                content.AppendLine("        bool AddDetail(DetailViewModel detail);	");
                content.AppendLine("        bool EditDetail(DetailViewModel detail);	");
                content.AppendLine("        bool DeleteDetail(DetailViewModel detail);	");
            } 
            content.AppendLine("    }																								");
            content.AppendLine("}																									");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        #endregion

        #region GenerateService
        /// <summary>
        /// Generate Service
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="mainTableName"></param>
        /// <param name="generateSearchList"></param>
        /// <param name="generateDetail"></param>
        public static void GenerateService(string controllerName, string mainTableName, bool generateSearchList, bool generateDetail)
        {
            #region 參數宣告
            string paramMainTableName = string.Concat(mainTableName.Substring(0, 1).ToLower(), mainTableName.Substring(1, mainTableName.Length - 1));
            string path = string.Concat(_appPath, "/", string.Format(_pathes[7], controllerName), "/");
            string filename = string.Format("{0}Service.cs", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;																			");
            content.AppendLine("using System.Collections.Generic;													  ");
            content.AppendLine("using System.Linq;																	  ");
            content.AppendLine("using System.Web;																	  ");
            content.AppendLine("using PPPWEBAPI.Extensions;															  ");
            content.AppendLine("using PPPWEBAPI.Models;																  ");
            content.AppendLine("using PPPWEBAPI.Models.ViewModels;													  ");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};												  ", controllerName));
            content.AppendLine("using PPPWEBAPI.Services.Interfaces;												  ");
            content.AppendLine("using PPPWEBAPI.Repositories;														  ");
            content.AppendLine("using PPPWEBAPI.Repositories.Interfaces;											  ");
            content.AppendLine("using PPPWEBAPI.Utilities;															  ");
            content.AppendLine("																					  ");
            content.AppendLine("namespace PPPWEBAPI.Services														  ");
            content.AppendLine("{																					  ");
            content.AppendLine(string.Format("    public class {0}Service : I{0}Service											  ", controllerName));
            content.AppendLine("    {																				  ");
            content.AppendLine("        /// <summary>																  ");
            content.AppendLine("        /// 初始化搜尋列表(下拉選單)												   ");
            content.AppendLine("        /// </summary>																  ");
            content.AppendLine("        /// <returns></returns>														  ");
            content.AppendLine("        public SearchInfoInitViewModel QuerySearchInfoInit()						  ");
            content.AppendLine("        {																			  ");
            content.AppendLine("            #region 參數宣告														  ");
            content.AppendLine("            SearchInfoInitViewModel searchInfoInit = new SearchInfoInitViewModel();	  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 流程																");
            content.AppendLine("																					  ");
            content.AppendLine("            return searchInfoInit;													  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("        }																			  ");
            content.AppendLine("																					  ");
            content.AppendLine("        /// <summary>																  ");
            content.AppendLine("        /// 查詢列表															  ");
            content.AppendLine("        /// </summary>																  ");
            content.AppendLine("        /// <param name=\"searchInfo\"></param>										  ");
            content.AppendLine("        /// <returns></returns>														  ");
            content.AppendLine("        public SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo)	  ");
            content.AppendLine("        {																			  ");
            content.AppendLine("            #region 參數宣告														  ");
            content.AppendLine("																					  ");
            content.AppendLine("            SearchListViewModel searchList = new SearchListViewModel();				  ");
            content.AppendLine(string.Format("            I{0}Repository {1}Rp = new {0}Repository();								  ", mainTableName,paramMainTableName));
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 流程																");
            content.AppendLine(string.Format("            searchList = {0}Rp.QuerySearchList(searchInfo);							  ", paramMainTableName));
            content.AppendLine("																					  ");
            content.AppendLine("            return searchList;														  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("        }																			  ");
            content.AppendLine("																					  ");
            content.AppendLine("        /// <summary>																  ");
            content.AppendLine("        /// 查詢明細															  ");
            content.AppendLine("        /// </summary>																  ");
            content.AppendLine("        /// <param name=\"detailRequest\"></param>									  ");
            content.AppendLine("        /// <returns></returns>														  ");
            content.AppendLine("        public DetailViewModel QueryDetail(DetailRequestViewModel detailRequest)	  ");
            content.AppendLine("        {																			  ");
            content.AppendLine("            #region 參數宣告														  ");
            content.AppendLine("            DetailViewModel detail = new DetailViewModel();							  ");
            content.AppendLine(string.Format("            I{0}Repository {1}Rp = new {0}Repository();								  ", mainTableName,paramMainTableName));
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 流程																");
            content.AppendLine(string.Format("            detail = {0}Rp.QueryDetail(detailRequest);								  ", paramMainTableName));
            content.AppendLine("            																		  ");
            content.AppendLine("            return detail;															  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("        }																			  ");
            content.AppendLine("																					  ");
            content.AppendLine("		/// <summary>																  ");
            content.AppendLine("        /// 初始化明細(下拉選單)														 ");
            content.AppendLine("        /// </summary>																  ");
            content.AppendLine("        /// <returns></returns>														  ");
            content.AppendLine("        public DetailOptionViewModel QueryDetailOption()							  ");
            content.AppendLine("        {																			  ");
            content.AppendLine("            #region 參數宣告														  ");
            content.AppendLine("            DetailOptionViewModel detailOption = new DetailOptionViewModel();		  ");
            content.AppendLine("            																		  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 流程																");
            content.AppendLine("																					  ");
            content.AppendLine("            return detailOption;													  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("        }																			  ");
            content.AppendLine("																					  ");
            content.AppendLine("        /// <summary>																  ");
            content.AppendLine("        /// 新增明細															  ");
            content.AppendLine("        /// </summary>																  ");
            content.AppendLine("        /// <param name=\"detail\"></param>											  ");
            content.AppendLine("        /// <returns></returns>														  ");
            content.AppendLine("        public bool AddDetail(DetailViewModel detail)								  ");
            content.AppendLine("        {																			  ");
            content.AppendLine("            #region 參數宣告														  ");
            content.AppendLine("            bool result = false;													  ");
            content.AppendLine(string.Format("			{0}Model {1} = new {0}Model(); 											  ",mainTableName,paramMainTableName));
            content.AppendLine(string.Format("            I{0}Repository {1}Rp = new {0}Repository();								  ", mainTableName,paramMainTableName));
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 流程																");
            content.AppendLine(string.Format("			{0} =  PropertyCopy.Convert<DetailViewModel, {1}Model>(detail);  ", paramMainTableName, mainTableName));
            content.AppendLine(string.Format("			result = {0}Rp.Add{1}({0});												  ", paramMainTableName, mainTableName));
            content.AppendLine("																					  ");
            content.AppendLine("            return result;															  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("        }																			  ");
            content.AppendLine("																					  ");
            content.AppendLine("        /// <summary>																  ");
            content.AppendLine("        /// 修改明細															  ");
            content.AppendLine("        /// </summary>																  ");
            content.AppendLine("        /// <param name=\"detail\"></param>											  ");
            content.AppendLine("        /// <returns></returns>														  ");
            content.AppendLine("        public bool EditDetail(DetailViewModel detail)								  ");
            content.AppendLine("        {																			  ");
            content.AppendLine("            #region 參數宣告														  ");
            content.AppendLine("            bool result = false;													  ");
            content.AppendLine(string.Format("			{0}Model {1} = new {0}Model(); 											  ", mainTableName, paramMainTableName));
            content.AppendLine(string.Format("            I{0}Repository {1}Rp = new {0}Repository();								  ", mainTableName, paramMainTableName));
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 流程																");
            content.AppendLine(string.Format("			{0} =  PropertyCopy.Convert<DetailViewModel, {1}Model>(detail);  ",  paramMainTableName,mainTableName));
            content.AppendLine(string.Format("			result = {0}Rp.Update{1}({0});											  ", paramMainTableName, mainTableName));
            content.AppendLine("																					  ");
            content.AppendLine("            return result;															  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("        }																			  ");
            content.AppendLine("																					  ");
            content.AppendLine("        /// <summary>																  ");
            content.AppendLine("        ///刪除明細															  ");
            content.AppendLine("        /// </summary>																  ");
            content.AppendLine("        /// <param name=\"detail\"></param>											  ");
            content.AppendLine("        /// <returns></returns>														  ");
            content.AppendLine("        public bool DeleteDetail(DetailViewModel detail)							  ");
            content.AppendLine("        {																			  ");
            content.AppendLine("            #region 參數宣告														  ");
            content.AppendLine("            bool result = false;													  ");
            content.AppendLine(string.Format("			{0}Model {1} = new {0}Model(); 											  ", mainTableName, paramMainTableName));
            content.AppendLine(string.Format("            I{0}Repository {1}Rp = new {0}Repository();								  ", mainTableName, paramMainTableName));
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 流程																");
            content.AppendLine(string.Format("			{0} =  PropertyCopy.Convert<DetailViewModel, {1}Model>(detail);  ", paramMainTableName, mainTableName));
            content.AppendLine(string.Format("			result = {0}Rp.Delete{1}({0});											  ", paramMainTableName, mainTableName));
            content.AppendLine("																					  ");
            content.AppendLine("            return result;															  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("        }																			  ");
            content.AppendLine("    }																				  ");
            content.AppendLine("}																					  ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        #endregion

        #region GenerateController

        /// <summary>
        /// Generate Controller
        /// </summary>
        /// <param name="controllerName"></param>
        private static void GenerateController(string controllerName)
        {
            #region 參數宣告
            
            string path = string.Concat(_appPath, "/", string.Format(_pathes[1], controllerName), "/");
            string filename = string.Format("{0}Controller.cs", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;															");
            content.AppendLine("using System.Collections.Generic;										");
            content.AppendLine("using System.Linq;														");
            content.AppendLine("using System.Net;														");
            content.AppendLine("using System.Net.Http;													");
            content.AppendLine("using System.Web.Http;													");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};					", controllerName));
            content.AppendLine("using PPPWEBAPI.Models;													");
            content.AppendLine("																		");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Controllers.{0}						", controllerName));
            content.AppendLine("{																		");
            content.AppendLine(string.Format("    public partial class {0}Controller : _BaseController	", controllerName));
            content.AppendLine("    {																	");
            content.AppendLine("        #region Properties												");
            content.AppendLine("        #endregion														");
            content.AppendLine("    }																	");
            content.AppendLine("}																		");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        /// <summary>
        /// Generate Controller SearchInfoInit Action
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="generateTokenFilter"></param>
        /// <param name="generationDataPermission"></param>
        private static void GenerateSearchInfoInitController(string controllerName, bool generateTokenFilter, bool generateDataPermission)
        {
            #region 參數宣告
            string paramControllerName = string.Concat(controllerName.Substring(0, 1).ToLower(), controllerName.Substring(1, controllerName.Length - 1));
            string path = string.Concat(_appPath, "/", string.Format(_pathes[1], controllerName), "/");
            string filename = string.Format("{0}Controller.SearchInfoInit.cs", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;															");
            content.AppendLine("using System.Collections.Generic;										");
            content.AppendLine("using System.Linq;														");
            content.AppendLine("using System.Net;														");
            content.AppendLine("using System.Net.Http;													");
            content.AppendLine("using System.Web.Http;													");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};					", controllerName));
            content.AppendLine("using PPPWEBAPI.Models;													");
            content.AppendLine("using PPPWEBAPI.Services;													");
            content.AppendLine("using PPPWEBAPI.Services.Interfaces;													");
            content.AppendLine("																		");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Controllers.{0}						", controllerName));
            content.AppendLine("{																		");
            content.AppendLine(string.Format("    public partial class {0}Controller : _BaseController	", controllerName));
            content.AppendLine("    {																	");
            content.AppendLine("        #region Properties												");
            content.AppendLine("        #endregion														");
            content.AppendLine("        														");
            content.AppendLine("        #region Action												");
            if (generateTokenFilter)
            {
                content.AppendLine("        [ApiJwtAuthActionFilter]														");
            }
            content.AppendLine(string.Format("        [System.Web.Http.Route(\"Api/{0}/SearchInfoInit\")]													  ", controllerName));
            content.AppendLine("        [System.Web.Http.HttpPost]													  ");
            content.AppendLine("        public SearchInfoInitViewModel SearchInfoInit()								  ");
            content.AppendLine("        {																			  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 參數宣告														  ");
            content.AppendLine("																					  ");
            content.AppendLine("            SearchInfoInitViewModel searchInfoInit = new SearchInfoInitViewModel();	  ");
            content.AppendLine(string.Format("            I{0}Service {1}Service = new {0}Service();								  ", controllerName, paramControllerName));
            if (generateDataPermission)
            {
                content.AppendLine("            IAuthorityService authorityService = new AuthorityService();	  ");
            }
            content.AppendLine("																					  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("            #region 流程																");
            if (generateTokenFilter)
            {
                content.AppendLine("																					  ");
                content.AppendLine("			//檢查是否驗證通過														  ");
                content.AppendLine("            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription);} ");
            }
            content.AppendLine("																					  ");
            content.AppendLine("            try																		  ");
            content.AppendLine("            {																		  ");
            content.AppendLine("				//取得SearchInfoInit													");
            content.AppendLine(string.Format("                searchInfoInit = {0}Service.QuerySearchInfoInit();					  ", paramControllerName ));
            content.AppendLine("																					  ");
            content.AppendLine("            }																		  ");
            content.AppendLine("            catch (Exception ex)													  ");
            content.AppendLine("            {																		  ");
            content.AppendLine("                throw ex;															  ");
            content.AppendLine("            }																		  ");
            content.AppendLine("            return searchInfoInit;													  ");
            content.AppendLine("            #endregion																  ");
            content.AppendLine("																					  ");
            content.AppendLine("        }																			  ");
            content.AppendLine("        #endregion														");
            content.AppendLine("    }																	");
            content.AppendLine("}																		");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        /// <summary>
        /// Generate Controller SearchList Action
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="generateTokenFilter"></param>
        /// <param name="generationDataPermission"></param>
        private static void GenerateSearchListController(string controllerName, bool generateTokenFilter, bool generateDataPermission)
        {
            #region 參數宣告
            string paramControllerName = string.Concat(controllerName.Substring(0, 1).ToLower(), controllerName.Substring(1, controllerName.Length - 1));
            string path = string.Concat(_appPath, "/", string.Format(_pathes[1], controllerName), "/");
            string filename = string.Format("{0}Controller.SearchList.cs", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;																																				  ");
            content.AppendLine("using System.Collections.Generic;																															   ");
            content.AppendLine("using System.Linq;																																			   ");
            content.AppendLine("using System.Net;																																			   ");
            content.AppendLine("using System.Net.Http;																																		   ");
            content.AppendLine("using System.Web.Http;																																		   ");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};																														   ", controllerName));
            content.AppendLine("using PPPWEBAPI.Models.ViewModel;																															   ");
            content.AppendLine("using PPPWEBAPI.Services;																																	   ");
            content.AppendLine("using PPPWEBAPI.Services.Interfaces;																														   ");
            content.AppendLine("using PPPWEBAPI.Utilities.Exceptions;																														   ");
            content.AppendLine("																																							   ");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Controllers.{0}																															   ", controllerName));
            content.AppendLine("{																																							   ");
            content.AppendLine(string.Format("    public partial class {0}Controller : _BaseController																									   ", controllerName));
            content.AppendLine("    {																																						   ");
            if (generateTokenFilter)
            {
                content.AppendLine("        [ApiJwtAuthActionFilter]														");
            }
            content.AppendLine(string.Format("        [System.Web.Http.Route(\"Api/{0}/SearchList\")]													  ", controllerName));
            content.AppendLine("        [System.Web.Http.HttpPost]																															   ");
            content.AppendLine("        public SearchListViewModel SearchList(SearchInfoViewModel searchInfo)																				   ");
            content.AppendLine("        {																																					   ");
            content.AppendLine("            #region 參數宣告																																   ");
            content.AppendLine("            SearchListViewModel searchList = new SearchListViewModel();																						   ");
            content.AppendLine(string.Format("            I{0}Service {1}Service = new {0}Service();																										   ", controllerName, paramControllerName));
            if (generateDataPermission)
            {
                content.AppendLine("            IAuthorityService authorityService = new AuthorityService();																			   ");
            }
            content.AppendLine("            #endregion																																		   ");
            content.AppendLine("																																							   ");
            content.AppendLine("            #region 流程																																	     ");
            if (generateTokenFilter)
            {
                content.AppendLine("																																							   ");
                content.AppendLine("			//檢查是否驗證通過														  ");
                content.AppendLine("            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription); }																		   ");
            }
            content.AppendLine("																																							   ");
            content.AppendLine("            // 參數驗證																																		   ");
            content.AppendLine("            VerifyParams(searchInfo);																														   ");
            content.AppendLine("																																							   ");
            content.AppendLine("            try																																				   ");
            content.AppendLine("            {																																				   ");
            content.AppendLine("				//取得查詢結果																															     ");
            content.AppendLine(string.Format("                searchList = {0}Service.QuerySearchList(searchInfo);																						   ",paramControllerName));
            if (generateDataPermission)
            {
                content.AppendLine("																																							   ");
                content.AppendLine("				//檢查資料編輯權限																															   ");
                content.AppendLine("                searchList.SearchItemList.ForEach(item => item.HasEditPermission = authorityService.HasDataPermission(_authState.UserID, item.DepartmentCD));  ");
            }
            content.AppendLine("            }																																				   ");
            content.AppendLine("            catch (Exception ex)																															   ");
            content.AppendLine("            {																																				   ");
            content.AppendLine("                throw ex;																																	   ");
            content.AppendLine("            }																																				   ");
            content.AppendLine("																																							   ");
            content.AppendLine("            #endregion																																		   ");
            content.AppendLine("																																							   ");
            content.AppendLine("            return searchList;																																   ");
            content.AppendLine("        }																																					   ");
            content.AppendLine("																																							   ");
            content.AppendLine("        private void VerifyParams(SearchInfoViewModel searchInfo)																							   ");
            content.AppendLine("        {																																					   ");
            content.AppendLine("            #region 參數宣告																																   ");
            content.AppendLine("            List<RequestValidateErrorViewModel> requestValidateErrorList = new List<RequestValidateErrorViewModel>();										   ");
            content.AppendLine("            #endregion																																		   ");
            content.AppendLine("																																							   ");
            content.AppendLine("            #region 流程																																	     ");
            content.AppendLine("            //處理欄位驗證																																     ");
            content.AppendLine("            if (requestValidateErrorList.Count > 0)																											   ");
            content.AppendLine("            {																																				   ");
            content.AppendLine("                throw new RequestValidateException(requestValidateErrorList);																				   ");
            content.AppendLine("            }																																				   ");
            content.AppendLine("																																							   ");
            content.AppendLine("            #endregion																																		   ");
            content.AppendLine("        }																																					   ");
            content.AppendLine("    }																																						   ");
            content.AppendLine("}																																							   ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        /// <summary>
        ///  Generate Controller ViewDetail Action
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="generateTokenFilter"></param>
        /// <param name="generateDataPermission"></param>
        private static void GenerateViewDetailController(string controllerName, bool generateTokenFilter, bool generateDataPermission)
        {
            #region 參數宣告
            string paramControllerName = string.Concat(controllerName.Substring(0, 1).ToLower(), controllerName.Substring(1, controllerName.Length - 1));
            string path = string.Concat(_appPath, "/", string.Format(_pathes[1], controllerName), "/");
            string filename = string.Format("{0}Controller.ViewDetail.cs", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;																																						");
            content.AppendLine("using System.Collections.Generic;																																	 ");
            content.AppendLine("using System.Linq;																																					 ");
            content.AppendLine("using System.Net;																																					 ");
            content.AppendLine("using System.Net.Http;																																				 ");
            content.AppendLine("using System.Web.Http;																																				 ");
            content.AppendLine("using PPPWEBAPI.Extensions;																																			 ");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};																																 ", controllerName));
            content.AppendLine("using PPPWEBAPI.Models.ViewModels;																																	 ");
            content.AppendLine("using PPPWEBAPI.Services;																																			 ");
            content.AppendLine("using PPPWEBAPI.Services.Interfaces;																																 ");
            content.AppendLine("using PPPWEBAPI.Utilities.Exceptions;																																 ");
            content.AppendLine("using PPPWEBAPI.Utilities;																																			 ");
            content.AppendLine("																																									 ");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Controllers.{0}																																	 ", controllerName));
            content.AppendLine("{																																									 ");
            content.AppendLine(string.Format("    public partial class {0}Controller : _BaseController																											 ", controllerName));
            content.AppendLine("    {																																								 ");
            if (generateTokenFilter)
            {
                content.AppendLine("        [ApiJwtAuthActionFilter]														");
            }
            content.AppendLine(string.Format("        [System.Web.Http.Route(\"Api/{0}/ViewDetail\")]													  ", controllerName));
            content.AppendLine("        [System.Web.Http.HttpPost]																																	 ");
            content.AppendLine("        public ViewDetailViewModel ViewDetail(DetailRequestViewModel detailRequest)																					 ");
            content.AppendLine("        {																																							 ");
            content.AppendLine("            #region 參數宣告																																		 ");
            content.AppendLine("            ViewDetailViewModel viewDetail = new ViewDetailViewModel();																								 ");
            content.AppendLine(string.Format("            I{0}Service {1}Service = new {0}Service();																												 ", controllerName, paramControllerName));
            content.AppendLine("            _BaseDetailRequestViewModel.EnumActiveType enumActiveType;																								 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #region 流程																																			   ");
            content.AppendLine("																																									 ");
            if (generateTokenFilter)
            {
                content.AppendLine("            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription);	}																			 ");
            }
            content.AppendLine("																																									 ");
            content.AppendLine("            // 參數驗證																																				 ");
            content.AppendLine("            VerifyParams(detailRequest);																															 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            try																																						 ");
            content.AppendLine("            {																																						 ");
            content.AppendLine("                enumActiveType = detailRequest.ActiveType.ConvertToEnum<_BaseDetailRequestViewModel.EnumActiveType>();												 ");
            content.AppendLine("																																									 ");
            content.AppendLine("                //判斷為EDIT 或 VIEW時需抓資料並檢查編輯權限																										 ");
            content.AppendLine("                if (enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.VIEW) || enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.EDIT))");
            content.AppendLine("                {																																					 ");
            content.AppendLine("                    //取得明細資料																																   ");
            content.AppendLine(string.Format("                    viewDetail.Detail = {0}Service.QueryDetail(detailRequest);																		 ", paramControllerName));
            content.AppendLine("																																									 ");
            content.AppendLine("                    //驗證編輯權限																																   ");
            content.AppendLine("                    VerifyActiveType(enumActiveType, ref viewDetail);																								 ");
            content.AppendLine("                }																																					 ");
            content.AppendLine("																																									 ");
            content.AppendLine("                //取得明細下拉選單項目																															   ");
            content.AppendLine(string.Format("                viewDetail.DetailOption = {0}Service.QueryDetailOption();																 ", paramControllerName));
            content.AppendLine("            }																																						 ");
            content.AppendLine("            catch (Exception ex)																																	 ");
            content.AppendLine("            {																																						 ");
            content.AppendLine("                throw ex;																																			 ");
            content.AppendLine("            }																																						 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            return viewDetail;																																		 ");
            content.AppendLine("        }																																							 ");
            content.AppendLine("																																									 ");
            content.AppendLine("        private void VerifyParams(DetailRequestViewModel detailRequest)																								 ");
            content.AppendLine("        {																																							 ");
            content.AppendLine("            #region 參數宣告																																		 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #region 流程																																			   ");
            content.AppendLine("																																									 ");
            content.AppendLine("            //處理欄位驗證																																		   ");
            content.AppendLine("			//檢核沒傳主Key時, 直接throw new Exception(\"未傳入主要查詢條件\")																						");
            content.AppendLine("																																									 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("        }																																							 ");
            content.AppendLine("																																									 ");
            content.AppendLine("        private bool VerifyActiveType(_BaseDetailRequestViewModel.EnumActiveType enumActiveType, ref ViewDetailViewModel viewDetail)								 ");
            content.AppendLine("        {																																							 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #region 參數宣告																																		 ");
            if (generateDataPermission)
            {
                content.AppendLine("            IAuthorityService authorityService = new AuthorityService();																							 ");
            }
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #region 流程處理																																		 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            if (enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.EDIT))																				 ");
            content.AppendLine("            {																																						 ");
            if (generateDataPermission)
            {
                content.AppendLine("				//先檢查是否有資料編輯權限																															 ");
                content.AppendLine("                if (!authorityService.HasDataPermission(_authState.UserID, viewDetail.Detail.DepartmentCD))															 ");
                content.AppendLine("                {																																					 ");
                content.AppendLine("                    throw new Exception(\"無資料編輯權限\");																											  ");
                content.AppendLine("                }																																					 ");
            }
            content.AppendLine("				//額外處理各功能有關初始化明細頁時, 與增改查有關的驗證																								");
            content.AppendLine("            }																																						 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            return true;																																			 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("        }																																							 ");
            content.AppendLine("    }																																								 ");
            content.AppendLine("}																																									 ");
            content.AppendLine("																																									 ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }

        /// <summary>
        /// Generate Controller Detail Action
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="generateTokenFilter"></param>
        /// <param name="generateDataPermission"></param>
        private static void GenerateDetailController(string controllerName, bool generateTokenFilter, bool generateDataPermission)
        {
            #region 參數宣告
            string paramControllerName = string.Concat(controllerName.Substring(0, 1).ToLower(), controllerName.Substring(1, controllerName.Length - 1));
            string path = string.Concat(_appPath, "/", string.Format(_pathes[1], controllerName), "/");
            string filename = string.Format("{0}Controller.Detail.cs", controllerName);
            StringBuilder content = new StringBuilder();
            #endregion

            #region 流程
            content.AppendLine("using System;																																						");
            content.AppendLine("using System.Collections.Generic;																																	 ");
            content.AppendLine("using System.Linq;																																					 ");
            content.AppendLine("using System.Net;																																					 ");
            content.AppendLine("using System.Net.Http;																																				 ");
            content.AppendLine("using System.Web.Http;																																				 ");
            content.AppendLine("using PPPWEBAPI.Extensions;																																			 ");
            content.AppendLine(string.Format("using PPPWEBAPI.Models.ViewModels.{0};																																 ", controllerName));
            content.AppendLine("using PPPWEBAPI.Models.ViewModels;																																	 ");
            content.AppendLine("using PPPWEBAPI.Services;																																			 ");
            content.AppendLine("using PPPWEBAPI.Services.Interfaces;																																 ");
            content.AppendLine("using PPPWEBAPI.Utilities.Exceptions;																																 ");
            content.AppendLine("using PPPWEBAPI.Utilities;																																			 ");
            content.AppendLine("																																									 ");
            content.AppendLine(string.Format("namespace PPPWEBAPI.Controllers.{0}																																	 ", controllerName));
            content.AppendLine("{																																									 ");
            content.AppendLine(string.Format("    public partial class {0}Controller : _BaseController																											 ", controllerName));
            content.AppendLine("    {																																								 ");
            if (generateTokenFilter)
            {
                content.AppendLine("        [ApiJwtAuthActionFilter]														");
            }
            content.AppendLine(string.Format("        [System.Web.Http.Route(\"Api/{0}/Detail\")]													  ", controllerName));
            content.AppendLine("        [System.Web.Http.HttpPost]																																	 ");
            content.AppendLine("        public bool Detail(DetailViewModel detail)																					 ");
            content.AppendLine("        {																																							 ");
            content.AppendLine("            #region 參數宣告																																		 ");
            content.AppendLine("            bool result = false;																								 ");
            content.AppendLine(string.Format("            I{0}Service {1}Service = new {0}Service();																												 ", controllerName, paramControllerName));
            content.AppendLine("            _BaseDetailRequestViewModel.EnumActiveType enumActiveType;																								 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #region 流程																																			   ");
            content.AppendLine("																																									 ");
            if (generateTokenFilter)
            {
                content.AppendLine("            if (!_authState.IsAuth) { throw new Exception(_authState.AuthDescription);}																				 ");
            }
            content.AppendLine("																																									 ");
            content.AppendLine("            // 參數驗證																																				 ");
            content.AppendLine("            VerifyParams(detail);																															 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            try																																						 ");
            content.AppendLine("            {																																						 ");
            content.AppendLine("                enumActiveType = detail.ActiveType.ConvertToEnum<_BaseDetailRequestViewModel.EnumActiveType>();												 ");
            content.AppendLine("                VerifyActiveType(enumActiveType, detail);																								 ");
            content.AppendLine("																																									 ");
            content.AppendLine("                //處理新增/編輯/刪除資料																										 ");
            content.AppendLine("                switch (enumActiveType)										");
            content.AppendLine("                {															");
            content.AppendLine("                    case _BaseDetailRequestViewModel.EnumActiveType.ADD:	");
            content.AppendLine(string.Format("                        {0}Service.AddDetail(detail);		", paramControllerName));
            content.AppendLine("                        result = true;												");
            content.AppendLine("                        break;												");
            content.AppendLine("                    case _BaseDetailRequestViewModel.EnumActiveType.EDIT:	");
            content.AppendLine(string.Format("                        {0}Service.EditDetail(detail);		", paramControllerName));
            content.AppendLine("                        result = true;												");
            content.AppendLine("                        break;												");
            content.AppendLine("                    case _BaseDetailRequestViewModel.EnumActiveType.DELETE:	");
            content.AppendLine(string.Format("                        {0}Service.DeleteDetail(detail);		", paramControllerName));
            content.AppendLine("                        result = true;												");
            content.AppendLine("                        break;												");
            content.AppendLine("                }															");
            content.AppendLine("            }																																						 ");
            content.AppendLine("            catch (Exception ex)																																	 ");
            content.AppendLine("            {																																						 ");
            content.AppendLine("                throw ex;																																			 ");
            content.AppendLine("            }																																						 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            return result;																																		 ");
            content.AppendLine("        }																																							 ");
            content.AppendLine("																																									 ");
            content.AppendLine("        private void VerifyParams(DetailViewModel detail)																								 ");
            content.AppendLine("        {																																							 ");
            content.AppendLine("            #region 參數宣告																																		 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #region 流程																																			   ");
            content.AppendLine("																																									 ");
            content.AppendLine("            //處理欄位驗證																																		   ");
            content.AppendLine("			//檢核沒傳主Key時, 直接throw new Exception(\"未傳入主要查詢條件\")																						");
            content.AppendLine("																																									 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("        }																																							 ");
            content.AppendLine("																																									 ");
            content.AppendLine("        private bool VerifyActiveType(_BaseDetailRequestViewModel.EnumActiveType enumActiveType, DetailViewModel Detail)								 ");
            content.AppendLine("        {																																							 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #region 參數宣告																																		 ");
            if (generateDataPermission)
            {
                content.AppendLine("            IAuthorityService authorityService = new AuthorityService();																							 ");
            }
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            #region 流程處理																																		 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            if (enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.EDIT) || enumActiveType.Equals(_BaseDetailRequestViewModel.EnumActiveType.DELETE))																				 ");
            content.AppendLine("            {																																						 ");
            if (generateDataPermission)
            {
                content.AppendLine("				//先檢查是否有資料編輯權限																															 ");
                content.AppendLine("                if (!authorityService.HasDataPermission(_authState.UserID, detail.DepartmentCD))															 ");
                content.AppendLine("                {																																					 ");
                content.AppendLine("                    throw new Exception(\"無資料編輯權限\");																											  ");
                content.AppendLine("                }																																					 ");
            }
            content.AppendLine("				//額外處理各功能有關初始化明細頁時, 與增改查有關的驗證																								");
            content.AppendLine("            }																																						 ");
            content.AppendLine("																																									 ");
            content.AppendLine("            return true;																																			 ");
            content.AppendLine("            #endregion																																				 ");
            content.AppendLine("        }																																							 ");
            content.AppendLine("    }																																								 ");
            content.AppendLine("}																																									 ");
            content.AppendLine("																																									 ");
            FileService.CreateFile(path, filename, content.ToString());
            #endregion
        }
        #endregion

        #endregion
    }
}
