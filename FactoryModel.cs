using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FactoryPlanner.Helper;
using FactoryPlanner;
using System.Data;

namespace FactoryPlanner;

public class FactoryModel
{
    public DataTable RecipeTable { get; set; }
    public DataTable UserSelections { get; set; }

    public DataTable ResultsTable { get; set; }

    public int IngredientCount = 0;


    /// <summary>
    /// Constructor to populate initial state.
    /// </summary>
    public FactoryModel()
    {
        // Create the Recipe table
        ResultsTable = new DataTable();
        RecipeTable = new DataTable();
        UserSelections = new DataTable();

        string currentDirectory = Environment.CurrentDirectory;

        string Recipes = GlobalConfig.TestRecipesFile;

        List<string> Recipes2 = Recipes.FullFilePath()
            .LoadFile();

        string Headers = Recipes2[0];
        List<string> ColHeaders = Headers.Split(",").ToList();


        for (int i = 2; i < ColHeaders.Count; i++)
        {
            RecipeTable.Columns.Add(ColHeaders[i]);
            ResultsTable.Columns.Add(ColHeaders[i]);
        }

        Recipes2.RemoveAt(0);

        //Initialise the UserSelections
        string UserSelectionsColText = "User \nSelect";
        UserSelections.Columns.Add(UserSelectionsColText);
        UserSelectionsColText = "Recipe";
        UserSelections.Columns.Add(UserSelectionsColText);
        UserSelectionsColText = "Machine";
        UserSelections.Columns.Add(UserSelectionsColText);

        foreach (var recipe in Recipes2)
        {
            string[] inputRowData = recipe.Split(",");
            int[] zeros = { 0 };
            object[] UserSelectRowData = zeros.Cast<object>().Concat(inputRowData.Take(2)).ToArray();
            string[] RecipeRowData = inputRowData.Skip(2).ToArray();

            UserSelections.Rows.Add(UserSelectRowData);
            RecipeTable.Rows.Add(RecipeRowData);
            IngredientCount = RecipeRowData.Count();
        }

        //Intialise the ResultsTable
        DataRow newRow = ResultsTable.NewRow();
        DataRow twoRow = ResultsTable.NewRow();
        DataRow threeRow = ResultsTable.NewRow();


        // Set values in the DataRow from the array
        for (int i = 0; i < IngredientCount; i++)
        {
            newRow[i] = 0;
            twoRow[i] = 0;
            threeRow[i] = 0;
        }
        ResultsTable.Rows.Add(newRow);
        ResultsTable.Rows.Add(twoRow);
        ResultsTable.Rows.Add(threeRow);
        return;
    }

    public void UpdateResults()
    {
        for (int i = 2; i < RecipeTable.Columns.Count; i++)
        {
            double resultPositiveTotal = 0;
            double resultNegativeTotal = 0;
            double resultBalance = 0;

            for (int j = 0; j < RecipeTable.Rows.Count; j++)
            {
                double countThisRecipe = Convert.ToDouble(UserSelections.Rows[j][0]);
                double recipeIOValue = 0;
                if (!string.IsNullOrEmpty(Convert.ToString(RecipeTable.Rows[j][i])))
                {
                    recipeIOValue = Convert.ToDouble(RecipeTable.Rows[j][i]);
                    if (recipeIOValue > 0)
                    {
                        resultPositiveTotal += countThisRecipe * recipeIOValue;
                    }
                    if (recipeIOValue < 0)
                    {
                        resultNegativeTotal += countThisRecipe * recipeIOValue;
                    }
                }
                resultBalance += countThisRecipe * recipeIOValue;
                ResultsTable.Rows[0][i] = resultNegativeTotal;
                ResultsTable.Rows[1][i] = resultPositiveTotal;
                ResultsTable.Rows[2][i] = resultBalance;
            }
        }
    }
}
