namespace FactoryPlanner;

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
        MachineComboBox = new ComboBox();
        MachineSelectLabel = new Label();
        FiltersLabel = new Label();
        SelectionsLabel = new Label();
        RecipesLabel = new Label();
        ResultsLabel = new Label();
        SumInLabel = new Label();
        SumOutLabel = new Label();
        BalanceLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)RecipesGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)UserSelectGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ResultsGridView).BeginInit();
        SuspendLayout();
        // 
        // RecipesGridView
        // 
        RecipesGridView.AllowUserToAddRows = false;
        RecipesGridView.AllowUserToDeleteRows = false;
        RecipesGridView.AllowUserToResizeColumns = false;
        RecipesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        RecipesGridView.Location = new Point(460, 47);
        RecipesGridView.Name = "RecipesGridView";
        RecipesGridView.RowHeadersWidth = 51;
        RecipesGridView.RowTemplate.Height = 29;
        RecipesGridView.Size = new Size(800, 540);
        RecipesGridView.TabIndex = 0;
        // 
        // UserSelectGridView
        // 
        UserSelectGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        UserSelectGridView.Location = new Point(78, 47);
        UserSelectGridView.Name = "UserSelectGridView";
        UserSelectGridView.RowHeadersWidth = 51;
        UserSelectGridView.RowTemplate.Height = 29;
        UserSelectGridView.Size = new Size(330, 540);
        UserSelectGridView.TabIndex = 1;
        // 
        // ResultsGridView
        // 
        ResultsGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        ResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        ResultsGridView.Location = new Point(460, 637);
        ResultsGridView.MaximumSize = new Size(1468, 140);
        ResultsGridView.MinimumSize = new Size(800, 140);
        ResultsGridView.Name = "ResultsGridView";
        ResultsGridView.RowHeadersWidth = 51;
        ResultsGridView.RowTemplate.Height = 29;
        ResultsGridView.Size = new Size(800, 140);
        ResultsGridView.TabIndex = 2;
        // 
        // ChkBoxShowAllRecipes
        // 
        ChkBoxShowAllRecipes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        ChkBoxShowAllRecipes.AutoSize = true;
        ChkBoxShowAllRecipes.Location = new Point(78, 648);
        ChkBoxShowAllRecipes.Name = "ChkBoxShowAllRecipes";
        ChkBoxShowAllRecipes.Size = new Size(301, 24);
        ChkBoxShowAllRecipes.TabIndex = 3;
        ChkBoxShowAllRecipes.Text = "Show All Recipes (Overrides other filters)";
        ChkBoxShowAllRecipes.UseVisualStyleBackColor = true;
        // 
        // MachineComboBox
        // 
        MachineComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        MachineComboBox.DataSource = new Machines[]
{
    Machines.All,
    Machines.Miner,
    Machines.AirCollector,
    Machines.WaterExtractor,
    Machines.BioWaterExtractor,
    Machines.OilExtractor,
    Machines.ResourceWellExtractor,
    Machines.Crusher,
    Machines.Sorter,
    Machines.OreWasher,
    Machines.Smelter,
    Machines.Foundry,
    Machines.BlastFurnace,
    Machines.CoolerSolidifier,
    Machines.FluidConditioner,
    Machines.Constructor,
    Machines.Assembler,
    Machines.Manufacturer,
    Machines.ChemicalReactor,
    Machines.Weaver
};
        MachineComboBox.FormattingEnabled = true;
        MachineComboBox.Location = new Point(194, 692);
        MachineComboBox.Name = "MachineComboBox";
        MachineComboBox.Size = new Size(151, 28);
        MachineComboBox.TabIndex = 4;
        // 
        // MachineSelectLabel
        // 
        MachineSelectLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        MachineSelectLabel.AutoSize = true;
        MachineSelectLabel.Location = new Point(78, 695);
        MachineSelectLabel.Name = "MachineSelectLabel";
        MachineSelectLabel.Size = new Size(112, 20);
        MachineSelectLabel.TabIndex = 5;
        MachineSelectLabel.Text = "Machine Select:";
        // 
        // FiltersLabel
        // 
        FiltersLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        FiltersLabel.AutoSize = true;
        FiltersLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        FiltersLabel.Location = new Point(78, 606);
        FiltersLabel.Name = "FiltersLabel";
        FiltersLabel.Size = new Size(70, 28);
        FiltersLabel.TabIndex = 8;
        FiltersLabel.Text = "Filters";
        // 
        // SelectionsLabel
        // 
        SelectionsLabel.AutoSize = true;
        SelectionsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        SelectionsLabel.Location = new Point(78, 16);
        SelectionsLabel.Name = "SelectionsLabel";
        SelectionsLabel.Size = new Size(108, 28);
        SelectionsLabel.TabIndex = 9;
        SelectionsLabel.Text = "Selections";
        // 
        // RecipesLabel
        // 
        RecipesLabel.AutoSize = true;
        RecipesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        RecipesLabel.Location = new Point(463, 16);
        RecipesLabel.Name = "RecipesLabel";
        RecipesLabel.Size = new Size(84, 28);
        RecipesLabel.TabIndex = 10;
        RecipesLabel.Text = "Recipes";
        // 
        // ResultsLabel
        // 
        ResultsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        ResultsLabel.AutoSize = true;
        ResultsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        ResultsLabel.Location = new Point(463, 606);
        ResultsLabel.Name = "ResultsLabel";
        ResultsLabel.Size = new Size(80, 28);
        ResultsLabel.TabIndex = 11;
        ResultsLabel.Text = "Results";
        // 
        // SumInLabel
        // 
        SumInLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        SumInLabel.AutoSize = true;
        SumInLabel.Location = new Point(402, 683);
        SumInLabel.Name = "SumInLabel";
        SumInLabel.Size = new Size(57, 20);
        SumInLabel.TabIndex = 12;
        SumInLabel.Text = "Sum In:";
        SumInLabel.TextAlign = ContentAlignment.TopRight;
        // 
        // SumOutLabel
        // 
        SumOutLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        SumOutLabel.AutoSize = true;
        SumOutLabel.Location = new Point(390, 715);
        SumOutLabel.Name = "SumOutLabel";
        SumOutLabel.Size = new Size(69, 20);
        SumOutLabel.TabIndex = 13;
        SumOutLabel.Text = "Sum Out:";
        SumOutLabel.TextAlign = ContentAlignment.TopRight;
        // 
        // BalanceLabel
        // 
        BalanceLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        BalanceLabel.AutoSize = true;
        BalanceLabel.Location = new Point(393, 744);
        BalanceLabel.Name = "BalanceLabel";
        BalanceLabel.Size = new Size(64, 20);
        BalanceLabel.TabIndex = 14;
        BalanceLabel.Text = "Balance:";
        BalanceLabel.TextAlign = ContentAlignment.TopRight;
        // 
        // FactoryView
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1342, 820);
        Controls.Add(BalanceLabel);
        Controls.Add(SumOutLabel);
        Controls.Add(SumInLabel);
        Controls.Add(ResultsLabel);
        Controls.Add(RecipesLabel);
        Controls.Add(SelectionsLabel);
        Controls.Add(FiltersLabel);
        Controls.Add(MachineSelectLabel);
        Controls.Add(MachineComboBox);
        Controls.Add(ChkBoxShowAllRecipes);
        Controls.Add(ResultsGridView);
        Controls.Add(UserSelectGridView);
        Controls.Add(RecipesGridView);
        Name = "FactoryView";
        Text = "Factory Planner 0.2";
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
		private ComboBox MachineComboBox;
		private Label MachineSelectLabel;
		private Label FiltersLabel;
		private Label SelectionsLabel;
		private Label RecipesLabel;
		private Label ResultsLabel;
		private Label SumInLabel;
		private Label SumOutLabel;
		private Label BalanceLabel;
	}