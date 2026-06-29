// Extracted from IL2CPP metadata v39 via Il2CppInspectorRedux
// Namespace: TLMobile.Generated.GraphQL.Game
// Source: global-metadata.dat (Travian Legends Mobile v3.13.0)

public class CategoryLabels : AlignedItemLabels
{
	// Fields
	[SerializeField]
	[Tooltip("Determines which labels are visible")]
	private ChartCategoryLabelOptions visibleLabels;

	// Properties
	public ChartCategoryLabelOptions VisibleLabels { get => default; set {} }
	protected override Action<IInternalUse, bool> Assign { get => default; }

	// Nested types
	public enum ChartCategoryLabelOptions
	{
		All = 0,
		FirstOnly = 1
	}

	// Constructors
	public CategoryLabels() {}
}
