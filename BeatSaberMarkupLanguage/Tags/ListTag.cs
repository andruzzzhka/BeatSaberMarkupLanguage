﻿using BeatSaberMarkupLanguage.Components;
using BS_Utils.Utilities;
using HMUI;
using UnityEngine;
using UnityEngine.UI;

namespace BeatSaberMarkupLanguage.Tags
{
    public class ListTag : BSMLTag
    {
        public override string[] Aliases => new[] { "list" };

        public override GameObject CreateObject(Transform parent)
        {
            RectTransform container = new GameObject("BSMLListContainer", typeof(RectTransform)).transform as RectTransform;
            LayoutElement layoutElement = container.gameObject.AddComponent<LayoutElement>();
            container.SetParent(parent, false);

            GameObject gameObject = new GameObject();
            gameObject.name = "BSMLList";
            gameObject.SetActive(false);

            TableView tableView = gameObject.AddComponent<TableView>();
            CustomListTableData tableData = container.gameObject.AddComponent<CustomListTableData>();
            tableData.tableView = tableView;

            gameObject.AddComponent<RectMask2D>();
            tableView.transform.SetParent(container, false);

            tableView.SetPrivateField("_preallocatedCells", new TableView.CellsGroup[0]);
            tableView.SetPrivateField("_isInitialized", false);

            RectTransform viewport = new GameObject("Viewport").AddComponent<RectTransform>();
            viewport.SetParent(gameObject.GetComponent<RectTransform>(), false);
            gameObject.GetComponent<ScrollRect>().viewport = viewport;

            (viewport.transform as RectTransform).anchorMin = new Vector2(0f, 0f);
            (viewport.transform as RectTransform).anchorMax = new Vector2(1f, 1f);
            (viewport.transform as RectTransform).sizeDelta = new Vector2(0f, 0f);
            (viewport.transform as RectTransform).anchoredPosition = new Vector3(0f, 0f);

            (tableView.transform as RectTransform).anchorMin = new Vector2(0f, 0f);
            (tableView.transform as RectTransform).anchorMax = new Vector2(1f, 1f);
            (tableView.transform as RectTransform).sizeDelta = new Vector2(0f, 0f);
            (tableView.transform as RectTransform).anchoredPosition = new Vector3(0f, 0f);

            tableView.dataSource = tableData;
            return container.gameObject;
        }
    }
}
