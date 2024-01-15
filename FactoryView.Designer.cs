namespace FactoryPlanner
{
	partial class FactoryView
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			RecipesGridView = new DataGridView();
			UserSelectGridView = new DataGridView();
			ResultsGridView = new DataGridView();
			ChkBoxShowAllRecipes = new CheckBox();
			ComboBoxMachine = new ComboBox();
			((System.ComponentModel.ISupportInitialize)RecipesGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)UserSelectGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)ResultsGridView).BeginInit();
			SuspendLayout();
			// 
			// RecipesGridView
			// 
			RecipesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			RecipesGridView.Location = new Point(463, 29);
			RecipesGridView.Name = "RecipesGridView";
			RecipesGridView.RowHeadersWidth = 51;
			RecipesGridView.RowTemplate.Height = 29;
			RecipesGridView.Size = new Size(784, 587);
			RecipesGridView.TabIndex = 0;
			// 
			// UserSelectGridView
			// 
			UserSelectGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			UserSelectGridView.Location = new Point(78, 29);
			UserSelectGridView.Name = "UserSelectGridView";
			UserSelectGridView.RowHeadersWidth = 51;
			UserSelectGridView.RowTemplate.Height = 29;
			UserSelectGridView.Size = new Size(326, 587);
			UserSelectGridView.TabIndex = 1;
			// 
			// ResultsGridView
			// 
			ResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			ResultsGridView.Location = new Point(463, 641);
			ResultsGridView.Name = "ResultsGridView";
			ResultsGridView.RowHeadersWidth = 51;
			ResultsGridView.RowTemplate.Height = 29;
			ResultsGridView.Size = new Size(784, 153);
			ResultsGridView.TabIndex = 2;
			// 
			// ChkBoxShowAllRecipes
			// 
			ChkBoxShowAllRecipes.AutoSize = true;
			ChkBoxShowAllRecipes.Location = new Point(78, 641);
			ChkBoxShowAllRecipes.Name = "ChkBoxShowAllRecipes";
			ChkBoxShowAllRecipes.Size = new Size(144, 24);
			ChkBoxShowAllRecipes.TabIndex = 3;
			ChkBoxShowAllRecipes.Text = "Show All Recipes";
			ChkBoxShowAllRecipes.UseVisualStyleBackColor = true;
			ChkBoxShowAllRecipes.CheckedChanged += MainForm_Load;
			// 
			// ComboBoxMachine
			// 
			ComboBoxMachine.FormattingEnabled = true;
			ComboBoxMachine.Location = new Point(180, 671);
			ComboBoxMachine.Name = "ComboBoxMachine";
			ComboBoxMachine.Size = new Size(151, 28);
			ComboBoxMachine.TabIndex = 4;
			// 
			// FactoryView
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1308, 817);
			Controls.Add(ComboBoxMachine);
			Controls.Add(ChkBoxShowAllRecipes);
			Controls.Add(ResultsGridView);
			Controls.Add(UserSelectGridView);
			Controls.Add(RecipesGridView);
			Name = "FactoryView";
			Text = "Factory Planner";
			((System.ComponentModel.ISupportInitialize)RecipesGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)UserSelectGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)ResultsGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView RecipesGridView;
		private DataGridView UserSelectGridView;
		private DataGridView ResultsGridView;
		private CheckBox ChkBoxShowAllRecipes;
		private ComboBox ComboBoxMachine;
	}
}