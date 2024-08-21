using APIServices;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorization]
    public class BaiVietController : BaseController
    {
        private readonly IBaiVietApiService _baiVietApiService;
        private readonly IAttachedFileApiService _attachedFileApiService;

        public BaiVietController(IBaiVietApiService baiVietApiService, IAttachedFileApiService attachedFileApiService)
        {
            _baiVietApiService = baiVietApiService;
            _attachedFileApiService = attachedFileApiService;
        }
        // GET: Admin/BaiViet
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ListBaiViet(BaiVietRequest requestModel)
        {
            //call api
            BaiVietPaging model = await _baiVietApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListBaiViet,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        [HttpGet]
        public async Task<ActionResult> _FormBaiViet(int id)
        {
            BaiViet model = new BaiViet();
            if (id > 0)
            {
                BaiViet result = await _baiVietApiService.GetById(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return PartialView(model);
        }
        [HttpPost]
        public async Task<ActionResult> Save(BaiViet requestModel)
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
                    result = await _baiVietApiService.Update(requestModel);
                }
                else
                {
                    requestModel.CreatedBy = User.UserName;
                    //call api insert sản phẩm
                    result = await _baiVietApiService.Creat(requestModel);

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
                            string type = Enum.GetName(typeof(Enums.AttachFileGroup), Enums.AttachFileGroup.BaiViet);
                            //lưu file
                            foreach (var file in listFiles)
                            {
                                //get file theo key
                                var fileInQueue = files.GetMultiple($"{file.Id}").Where(x => x.FileName == file.FileName).FirstOrDefault();
                                string filePath = FileManageHelper.SaveFile(this, fileInQueue, ModuleConstants.BaiVietCode);
                                //add file to list
                                listAttachedFiles.Add(new AttachedFile()
                                {
                                    FileGroupCode = ModuleConstants.BaiVietCode,
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
        public async Task<ActionResult> Delete(BaiVietRequest requestModel)
        {
            try
            {
                requestModel.DeletedBy = User.UserName;
                //call api
                int result = await _baiVietApiService.Delete(requestModel);
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
        [HttpPost]
        public async Task<ActionResult> UpdateActive(BaiVietRequest requestModel)
        {
            try
            {
                requestModel.UpdatedBy = User.UserName;
                //call api
                int result = await _baiVietApiService.UpdateActive(requestModel);
                if (result > 0)
                {
                    return Json(new { result = "success", message = "Cập nhật thành công" });
                }
                return Json(new { result = "error", message = "Cập nhật thất bại" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
    }
}