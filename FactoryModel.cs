using FactoryPlanner.Helper;
using System.Data;

namespace FactoryPlanner;

/// <summary>
/// Has the recpie table and calculates inputs and outputs of a factory.
/// </summary>
public class FactoryModel 
{
    /// <summary>
    /// A table of coefficients. Each line represents inputs (-ve) and (+ve) inputs to a machine.
    /// </summary>
    public DataTable RecipeTable { get; private set; }
    /// <summary>
    /// The headers to each recipe, contains a machine to associate, the recipe name. Also contains a user multiple for selecting this recipe.
    /// </summary>
    public DataTable UserSelections { get; private set; }
    /// <summary>
    /// Contains the total input, output and balance (output - input) of the factory.
    /// </summary>
    public DataTable ResultsTable { get; private set; }
    public int IngredientCount = 0;

    /// <summary>
    /// Constructor to populate initial state.
    /// </summary>
    public FactoryModel()
    {
        System.Diagnostics.Debug.WriteLine("Model is instantiating");

        // Create the Recipe table
        ResultsTable = new DataTable();
        RecipeTable = new DataTable();
        UserSelections = new DataTable();

        string currentDirectory = Environment.CurrentDirectory;

        List<string> Recipes = GlobalConfig.TestRecipesFile.
            FullFilePath()
            .LoadFile();

        string Headers = Recipes[0];
        List<string> ColHeaders = Headers.Split(",").ToList();


        for (int i = 2; i < ColHeaders.Count; i++)
        {
            RecipeTable.Columns.Add(ColHeaders[i]);
            ResultsTable.Columns.Add(ColHeaders[i]);
        }

        Recipes.RemoveAt(0);

        IntialiseUserSelections(Recipes);
        IntialiseResults();

        return;
    }

    /// <summary>
    /// Initalise the user selections by creating a [3,r] table of {userInputField, RecipeName, Machine} for each recipe r
    /// </summary>
    /// <param name="Recipes"></param>
    private void IntialiseUserSelections(List<string> Recipes)
    {
        string UserSelectionsColText = "User \nSelect";
        UserSelections.Columns.Add(UserSelectionsColText);
        UserSelectionsColText = "Recipe";
        UserSelections.Columns.Add(UserSelectionsColText);
        UserSelectionsColText = "Machine";
        UserSelections.Columns.Add(UserSelectionsColText);

        foreach (var recipe in Recipes)
        {
            string[] inputRowData = recipe.Split(",");
            int[] zeros = { 0 };
            object[] UserSelectRowData = zeros.Cast<object>().Concat(inputRowData.Take(2)).ToArray();
            string[] RecipeRowData = inputRowData.Skip(2).ToArray();

            UserSelections.Rows.Add(UserSelectRowData);
            RecipeTable.Rows.Add(RecipeRowData);
            IngredientCount = RecipeRowData.Count();
        }
    }

    /// <summary>
    /// Sets the results table to a set of zeros [i,3] for each ingrediant i , and {input, output balance}
    /// </summary>
    private void IntialiseResults()
    {
        //Intialise the ResultsTable
        DataRow resultsInput = ResultsTable.NewRow();
        DataRow resultsOutput = ResultsTable.NewRow();
        DataRow resultsBalance = ResultsTable.NewRow();


        // Set values in the DataRow from the array
        for (int i = 0; i < IngredientCount; i++)
        {
            resultsInput[i] = 0;
            resultsOutput[i] = 0;
            resultsBalance[i] = 0;
        }
        ResultsTable.Rows.Add(resultsInput);
        ResultsTable.Rows.Add(resultsOutput);
        ResultsTable.Rows.Add(resultsBalance);
    }

    /// <summary>
    /// Recalculate results when user Selections is updated.
    /// </summary>
    public void UpdateResults()
    {
        for (int i = 0; i < RecipeTable.Columns.Count; i++)
        {
            double resultPositiveTotal = 0;
            double resultNegativeTotal = 0;
            double resultBalance = 0;

            for (int j = 0; j < RecipeTable.Rows.Count; j++)
            {
                //skip this row if nothing in the userSelection
                if (string.IsNullOrEmpty(Convert.ToString(RecipeTable.Rows[j][i])))
                {
                    continue;
                }

                double countThisRecipe = Convert.ToDouble(UserSelections.Rows[j][0]);
                double recipeIOValue = 0;
                
                recipeIOValue = Convert.ToDouble(RecipeTable.Rows[j][i]);
                if (recipeIOValue > 0)
                {
                    resultPositiveTotal += countThisRecipe * recipeIOValue;
                }
                if (recipeIOValue < 0)
                {
                    resultNegativeTotal += countThisRecipe * recipeIOValue;
                }
                resultBalance += countThisRecipe * recipeIOValue;
                ResultsTable.Rows[0][i] = resultNegativeTotal;
                ResultsTable.Rows[1][i] = resultPositiveTotal;
                ResultsTable.Rows[2][i] = resultBalance;
            }
        }
    }
}