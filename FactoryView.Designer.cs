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
			label1 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			label8 = new Label();
			label9 = new Label();
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
			RecipesGridView.MaximumSize = new Size(1468, 542);
			RecipesGridView.MinimumSize = new Size(800, 542);
			RecipesGridView.Name = "RecipesGridView";
			RecipesGridView.RowHeadersWidth = 51;
			RecipesGridView.RowTemplate.Height = 29;
			RecipesGridView.Size = new Size(800, 542);
			RecipesGridView.TabIndex = 0;
			// 
			// UserSelectGridView
			// 
			UserSelectGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			UserSelectGridView.Location = new Point(78, 47);
			UserSelectGridView.Name = "UserSelectGridView";
			UserSelectGridView.RowHeadersWidth = 51;
			UserSelectGridView.RowTemplate.Height = 29;
			UserSelectGridView.Size = new Size(326, 542);
			UserSelectGridView.TabIndex = 1;
			// 
			// ResultsGridView
			// 
			ResultsGridView.Anchor = AnchorStyles.Left;
			ResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			ResultsGridView.Location = new Point(460, 637);
			ResultsGridView.MaximumSize = new Size(1468, 136);
			ResultsGridView.MinimumSize = new Size(800, 136);
			ResultsGridView.Name = "ResultsGridView";
			ResultsGridView.RowHeadersWidth = 51;
			ResultsGridView.RowTemplate.Height = 29;
			ResultsGridView.Size = new Size(800, 136);
			ResultsGridView.TabIndex = 2;
			// 
			// ChkBoxShowAllRecipes
			// 
			ChkBoxShowAllRecipes.AutoSize = true;
			ChkBoxShowAllRecipes.Location = new Point(78, 648);
			ChkBoxShowAllRecipes.Name = "ChkBoxShowAllRecipes";
			ChkBoxShowAllRecipes.Size = new Size(301, 24);
			ChkBoxShowAllRecipes.TabIndex = 3;
			ChkBoxShowAllRecipes.Text = "Show All Recipes (Overrides other filters)";
			ChkBoxShowAllRecipes.UseVisualStyleBackColor = true;
			ChkBoxShowAllRecipes.CheckedChanged += MainForm_Load;
			// 
			// ComboBoxMachine
			// 
			ComboBoxMachine.FormattingEnabled = true;
			ComboBoxMachine.Location = new Point(194, 692);
			ComboBoxMachine.Name = "ComboBoxMachine";
			ComboBoxMachine.Size = new Size(151, 28);
			ComboBoxMachine.TabIndex = 4;
            ComboBoxMachine.DataSource = Enum.GetValues(typeof(Machines));
            // 
            // label1
            // 
            label1.AutoSize = true;
			label1.Location = new Point(78, 695);
			label1.Name = "label1";
			label1.Size = new Size(112, 20);
			label1.TabIndex = 5;
			label1.Text = "Machine Select:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			label3.Location = new Point(78, 606);
			label3.Name = "label3";
			label3.Size = new Size(70, 28);
			label3.TabIndex = 8;
			label3.Text = "Filters";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			label4.Location = new Point(78, 16);
			label4.Name = "label4";
			label4.Size = new Size(108, 28);
			label4.TabIndex = 9;
			label4.Text = "Selections";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			label5.Location = new Point(463, 16);
			label5.Name = "label5";
			label5.Size = new Size(84, 28);
			label5.TabIndex = 10;
			label5.Text = "Recipes";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			label6.Location = new Point(463, 606);
			label6.Name = "label6";
			label6.Size = new Size(80, 28);
			label6.TabIndex = 11;
			label6.Text = "Results";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(402, 683);
			label7.Name = "label7";
			label7.Size = new Size(57, 20);
			label7.TabIndex = 12;
			label7.Text = "Sum In:";
			label7.TextAlign = ContentAlignment.TopRight;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(390, 715);
			label8.Name = "label8";
			label8.Size = new Size(69, 20);
			label8.TabIndex = 13;
			label8.Text = "Sum Out:";
			label8.TextAlign = ContentAlignment.TopRight;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(393, 744);
			label9.Name = "label9";
			label9.Size = new Size(64, 20);
			label9.TabIndex = 14;
			label9.Text = "Balance:";
			label9.TextAlign = ContentAlignment.TopRight;
			// 
			// FactoryView
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1342, 817);
			Controls.Add(label9);
			Controls.Add(label8);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label1);
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
		private Label label1;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private Label label9;
	}
}