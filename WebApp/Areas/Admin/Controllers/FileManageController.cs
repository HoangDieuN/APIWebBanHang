using APIServices;
using MimeMapping;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;
namespace WebApp.Areas.Admin.Controllers
{
    public class FileManageController : Controller
    {
        // GET: FileManage
        private readonly IAttachedFileApiService _attachedFileApiService;
        public FileManageController(IAttachedFileApiService attachedFileApiService)
        {
            _attachedFileApiService = attachedFileApiService;
        }

        #region Views
        public ActionResult Index()
        {
            return View();
        }
        #endregion Views

        #region PartialViews
        public ActionResult FileUpload(AttachedFile model)
        {
            return PartialView(model);
        }

        public ActionResult _ViewListFiles()
        {
            return PartialView();
        }
        public ActionResult _PreviewFile()
        {
            return PartialView();
        }
        #endregion PartialViews

        #region Actions
        [HttpPost]
        public async Task<ActionResult> ListAttachedFile(AttachedFileRequest requestModel)
        {
            //call api
           AttachedFilePaging model = await _attachedFileApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListAttachedFile,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }

        [HttpPost]
        public async Task<ActionResult> ListAttachedFileByGroupProduct(AttachedFileRequest requestModel)
        {
            //call api
            List<AttachedFile> model = await _attachedFileApiService.GetByGroupProduct(requestModel);

            return Json(new
            {
                data = model,
                recordsTotal = model.Count,
                recordsFiltered = model.Count,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }


        [HttpPost]
        public async Task<ActionResult> UploadFile()
        {
            try
            {
                AttachedFile attachFile = JsonConvert.DeserializeObject<AttachedFile>(Request.Params["fileInfo"]);
                var files = Request.Files;
                string type = Enum.GetName(typeof(Enums.AttachFileGroup),Enums.AttachFileGroup.SanPham);
                if (files.Count > 0)
                {
                    List<AttachedFile> listAttachedFiles = new List<AttachedFile>();
                    var listFiles = files.GetMultiple(Request.Files.AllKeys[0]);
                    foreach (HttpPostedFileBase file in listFiles)
                    {
                        string filePath = FileManageHelper.SaveFile(this, file, type);
                        AttachedFile newFile = new AttachedFile()
                        {
                            FileGroupCode = attachFile.FileGroupCode,
                            ProductID = attachFile.ProductID,
                            FileKey = attachFile.FileKey,
                            FileName = file.FileName,
                            FilePath = filePath
                        };
                        //add to list
                        listAttachedFiles.Add(newFile);
                    }
                    //cập nhật vào bảng attached file
                    int rsAttachedFile = await _attachedFileApiService.Create(new AttachedFile()
                    {
                        ListAttachedFile = listAttachedFiles,
                        //UpdatedBy = User.ID_cb
                    });
                }
                else
                {
                    return Json(new { result = "error", message = Constants.MSG_ERR_SAVE_FAILED });
                }
                return Json(new { result = "success", message = Constants.MSG_ERR_SAVE_SUCCESS });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra: " + ex.Message });
            }
        }


        public async Task<ActionResult> DownloadFile(AttachedFile attachedFile)
        {
            try
            {
                AttachedFile file = new AttachedFile();
                if (attachedFile.Id != null && attachedFile.Id != default(Guid))
                {
                    file = await _attachedFileApiService.GetById(attachedFile);
                }
                else
                {
                    file = attachedFile;
                }
                string filePath = Encryptor.Decrypt(file.FilePath, FileManageHelper.encryptKey);
                string uploadDir = Constants.UPLOAD_DIR + filePath;
                string fullPath = Server.MapPath(uploadDir);
                byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
                Response.AddHeader("Content-Disposition", "attachment; filename*=" + Uri.EscapeDataString(file.FileName.Trim()));
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = ex.Message });
            }
        }

        public ActionResult PreviewFile(string filePath)
        {
            try
            {
                byte[] fileBytes = null;

                string uploadDir = Constants.UPLOAD_DIR + Encryptor.Decrypt(filePath, FileManageHelper.encryptKey);
                string sourcePath = Server.MapPath(uploadDir);
                string fileName = Path.GetFileName(sourcePath);
                string mimeType = System.Web.MimeMapping.GetMimeMapping(fileName);
                string destinationPath = String.Empty;
                if (mimeType == KnownMimeTypes.Docx || mimeType == KnownMimeTypes.Doc)
                {
                    //convert to pdf
                    string tempPath = $"{Constants.UPLOAD_DIR}/tempFile{DateTime.Now.Ticks}.pdf";
                    destinationPath = Server.MapPath(tempPath);
                    FileManageHelper.convertWordToPdf(this, sourcePath, destinationPath);
                    fileBytes = System.IO.File.ReadAllBytes(destinationPath);
                }
                else
                {
                    fileBytes = System.IO.File.ReadAllBytes(sourcePath);
                }
                MemoryStream ms = new MemoryStream();
                ms.Write(fileBytes, 0, fileBytes.Length);
                ms.Seek(0, SeekOrigin.Begin);

                if (!String.IsNullOrEmpty(destinationPath))
                    System.IO.File.Delete(destinationPath);

                Response.AddHeader("Content-Disposition", "attachment; filename*=" + Uri.EscapeDataString(fileName.Trim()));
                return File(ms, System.Net.Mime.MediaTypeNames.Application.Pdf);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("PreviewFile error: " + ex.Message);
                return Redirect("/file-not-found");
            }

        }

        public ActionResult FilePathDecode(string filePath)
        {
            try
            {
                string uploadDir = Constants.UPLOAD_DIR + Encryptor.Decrypt(filePath, FileManageHelper.encryptKey);
                uploadDir = uploadDir.Replace("~", "");
                return Json(new { path = uploadDir });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("PreviewFile error: " + ex.Message);
                return Json(new { path = "/file-not-found" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(AttachedFile attachFile)
        {
            try
            {
                //attachFile.UpdatedBy = User.ID_cb;
                //call api
                int result = await _attachedFileApiService.Delete(attachFile);
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
        #endregion Actions
    }
}