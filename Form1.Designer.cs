
namespace Linear_equation_systems
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton_isGaussSeidelMethodTrue = new System.Windows.Forms.RadioButton();
            this.radioButton_isGaussSeidelMethodFalse = new System.Windows.Forms.RadioButton();
            this.groupBox_isGaussSeidelMethod = new System.Windows.Forms.GroupBox();
            this.button_calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_varAmount = new System.Windows.Forms.TextBox();
            this.textBox_approx = new System.Windows.Forms.TextBox();
            this.button_varAmountApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_previous = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.button_backToMenu = new System.Windows.Forms.Button();
            this.groupBox_isGaussSeidelMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton_isGaussSeidelMethodTrue
            // 
            this.radioButton_isGaussSeidelMethodTrue.AutoSize = true;
            this.radioButton_isGaussSeidelMethodTrue.Checked = true;
            this.radioButton_isGaussSeidelMethodTrue.Location = new System.Drawing.Point(6, 15);
            this.radioButton_isGaussSeidelMethodTrue.Name = "radioButton_isGaussSeidelMethodTrue";
            this.radioButton_isGaussSeidelMethodTrue.Size = new System.Drawing.Size(132, 21);
            this.radioButton_isGaussSeidelMethodTrue.TabIndex = 0;
            this.radioButton_isGaussSeidelMethodTrue.TabStop = true;
            this.radioButton_isGaussSeidelMethodTrue.Text = "Метод Зейделя";
            this.radioButton_isGaussSeidelMethodTrue.UseVisualStyleBackColor = true;
            // 
            // radioButton_isGaussSeidelMethodFalse
            // 
            this.radioButton_isGaussSeidelMethodFalse.AutoSize = true;
            this.radioButton_isGaussSeidelMethodFalse.Location = new System.Drawing.Point(6, 41);
            this.radioButton_isGaussSeidelMethodFalse.Name = "radioButton_isGaussSeidelMethodFalse";
            this.radioButton_isGaussSeidelMethodFalse.Size = new System.Drawing.Size(128, 21);
            this.radioButton_isGaussSeidelMethodFalse.TabIndex = 1;
            this.radioButton_isGaussSeidelMethodFalse.TabStop = true;
            this.radioButton_isGaussSeidelMethodFalse.Text = "Метод ітерацій";
            this.radioButton_isGaussSeidelMethodFalse.UseVisualStyleBackColor = true;
            // 
            // groupBox_isGaussSeidelMethod
            // 
            this.groupBox_isGaussSeidelMethod.Controls.Add(this.radioButton_isGaussSeidelMethodTrue);
            this.groupBox_isGaussSeidelMethod.Controls.Add(this.radioButton_isGaussSeidelMethodFalse);
            this.groupBox_isGaussSeidelMethod.Location = new System.Drawing.Point(418, 31);
            this.groupBox_isGaussSeidelMethod.Name = "groupBox_isGaussSeidelMethod";
            this.groupBox_isGaussSeidelMethod.Size = new System.Drawing.Size(146, 71);
            this.groupBox_isGaussSeidelMethod.TabIndex = 2;
            this.groupBox_isGaussSeidelMethod.TabStop = false;
            // 
            // button_calculate
            // 
            this.button_calculate.Location = new System.Drawing.Point(597, 46);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(153, 56);
            this.button_calculate.TabIndex = 3;
            this.button_calculate.Text = "Обчислити";
            this.button_calculate.UseVisualStyleBackColor = true;
            this.button_calculate.Click += new System.EventHandler(this.button_calculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Кількість змінних:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Цільове наближення:";
            // 
            // textBox_varAmount
            // 
            this.textBox_varAmount.Location = new System.Drawing.Point(64, 80);
            this.textBox_varAmount.Name = "textBox_varAmount";
            this.textBox_varAmount.Size = new System.Drawing.Size(41, 22);
            this.textBox_varAmount.TabIndex = 6;
            this.textBox_varAmount.Text = "3";
            // 
            // textBox_approx
            // 
            this.textBox_approx.Location = new System.Drawing.Point(248, 80);
            this.textBox_approx.Name = "textBox_approx";
            this.textBox_approx.Size = new System.Drawing.Size(100, 22);
            this.textBox_approx.TabIndex = 7;
            this.textBox_approx.Text = "0,001";
            // 
            // button_varAmountApply
            // 
            this.button_varAmountApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.button_varAmountApply.Location = new System.Drawing.Point(111, 76);
            this.button_varAmountApply.Name = "button_varAmountApply";
            this.button_varAmountApply.Size = new System.Drawing.Size(91, 29);
            this.button_varAmountApply.TabIndex = 8;
            this.button_varAmountApply.Text = "Застосувати";
            this.button_varAmountApply.UseVisualStyleBackColor = true;
            this.button_varAmountApply.Click += new System.EventHandler(this.button_varAmountApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Обчислювана система:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "(Пусте поле сприймається як 0)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "(Дробові числа розділяються комою)";
            // 
            // button_previous
            // 
            this.button_previous.Enabled = false;
            this.button_previous.Location = new System.Drawing.Point(64, 46);
            this.button_previous.Name = "button_previous";
            this.button_previous.Size = new System.Drawing.Size(153, 59);
            this.button_previous.TabIndex = 12;
            this.button_previous.Text = "Назад";
            this.button_previous.UseVisualStyleBackColor = true;
            this.button_previous.Visible = false;
            this.button_previous.Click += new System.EventHandler(this.button_previous_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(241, 46);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(153, 59);
            this.button_next.TabIndex = 13;
            this.button_next.Text = "Вперед";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Visible = false;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_backToMenu
            // 
            this.button_backToMenu.Location = new System.Drawing.Point(597, 43);
            this.button_backToMenu.Name = "button_backToMenu";
            this.button_backToMenu.Size = new System.Drawing.Size(153, 59);
            this.button_backToMenu.TabIndex = 14;
            this.button_backToMenu.Text = "До меню";
            this.button_backToMenu.UseVisualStyleBackColor = true;
            this.button_backToMenu.Visible = false;
            this.button_backToMenu.Click += new System.EventHandler(this.button_backToMenu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_backToMenu);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_previous);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_varAmountApply);
            this.Controls.Add(this.textBox_approx);
            this.Controls.Add(this.textBox_varAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_calculate);
            this.Controls.Add(this.groupBox_isGaussSeidelMethod);
            this.Name = "Form1";
            this.Text = "Linear equation system solver";
            this.groupBox_isGaussSeidelMethod.ResumeLayout(false);
            this.groupBox_isGaussSeidelMethod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_isGaussSeidelMethodTrue;
        private System.Windows.Forms.RadioButton radioButton_isGaussSeidelMethodFalse;
        private System.Windows.Forms.GroupBox groupBox_isGaussSeidelMethod;
        private System.Windows.Forms.Button button_calculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_varAmount;
        private System.Windows.Forms.TextBox textBox_approx;
        private System.Windows.Forms.Button button_varAmountApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_previous;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_backToMenu;
    }
}

