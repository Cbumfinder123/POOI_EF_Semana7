using System.Linq;
using System.Web.Mvc;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class ITAssetsController : Controller
    {
        private ITAssetDataAccess itAssetDataAccess = new ITAssetDataAccess();

        // GET: ITAssets
        public ActionResult Index()
        {
            var itAssets = itAssetDataAccess.GetAllITAssets();
            return View(itAssets);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var itAsset = itAssetDataAccess.GetAllITAssets().FirstOrDefault(a => a.asset_id == id);
            if (itAsset == null)
            {
                return HttpNotFound();
            }
            return View(itAsset);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "asset_type_id,asset_name,description,other_details")] ITAsset itAsset)
        {
            if (ModelState.IsValid)
            {
                itAssetDataAccess.AddITAsset(itAsset);
                return RedirectToAction("Index");
            }
            return View(itAsset);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var itAsset = itAssetDataAccess.GetAllITAssets().FirstOrDefault(a => a.asset_id == id);
            if (itAsset == null)
            {
                return HttpNotFound();
            }
            return View(itAsset);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "asset_id,asset_type_id,asset_name,description,other_details")] ITAsset itAsset)
        {
            if (ModelState.IsValid)
            {
                itAssetDataAccess.UpdateITAsset(itAsset);
                return RedirectToAction("Index");
            }
            return View(itAsset);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            var itAsset = itAssetDataAccess.GetAllITAssets().FirstOrDefault(a => a.asset_id == id);
            if (itAsset == null)
            {
                return HttpNotFound();
            }
            return View(itAsset);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itAssetDataAccess.DeleteITAsset(id);
            return RedirectToAction("Index");
        }
    }
}
