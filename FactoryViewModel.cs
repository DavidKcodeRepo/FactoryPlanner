using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FactoryPlanner.Helper;
using FactoryPlanner;
using System.Data;

namespace FactoryPlanner;

public class FactoryViewModel
{
    private readonly FactoryModel Model;

    public FactoryViewModel()
    {
        this.Model = new FactoryModel();
    }

    public DataTable RecipeTable => Model.RecipeTable;
    public DataTable UserSelections => Model.UserSelections;
    public DataTable ResultsTable => Model.ResultsTable;

    public void FormatNonZero(object sender, DataGridViewCellFormattingEventArgs e)
    {
        DataGridView dataGridView = (DataGridView)sender;

        if (e.Value != null && double.TryParse(e.Value.ToString(), out double result))
        {
            // Check if the value is greater than 0
            if (Convert.ToDouble(e.Value) > 0)
            {
                e.CellStyle.ForeColor = Color.Green;
                e.CellStyle.BackColor = Color.LightGreen;
            }
            else if (Convert.ToDouble(e.Value) < 0)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.BackColor = Color.MistyRose;
            }
        }
    }

    public void UpdateCalculation(object? sender, DataGridViewCellEventArgs e)
    {
        // publish result to results table
        Model.UpdateResults();
    }
}
