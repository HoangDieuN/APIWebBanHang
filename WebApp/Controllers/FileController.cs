using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{
    public class FileController : BaseController
    {
        private readonly IAttachedFileApiService _attachedFileApiService;
        public FileController(IAttachedFileApiService attachedFileApiService)
        {
            _attachedFileApiService = attachedFileApiService;
        }
        // GET: File
        public async Task<ActionResult> ViewFileAnhSanPham(int id)
        {
            //lấy danh sách file
            AttachedFileRequest requestFile = new AttachedFileRequest();
            requestFile.ProductIds = id.ToString();
            requestFile.FileGroupCode = ModuleConstants.SanPhamCode;
            List<AttachedFile> listAnh = await _attachedFileApiService.GetByGroupProduct(requestFile);
            return PartialView("_ViewFileAnhSanPham", listAnh);
        }    
    }
}