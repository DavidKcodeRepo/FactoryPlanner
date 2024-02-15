using System;
using System.Configuration;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using FactoryPlanner.Helper;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace FactoryPlanner;

public partial class FactoryView : Form
{
	private readonly FactoryViewModel ViewModel;
	private bool IsResizing = false;

	public FactoryView()
	{
        System.Diagnostics.Debug.WriteLine("View is instantiating");

        InitializeComponent();
        this.ViewModel = new FactoryViewModel();
        InitializeGridViews();
        Load += MainForm_Load;
	}

	private void MainForm_Load(object? sender, EventArgs e)
	{
        System.Diagnostics.Debug.WriteLine("Form has loaded");

        // Set up the DataGridView
        RecipesGridView.AutoGenerateColumns = true; // Allow auto-generation of columns
		RecipesGridView.ReadOnly = true;
		RecipesGridView.RowHeadersVisible = false;
		RecipesGridView.ScrollBars = ScrollBars.Vertical;


		foreach (DataGridViewColumn col in RecipesGridView.Columns)
		{
			col.Width = 50;
		}

        UserSelectGridView.Columns[0].Width = 55;
		UserSelectGridView.RowHeadersVisible = false;
		UserSelectGridView.ScrollBars = ScrollBars.Vertical;


		foreach (DataGridViewColumn col in ResultsGridView.Columns)
		{
			col.Width = 50;
		}
		ResultsGridView.RowHeadersVisible = false;
		ResultsGridView.ReadOnly = true;
		ResultsGridView.ScrollBars = ScrollBars.None;
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {

        System.Diagnostics.Debug.WriteLine("Subscribing the view to events");


        //Subscribe viemodel events to View event handlers

        ViewModel.PropertyChanged += ResetDataGrid;
		ChkBoxShowAllRecipes.CheckedChanged += ResetRows;
        MachineComboBox.SelectedValueChanged += ResetRows;


        //UserSelectGridView.CellValueChanged += ResetColumns;
        //UserSelectGridView.CellValueChanged += ResetRows;
        //ChkBoxShowAllRecipes.CheckedChanged += ResetRows;
        //MachineComboBox.SelectedValueChanged += ResetRows;

        // Subscribe view events to view event handlers
        RecipesGridView.Scroll += RecipesGridView_VertScroll;
        UserSelectGridView.Scroll += UserSelectGridView_VertScroll;


        RecipesGridView.Scroll += RecipesGridView_HorzScroll;
        ResultsGridView.Scroll += ResultsGridView_HorzScroll;
        this.Resize += MainForm_Resize;

        // Subscribe view events to ViewModel eventHandlers
        RecipesGridView.CellFormatting += ViewModel.FormatNonZero;
        ResultsGridView.CellFormatting += ViewModel.FormatNonZero;
        UserSelectGridView.CellFormatting += ViewModel.FormatNonZero;


    }

    private void ResetDataGrid(object? sender, PropertyChangedEventArgs e)
    {
        ShowHideRows((string)MachineComboBox.Text);
        ShowHideColumns((string)MachineComboBox.Text);
    }

    private void InitializeGridViews()
    {

        System.Diagnostics.Debug.WriteLine("view is binding data to viewmodel");

        RecipesGridView.DataSource = ViewModel.RecipeTable;
        UserSelectGridView.DataSource = ViewModel.UserSelections;
        ResultsGridView.DataSource = ViewModel.ResultsTable;
    }

    private void MainForm_Resize(object? sender, EventArgs e)
	{
		if (!IsResizing)
		{
			IsResizing = true;
			System.Diagnostics.Debug.WriteLine("Resizing the form");

			//Adjust Control sizes and positions here

			RecipesGridView.Width = this.Width - 460 - 100;
			ResultsGridView.Width = this.Width - 460 - 100;

			UserSelectGridView.Height = this.Height - 140 - 200;
			RecipesGridView.Height = this.Height - 140 - 200;
			IsResizing = false;
		}
    }

    private void ResultsGridView_HorzScroll(object? sender, ScrollEventArgs e)
	{
        System.Diagnostics.Debug.WriteLine("Scrolling!");

        RecipesGridView.FirstDisplayedScrollingColumnIndex =
			ResultsGridView.FirstDisplayedScrollingColumnIndex;
	}

	private void RecipesGridView_HorzScroll(object? sender, ScrollEventArgs e)
	{
        System.Diagnostics.Debug.WriteLine("Scrolling!");
        ResultsGridView.FirstDisplayedScrollingColumnIndex =
	RecipesGridView.FirstDisplayedScrollingColumnIndex;
	}

	private void ResetRows(object? sender, EventArgs e)
	{
		ShowHideRows((string)MachineComboBox.Text);
	}

	private void ResetColumns(object? sender, EventArgs e)
	{
		System.Diagnostics.Debug.WriteLine("Resetting Column visibility");
		ShowHideColumns((string)MachineComboBox.Text);
	}
	private void ShowHideColumns(string machineType)
	{
		//show all recipe checkbox overrides hide-cols functionality by resetting tables and exits early 
		if (ChkBoxShowAllRecipes.Checked)
		{
			for (int i = 0; i < ViewModel.RecipeTable.Columns.Count; i++)
			{
				DataGridViewColumn resColV = ResultsGridView.Columns[i];
				DataGridViewColumn recpColV = RecipesGridView.Columns[i];

				resColV.Visible = true;
				recpColV.Visible = true;
			}

			return;
		}

		//update hidden columns
		for (int i = 0; i < ViewModel.RecipeTable.Columns.Count; i++)
		{
			double check1 = Convert.ToDouble(ViewModel.ResultsTable.Rows[0][i]);
			double check2 = Convert.ToDouble(ViewModel.ResultsTable.Rows[1][i]);
			double check3 = Convert.ToDouble(ViewModel.ResultsTable.Rows[2][i]);

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

        System.Diagnostics.Debug.WriteLine("Refreshing the view");
		return;
	}

	private void ShowHideRows(string machinetype)
	{
        System.Diagnostics.Debug.WriteLine("Resetting Row visibility");
        //show all recipes overides hide-rows functionality by resetting tables and exiting early 
        if (ChkBoxShowAllRecipes.Checked)
		{

			for (int j = 0; j < ViewModel.RecipeTable.Rows.Count; j++)
			{
				DataGridViewRow userSRowV = UserSelectGridView.Rows[j];
				DataGridViewRow recpRowV = RecipesGridView.Rows[j];

				userSRowV.Visible = true;
				recpRowV.Visible = true;
			}
			return;
		}

		//next machine-type overides hide-rows functionality by choosing rows and exiting early
		if (!machinetype.Equals("All")) //a specific-machine is selected
		{
			for (int j = 0; j < ViewModel.RecipeTable.Rows.Count; j++)
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
			return;
		}

		for (int j = 0; j < ViewModel.RecipeTable.Rows.Count; j++)
		{
			DataGridViewRow userSRowV = UserSelectGridView.Rows[j];
			DataGridViewRow recpRowV = RecipesGridView.Rows[j];

			userSRowV.Visible = true;
			recpRowV.Visible = true;
		}

		for (int j = 0; j < ViewModel.RecipeTable.Rows.Count; j++)
		{
			double result = Convert.ToDouble(ViewModel.UserSelections.Rows[j][0]);
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
		return;
	}

	private void RecipesGridView_VertScroll(object? sender, ScrollEventArgs e)
	{
		UserSelectGridView.FirstDisplayedScrollingRowIndex =
			RecipesGridView.FirstDisplayedScrollingRowIndex;
	}

	private void UserSelectGridView_VertScroll(object? sender, ScrollEventArgs e)
	{
		RecipesGridView.FirstDisplayedScrollingRowIndex =
			UserSelectGridView.FirstDisplayedScrollingRowIndex;
	}
}