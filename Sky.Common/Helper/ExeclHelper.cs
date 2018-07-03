using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sky.Common.Helper
{
    public class ExeclHelper
    {
        /// <summary>
        /// 导出Execl（NOPI）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="url">返回下载地址</param>
        /// <returns></returns>
        public static bool ExportExcel(DataTable dt, out string url)
        {
            bool isSuccess = true;
            url = "";
            try
            {
                HSSFWorkbook wb = new HSSFWorkbook();
                HSSFSheet sheet = (HSSFSheet)wb.CreateSheet(dt.TableName); //创建工作表
                sheet.CreateFreezePane(0, 1); //冻结列头行
                HSSFRow row_Title = (HSSFRow)sheet.CreateRow(0); //创建列头行
                row_Title.HeightInPoints = 19.5F; //设置列头行高



                #region 设置列头单元格样式                
                HSSFCellStyle cs_Title = (HSSFCellStyle)wb.CreateCellStyle(); //创建列头样式
                cs_Title.Alignment = HorizontalAlignment.Center; //水平居中
                cs_Title.VerticalAlignment = VerticalAlignment.Center; //垂直居中
                HSSFFont cs_Title_Font = (HSSFFont)wb.CreateFont(); //创建字体
                cs_Title_Font.IsBold = true; //字体加粗
                cs_Title_Font.FontHeightInPoints = 12; //字体大小
                cs_Title.SetFont(cs_Title_Font); //将字体绑定到样式
                cs_Title.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                cs_Title.FillPattern = FillPattern.SolidForeground;

                //有边框
                cs_Title.BorderBottom = BorderStyle.Thin;
                cs_Title.BorderLeft = BorderStyle.Thin;
                cs_Title.BorderRight = BorderStyle.Thin;
                cs_Title.BorderTop = BorderStyle.Thin;

                #endregion

                #region 生成列头
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    HSSFCell cell_Title = (HSSFCell)row_Title.CreateCell(i); //创建单元格
                    cell_Title.CellStyle = cs_Title; //将样式绑定到单元格
                    cell_Title.SetCellValue(dt.Columns[i].ColumnName);

                    #region 设置列宽
                    sheet.SetColumnWidth(i, 20 * 300);
                    #endregion
                }
                #endregion

                #region 设置列值
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        #region 设置内容单元格样式
                        HSSFCellStyle cs_Content = (HSSFCellStyle)wb.CreateCellStyle(); //创建列头样式
                        cs_Content.Alignment = HorizontalAlignment.Center; //水平居中
                        cs_Content.VerticalAlignment = VerticalAlignment.Center; //垂直居中
                        #endregion

                        #region 生成内容单元格
                        HSSFRow row_Content = (HSSFRow)sheet.CreateRow(i + 1); //创建行
                        row_Content.HeightInPoints = 16;
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            HSSFCell cell_Conent = (HSSFCell)row_Content.CreateCell(j); //创建单元格
                            cell_Conent.CellStyle = cs_Content;
                            cell_Conent.SetCellValue(dt.Rows[i][j].ToString());
                        }
                        #endregion
                    }

                    string sWebBasePath = HttpContext.Current.Server.MapPath("~"); //获取网站根目录物理路径
                    string sExportDir = sWebBasePath + "/Export"; //临时保存文件夹
                    string sExportFileName = dt.TableName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                    string sExportFilePath = sExportDir + "/" + sExportFileName;//文件保存路径（保存到服务器）
                    url = HttpContext.Current.Request.Url.Authority + "/Export/" + sExportFileName;

                    //创建文件夹
                    if (!Directory.Exists(sExportDir))
                    {
                        Directory.CreateDirectory(sExportDir);
                    }
                    //保存本地文件
                    using (FileStream file = new FileStream(sExportFilePath, FileMode.Create))
                    {
                        wb.Write(file);
                    }
                }
                #endregion


            }
            catch (Exception ex)
            {
                isSuccess = false;

            }
            return isSuccess;
        }
    }
}
