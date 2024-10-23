using System.Linq;
using System.Web.Mvc;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class EmployeeAssetsController : Controller
    {
        private EmployeeAssetDataAccess employeeAssetDataAccess = new EmployeeAssetDataAccess();

        // GET: EmployeeAssets
        public ActionResult Index()
        {
            var employeeAssets = employeeAssetDataAccess.GetAllEmployeeAssets();
            return View(employeeAssets);
        }

        // GET: Details
        public ActionResult Details(int assetId, int employeeId)
        {
            var employeeAsset = employeeAssetDataAccess.GetAllEmployeeAssets().FirstOrDefault(ea => ea.AssetId == assetId && ea.EmployeeId == employeeId);
            if (employeeAsset == null)
            {
                return HttpNotFound();
            }
            return View(employeeAsset);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetId,EmployeeId,DateOut,DateReturned,ConditionOut,ConditionReturned,OtherDetails")] EmployeeAsset employeeAsset)
        {
            if (ModelState.IsValid)
            {
                employeeAssetDataAccess.AddEmployeeAsset(employeeAsset);
                return RedirectToAction("Index");
            }
            return View(employeeAsset);
        }

        // GET: Edit
        public ActionResult Edit(int assetId, int employeeId)
        {
            var employeeAsset = employeeAssetDataAccess.GetAllEmployeeAssets().FirstOrDefault(ea => ea.AssetId == assetId && ea.EmployeeId == employeeId);
            if (employeeAsset == null)
            {
                return HttpNotFound();
            }
            return View(employeeAsset);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetId,EmployeeId,DateOut,DateReturned,ConditionOut,ConditionReturned,OtherDetails")] EmployeeAsset employeeAsset)
        {
            if (ModelState.IsValid)
            {
                employeeAssetDataAccess.UpdateEmployeeAsset(employeeAsset);
                return RedirectToAction("Index");
            }
            return View(employeeAsset);
        }

        // GET: Delete
        public ActionResult Delete(int assetId, int employeeId)
        {
            var employeeAsset = employeeAssetDataAccess.GetAllEmployeeAssets().FirstOrDefault(ea => ea.AssetId == assetId && ea.EmployeeId == employeeId);
            if (employeeAsset == null)
            {
                return HttpNotFound();
            }
            return View(employeeAsset);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int assetId, int employeeId)
        {
            employeeAssetDataAccess.DeleteEmployeeAsset(assetId, employeeId);
            return RedirectToAction("Index");
        }
    }
}
