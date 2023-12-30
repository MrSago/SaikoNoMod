using UnityEngine;
using UnityEngine.UI;
using UniverseLib;
using UniverseLib.UI;
using UniverseLib.UI.Models;
using UniverseLib.UI.Panels;
using SaikoNoMod.Properties;

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

        protected Text? StatusBar { get; private set; }

        private void CreateOneHPChallengeToggle()
        {
            GameObject checkbox = UIFactory.CreateToggle(ContentRoot, "OneHPChallengeCheckbox", out Toggle toggle, out Text text);
            text.text = "One HP Challenge";
            toggle.isOn = false;
            toggle.onValueChanged.AddListener((value) =>
            {
                if (value)
                {
                    SaikoNoModCore.Log("One HP Challenge: ON");
                    // Settings.Default.OneHPMode = true;
                }
                else
                {
                    SaikoNoModCore.Log("One HP Challenge: OFF");
                    // Settings.Default.OneHPMode = false;
                }
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
