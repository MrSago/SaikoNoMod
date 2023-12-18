using UnityEngine;
using UnityEngine.UI;
using UniverseLib;
using UniverseLib.UI;
using UniverseLib.UI.Models;
using UniverseLib.UI.Panels;
using MelonLoader;

namespace SaikoNoMod.UI
{
    public class MainPanel : PanelBase
    {
        public MainPanel(UIBase owner) : base(owner) { }

        public override string Name => "My Panel";
        public override int MinWidth => 100;
        public override int MinHeight => 200;
        public override Vector2 DefaultAnchorMin => new(0.25f, 0.25f);
        public override Vector2 DefaultAnchorMax => new(0.75f, 0.75f);
        public override bool CanDragAndResize => true;

        protected override void OnClosePanelClicked()
        {
            Owner.Enabled = !Owner.Enabled;
        }

        protected override void ConstructPanelContent()
        {
            Text myText = UIFactory.CreateLabel(ContentRoot, "myText", "Hello world");
            UIFactory.SetLayoutElement(myText.gameObject, minWidth: 200, minHeight: 25);
            UIFactory.SetLayoutGroup<VerticalLayoutGroup>(myText.gameObject, true, true, true, true, 0, 0, 0, 5, 5, TextAnchor.MiddleLeft);

            Text NameLabel = UIFactory.CreateLabel(UIRoot, "NameLabel", "AHSUDIHASUIDHAUISDHUIASHDUIASHDUIASHD", TextAnchor.MiddleLeft);
            NameLabel.horizontalOverflow = HorizontalWrapMode.Wrap;
            UIFactory.SetLayoutElement(NameLabel.gameObject, minHeight: 25, flexibleWidth: 9999, flexibleHeight: 300);
        }
    }
}
