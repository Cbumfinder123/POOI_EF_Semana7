using AssetManagement.Data;
using AssetManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace AssetManagement.Controllers
{
    public class ITAssetInventoriesController : Controller
    {
        private ITAssetInventoryDataAccess itAssetInventoryDataAccess = new ITAssetInventoryDataAccess();

        // GET: ITAssetInventories
        public ActionResult Index()
        {
            var inventories = itAssetInventoryDataAccess.GetAllITAssetInventories();
            return View(inventories);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var inventory = itAssetInventoryDataAccess.GetAllITAssetInventories().FirstOrDefault(i => i.it_asset_inventory_id == id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "asset_id,inventory_date,number_assigned,number_in_stock,other_details")] ITAssetInventory inventory)
        {
            if (ModelState.IsValid)
            {
                itAssetInventoryDataAccess.AddITAssetInventory(inventory);
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var inventory = itAssetInventoryDataAccess.GetAllITAssetInventories().FirstOrDefault(i => i.it_asset_inventory_id == id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "it_asset_inventory_id,asset_id,inventory_date,number_assigned,number_in_stock,other_details")] ITAssetInventory inventory)
        {
            if (ModelState.IsValid)
            {
                itAssetInventoryDataAccess.UpdateITAssetInventory(inventory);
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            var inventory = itAssetInventoryDataAccess.GetAllITAssetInventories().FirstOrDefault(i => i.it_asset_inventory_id == id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itAssetInventoryDataAccess.DeleteITAssetInventory(id);
            return RedirectToAction("Index");
        }
    }
}
