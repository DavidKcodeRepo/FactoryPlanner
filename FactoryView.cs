using System;
using System.Configuration;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FactoryPlanner;

public partial class FactoryView : Form
{
	private readonly MainViewModel viewModel;

	public FactoryView()
	{
		InitializeComponent();
		viewModel = new MainViewModel();

		// Subscribe MainForm_Load to the Load event of the form
		Load += MainForm_Load;
	}

	private void MainForm_Load(object sender, EventArgs e)
	{

		// Set up the DataGridView
		RecipesGridView.AutoGenerateColumns = true; // Allow auto-generation of columns
		RecipesGridView.DataSource = viewModel.RecipeTable;
		RecipesGridView.ReadOnly = true;
		RecipesGridView.RowHeadersVisible = false;

		foreach (DataGridViewColumn col in RecipesGridView.Columns)
		{
			col.Width = 50;
		}

		ComboBoxMachine.DataSource = Enum.GetValues(typeof(Machines));
		ComboBoxMachine.SelectedValueChanged += ResetRows;
		UserSelectGridView.CellValueChanged += UpdateCalculation;
		UserSelectGridView.CellValueChanged += ResetColumns;
		UserSelectGridView.CellValueChanged += ResetRows;
		ChkBoxShowAllRecipes.CheckedChanged += ResetRows;
		RecipesGridView.CellFormatting += FormatNonZero;
		ResultsGridView.CellFormatting += FormatNonZero;
		UserSelectGridView.CellFormatting += FormatNonZero;
		RecipesGridView.Scroll += RecipesGridView_VertScroll;
		UserSelectGridView.Scroll += UserSelectGridView_VertScroll;
		RecipesGridView.Scroll += RecipesGridView_HorzScroll;
		ResultsGridView.Scroll += ResultsGridView_HorzScroll;


		UserSelectGridView.DataSource = viewModel.UserSelections;
		UserSelectGridView.Columns[0].Width = 55;
		UserSelectGridView.RowHeadersVisible = false;
		ResultsGridView.DataSource = viewModel.ResultsTable;

		foreach (DataGridViewColumn col in ResultsGridView.Columns)
		{
			col.Width = 50;
		}
		ResultsGridView.RowHeadersVisible = false;
		ResultsGridView.ReadOnly = true;

	}

	private void ResultsGridView_HorzScroll(object? sender, ScrollEventArgs e)
	{
		RecipesGridView.FirstDisplayedScrollingColumnIndex =
			ResultsGridView.FirstDisplayedScrollingColumnIndex;
	}

	private void RecipesGridView_HorzScroll(object? sender, ScrollEventArgs e)
	{
		ResultsGridView.FirstDisplayedScrollingColumnIndex =
			RecipesGridView.FirstDisplayedScrollingColumnIndex;
	}

	private void ResetRows(object sender, EventArgs e)
	{
		ShowHideRows((string)ComboBoxMachine.Text);
	}

	private void ResetColumns(object? sender, DataGridViewCellEventArgs e)
	{
		ShowHideColumns((string)ComboBoxMachine.Text);
	}
	private void ShowHideColumns(string machineType)
	{
		//show all recipe checkbox overrides hide-cols functionality by resetting tables and exits early 
		if (ChkBoxShowAllRecipes.Checked)
		{
			for (int i = 0; i < viewModel.RecipeTable.Columns.Count; i++)
			{
				DataGridViewColumn resColV = ResultsGridView.Columns[i];
				DataGridViewColumn recpColV = RecipesGridView.Columns[i];

				resColV.Visible = true;
				recpColV.Visible = true;
			}

			this.Refresh();
			return;
		}

		//update hidden columns
		for (int i = 0; i < viewModel.RecipeTable.Columns.Count; i++)
		{
			double check1 = Convert.ToDouble(viewModel.ResultsTable.Rows[0][i]);
			double check2 = Convert.ToDouble(viewModel.ResultsTable.Rows[1][i]);
			double check3 = Convert.ToDouble(viewModel.ResultsTable.Rows[2][i]);

			DataGridViewColumn resColV = ResultsGridView.Columns[i];
			DataGridViewColumn recpColV = RecipesGridView.Columns[i];

			if (check1 == 0 && check2 == 0 && check3 == 0)
			{
				resColV.Visible = false;
				recpColV.Visible = false;
			}
			else
			{
				resColV.Visible = true;
				recpColV.Visible = true;
			}
		}

		this.Refresh();
		return;
	}

	private void ShowHideRows(string machinetype)
	{
		//show all recipes overides hide-rows functionality by resetting tables and exiting early 
		if (ChkBoxShowAllRecipes.Checked)
		{

			for (int j = 0; j < viewModel.RecipeTable.Rows.Count; j++)
			{
				DataGridViewRow userSRowV = UserSelectGridView.Rows[j];
				DataGridViewRow recpRowV = RecipesGridView.Rows[j];

				userSRowV.Visible = true;
				recpRowV.Visible = true;
			}
			this.Refresh();
			return;
		}

		//next machine-type overides hide-rows functionality by choosing rows and exiting early
		if (!machinetype.Equals("All")) //a specific-machine is selected
		{
			for (int j = 0; j < viewModel.RecipeTable.Rows.Count; j++)
			{
				DataGridViewRow userSRowV = UserSelectGridView.Rows[j];
				DataGridViewRow recpRowV = RecipesGridView.Rows[j];

				if (!userSRowV.Cells[2].Value.Equals(machinetype))
				{
					UserSelectGridView.CurrentCell = null;
					userSRowV.Visible = false;
					RecipesGridView.CurrentCell = null;
					recpRowV.Visible = false;
				}
				else
				{
					userSRowV.Visible = true;
					recpRowV.Visible = true;
				}
			}
			this.Refresh();
			return;
		}

		for (int j = 0; j < viewModel.RecipeTable.Rows.Count; j++)
		{
			DataGridViewRow userSRowV = UserSelectGridView.Rows[j];
			DataGridViewRow recpRowV = RecipesGridView.Rows[j];

			userSRowV.Visible = true;
			recpRowV.Visible = true;
		}

		for (int j = 0; j < viewModel.RecipeTable.Rows.Count; j++)
		{
			double result = Convert.ToDouble(viewModel.UserSelections.Rows[j][0]);
			DataGridViewRow userSRowV = UserSelectGridView.Rows[j];
			DataGridViewRow recpRowV = RecipesGridView.Rows[j];

			if (result == 0)
			{
				UserSelectGridView.CurrentCell = null;
				userSRowV.Visible = false;
				RecipesGridView.CurrentCell = null;
				recpRowV.Visible = false;
			}
			else
			{
				userSRowV.Visible = true;
				recpRowV.Visible = true;
			}
		}
		this.Refresh();
		return;
	}

	private static void FormatNonZero(object sender, DataGridViewCellFormattingEventArgs e)
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
	private void UpdateCalculation(object? sender, DataGridViewCellEventArgs e)
	{
		// publish result to results table
		viewModel.UpdateResults();
	}

	private void RecipesGridView_VertScroll(object sender, ScrollEventArgs e)
	{
		UserSelectGridView.FirstDisplayedScrollingRowIndex =
			RecipesGridView.FirstDisplayedScrollingRowIndex;
	}

	private void UserSelectGridView_VertScroll(object sender, ScrollEventArgs e)
	{
		RecipesGridView.FirstDisplayedScrollingRowIndex =
			UserSelectGridView.FirstDisplayedScrollingRowIndex;
	}
}

public class MainViewModel
{
	public DataTable RecipeTable { get; set; }
	public DataTable UserSelections { get; set; }

	public DataTable ResultsTable { get; set; }

	public int IngredientCount = 0;


	/// <summary>
	/// Constructor to populate initial state.
	/// </summary>
	public MainViewModel()
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
public static class FileIO
{
	//split headers

	public static string FullFilePath(this string fileName)
	{
		return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
	}

	public static List<string> LoadFile(this string fileName)
	{
		if (!File.Exists(fileName))
		{
			return new List<string>();
		}
		return File.ReadAllLines(fileName).ToList();
	}
}

public static class GlobalConfig
{
	public const string TestRecipesFile = "RecipeList.csv";
}
