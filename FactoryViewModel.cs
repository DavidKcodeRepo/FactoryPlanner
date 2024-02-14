using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FactoryPlanner.Helper;
using FactoryPlanner;
using System.Data;
using System.ComponentModel;

namespace FactoryPlanner;

public class FactoryViewModel : INotifyPropertyChanged
{
    public FactoryViewModel()
    {
        System.Diagnostics.Debug.WriteLine("ViewModel is instantiating");

        Model = new FactoryModel();

        RecipeTable = Model.RecipeTable;
        UserSelections = Model.UserSelections;
        ResultsTable = Model.ResultsTable;
        WireUpEventHandlers();
    }

    public FactoryModel Model { get; set; }

    public DataTable RecipeTable { get; set; }

    private DataTable _userSelections;
    public DataTable UserSelections
    {
        get { return _userSelections; }
        set
        {
            _userSelections = value;
            OnPropertyChanged(nameof(UserSelections));
        }
    }

    private DataTable _resultsTable;
    public DataTable ResultsTable
    {
        get { return _resultsTable; }
        set
        {
            _resultsTable = value;
            OnPropertyChanged(nameof(ResultsTable));
        }
    }

    private void WireUpEventHandlers()
    {
        System.Diagnostics.Debug.WriteLine("Wiring Event Handlers for View Model");
        UserSelections.RowChanged += UserSelections_RowChanged;
    }
    public void UserSelections_RowChanged(object sender, DataRowChangeEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Updating Calcs");
        Model.UpdateResults();
        // Raise PropertyChanged event when a row in the UserSelections DataTable changes
        OnPropertyChanged(nameof(UserSelections));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) 
    {
        System.Diagnostics.Debug.WriteLine($"{propertyName} was changed in viewmodel");
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void FormatNonZero(object sender, DataGridViewCellFormattingEventArgs e)
    {
        DataGridView dataGridView = (DataGridView)sender;

        if (e.Value != null && double.TryParse(e.Value.ToString(), out double result))
        {
            if (Convert.ToDouble(e.Value) > 0.1)
            {
                e.CellStyle.ForeColor = Color.Green;
                e.CellStyle.BackColor = Color.LightGreen;
            }
            else if (Convert.ToDouble(e.Value) < -0.1)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.BackColor = Color.MistyRose;
            }
        }
    }
}
