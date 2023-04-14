using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Uno.Extensions.Reactive;

namespace MultiSelectionListView;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        page.DataContext = new BindableModel();
    }
}

public partial record Model
{
    public IImmutableList<string> Names { get; } = new[]
    {
        "Joe",
        "Judith",
        "Guy",
        "Lauren",
        "Elizabeth"
    }
    .ToImmutableList();

    private ValueTask<IImmutableList<string>> GetNames(CancellationToken _) => new(Names);

    public IListFeed<string> MvuxNames => ListFeed.Async(GetNames);
}