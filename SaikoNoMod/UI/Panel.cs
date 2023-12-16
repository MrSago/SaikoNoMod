using UnityEngine;
using UnityEngine.UI;
using UniverseLib;
using UniverseLib.UI;
using UniverseLib.UI.Models;

namespace SaikoNoMod.UI
{
    public class Panel : UniverseLib.UI.Panels.PanelBase
    {
        public Panel(UIBase owner) : base(owner)
        {
        }

        public override string Name => "My Panel";
        public override int MinWidth => 100;
        public override int MinHeight => 200;
        public override Vector2 DefaultAnchorMin => new(0.25f, 0.25f);
        public override Vector2 DefaultAnchorMax => new(0.75f, 0.75f);
        public override bool CanDragAndResize => true;

        protected override void ConstructPanelContent()
        {
            Text myText = UIFactory.CreateLabel(ContentRoot, "myText", "Hello world");
            UIFactory.SetLayoutElement(myText.gameObject, minWidth: 200, minHeight: 25);

            // GameObject refreshToggle = UIFactory.CreateToggle(ContentRoot, "Kekis", out Toggle toggle, out Text text);
            // UIFactory.SetLayoutElement(refreshToggle, flexibleWidth: 9999);
            // text.font = UniversalUI.ConsoleFont;
            // text.supportRichText = true;
            // text.text = "Auto-update (1 second)";
            // text.alignment = TextAnchor.MiddleLeft;
            // text.color = Color.white;
            // text.fontSize = 12;
            // toggle.isOn = false;
        }
    }
}