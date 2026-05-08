using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace proje_hastane
{
    internal static class ModernTheme
    {
        private static readonly Color PageBackColor = Color.FromArgb(243, 247, 250);
        private static readonly Color CardBackColor = Color.White;
        private static readonly Color AccentColor = Color.FromArgb(0, 122, 204);
        private static readonly Color AccentDarkColor = Color.FromArgb(16, 75, 139);
        private static readonly Color TitleColor = Color.FromArgb(30, 41, 59);
        private static readonly Color MutedTextColor = Color.FromArgb(100, 116, 139);
        private static readonly Color BorderColor = Color.FromArgb(220, 227, 234);
        private const int HorizontalOuterMargin = 110;
        private const int VerticalOuterMargin = 28;

        public static void StyleForm(Form form, string title, string subtitle)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = PageBackColor;
            form.Text = title;

            // Projedeki küçük boyut sorununu çözmek için tüm formu orantýlý olarak büyütüyoruz
            if (form.Tag == null || !string.Equals(form.Tag.ToString(), "theme-applied", StringComparison.Ordinal))
            {
                form.Scale(new SizeF(1.35f, 1.35f));
            }

            if (form.Name.EndsWith("_login_form") || form.Name.EndsWith("_kayit_form") || form.Name.EndsWith("_guncelle_form"))
            {
                form.WindowState = FormWindowState.Normal;
            }
            else
            {
                form.WindowState = FormWindowState.Maximized;
            }

            form.AutoScroll = true;

            if (form.Tag == null || !string.Equals(form.Tag.ToString(), "theme-applied", StringComparison.Ordinal))
            {
                Panel headerPanel = CreateHeaderPanel(title, subtitle);
                form.Controls.Add(headerPanel);
                headerPanel.BringToFront();
                ShiftControlsBelowHeader(form, headerPanel.Height);

                form.Tag = "theme-applied";

                // Form boyutu deðiþtiðinde içerikleri her zaman yatayda ortalamak için bir panel mantýðý veya dinamik hizalama ekliyoruz
                form.Resize += (sender, args) =>
                {
                    if (form.Name.EndsWith("_login_form") || form.Name.EndsWith("_kayit_form") || form.Name.EndsWith("_guncelle_form"))
                    {
                        CenterControlsHorizontally(form, headerPanel);
                    }
                };
            }

            StyleControls(form.Controls);
        }

        private static void CenterControlsHorizontally(Form form, Panel headerPanel)
        {
            if (form.ClientSize.Width <= 0 || form.ClientSize.Height <= 0) return;

            // Tüm kontrollerin bounding box'ýný bul
            int minX = int.MaxValue;
            int maxX = 0;

            foreach (Control control in form.Controls)
            {
                if (control != headerPanel && !(control is Panel p && p.Dock == DockStyle.Top))
                {
                    if (control.Left < minX) minX = control.Left;
                    if (control.Right > maxX) maxX = control.Right;
                }
            }

            if (minX == int.MaxValue) return;

            int contentWidth = maxX - minX;
            int targetX = (form.ClientSize.Width - contentWidth) / 2;
            int dx = targetX - minX;

            if (dx == 0) return;

            form.SuspendLayout();
            foreach (Control control in form.Controls)
            {
                if (control != headerPanel && !(control is Panel p && p.Dock == DockStyle.Top))
                {
                    control.Left += dx;
                }
            }
            form.ResumeLayout();
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = CardBackColor;
            grid.BorderStyle = BorderStyle.None;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = AccentDarkColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 45;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            grid.DefaultCellStyle.SelectionForeColor = TitleColor;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = TitleColor;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            grid.DefaultCellStyle.Padding = new Padding(6);
            grid.RowTemplate.Height = 35;
            grid.GridColor = BorderColor;
        }

        public static FlowLayoutPanel CreateStatsPanel(params Control[] cards)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                AutoSize = false,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
                Margin = new Padding(12, 8, 12, 8),
                Height = 110
            };

            foreach (Control card in cards)
            {
                panel.Controls.Add(card);
            }

            return panel;
        }

        public static Panel CreateStatCard(string title, string value, string description, Color accent)
        {
            Panel card = new Panel
            {
                Size = new Size(220, 100),
                BackColor = CardBackColor,
                Margin = new Padding(0, 0, 12, 0),
                Padding = new Padding(16)
            };

            card.Paint += (sender, args) =>
            {
                using (Pen pen = new Pen(BorderColor))
                {
                    args.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            Panel accentBar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 6,
                BackColor = accent
            };

            Label titleLabel = new Label
            {
                AutoSize = true,
                Text = title,
                ForeColor = MutedTextColor,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular)
            };

            Label valueLabel = new Label
            {
                AutoSize = true,
                Top = 24,
                Text = value,
                ForeColor = TitleColor,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold)
            };

            Label descriptionLabel = new Label
            {
                AutoSize = true,
                Top = 62,
                Text = description,
                ForeColor = MutedTextColor,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular)
            };

            card.Controls.Add(descriptionLabel);
            card.Controls.Add(valueLabel);
            card.Controls.Add(titleLabel);
            card.Controls.Add(accentBar);

            titleLabel.Left = 20;
            valueLabel.Left = 20;
            descriptionLabel.Left = 20;

            return card;
        }

        public static Button CreateSecondaryButton(string text, EventHandler onClick)
        {
            Button button = new Button
            {
                Text = text,
                Width = 176,
                Height = 34,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = TitleColor
            };
            button.FlatAppearance.BorderColor = BorderColor;
            button.Click += onClick;
            return button;
        }

        public static int GetHeaderHeight(Form form)
        {
            Panel headerPanel = form.Controls
                .OfType<Panel>()
                .FirstOrDefault(panel => string.Equals(panel.Tag as string, "theme-header", StringComparison.Ordinal));

            return headerPanel?.Height ?? 0;
        }

        private static Panel CreateHeaderPanel(string title, string subtitle)
        {
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 88,
                BackColor = AccentColor,
                Tag = "theme-header"
            };

            headerPanel.Paint += (sender, args) =>
            {
                Rectangle area = headerPanel.ClientRectangle;
                using (LinearGradientBrush brush = new LinearGradientBrush(area, AccentColor, AccentDarkColor, 0F))
                {
                    args.Graphics.FillRectangle(brush, area);
                }
            };

            Label titleLabel = new Label
            {
                AutoSize = true,
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 21F, FontStyle.Bold),
                Location = new Point(18, 14)
            };

            Label subtitleLabel = new Label
            {
                AutoSize = true,
                Text = subtitle,
                ForeColor = Color.FromArgb(232, 242, 255),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                Location = new Point(20, 52)
            };

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(subtitleLabel);
            return headerPanel;
        }

        private static void ShiftControlsBelowHeader(Form form, int offset)
        {
            List<Control> controls = form.Controls.Cast<Control>()
                .Where(control => !(control is Panel panel && panel.Dock == DockStyle.Top))
                .ToList();

            foreach (Control control in controls)
            {
                control.Top += offset;
            }

            form.ClientSize = new Size(form.ClientSize.Width, form.ClientSize.Height + offset);
        }

        private static void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is GroupBox groupBox)
                {
                    groupBox.BackColor = CardBackColor;
                    groupBox.ForeColor = TitleColor;
                    groupBox.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
                    groupBox.Padding = new Padding(12);
                }
                else if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = AccentColor;
                    button.ForeColor = Color.White;
                    button.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
                    button.Cursor = Cursors.Hand;
                    button.Height = Math.Max(button.Height, 45);
                }
                else if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = TitleColor;
                }
                else if (control is MaskedTextBox maskedTextBox)
                {
                    maskedTextBox.BorderStyle = BorderStyle.FixedSingle;
                    maskedTextBox.BackColor = Color.White;
                    maskedTextBox.ForeColor = TitleColor;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = TitleColor;
                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.BorderStyle = BorderStyle.FixedSingle;
                    richTextBox.BackColor = Color.White;
                    richTextBox.ForeColor = TitleColor;
                }
                else if (control is Label label)
                {
                    label.ForeColor = TitleColor;
                }
                else if (control is LinkLabel linkLabel)
                {
                    linkLabel.LinkColor = AccentDarkColor;
                    linkLabel.ActiveLinkColor = AccentColor;
                    linkLabel.VisitedLinkColor = AccentDarkColor;
                }
                else if (control is DataGridView dataGridView)
                {
                    StyleGrid(dataGridView);
                }

                if (control.HasChildren)
                {
                    StyleControls(control.Controls);
                }
            }
        }
    }
}
