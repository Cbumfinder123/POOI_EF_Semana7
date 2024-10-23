using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using AssetManagement.Data;
using AssetManagement.Models;

public class AssetTypesController : Controller
{
    private readonly AssetTypeDataAccess assetTypeDataAccess = new AssetTypeDataAccess();

    // GET: AssetTypes
    public ActionResult Index()
    {
        var assetTypes = assetTypeDataAccess.GetAllAssetTypes();
        return View(assetTypes);
    }

    // GET: Details
    public ActionResult Details(int id)
    {
        var assetType = assetTypeDataAccess.GetAllAssetTypes().FirstOrDefault(at => at.AssetTypeId == id);
        if (assetType == null)
        {
            return HttpNotFound();
        }
        return View(assetType);
    }

    // GET: Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "AssetTypeDescription")] AssetType assetType)
    {
        if (ModelState.IsValid)
        {
            assetTypeDataAccess.AddAssetType(assetType);
            return RedirectToAction("Index");
        }
        return View(assetType);
    }

    // GET: Edit
    public ActionResult Edit(int id)
    {
        var assetType = assetTypeDataAccess.GetAllAssetTypes().FirstOrDefault(at => at.AssetTypeId == id);
        if (assetType == null)
        {
            return HttpNotFound();
        }
        return View(assetType);
    }

    // POST: Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "AssetTypeId,AssetTypeDescription")] AssetType assetType)
    {
        if (ModelState.IsValid)
        {
            assetTypeDataAccess.UpdateAssetType(assetType);
            return RedirectToAction("Index");
        }
        return View(assetType);
    }

    // GET: Delete
    public ActionResult Delete(int id)
    {
        var assetType = assetTypeDataAccess.GetAllAssetTypes().FirstOrDefault(at => at.AssetTypeId == id);
        if (assetType == null)
        {
            return HttpNotFound();
        }
        return View(assetType);
    }

    // POST: Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        assetTypeDataAccess.DeleteAssetType(id);
        return RedirectToAction("Index");
    }
}
