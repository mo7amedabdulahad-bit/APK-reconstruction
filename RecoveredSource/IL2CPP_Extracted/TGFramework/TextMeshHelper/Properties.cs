// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TGFramework.TextMeshHelper
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

	public class Properties
	{
		// Fields
		public Mask excludeCopyMask;
		public TextAnchor anchor;
		public UnityEngine.Color color;
		public TMP_FontAsset tmFont;
		public float fontSize;
		public float fontSizeMin;
		public float fontSizeMax;
		public FontStyle fontStyle;
		public float lineSpacing;
		public Material tmpMaterial;
		public bool raycast;
		public bool enableAutoSizing;
		public bool enableWordWrapping;
		public TextOverflowModes overflowMode;
		private static Dictionary<TextAnchor, TextAlignmentOptions> alignmentCfg;
		private static Dictionary<FontStyle, TMPro.FontStyles> fontStyleCfg;
		private UnityEngine.Color? multiplyColor;
		private UnityEngine.Color? addColor;
		private float? multiplyFontSize;
		private float? addFontSize;
		private float? addLineHeight;
		private bool? ignoreFontStyle;
		private bool? forceSmallCaps;
	
		// Nested types
		[Flags]
		public enum Mask
		{
			Anchor = 1,
			Alignment = 2,
			Color = 4,
			Font = 8,
			FontStyle = 16,
			FontSize = 32,
			FontMinSize = 64,
			FontMaxSize = 128,
			LineSpacing = 256,
			RaycastTarget = 512,
			AutoSizing = 1024,
			OverflowMode = 2048
		}
	
		// Constructors
		static Properties() {}
		public Properties() {}
	
		// Methods
		private static TextAlignmentOptions ConvertAlignment(TextAnchor uGuiAlignment) => default;
		private static TextAnchor ConvertAlignment(TextAlignmentOptions uGuiAlignment) => default;
		private static TMPro.FontStyles ConvertFontStyle(FontStyle uGuiFont) => default;
		private static FontStyle ConvertFontStyle(TMPro.FontStyles uGuiFont) => default;
		public void ReadFrom(FontStyleCfg sourceText, Material materialCopyToUse = null) {}
		public void ApplyOverride(FontStyleOverride fontStyleOverride) {}
		public void ReadFrom(Wrapper sourceText) {}
		public void WriteTo(TMP_Text sourceText) {}
		public void ReadFrom(TMP_Text sourceText) {}
		public void WriteTo(Wrapper sourceText) {}
	}
