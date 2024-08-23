using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Utilities;


namespace WebApp.Areas.Admin.Controllers
{
    [Authorization]
    public class SanPhamController : BaseController
    {
        private readonly ISanPhamApiService _sanPhamApiService;
        private readonly IAttachedFileApiService _attachedFileApiService;

        public SanPhamController(ISanPhamApiService sanPhamApiService, IAttachedFileApiService attachedFileApiService)
        {
            _sanPhamApiService = sanPhamApiService;
            _attachedFileApiService = attachedFileApiService;   
        }
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ListSanPham(SanPhamRequest requestModel)
        {
            //call api
            SanPhamPaging model = await _sanPhamApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListSanPham,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        [HttpGet]
        public async Task<ActionResult> _FormSanPham(int id)
        {
            SanPham model = new SanPham();
            if (id > 0)
            {
                SanPham result = await _sanPhamApiService.GetById(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return PartialView(model);
        }
        [HttpPost]
        public async Task<ActionResult> Save(SanPham requestModel)
        {
            try
            {
                int result = 0;
                //list  file đính kèm chưa lưu
                string jsonFiles = Request.Params["attachedFiles"] ?? "[]";
                List<AttachedFile> listFiles = JsonConvert.DeserializeObject<List<AttachedFile>>(jsonFiles, Common.JsonSettings);

                if (requestModel.Id > 0)
                {
                    requestModel.UpdatedBy = User.UserName;
                    //call api update sản phẩm
                    result = await _sanPhamApiService.Update(requestModel);
                }
                else
                {
                    requestModel.CreatedBy = User.UserName;
                    //call api insert sản phẩm
                    result = await _sanPhamApiService.Creat(requestModel);

                }
                if (result > 0)
                {                
                    #region file đính kèm
                    var files = Request.Files;

                    //list file cần lưu vào bảng attached file
                    List<AttachedFile> listAttachedFiles = new List<AttachedFile>();

                    int productId = requestModel.Id > 0 ? requestModel.Id : result;

                    if (listFiles != null && listFiles.Count > 0)
                    {
                        listFiles = listFiles.Where(x => x.IsUploaded != 1).ToList();

                        //add thông tin file cần lưu
                        if (listFiles.Count > 0)
                        {
                            //lưu file
                            foreach (var file in listFiles)
                            {
                                //get file theo key
                                var fileInQueue = files.GetMultiple($"{file.Id}").Where(x => x.FileName == file.FileName).FirstOrDefault();
                                string filePath = FileManageHelper.SaveFile(this, fileInQueue,ModuleConstants.SanPhamCode);
                                //add file to list
                                listAttachedFiles.Add(new AttachedFile()
                                {
                                    FileGroupCode = ModuleConstants.SanPhamCode,
                                    ProductID = productId,
                                    FileKey = file.FileKey,
                                    FileName = file.FileName,
                                    FileType = file.FileType,
                                    FileSize = file.FileSize,
                                    FilePath = filePath
                                });
                            }
                            //cập nhật vào bảng attached file
                            await _attachedFileApiService.Create(new AttachedFile()
                            {
                                ListAttachedFile = listAttachedFiles,
                                UpdatedBy = User.UserName
                            });
                        }
                    }
                    #endregion file đính kèm
                    return Json(new { result = "success", message = "Lưu thông tin thành công" });
                }
                return Json(new { result = "error", message = "Lưu thông tin thất bại" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(SanPhamRequest requestModel)
        {
            try
            {
                requestModel.DeletedBy = User.UserName;
                //call api
                int result = await _sanPhamApiService.Delete(requestModel);
                if (result > 0)
                {
                    return Json(new { result = "success", message = "Xóa thành công" });
                }
                return Json(new { result = "error", message = "Xóa thất bại" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
    }
}