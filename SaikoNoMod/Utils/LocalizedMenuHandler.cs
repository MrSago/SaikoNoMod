using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;
using UnityEngine.UI;

namespace SaikoNoMod.Utils
{
    public static class LocalizedMenuHandler
    {
        public static void Init()
        {
            if (_textFields != null)
            {
                SaikoNoModCore.LogWarning(
                    $"[{nameof(LocalizedMenuHandler)}] Localized Menu is already initialized!"
                );
                return;
            }

            LanguageMenu? menu = GetLanguageMenu();
            if (menu == null)
            {
                SaikoNoModCore.LogWarning(
                    $"[{nameof(LocalizedMenuHandler)}] Can't get {nameof(LanguageMenu)} " +
                    $"component of GameObject {ObjectNames.LANGUAGE_MENU}!"
                );
                return;
            }

            _textFields = menu.textFields;
            SaikoNoModCore.Log(
                $"[{nameof(LocalizedMenuHandler)}] Text fields initialized with count: {_textFields.Length}"
            );
        }

        public static Text? GetTextAtIndex(int index)
        {
            if (_textFields == null)
            {
                SaikoNoModCore.LogWarning(
                    $"[{nameof(LocalizedMenuHandler)}] {nameof(_textFields)} is not initialized!"
                );
                return null;
            }

            if (index < 0 || index >= _textFields.Length)
            {
                SaikoNoModCore.LogWarning(
                    $"[{nameof(LocalizedMenuHandler)}] Index {index} is out of range: [0; {_textFields.Length - 1}]!"
                );
                return null;
            }

            return _textFields[index];
        }

        private static Il2CppReferenceArray<Text>? _textFields = null;

        private static LanguageMenu? GetLanguageMenu()
        {
            LanguageMenu? menu = null;
            try
            {
                menu = GameObject.Find(ObjectNames.LANGUAGE_MENU)?.GetComponent<LanguageMenu>();
            }
            catch (Exception ex)
            {
                SaikoNoModCore.LogError(ex);
            }
            return menu;
        }
    }
}
