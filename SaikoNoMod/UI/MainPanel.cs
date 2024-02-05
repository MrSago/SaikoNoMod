using UnityEngine;
using UnityEngine.UI;
using UniverseLib;
using UniverseLib.UI;
using UniverseLib.UI.Panels;
using SaikoNoMod.Properties;
using SaikoNoMod.Mods;

namespace SaikoNoMod.UI
{
    public class MainPanel : PanelBase
    {
        public MainPanel(UIBase owner) : base(owner) { }

        public override string Name => $"{BuildInfo.NAME} v{BuildInfo.VERSION}";
        public override int MinWidth => 100;
        public override int MinHeight => 200;
        public override Vector2 DefaultAnchorMin => new(0.25f, 0.25f);
        public override Vector2 DefaultAnchorMax => new(0.75f, 0.75f);
        public override bool CanDragAndResize => true;

        protected override void ConstructPanelContent()
        {
            Text myText = UIFactory.CreateLabel(ContentRoot, "OneHPModeText", "Some text", TextAnchor.MiddleLeft);

            CreateOneHPChallengeToggle();

            CreateStatusBar();
        }

        protected override void OnClosePanelClicked()
        {
            Owner.Enabled = !Owner.Enabled;
        }

        protected Text StatusBar { get; private set; } = null!;

        private void CreateOneHPChallengeToggle()
        {
            GameObject checkbox = UIFactory.CreateToggle(ContentRoot, "OneHPChallengeCheckbox", out Toggle toggle, out Text text);
            text.text = "One HP Challenge";
            toggle.isOn = OneHPChallenge.Enabled;
            toggle.onValueChanged.AddListener((value) =>
            {
                OneHPChallenge.Enabled = value;
            });
        }

        private void CreateStatusBar()
        {
            StatusBar = UIFactory.CreateLabel(UIRoot, "StatusBar", "Ready!", TextAnchor.MiddleLeft);
            StatusBar.horizontalOverflow = HorizontalWrapMode.Wrap;
            UIFactory.SetLayoutElement(StatusBar.gameObject, minHeight: 25, flexibleWidth: 9999, flexibleHeight: 200);
        }
    }
}
